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

        public RunnerLogic logic = new RunnerLogic();


        public string NuGetPath { get =>  logic.NuGetPath; }

        public string OpenCoverPath { get => logic.OpenCoverPath; } 

        public string ReportGeneratorPath { get => logic.ReportGeneratorPath; }

        public int IISExpressPort { get => logic.IISExpressPort; }

        public string MSTestPath
        {
            get => logic.MSTestPath;
            set => logic.MSTestPath = value;
        }

        public string OutputPath
        {
            get
            {
                logic.TargetType = tabControl.SelectedIndex == 0 ? TargetType.ExeApp: TargetType.WebApp;
                return logic.OutputPath;
            }
        }

        private void RunnerForm_Load(object sender, EventArgs e)
        {
            
            txtOpernCoverPath.Text = OpenCoverPath;
            txtReportGenerator.Text = ReportGeneratorPath;
            txtTestTargetExePath.Text = ConfigurationManager.AppSettings["TestTargetExePath"];
            txtTestTargetWebAppPath.Text = ConfigurationManager.AppSettings["TestTargetWebAppPath"];
            txtOutputReportPath.Text = OutputPath;
        }

        private string SearchVSTestPath()
        {
            return logic.SearchVSTestPath();
        }

        private Tuple<int, string> ExecAndReadConsole(string path, string args, bool noWindow = true)
        {
            return logic.ExecAndReadConsole(path, args, noWindow);
        }

        private string[] SearchInNugetPath(string exeName)
        {
            return logic.SearchInNugetPath(exeName);
        }

        private string GetOpenCoverExeArgs(string outputPath, string targetExe)
        {
            return logic.GetOpenCoverExeArgs(outputPath, targetExe);
        }

        private string GetReportGeneratorArgs(string outputPath, string testTarget)
        {
             return logic.GetReportGeneratorArgs(outputPath, testTarget);
        }


        private string GetMSTestArgs(string outputPath, string msTestPath, string unitTestPath)
        {
             return logic.GetMSTestArgs(outputPath, msTestPath, unitTestPath);
        }

        private string GetOpenCoverWebArgs(string outputPath, string targetWebApp)
        {
            return logic.GetOpenCoverWebArgs(outputPath, targetWebApp);
        }


        private void btnRunProgram_Click(object sender, EventArgs e)
        {
            var target = txtTestTargetExePath.Text;
            var exePath = target.Split(' ', '\t');
            if (target.Length > 9 && string.IsNullOrEmpty(exePath[0]) || !File.Exists(exePath[0]))
            {
                return;
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["TestTargetExePath"].Value = target;
            config.Save();

            var args = GetOpenCoverExeArgs(OutputPath, target);
            Cursor.Current = Cursors.WaitCursor;
            if (RunOpenCoverAndReport(args) )
            {
                var dialogResult = MessageBox.Show("生成したレポートファイルを開きますか？", "処理完了", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start($@"{OutputPath}\index.htm");
                }
            }
            Cursor.Current = Cursors.Default;
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

            var args = GetOpenCoverWebArgs(OutputPath, target);
            Cursor.Current = Cursors.WaitCursor;
            if (RunOpenCoverAndReport(args))
            {
                var dialogResult = MessageBox.Show("生成したレポートファイルを開きますか？", "処理完了", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start($@"{OutputPath}\index.htm");
                }
            }
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
            if (RunOpenCoverAndReport(args, false))
            {
                var dialogResult = MessageBox.Show("生成したレポートファイルを開きますか？", "処理完了", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start($@"{OutputPath}\index.htm");
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private bool RunOpenCoverAndReport(string execTarget, bool showConsole = true)
        {
            return logic.RunOpenCoverAndReport(showConsole);
        }




        private void btnOpernCoverPath_Click(object sender, EventArgs e)
        {
            txtOpernCoverPath.Text = OpenFileDialog("OpenCover.Console.exe", txtOpernCoverPath.Text);
        }

        private void btnReportGenerator_Click(object sender, EventArgs e)
        {
            txtReportGenerator.Text = OpenFileDialog("ReportGenerator.exe", txtReportGenerator.Text);
        }

        private string OpenFileDialog(string fileName, string originalPath)
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
                    return  ofd.FileName;
                }
            }
            return originalPath;
        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtOutputReportPath.Text))
            {
                if (MessageBox.Show("前回までの実行履歴をクリアしますか？", "確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Directory.Delete(txtOutputReportPath.Text, true);
                    lblPrevReport.Text = "";
                }
            }
        }

        private void txtTestTargetExePath_TextChanged(object sender, EventArgs e)
        {
            logic.TestTargetExePath = txtTestTargetExePath.Text;
        }

        private void txtTestTargetWebAppPath_TextChanged(object sender, EventArgs e)
        {
            logic.TestTargetWebAppPath = txtTestTargetWebAppPath.Text;
        }

        #region "Drag & Drop"
        private static void OnTargetDragEnter(DragEventArgs e)
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

        private static void OnTargetDragDrop(object sender, DragEventArgs e)
        {
            var textbox = (TextBox)sender;
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            textbox.Text = fileName[0];
        }

        private void txtTestTargetExePath_DragEnter(object sender, DragEventArgs e)
        {
            OnTargetDragEnter(e);
        }

        private void txtTestTargetExePath_DragDrop(object sender, DragEventArgs e)
        {
            OnTargetDragDrop(sender, e);
            txtOutputReportPath.Text = OutputPath;
        }


        private void txtUnitTestDllPath_DragEnter(object sender, DragEventArgs e)
        {
            OnTargetDragEnter(e);
        }

        private void txtUnitTestDllPath_DragDrop(object sender, DragEventArgs e)
        {
            OnTargetDragDrop(sender, e);            
        }

        private void txtTestTargetWebAppPath_DragEnter(object sender, DragEventArgs e)
        {
            OnTargetDragEnter(e);
        }

        private void txtTestTargetWebAppPath_DragDrop(object sender, DragEventArgs e)
        {
            OnTargetDragDrop(sender, e);
            txtOutputReportPath.Text = OutputPath;
        }


        #endregion

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOutputReportPath.Text = this.OutputPath;
        }

        private void txtOutputReportPath_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(this.OutputPath, "coverageReport.xml")))
            {
                lblPrevReport.Text = "【前回レポート有り】";
            }
            else
            {
                lblPrevReport.Text = "";
            }
        }
    }
}
