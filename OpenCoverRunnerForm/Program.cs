using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OpenCoverRunnerForm
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")] // この行を追加
        private static extern bool AllocConsole();

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
            for(var i = 1; i < args.Length; i++)
            {
                argSet.Add(args[i]);
            }

            if (argSet.Contains("-hideresult"))
            {
                hideresult = true;
            }


          
            Action<RunnerLogic> deleteResult = (e) =>
            {
                if (!argSet.Contains("-preserveresult"))
                {
                    if (Directory.Exists(e.OutputPath))
                    {
                        Directory.Delete(e.OutputPath, true);
                    }
                }
            };



            var logic = new RunnerLogic();

            
            if (Path.GetExtension(target).ToLower().Contains(".exe"))
            {
                AllocConsole();
                logic.TargetType = TargetType.ExeApp;
                logic.TestTargetExePath = target;
                deleteResult(logic);
                var exeArgs = logic.GetOpenCoverExeArgs(logic.OutputPath, target);

                if (logic.RunOpenCoverAndReport(exeArgs))
                {
                    if(!hideresult)
                        Process.Start($@"{logic.OutputPath}\index.htm");
                }
            }
            else
            {
                logic.TargetType = TargetType.WebApp;
                logic.TestTargetWebAppPath = target;
                deleteResult(logic);
                var webArgs = logic.GetOpenCoverWebArgs(logic.OutputPath, target);
                if (logic.RunOpenCoverAndReport(webArgs, false))
                {
                    if (!hideresult)
                        Process.Start($@"{logic.OutputPath}\index.htm");
                }
            }
          
            return 0;
        }
    }
}
