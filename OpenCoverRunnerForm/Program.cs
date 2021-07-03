using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OpenCoverRunnerForm
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                // show UI
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new RunnerForm());
                return 0;
            }
            else
            {
                // show console
                return RunCoverage(args);
            }
        }


        static int RunCoverage(string[] args)
        {
            var target = args[0];
            var hideresult = false;
            var argSet = new HashSet<string>();
            for (var i = 1; i < args.Length; i++)
            {
                argSet.Add(args[i]);
            }

            hideresult = argSet.Contains("-hideresult");

            TargetType targetType = Path.GetExtension(target).ToLower().Contains(".exe") ? TargetType.ExeApp : TargetType.WebApp;

            var logic = new RunnerLogic(targetType, target);

            ClearPreviousResult(logic, argSet.Contains("-mergeresult"));

            if (logic.RunOpenCoverAndReport(false))
            {
                if (!hideresult)
                    Process.Start($@"{logic.OutputPath}\index.htm");
            }

            return 0;
        }

        private static void ClearPreviousResult(RunnerLogic e, bool preserve)
        {
            if (!preserve)
            {
                if (Directory.Exists(e.OutputPath))
                {
                    Directory.Delete(e.OutputPath, true);
                }
            }
        }
    }
}
