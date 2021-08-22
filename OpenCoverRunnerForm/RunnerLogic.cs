using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace OpenCoverRunnerForm
{
    public enum TargetType
    {
        ExeApp = 0,
        WebApp = 1,
    }
    public class RunnerLogic
    {
        public RunnerLogic() : this(TargetType.ExeApp, "")
        {
        }

        public RunnerLogic(TargetType targetType, string targetPath)
        {
            this.TargetType = targetType;
            if (this.TargetType == TargetType.ExeApp)
            {
                this.TestTargetExePath = targetPath;
            }
            else
            {
                this.TestTargetWebAppPath = targetPath;
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (string.IsNullOrEmpty(OpenCoverPath))
            {
                var paths = SearchInNugetPath("OpenCover.Console.exe");
                if (paths.Length > 0)
                {
                    // TODO:複数バージョンインストールされている場合、バージョンが最も新しいファイルを探す
                    config.AppSettings.Settings["OpenCoverPath"].Value = paths[0];
                    config.Save();
                }
            }

            if (string.IsNullOrEmpty(ReportGeneratorPath))
            {
                var paths = SearchInNugetPath("ReportGenerator.exe");
                if (paths.Length > 0)
                {
                    // TODO:複数バージョンインストールされている場合、バージョンが最も新しいファイルを探す
                    var net47 = paths.FirstOrDefault(item => item.Contains("\\net47"));
                    config.AppSettings.Settings["ReportGeneratorPath"].Value = net47;
                    config.Save();
                }
            }

            MSTestPath = SearchVSTestPath();

            ConfigurationManager.RefreshSection("appSettings");
        }

        public readonly string NuGetPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\.nuget\packages";

        public string OpenCoverPath { get => ConfigurationManager.AppSettings["OpenCoverPath"]; }

        public string ReportGeneratorPath { get => ConfigurationManager.AppSettings["ReportGeneratorPath"]; }

        public int IISExpressPort
        {
            get
            {
                var config = ConfigurationManager.AppSettings["IISExpressPort"];
                int port;
                if (string.IsNullOrEmpty(config) || int.TryParse(config, out port))
                {
                    return 8080;
                }
                else
                {
                    return port;
                }
            }
        }

        public string MSTestPath { get; set; } = "";

        public TargetType TargetType { get; set; } = 0;
        public string TestTargetExePath { get; set; } = "";
        public string TestTargetWebAppPath { get; set; } = "";

        public string OutputPath
        {
            get
            {
                if (TargetType == TargetType.ExeApp)
                {
                    if (string.IsNullOrEmpty(TestTargetExePath)) return "";
                    var outputPath = Path.Combine(Path.GetDirectoryName(TestTargetExePath), "OpenCoverResult");
                    return outputPath;
                }
                else
                {
                    if (string.IsNullOrEmpty(TestTargetWebAppPath)) return "";
                    var outputPath = Path.Combine(TestTargetWebAppPath, @"obj\OpenCoverResult");
                    return outputPath;
                }
            }
        }


        public string SearchVSTestPath()
        {
            Func<string, string> SearchVSTestPathSub = (string basePath) =>
            {
                var installerPath = Path.Combine(basePath, @"Microsoft Visual Studio\Installer\vswhere.exe");
                if (File.Exists(installerPath))
                {
                    var result = ExecAndReadConsole(installerPath, " -latest -property installationPath", false);
                    if (result.Item1 == -0)
                    {
                        return Path.Combine(result.Item2, @"Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe");
                    }
                }
                return "";
            };

            // 64bit OSの場合はProgramFiles(x86), 32bitの場合はProgramFilesにインストールされる
            var programFiles86 = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            var vsTest86 = SearchVSTestPathSub(programFiles86);
            if (string.IsNullOrEmpty(vsTest86))
            {
                var programFiles = Environment.GetEnvironmentVariable("ProgramFiles");
                return SearchVSTestPathSub(programFiles);

            }
            return vsTest86;
        }


        public Tuple<int, string> ExecAndReadConsole(string path, string args, bool showConsole)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo(path, args)
            {
                CreateNoWindow = !showConsole,
                UseShellExecute = false,
                RedirectStandardOutput = !showConsole,
                RedirectStandardInput = !showConsole,
                WorkingDirectory = Path.GetDirectoryName(path),
            };

            var ps = Process.Start(psInfo);
            string output = "";

            if (!showConsole)
            {
                output = ps.StandardOutput.ReadToEnd().TrimEnd();
            }

            Console.WriteLine($"output: \"{output}\"");
            ps.WaitForExit();
            return new Tuple<int, string>(ps.ExitCode, output);
        }

        public string[] SearchInNugetPath(string exeName)
        {
            var paths = Directory.GetFiles(NuGetPath, exeName, SearchOption.AllDirectories);
            return paths;
        }


        public string GetOpenCoverArgs()
        {
            if (TargetType == TargetType.ExeApp)
            {
                return GetOpenCoverExeArgs(this.OutputPath, this.TestTargetExePath);
            }
            else
            {
                return GetOpenCoverWebArgs(this.OutputPath, this.TestTargetWebAppPath);
            }
        }

        public string GetOpenCoverExeArgs(string outputPath, string targetExe)
        {
            var exeAndArgs = targetExe.Split(' ', '\t');
            var exeArgs = exeAndArgs.Where((_, index) => index != 0);
            var pdbPath = Win32API.GetModuleEmbeddedPdbPath(exeAndArgs[0]);
         

            var outputFile = Path.Combine(outputPath, "coverageReport.xml");
            var target = $"-target:\"{exeAndArgs[0]}\"";
            var targetargs = exeAndArgs.Length == 0 ? "" : $@"-targetargs:""{string.Join(" ", exeArgs)}""";
            var searchdirs = "";
            if (pdbPath != "") searchdirs = $@"-searchdirs:""{Path.GetDirectoryName(pdbPath)}""";
            var output = $"-output:\"{outputFile}\"";
            var etcArgs = "-mergeoutput -register:user";

            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }

            var args = $"{target} {targetargs} {output} {searchdirs} {etcArgs}";

            Debug.WriteLine(args);
            return args;
        }


        public string GetReportGeneratorArgs(string outputPath, string classFilter)
        {
            var reports = $@"-reports:""{Path.Combine(outputPath, "coverageReport.xml")}""";
            var reportType = "-reporttypes:HtmlInline;";
            var targetdir = $@"-targetdir:""{outputPath}""";
            var classfilters = string.IsNullOrEmpty(classFilter) ? "" : $@"-classfilters:""-{classFilter}""";
            var filefilters = "";// $@"-filefilters:""-*.Designer.cs;""";

            var args = $"{reports} {reportType} {targetdir} {classfilters} {filefilters}";

            Debug.WriteLine(args);
            return args;
        }


        public string GetMSTestArgs(string outputPath, string msTestPath, string unitTestPath)
        {
            var outputFile = Path.Combine(outputPath, "coverageReport.xml");
            var target = $@"-target:""{msTestPath}""";
            var targetargs = $@"-targetargs:""{unitTestPath}""";
            var output = $@"-output:""{outputFile}""";
            var etcArgs = "-mergeoutput -register:user";

            var args = $"{target} {targetargs} {output} {etcArgs}";

            Debug.WriteLine(args);
            return args;
        }

        public string GetOpenCoverWebArgs(string outputPath, string targetWebApp)
        {
            var iisExp = @"C:\Program Files\IIS Express\iisexpress.exe";
            var webAppArgs = $@"/path:{targetWebApp} /port:""{IISExpressPort}""";
            var outputFile = Path.Combine(outputPath, "coverageReport.xml");
            var target = $@"-target:""{iisExp}""";
            var searchdirs = $@"-searchdirs:""{targetWebApp}\bin""";
            var targetargs = $@"-targetargs:""{webAppArgs}""";
            var output = $@"-output:""{outputFile}""";
            var etcArgs = "-mergeoutput -register:user";

            var args = $"{target} {targetargs} {output} {searchdirs} {etcArgs}";

            Debug.WriteLine(args);
            return args;
        }

        public bool RunOpenCoverAndReport(bool showConsole = true)
        {
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }

            var openCoverArgs = GetOpenCoverArgs();
            var excludeFilter = "";
            if (this.TargetType == TargetType.ExeApp)
            {
                excludeFilter = $"{ Path.GetFileNameWithoutExtension(TestTargetExePath) }.Properties.*";
            }


            if (ExecAndReadConsole(OpenCoverPath, openCoverArgs, showConsole).Item1 == 0)
            {
                   var reportGenArgs = GetReportGeneratorArgs(OutputPath, excludeFilter);
                if (ExecAndReadConsole(ReportGeneratorPath, reportGenArgs, showConsole).Item1 == 0)
                {
                    return true;   
                }
            }
            return false;
        }
    }
}
