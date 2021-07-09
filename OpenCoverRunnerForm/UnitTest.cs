using System.Configuration;
using OpenCoverRunnerForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest_RunnerLogic
    {

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["IISExpressPort"].Value = "";
            config.Save();
        }


        [TestInitialize]
        public void TestInitialize()
        {
            // テスト クラスのすべてのテストに必要なリソースの割り当ておよび構成を行うために、テストの前に実行するメソッドを識別します。
            System.Diagnostics.Trace.WriteLine("TestInitialize");
        }

        [TestCleanup]
        public void TestCelean()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["IISExpressPort"].Value = "8081";
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        [TestMethod]
        public void RunnerLogic_CheckBlankConfig()
        {
            // 初回起動時はapp.configの設定が空。コンストラクタで検索して設定するのをテスト。
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["OpenCoverPath"].Value = "";
            config.AppSettings.Settings["ReportGeneratorPath"].Value = "";
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");

            var logic = new RunnerLogic(TargetType.ExeApp, "test.exe");
            Assert.AreEqual(logic.TargetType, TargetType.ExeApp);
            Assert.AreEqual(logic.TestTargetExePath, "test.exe");
            Assert.IsTrue(logic.OpenCoverPath.Contains("OpenCover.Console.exe"));
            Assert.IsTrue(logic.ReportGeneratorPath.Contains("ReportGenerator.exe"));
        }

        [TestMethod]
        public void RunnerLogic_CheckNotBlankConfig()
        {
            // 2回目の起動
            var logic = new RunnerLogic(TargetType.ExeApp, "test.exe");
            Assert.AreEqual(logic.TargetType, TargetType.ExeApp);
            Assert.AreEqual(logic.TestTargetExePath, "test.exe");
            Assert.IsTrue(logic.OpenCoverPath.Contains("OpenCover.Console.exe"));
            Assert.IsTrue(logic.ReportGeneratorPath.Contains("ReportGenerator.exe"));
        }

        [TestMethod]
        public void RunnerLogic_IISPort()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["IISExpressPort"].Value = "";
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            var logic = new RunnerLogic();
            Assert.AreEqual(logic.IISExpressPort, 8080);

            config.AppSettings.Settings["IISExpressPort"].Value = "8081";
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
