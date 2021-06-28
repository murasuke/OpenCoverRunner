namespace OpenCoverRunnerForm
{
    partial class RunnerForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunnerForm));
            this.txtTestTargetExePath = new System.Windows.Forms.TextBox();
            this.btnRunProgram = new System.Windows.Forms.Button();
            this.txtOpernCoverPath = new System.Windows.Forms.TextBox();
            this.txtReportGenerator = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpSetting = new System.Windows.Forms.GroupBox();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.btnReportGenerator = new System.Windows.Forms.Button();
            this.btnOpernCoverPath = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReportPath = new System.Windows.Forms.Label();
            this.txtOutputReportPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnitTestDllPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRunTest = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabExePath = new System.Windows.Forms.TabPage();
            this.tabWebAppPath = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTestTargetWebAppPath = new System.Windows.Forms.TextBox();
            this.btnRunWebApp = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Output = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPrevReport = new System.Windows.Forms.Label();
            this.grpSetting.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabExePath.SuspendLayout();
            this.tabWebAppPath.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTestTargetExePath
            // 
            this.txtTestTargetExePath.AllowDrop = true;
            this.txtTestTargetExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestTargetExePath.BackColor = System.Drawing.Color.LightCyan;
            this.txtTestTargetExePath.Location = new System.Drawing.Point(11, 29);
            this.txtTestTargetExePath.Name = "txtTestTargetExePath";
            this.txtTestTargetExePath.Size = new System.Drawing.Size(789, 19);
            this.txtTestTargetExePath.TabIndex = 0;
            this.txtTestTargetExePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtTestTargetExePath_DragDrop);
            this.txtTestTargetExePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtTestTargetExePath_DragEnter);
            // 
            // btnRunProgram
            // 
            this.btnRunProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunProgram.BackColor = System.Drawing.Color.Khaki;
            this.btnRunProgram.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRunProgram.Location = new System.Drawing.Point(807, 13);
            this.btnRunProgram.Name = "btnRunProgram";
            this.btnRunProgram.Size = new System.Drawing.Size(113, 47);
            this.btnRunProgram.TabIndex = 1;
            this.btnRunProgram.Text = "テスト対象\r\nプログラム起動";
            this.btnRunProgram.UseVisualStyleBackColor = false;
            this.btnRunProgram.Click += new System.EventHandler(this.btnRunProgram_Click);
            // 
            // txtOpernCoverPath
            // 
            this.txtOpernCoverPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOpernCoverPath.Location = new System.Drawing.Point(151, 20);
            this.txtOpernCoverPath.Name = "txtOpernCoverPath";
            this.txtOpernCoverPath.ReadOnly = true;
            this.txtOpernCoverPath.Size = new System.Drawing.Size(677, 19);
            this.txtOpernCoverPath.TabIndex = 2;
            // 
            // txtReportGenerator
            // 
            this.txtReportGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReportGenerator.Location = new System.Drawing.Point(151, 45);
            this.txtReportGenerator.Name = "txtReportGenerator";
            this.txtReportGenerator.ReadOnly = true;
            this.txtReportGenerator.Size = new System.Drawing.Size(677, 19);
            this.txtReportGenerator.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "OpenCoverパス";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "RreportGeneratorパス";
            // 
            // grpSetting
            // 
            this.grpSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSetting.Controls.Add(this.btnClearOutput);
            this.grpSetting.Controls.Add(this.btnReportGenerator);
            this.grpSetting.Controls.Add(this.btnOpernCoverPath);
            this.grpSetting.Controls.Add(this.label1);
            this.grpSetting.Controls.Add(this.label6);
            this.grpSetting.Controls.Add(this.label5);
            this.grpSetting.Controls.Add(this.lblPrevReport);
            this.grpSetting.Controls.Add(this.lblReportPath);
            this.grpSetting.Controls.Add(this.label2);
            this.grpSetting.Controls.Add(this.txtOpernCoverPath);
            this.grpSetting.Controls.Add(this.txtOutputReportPath);
            this.grpSetting.Controls.Add(this.txtReportGenerator);
            this.grpSetting.Location = new System.Drawing.Point(12, 78);
            this.grpSetting.Name = "grpSetting";
            this.grpSetting.Size = new System.Drawing.Size(933, 159);
            this.grpSetting.TabIndex = 5;
            this.grpSetting.TabStop = false;
            this.grpSetting.Text = "【パス一覧（起動時にインストール先を検索してセットします）】";
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOutput.Location = new System.Drawing.Point(834, 104);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(93, 34);
            this.btnClearOutput.TabIndex = 5;
            this.btnClearOutput.Text = "前回のレポート削除";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // btnReportGenerator
            // 
            this.btnReportGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportGenerator.Location = new System.Drawing.Point(834, 41);
            this.btnReportGenerator.Name = "btnReportGenerator";
            this.btnReportGenerator.Size = new System.Drawing.Size(93, 23);
            this.btnReportGenerator.TabIndex = 5;
            this.btnReportGenerator.Text = "選択";
            this.btnReportGenerator.UseVisualStyleBackColor = true;
            this.btnReportGenerator.Click += new System.EventHandler(this.btnReportGenerator_Click);
            // 
            // btnOpernCoverPath
            // 
            this.btnOpernCoverPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpernCoverPath.Location = new System.Drawing.Point(834, 18);
            this.btnOpernCoverPath.Name = "btnOpernCoverPath";
            this.btnOpernCoverPath.Size = new System.Drawing.Size(93, 23);
            this.btnOpernCoverPath.TabIndex = 5;
            this.btnOpernCoverPath.Text = "選択";
            this.btnOpernCoverPath.UseVisualStyleBackColor = true;
            this.btnOpernCoverPath.Click += new System.EventHandler(this.btnOpernCoverPath_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(571, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "初回起動時、「%USERPROFILE%\\.nuget\\packages」から、「OpenCover」と「ReportGenerator]を検索してセットします。" +
    "\r\n見つかった場合app.configに保存し、2回目以降の起動ではapp.configから読み込んで表示します。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(604, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "テスト対象フォルダ配下に「OpenCoverResult」をフォルダ作成し、そこにレポートファイル「index.html」ができます。\r\n複数回「プログラム実行」" +
    "を行った場合、テスト結果(カバレッジ率)をマージします。最初から計測したい場合は「クリア」してください。";
            // 
            // lblReportPath
            // 
            this.lblReportPath.AutoSize = true;
            this.lblReportPath.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblReportPath.Location = new System.Drawing.Point(15, 109);
            this.lblReportPath.Name = "lblReportPath";
            this.lblReportPath.Size = new System.Drawing.Size(93, 12);
            this.lblReportPath.TabIndex = 4;
            this.lblReportPath.Text = "レポート出力パス";
            // 
            // txtOutputReportPath
            // 
            this.txtOutputReportPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputReportPath.Location = new System.Drawing.Point(151, 106);
            this.txtOutputReportPath.Name = "txtOutputReportPath";
            this.txtOutputReportPath.ReadOnly = true;
            this.txtOutputReportPath.Size = new System.Drawing.Size(677, 19);
            this.txtOutputReportPath.TabIndex = 3;
            this.txtOutputReportPath.TextChanged += new System.EventHandler(this.txtOutputReportPath_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(9, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(344, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "テスト対象のプログラム(exe)パスを入力(Drag && Drop可能)";
            // 
            // txtUnitTestDllPath
            // 
            this.txtUnitTestDllPath.AllowDrop = true;
            this.txtUnitTestDllPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnitTestDllPath.BackColor = System.Drawing.Color.LightCyan;
            this.txtUnitTestDllPath.Location = new System.Drawing.Point(10, 84);
            this.txtUnitTestDllPath.Name = "txtUnitTestDllPath";
            this.txtUnitTestDllPath.Size = new System.Drawing.Size(790, 19);
            this.txtUnitTestDllPath.TabIndex = 0;
            this.txtUnitTestDllPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtUnitTestDllPath_DragDrop);
            this.txtUnitTestDllPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtUnitTestDllPath_DragEnter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(9, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(416, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "任意：ユニットテスト(dll)のパスを入力(手動テストの結果とマージされます)";
            // 
            // btnRunTest
            // 
            this.btnRunTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunTest.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRunTest.Location = new System.Drawing.Point(806, 68);
            this.btnRunTest.Name = "btnRunTest";
            this.btnRunTest.Size = new System.Drawing.Size(113, 47);
            this.btnRunTest.TabIndex = 1;
            this.btnRunTest.Text = "ユニットテスト実行";
            this.btnRunTest.UseVisualStyleBackColor = true;
            this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabExePath);
            this.tabControl.Controls.Add(this.tabWebAppPath);
            this.tabControl.Location = new System.Drawing.Point(12, 244);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(933, 153);
            this.tabControl.TabIndex = 7;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabExePath
            // 
            this.tabExePath.Controls.Add(this.label4);
            this.tabExePath.Controls.Add(this.txtTestTargetExePath);
            this.tabExePath.Controls.Add(this.btnRunTest);
            this.tabExePath.Controls.Add(this.btnRunProgram);
            this.tabExePath.Controls.Add(this.txtUnitTestDllPath);
            this.tabExePath.Controls.Add(this.label9);
            this.tabExePath.Location = new System.Drawing.Point(4, 22);
            this.tabExePath.Name = "tabExePath";
            this.tabExePath.Padding = new System.Windows.Forms.Padding(3);
            this.tabExePath.Size = new System.Drawing.Size(925, 127);
            this.tabExePath.TabIndex = 0;
            this.tabExePath.Text = "実行可能プログラムの手動テスト";
            this.tabExePath.UseVisualStyleBackColor = true;
            // 
            // tabWebAppPath
            // 
            this.tabWebAppPath.Controls.Add(this.label8);
            this.tabWebAppPath.Controls.Add(this.txtTestTargetWebAppPath);
            this.tabWebAppPath.Controls.Add(this.btnRunWebApp);
            this.tabWebAppPath.Controls.Add(this.label11);
            this.tabWebAppPath.Location = new System.Drawing.Point(4, 22);
            this.tabWebAppPath.Name = "tabWebAppPath";
            this.tabWebAppPath.Padding = new System.Windows.Forms.Padding(3);
            this.tabWebAppPath.Size = new System.Drawing.Size(925, 127);
            this.tabWebAppPath.TabIndex = 1;
            this.tabWebAppPath.Text = "Webアプリケーションのテスト";
            this.tabWebAppPath.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(9, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(402, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "テスト対象のWebアプリケーションルートパスを入力(Drag && Drop可能)";
            // 
            // txtTestTargetWebAppPath
            // 
            this.txtTestTargetWebAppPath.AllowDrop = true;
            this.txtTestTargetWebAppPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestTargetWebAppPath.BackColor = System.Drawing.Color.LightCyan;
            this.txtTestTargetWebAppPath.Location = new System.Drawing.Point(11, 29);
            this.txtTestTargetWebAppPath.Name = "txtTestTargetWebAppPath";
            this.txtTestTargetWebAppPath.Size = new System.Drawing.Size(789, 19);
            this.txtTestTargetWebAppPath.TabIndex = 5;
            this.txtTestTargetWebAppPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtTestTargetWebAppPath_DragDrop);
            this.txtTestTargetWebAppPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtTestTargetWebAppPath_DragEnter);
            // 
            // btnRunWebApp
            // 
            this.btnRunWebApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunWebApp.BackColor = System.Drawing.Color.Khaki;
            this.btnRunWebApp.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRunWebApp.Location = new System.Drawing.Point(807, 13);
            this.btnRunWebApp.Name = "btnRunWebApp";
            this.btnRunWebApp.Size = new System.Drawing.Size(113, 47);
            this.btnRunWebApp.TabIndex = 6;
            this.btnRunWebApp.Text = "テスト対象\r\nプログラム起動";
            this.btnRunWebApp.UseVisualStyleBackColor = false;
            this.btnRunWebApp.Click += new System.EventHandler(this.btnRunWebApp_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(527, 36);
            this.label11.TabIndex = 4;
            this.label11.Text = "・IISExpressコンソールが起動します。portは「8080」です(app.configで変更できます)。\r\n・ブラウザでコンソールに表示されているURLを" +
    "開きテストします。\r\n・テスト終了後、コンソール画面に切り替えてから「q」キーを押すとIISExpressが終了し、レポートが表示されます。";
            // 
            // Output
            // 
            this.Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Output.Location = new System.Drawing.Point(16, 415);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Output.Size = new System.Drawing.Size(925, 101);
            this.Output.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 401);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "Console";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 59);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "プログラム概要";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(15, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(454, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = " ・テスト対象のプログラムを指定後、「プログラム起動」ボタンをクリックします。\r\n ・プログラムを終了すると、カバレッジのレポートを表示します(ブラウザを起動して" +
    "表示)。\r\n ・「OpenCover」と「ReportGenerator]を「NuGetパッケージの管理」からインストールしてください)。";
            // 
            // lblPrevReport
            // 
            this.lblPrevReport.AutoSize = true;
            this.lblPrevReport.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPrevReport.Location = new System.Drawing.Point(35, 127);
            this.lblPrevReport.Name = "lblPrevReport";
            this.lblPrevReport.Size = new System.Drawing.Size(0, 12);
            this.lblPrevReport.TabIndex = 4;
            // 
            // RunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 528);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.grpSetting);
            this.Controls.Add(this.label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RunnerForm";
            this.Text = "カバレッジ測定ツール(.NET Framework exe, asp.net)";
            this.Load += new System.EventHandler(this.RunnerForm_Load);
            this.grpSetting.ResumeLayout(false);
            this.grpSetting.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabExePath.ResumeLayout(false);
            this.tabExePath.PerformLayout();
            this.tabWebAppPath.ResumeLayout(false);
            this.tabWebAppPath.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTestTargetExePath;
        private System.Windows.Forms.Button btnRunProgram;
        private System.Windows.Forms.TextBox txtOpernCoverPath;
        private System.Windows.Forms.TextBox txtReportGenerator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpSetting;
        private System.Windows.Forms.Button btnReportGenerator;
        private System.Windows.Forms.Button btnOpernCoverPath;
        private System.Windows.Forms.Label lblReportPath;
        private System.Windows.Forms.TextBox txtOutputReportPath;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnitTestDllPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRunTest;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabExePath;
        private System.Windows.Forms.TabPage tabWebAppPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTestTargetWebAppPath;
        private System.Windows.Forms.Button btnRunWebApp;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPrevReport;
    }
}

