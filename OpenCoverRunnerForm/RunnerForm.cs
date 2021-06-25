using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace OpenCoverRunnerForm
{
    public partial class RunnerForm : Form
    {
        public RunnerForm()
        {
            InitializeComponent();
        }

        public readonly string NugetPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\.nuget\packages";

        public string OpenCoverPath { get { return ConfigurationManager.AppSettings["OpenCoverPath"]; } }

        public string ReportGeneratorPath { get { return ConfigurationManager.AppSettings["ReportGeneratorPath"]; } }

        public string MSTestPath { get; set; }

        public string OutputPath
        {
            get
            {
                if (string.IsNullOrEmpty(txtTestTargetExePath.Text)) return "";
                var outputPath = Path.Combine(Path.GetDirectoryName(txtTestTargetExePath.Text), "OpenCoverResult");
                return outputPath;
            }
        }

        private void RunnerForm_Load(object sender, EventArgs e)
        {
            // todo: Visual Studioのインストール先を取得する。MSTestのパスを見つけるため
            MSTestPath = SearchVSTestPath();


            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (string.IsNullOrEmpty(OpenCoverPath))
            {
                var paths = searchExeFromNuget("OpenCover.Console.exe");
                if (paths.Length > 0)
                {
                    // TODO:複数バージョンインストールされている場合、バージョンが最も新しいファイルを探す
                    config.AppSettings.Settings["OpenCoverPath"].Value= paths[0];
                    config.Save();
                }
            }

            if (string.IsNullOrEmpty(ReportGeneratorPath))
            {
                var paths = searchExeFromNuget("ReportGenerator.exe");
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
            txtOutputReportPath.Text = OutputPath;
        }

        private string SearchVSTestPath()
        {         
            Func<string, string> SearchPathSub = (string basePath) =>
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

            var pgFiles86 = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            var vsTest86 = SearchPathSub(pgFiles86);
            if (string.IsNullOrEmpty(vsTest86))
            {
                var pgFiles = Environment.GetEnvironmentVariable("ProgramFiles");
                return SearchPathSub(pgFiles);

            }
            return vsTest86;
        }

        private Tuple<int, string> ExecAndReadConsole(string path, string args)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo(path, args);
            psInfo.CreateNoWindow = true; // コンソール・ウィンドウを開かない
            psInfo.UseShellExecute = false;
            psInfo.RedirectStandardOutput = true; // 標準出力をリダイレクト
            psInfo.RedirectStandardError = true;
            var ps = Process.Start(psInfo);

            var stdout = ps.StandardOutput.ReadToEnd().TrimEnd();
            Debug.Write(ps.StandardError.ReadToEnd());
            ps.WaitForExit();
            return new Tuple<int, string>(ps.ExitCode, stdout);
        }

        private string[] searchExeFromNuget(string exeName)
        {
            var paths = Directory.GetFiles(NugetPath, exeName, System.IO.SearchOption.AllDirectories);
            return paths;
        }



        private string GetOpenCoverArgs()
        {
            var outputFile = Path.Combine(OutputPath, "results.xml");
            var target = $"-target:\"{txtTestTargetExePath.Text}\"";
            var output = $"-output:\"{outputFile}\"";
            var etcArgs = "-mergeoutput -register:user";

            if(!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }

            var args = $"{target} {output} {etcArgs}";

            Debug.WriteLine(args);
            return args;
        }

        private string GetReportGeneratorArgs()
        {
            //var outputPath = Path.Combine(OutputPath, "OpenCoverResult\\results.xml");
            var reports = $"-reports:\"{Path.Combine(OutputPath, "results.xml")}\"";
            var reportType = "-reporttypes:HtmlInline;";
            var targetdir = $"-targetdir:\"{Path.Combine(OutputPath, "")}\"";
            var classfilters = $"-classfilters:\"-{Path.GetFileNameWithoutExtension(txtTestTargetExePath.Text)}.Properties.*\"";
            var filefilters = $"-filefilters:\"-*.Designer.cs;\"";
      

            var args = $"{reports} {reportType} {targetdir} {classfilters} {filefilters}";

            Debug.WriteLine(args);
            return args;
        }




        private void btnRunProgram_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtTestTargetExePath.Text))
            {
                return;
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["TestTargetExePath"].Value = txtTestTargetExePath.Text;
            config.Save();


            // exeの場合は直接起動をして手動テスト、dllの場合はUnitTestとみなして実行する
            var extention = Path.GetExtension(txtTestTargetExePath.Text).ToLower();
            if (extention == ".exe")
            {
                if (ExecAndReadConsole(OpenCoverPath, GetOpenCoverArgs()).Item1 == 0)
                {
                    if (ExecAndReadConsole(ReportGeneratorPath, GetReportGeneratorArgs()).Item1 == 0)
                    {
                        var dialogResult = MessageBox.Show( "生成したレポートファイルを開きますか？", "処理完了", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Process.Start($@"{OutputPath}\index.htm");
                        }
                    }
                }
            }
            else if (extention == ".dll")
            {
                var outputFile = Path.Combine(OutputPath, "results.xml");
                var target = $"-target:\"{MSTestPath}\"";
                var targetargs = $"-targetargs:\"{txtTestTargetExePath.Text}\"";
                var output = $"-output:\"{outputFile}\"";
                var etcArgs = "-mergeoutput -register:user";

                if (!Directory.Exists(OutputPath))
                {
                    Directory.CreateDirectory(OutputPath);
                }

                var args = $"{target} {targetargs} {output} {etcArgs}";

                Debug.WriteLine(args);

                if (ExecAndReadConsole(OpenCoverPath, args).Item1 == 0)
                {
                    if (ExecAndReadConsole(ReportGeneratorPath, GetReportGeneratorArgs()).Item1 == 0)
                    {
                        var dialogResult = MessageBox.Show("生成したレポートファイルを開きますか？", "処理完了", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Process.Start($@"{OutputPath}\index.htm");
                        }
                    }
                }
            }
        }


        private void btnOpernCoverPath_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.FileName = "OpenCover.Console.exe";
                ofd.InitialDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\.nuget\packages";
                ofd.Filter = "プログラムファイル(*.exe)|*.exe;";
                ofd.FilterIndex = 1;
                ofd.Title = "OpenCoverを選択してください";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtOpernCoverPath.Text = ofd.FileName;
                }
            }
        }

        private void btnReportGenerator_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.FileName = "ReportGenerator.exe";
                ofd.InitialDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\.nuget\packages";
                ofd.Filter = "プログラムファイル(*.exe)|*.exe;";
                ofd.FilterIndex = 1;
                ofd.Title = "ReportGeneratorを選択してください";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtReportGenerator.Text = ofd.FileName;
                }
            }
        }


        private void txtTestTargetExePath_DragEnter(object sender, DragEventArgs e)
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

        private void txtTestTargetExePath_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            txtTestTargetExePath.Text = fileName[0];
            txtOutputReportPath.Text = OutputPath;
        }


        private void txtTestTargetExePath_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestTargetExePath.Text))
            {
                txtTestTargetExePath.Text = "";
                return;
            }
        }


        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            if( Directory.Exists( txtOutputReportPath.Text))
            {
                if( MessageBox.Show("前回までの実行履歴をクリアしますか？","確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Directory.Delete(txtOutputReportPath.Text, true);
                }               
            }
        }


        private void txtUnitTestDllPath_DragDrop(object sender, DragEventArgs e)
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

        private void txtUnitTestDllPath_DragEnter(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            txtUnitTestDllPath.Text = fileName[0];
        }

        private void txtUnitTestDllPath_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestTargetExePath.Text))
            {
                txtUnitTestDllPath.Text = "";
                return;
            }
        }
    }
}
