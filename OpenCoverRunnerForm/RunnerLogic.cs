using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoverRunnerForm
{
    public class RunnerLogic
    {
        public readonly string NuGetPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\.nuget\packages";

        public string OpenCoverPath { get { return ConfigurationManager.AppSettings["OpenCoverPath"]; } }

        public string ReportGeneratorPath { get { return ConfigurationManager.AppSettings["ReportGeneratorPath"]; } }

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

        public int tabSelectedIncex = 0;

        public string OutputPath
        {
            get
            {
                //if (tabSelectedIncex == 0)
                //{
                //    if (string.IsNullOrEmpty(txtTestTargetExePath.Text)) return "";
                //    var outputPath = Path.Combine(Path.GetDirectoryName(txtTestTargetExePath.Text), "OpenCoverResult");
                //    return outputPath;
                //}
                //else
                //{
                //    if (string.IsNullOrEmpty(txtTestTargetWebAppPath.Text)) return "";
                //    var outputPath = Path.Combine(txtTestTargetWebAppPath.Text, @"obj\OpenCoverResult");
                //    return outputPath;
                //}
                return "";
            }
        }

        public RunnerLogic()
        {

        }

        private string SearchVSTestPath()
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


        private Tuple<int, string> ExecAndReadConsole(string path, string args, bool noWindow = true)
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

        private string[] SearchInNugetPath(string exeName)
        {
            var paths = Directory.GetFiles(NuGetPath, exeName, SearchOption.AllDirectories);
            return paths;
        }


        private string GetOpenCoverExeArgs(string outputPath, string targetExe)
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

        private string GetReportGeneratorArgs(string outputPath, string testTarget)
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


        private string GetMSTestArgs(string outputPath, string msTestPath, string unitTestPath)
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

        private string GetOpenCoverWebArgs(string outputPath, string targetWebApp)
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
    }
}
