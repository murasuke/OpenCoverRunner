using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OpenCoverRunnerForm
{
    public partial class RunnerForm : Form
    {
        public RunnerForm()
        {
            InitializeComponent();
        }

        public readonly string NuGetPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\.nuget\packages";

        public string OpenCoverPath { get { return ConfigurationManager.AppSettings["OpenCoverPath"]; } }

        public string ReportGeneratorPath { get { return ConfigurationManager.AppSettings["ReportGeneratorPath"]; } }

        public int IISExpressPort
        {
            get {
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

        public string OutputPath
        {
            get
            {
                if (tabControl.SelectedIndex == 0)
                { 
                    if (string.IsNullOrEmpty(txtTestTargetExePath.Text)) return "";
                    var outputPath = Path.Combine(Path.GetDirectoryName(txtTestTargetExePath.Text), "OpenCoverResult");
                    return outputPath;
                }
                else
                {
                    if (string.IsNullOrEmpty(txtTestTargetWebAppPath.Text)) return "";
                    var outputPath = Path.Combine(txtTestTargetWebAppPath.Text, @"obj\OpenCoverResult");
                    return outputPath;
                }
            }
        }

        private void RunnerForm_Load(object sender, EventArgs e)
        {
            // todo: Visual Studioのインストール先を取得する。MSTestのパスを見つけるため
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

            ConfigurationManager.RefreshSection("appSettings");
            txtOpernCoverPath.Text = OpenCoverPath;
            txtReportGenerator.Text = ReportGeneratorPath;
            txtTestTargetExePath.Text = ConfigurationManager.AppSettings["TestTargetExePath"];
            txtTestTargetWebAppPath.Text = ConfigurationManager.AppSettings["TestTargetWebAppPath"];
            txtOutputReportPath.Text = OutputPath;
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
            Output.Text += $"{path} {args}\r\n\r\n";
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


        private void btnRunProgram_Click(object sender, EventArgs e)
        {
            var target = txtTestTargetExePath.Text;
            if (string.IsNullOrEmpty(target) || !File.Exists(target))
            {
                return;
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["TestTargetExePath"].Value = target;
            config.Save();

            var args = GetOpenCoverExeArgs(OutputPath, target);
            Cursor.Current = Cursors.WaitCursor;
            RunOpenCoverAndReport(args);
            Cursor.Current = Cursors.Default;
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            var target = txtTestTargetExePath.Text;
            var unitTest = txtUnitTestDllPath.Text;
            if (string.IsNullOrEmpty(target) || !File.Exists(target))
            {
                return;
            }

            if (string.IsNullOrEmpty(unitTest) || !File.Exists(unitTest))
            {
                return;
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["UnitTestDllPath"].Value = target;
            config.Save();

            var args = GetMSTestArgs(OutputPath, MSTestPath, unitTest);
            Cursor.Current = Cursors.WaitCursor;
            RunOpenCoverAndReport(args);
            Cursor.Current = Cursors.Default;
        }

        private void RunOpenCoverAndReport(string execTarget, bool noWindow = true)
        {
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }

            if (ExecAndReadConsole(OpenCoverPath, execTarget, noWindow).Item1 == 0)
            {
                if (ExecAndReadConsole(ReportGeneratorPath, GetReportGeneratorArgs(OutputPath, txtTestTargetExePath.Text)).Item1 == 0)
                {
                    var dialogResult = MessageBox.Show("生成したレポートファイルを開きますか？", "処理完了", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Process.Start($@"{OutputPath}\index.htm");
                    }
                }
            }
        }

        private void btnRunWebApp_Click(object sender, EventArgs e)
        {
            var target = txtTestTargetWebAppPath.Text;
            if (string.IsNullOrEmpty(target) || !Directory.Exists(target))
            {
                return;
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["TestTargetWebAppPath"].Value = target;
            config.Save();

            // web.configから<compilation tempDirectory=""> を探す。見つからない場合は実行不可(メッセージを表示する)
            // dllを探す(./obj/Debug/にあるdllとする。(
            // tempDireco

            var args = GetOpenCoverWebArgs(OutputPath, target);
            Cursor.Current = Cursors.WaitCursor;
            RunOpenCoverAndReport(args, false);
            Cursor.Current = Cursors.Default;
        }


        private void btnOpernCoverPath_Click(object sender, EventArgs e)
        {
            txtOpernCoverPath.Text = OpenFileDialog("OpenCover.Console.exe");
        }

        private void btnReportGenerator_Click(object sender, EventArgs e)
        {
            txtReportGenerator.Text = OpenFileDialog("ReportGenerator.exe");
        }

        private string OpenFileDialog(string fileName)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.FileName = fileName;
                ofd.InitialDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\.nuget\packages";
                ofd.Filter = "プログラムファイル(*.exe)|*.exe;";
                ofd.FilterIndex = 1;
                ofd.Title = $"{fileName}を選択してください";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
            }
            return "";
        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtOutputReportPath.Text))
            {
                if (MessageBox.Show("前回までの実行履歴をクリアしますか？", "確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Directory.Delete(txtOutputReportPath.Text, true);
                }
            }
        }

        #region "Drag & Drop"
        private static void OnDragEnter(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private static void OnDragDrop(object sender, DragEventArgs e)
        {
            var textbox = (TextBox)sender;
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            textbox.Text = fileName[0];
        }

        private void txtTestTargetExePath_DragEnter(object sender, DragEventArgs e)
        {
            OnDragEnter(e);
        }

        private void txtTestTargetExePath_DragDrop(object sender, DragEventArgs e)
        {
            OnDragDrop(sender, e);
            txtOutputReportPath.Text = OutputPath;
        }


        private void txtUnitTestDllPath_DragEnter(object sender, DragEventArgs e)
        {
            OnDragEnter(e);
        }

        private void txtUnitTestDllPath_DragDrop(object sender, DragEventArgs e)
        {
            OnDragDrop(sender, e);            
        }

        private void txtTestTargetWebAppPath_DragEnter(object sender, DragEventArgs e)
        {
            OnDragEnter(e);
        }

        private void txtTestTargetWebAppPath_DragDrop(object sender, DragEventArgs e)
        {
            OnDragDrop(sender, e);
            txtOutputReportPath.Text = OutputPath;
        }


        #endregion

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOutputReportPath.Text = this.OutputPath;
        }
    }
}
