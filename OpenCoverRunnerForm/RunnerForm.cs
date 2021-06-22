using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public string OpenCoverPath { get; set; } = ConfigurationManager.AppSettings["OpenCoverPath"];
        public string ReportGeneratorPath { get; set; } = ConfigurationManager.AppSettings["ReportGeneratorPath"];

        private void RunnerForm_Load(object sender, EventArgs e)
        {
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
        }

        private string[] searchExeFromNuget(string exeName)
        {
            var paths = Directory.GetFiles(NugetPath, exeName, System.IO.SearchOption.AllDirectories);
            return paths;
        }

        private void txtTestTargetExePath_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestTargetExePath.Text))
            {
                txtTestTargetExePath.Text = "";
                return;
            }
        }

        public string OutputPath {
            get {
                var outputPath = Path.Combine(Path.GetDirectoryName(txtTestTargetExePath.Text), "OpenCoverResult");
                return outputPath;
            }
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
            Func<string, string, int> execProcess = (path, args) => {
                ProcessStartInfo psInfo = new ProcessStartInfo(path, args);
                psInfo.CreateNoWindow = true; // コンソール・ウィンドウを開かない
                psInfo.UseShellExecute = false;
                psInfo.RedirectStandardOutput = true; // 標準出力をリダイレクト
                psInfo.RedirectStandardError = true;
                var ps = Process.Start(psInfo);

                Debug.Write(ps.StandardOutput.ReadToEnd());
                Debug.Write(ps.StandardError.ReadToEnd());
                ps.WaitForExit();
         
                return ps.ExitCode;
            };

            if(execProcess(OpenCoverPath, GetOpenCoverArgs()) == 0)
            {
                if (execProcess(ReportGeneratorPath, GetReportGeneratorArgs()) == 0)
                {
                    var dialogResult = MessageBox.Show( "生成したレポートファイルを開きますか？", "処理完了", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Process.Start($@"{OutputPath}\index.htm");
                    }
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
    }
}
