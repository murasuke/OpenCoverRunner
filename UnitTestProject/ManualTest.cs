using ManualTestExeForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace UnitTestProject
{
    [TestClass]
    public class ManualTest
    {
        [TestMethod]
        public void ShowFormForManualTest()
        {
            ManualTestSample.Program.Main();
        }

       
    }
}
