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
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputReportPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUnitTestDllPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRunTest = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabExePath = new System.Windows.Forms.TabPage();
            this.tabWebAppPath = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTestTargetWebAppPath = new System.Windows.Forms.TextBox();
            this.btnRunWebApp = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.grpSetting.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabExePath.SuspendLayout();
            this.tabWebAppPath.SuspendLayout();
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
            this.txtTestTargetExePath.Size = new System.Drawing.Size(793, 19);
            this.txtTestTargetExePath.TabIndex = 0;
            this.txtTestTargetExePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtTestTargetExePath_DragDrop);
            this.txtTestTargetExePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtTestTargetExePath_DragEnter);
            // 
            // btnRunProgram
            // 
            this.btnRunProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunProgram.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRunProgram.Location = new System.Drawing.Point(811, 13);
            this.btnRunProgram.Name = "btnRunProgram";
            this.btnRunProgram.Size = new System.Drawing.Size(113, 47);
            this.btnRunProgram.TabIndex = 1;
            this.btnRunProgram.Text = "テスト対象\r\nプログラム起動";
            this.btnRunProgram.UseVisualStyleBackColor = true;
            this.btnRunProgram.Click += new System.EventHandler(this.btnRunProgram_Click);
            // 
            // txtOpernCoverPath
            // 
            this.txtOpernCoverPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOpernCoverPath.Location = new System.Drawing.Point(131, 25);
            this.txtOpernCoverPath.Name = "txtOpernCoverPath";
            this.txtOpernCoverPath.ReadOnly = true;
            this.txtOpernCoverPath.Size = new System.Drawing.Size(701, 19);
            this.txtOpernCoverPath.TabIndex = 2;
            // 
            // txtReportGenerator
            // 
            this.txtReportGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReportGenerator.Location = new System.Drawing.Point(131, 50);
            this.txtReportGenerator.Name = "txtReportGenerator";
            this.txtReportGenerator.ReadOnly = true;
            this.txtReportGenerator.Size = new System.Drawing.Size(701, 19);
            this.txtReportGenerator.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "OpenCoverパス";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 12);
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
            this.grpSetting.Controls.Add(this.label3);
            this.grpSetting.Controls.Add(this.label2);
            this.grpSetting.Controls.Add(this.txtOpernCoverPath);
            this.grpSetting.Controls.Add(this.txtOutputReportPath);
            this.grpSetting.Controls.Add(this.txtReportGenerator);
            this.grpSetting.Location = new System.Drawing.Point(12, 59);
            this.grpSetting.Name = "grpSetting";
            this.grpSetting.Size = new System.Drawing.Size(937, 159);
            this.grpSetting.TabIndex = 5;
            this.grpSetting.TabStop = false;
            this.grpSetting.Text = "【パス一覧（自動で検索してセットします）】";
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOutput.Location = new System.Drawing.Point(838, 104);
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
            this.btnReportGenerator.Location = new System.Drawing.Point(838, 46);
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
            this.btnOpernCoverPath.Location = new System.Drawing.Point(838, 23);
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
            this.label6.Location = new System.Drawing.Point(129, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(571, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "初回起動時、「%USERPROFILE%\\.nuget\\packages」から、「OpenCover」と「ReportGenerator]を検索してセットします。" +
    "\r\n見つかった場合app.configに保存し、2回目以降の起動ではapp.configから読み込んで表示します。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(597, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "テスト対象プログラムパスにサブフォルダ「OpenCoverResult」を作成し、そこにレポートファイル「index.html」を作成します。\r\n複数回「プログラ" +
    "ム実行」を行った場合、テスト結果(カバレッジ率)はマージされます。1から計測したい場合は「クリア」してください。";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "レポート出力パス";
            // 
            // txtOutputReportPath
            // 
            this.txtOutputReportPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputReportPath.Location = new System.Drawing.Point(131, 106);
            this.txtOutputReportPath.Name = "txtOutputReportPath";
            this.txtOutputReportPath.ReadOnly = true;
            this.txtOutputReportPath.Size = new System.Drawing.Size(701, 19);
            this.txtOutputReportPath.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(9, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(311, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "テスト対象のプログラムパスを入力(Drag && Drop可能)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(900, 39);
            this.label7.TabIndex = 4;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // txtUnitTestDllPath
            // 
            this.txtUnitTestDllPath.AllowDrop = true;
            this.txtUnitTestDllPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnitTestDllPath.BackColor = System.Drawing.Color.LightCyan;
            this.txtUnitTestDllPath.Location = new System.Drawing.Point(10, 84);
            this.txtUnitTestDllPath.Name = "txtUnitTestDllPath";
            this.txtUnitTestDllPath.Size = new System.Drawing.Size(794, 19);
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
            this.label9.Size = new System.Drawing.Size(244, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "ユニットテスト(dll)のパスを入力(Optional)";
            // 
            // btnRunTest
            // 
            this.btnRunTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunTest.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRunTest.Location = new System.Drawing.Point(810, 68);
            this.btnRunTest.Name = "btnRunTest";
            this.btnRunTest.Size = new System.Drawing.Size(113, 47);
            this.btnRunTest.TabIndex = 1;
            this.btnRunTest.Text = "ユニットテスト実行";
            this.btnRunTest.UseVisualStyleBackColor = true;
            this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabExePath);
            this.tabControl1.Controls.Add(this.tabWebAppPath);
            this.tabControl1.Location = new System.Drawing.Point(12, 236);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(937, 153);
            this.tabControl1.TabIndex = 7;
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
            this.tabExePath.Size = new System.Drawing.Size(929, 127);
            this.tabExePath.TabIndex = 0;
            this.tabExePath.Text = "実行可能プログラムの手動テスト";
            this.tabExePath.UseVisualStyleBackColor = true;
            // 
            // tabWebAppPath
            // 
            this.tabWebAppPath.Controls.Add(this.label8);
            this.tabWebAppPath.Controls.Add(this.txtTestTargetWebAppPath);
            this.tabWebAppPath.Controls.Add(this.btnRunWebApp);
            this.tabWebAppPath.Location = new System.Drawing.Point(4, 22);
            this.tabWebAppPath.Name = "tabWebAppPath";
            this.tabWebAppPath.Padding = new System.Windows.Forms.Padding(3);
            this.tabWebAppPath.Size = new System.Drawing.Size(929, 127);
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
            this.label8.Size = new System.Drawing.Size(410, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "テスト対象のWebアプリケーションフォルダパスを入力(Drag && Drop可能)";
            // 
            // txtTestTargetWebAppPath
            // 
            this.txtTestTargetWebAppPath.AllowDrop = true;
            this.txtTestTargetWebAppPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestTargetWebAppPath.BackColor = System.Drawing.Color.LightCyan;
            this.txtTestTargetWebAppPath.Location = new System.Drawing.Point(11, 29);
            this.txtTestTargetWebAppPath.Name = "txtTestTargetWebAppPath";
            this.txtTestTargetWebAppPath.Size = new System.Drawing.Size(793, 19);
            this.txtTestTargetWebAppPath.TabIndex = 5;
            this.txtTestTargetWebAppPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtTestTargetWebAppPath_DragDrop);
            this.txtTestTargetWebAppPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtTestTargetWebAppPath_DragEnter);
            // 
            // btnRunWebApp
            // 
            this.btnRunWebApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunWebApp.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRunWebApp.Location = new System.Drawing.Point(811, 13);
            this.btnRunWebApp.Name = "btnRunWebApp";
            this.btnRunWebApp.Size = new System.Drawing.Size(113, 47);
            this.btnRunWebApp.TabIndex = 6;
            this.btnRunWebApp.Text = "テスト対象\r\nプログラム起動";
            this.btnRunWebApp.UseVisualStyleBackColor = true;
            this.btnRunWebApp.Click += new System.EventHandler(this.btnRunWebApp_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(15, 433);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(928, 96);
            this.textBox2.TabIndex = 8;
            // 
            // RunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 518);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grpSetting);
            this.Controls.Add(this.label7);
            this.Name = "RunnerForm";
            this.Text = "OpenCoverRunnerForm";
            this.Load += new System.EventHandler(this.RunnerForm_Load);
            this.grpSetting.ResumeLayout(false);
            this.grpSetting.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabExePath.ResumeLayout(false);
            this.tabExePath.PerformLayout();
            this.tabWebAppPath.ResumeLayout(false);
            this.tabWebAppPath.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutputReportPath;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUnitTestDllPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRunTest;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabExePath;
        private System.Windows.Forms.TabPage tabWebAppPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTestTargetWebAppPath;
        private System.Windows.Forms.Button btnRunWebApp;
        private System.Windows.Forms.TextBox textBox2;
    }
}

