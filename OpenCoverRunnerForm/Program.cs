﻿using System;
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
            var exeArgs = "";
            if (Path.GetExtension(target).ToLower().Contains(".exe"))
            {
                logic.TargetType = TargetType.ExeApp;
                logic.TestTargetExePath = target;
                exeArgs = logic.GetOpenCoverExeArgs(logic.OutputPath, target);
            }
            else
            {
                logic.TargetType = TargetType.WebApp;
                logic.TestTargetWebAppPath = target;
                exeArgs = logic.GetOpenCoverWebArgs(logic.OutputPath, target);
            }

            deleteResult(logic);

            if (logic.RunOpenCoverAndReport(exeArgs, false))
            {
                if (!hideresult)
                    Process.Start($@"{logic.OutputPath}\index.htm");
            }

            return 0;
        }
    }
}
