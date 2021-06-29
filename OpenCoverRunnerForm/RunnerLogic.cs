using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OpenCoverRunnerForm
{
    public class RunnerLogic
    {
        public RunnerLogic()
        {
            MSTestPath = SearchVSTestPath();


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

        public int tabSelectedIndex { get; set; } = 0;
        public string TestTargetExePath { get; set; } = "";
        public string TestTargetWebAppPath { get; set; } = "";

        public string OutputPath
        {
            get
            {
                if (tabSelectedIndex == 0)
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
                    var result = ExecAndReadConsole(installerPath, " -latest -property installationPath");
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


        public Tuple<int, string> ExecAndReadConsole(string path, string args, bool noWindow = true)
        {
            //Output.Text += $"{path} {args}\r\n\r\n";
            ProcessStartInfo psInfo = new ProcessStartInfo(path, args);
            psInfo.CreateNoWindow = noWindow;
            psInfo.UseShellExecute = false;
            psInfo.RedirectStandardOutput = noWindow; // 標準出力をリダイレクト
            psInfo.RedirectStandardError = noWindow;
            var ps = Process.Start(psInfo);

            var stdout = "";
            if (noWindow)
            {
                stdout = ps.StandardOutput.ReadToEnd().TrimEnd();
                Debug.Write(ps.StandardError.ReadToEnd());
            }

            ps.WaitForExit();
            return new Tuple<int, string>(ps.ExitCode, stdout);
        }

        public string[] SearchInNugetPath(string exeName)
        {
            var paths = Directory.GetFiles(NuGetPath, exeName, SearchOption.AllDirectories);
            return paths;
        }


        public string GetOpenCoverExeArgs(string outputPath, string targetExe)
        {
            var outputFile = Path.Combine(outputPath, "results.xml");
            var target = $"-target:\"{targetExe}\"";
            var output = $"-output:\"{outputFile}\"";
            var etcArgs = "-mergeoutput -register:user";

            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }

            var args = $"{target} {output} {etcArgs}";

            Debug.WriteLine(args);
            return args;
        }

        public string GetReportGeneratorArgs(string outputPath, string testTarget)
        {
            var reports = $@"-reports:""{Path.Combine(outputPath, "results.xml")}""";
            var reportType = "-reporttypes:HtmlInline;";
            var targetdir = $@"-targetdir:""{Path.Combine(outputPath, "")}""";
            var classfilters = $@"-classfilters:""-{Path.GetFileNameWithoutExtension(testTarget)}.Properties.*""";
            var filefilters = "";// $@"-filefilters:""-*.Designer.cs;""";

            var args = $"{reports} {reportType} {targetdir} {classfilters} {filefilters}";

            Debug.WriteLine(args);
            return args;
        }


        public string GetMSTestArgs(string outputPath, string msTestPath, string unitTestPath)
        {
            var outputFile = Path.Combine(outputPath, "results.xml");
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
            var outputFile = Path.Combine(outputPath, "results.xml");
            var target = $@"-target:""{iisExp}""";
            var searchdirs = $@"-searchdirs:""{targetWebApp}\bin""";
            var targetargs = $@"-targetargs:""{webAppArgs}""";
            var output = $@"-output:""{outputFile}""";
            var etcArgs = "-mergeoutput -register:user";

            var args = $"{target} {targetargs} {output} {searchdirs} {etcArgs}";

            Debug.WriteLine(args);
            return args;
        }

        public bool IsFormApp()
        {
            return Application.OpenForms.Count > 0;
        }

        public bool RunOpenCoverAndReport(string execTarget, bool noWindow = true)
        {
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }

            if (ExecAndReadConsole(OpenCoverPath, execTarget, noWindow).Item1 == 0)
            {
                if (ExecAndReadConsole(ReportGeneratorPath, GetReportGeneratorArgs(OutputPath, TestTargetExePath)).Item1 == 0)
                {
                    return true;
   
                }
            }
            return false;
        }
    }
}
