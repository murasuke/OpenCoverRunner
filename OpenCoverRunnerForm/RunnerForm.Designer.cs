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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtTestTargetExePath = new System.Windows.Forms.TextBox();
            this.btnRunProgram = new System.Windows.Forms.Button();
            this.txtOpernCoverPath = new System.Windows.Forms.TextBox();
            this.txtReportGenerator = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpSetting = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputReportPath = new System.Windows.Forms.TextBox();
            this.btnOpernCoverPath = new System.Windows.Forms.Button();
            this.btnReportGenerator = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpSetting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtTestTargetExePath
            // 
            this.txtTestTargetExePath.AllowDrop = true;
            this.txtTestTargetExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestTargetExePath.Location = new System.Drawing.Point(12, 269);
            this.txtTestTargetExePath.Name = "txtTestTargetExePath";
            this.txtTestTargetExePath.Size = new System.Drawing.Size(746, 19);
            this.txtTestTargetExePath.TabIndex = 0;
            this.txtTestTargetExePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtTestTargetExePath_DragDrop);
            this.txtTestTargetExePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtTestTargetExePath_DragEnter);
            this.txtTestTargetExePath.Leave += new System.EventHandler(this.txtTestTargetExePath_Leave);
            // 
            // btnRunProgram
            // 
            this.btnRunProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunProgram.Location = new System.Drawing.Point(764, 267);
            this.btnRunProgram.Name = "btnRunProgram";
            this.btnRunProgram.Size = new System.Drawing.Size(93, 23);
            this.btnRunProgram.TabIndex = 1;
            this.btnRunProgram.Text = "プログラム実行";
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
            this.txtOpernCoverPath.Size = new System.Drawing.Size(615, 19);
            this.txtOpernCoverPath.TabIndex = 2;
            // 
            // txtReportGenerator
            // 
            this.txtReportGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReportGenerator.Location = new System.Drawing.Point(131, 50);
            this.txtReportGenerator.Name = "txtReportGenerator";
            this.txtReportGenerator.ReadOnly = true;
            this.txtReportGenerator.Size = new System.Drawing.Size(615, 19);
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
            this.grpSetting.Size = new System.Drawing.Size(851, 159);
            this.grpSetting.TabIndex = 5;
            this.grpSetting.TabStop = false;
            this.grpSetting.Text = "パス一覧";
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
            this.txtOutputReportPath.Size = new System.Drawing.Size(615, 19);
            this.txtOutputReportPath.TabIndex = 3;
            // 
            // btnOpernCoverPath
            // 
            this.btnOpernCoverPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpernCoverPath.Location = new System.Drawing.Point(752, 23);
            this.btnOpernCoverPath.Name = "btnOpernCoverPath";
            this.btnOpernCoverPath.Size = new System.Drawing.Size(93, 23);
            this.btnOpernCoverPath.TabIndex = 5;
            this.btnOpernCoverPath.Text = "選択(未)";
            this.btnOpernCoverPath.UseVisualStyleBackColor = true;
            this.btnOpernCoverPath.Click += new System.EventHandler(this.btnOpernCoverPath_Click);
            // 
            // btnReportGenerator
            // 
            this.btnReportGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportGenerator.Location = new System.Drawing.Point(752, 46);
            this.btnReportGenerator.Name = "btnReportGenerator";
            this.btnReportGenerator.Size = new System.Drawing.Size(93, 23);
            this.btnReportGenerator.TabIndex = 5;
            this.btnReportGenerator.Text = "選択(未)";
            this.btnReportGenerator.UseVisualStyleBackColor = true;
            this.btnReportGenerator.Click += new System.EventHandler(this.btnReportGenerator_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(473, 36);
            this.label4.TabIndex = 4;
            this.label4.Text = "テスト対象のプログラムパスを入力(Drag && Drop可能)。\r\n「プログラム実行」ボタン押下でプログラムが起動するので、単体テスト(手動テスト)を実施してく" +
    "ださい。\r\nプログラムを終了すると、カバレッジに関するレポートを生成します。";
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOutput.Location = new System.Drawing.Point(752, 104);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(93, 34);
            this.btnClearOutput.TabIndex = 5;
            this.btnClearOutput.Text = "前回のレポート削除";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(753, 36);
            this.label7.TabIndex = 4;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(845, 133);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "今後の機能追加メモ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(747, 72);
            this.label8.TabIndex = 0;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // RunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpSetting);
            this.Controls.Add(this.btnRunProgram);
            this.Controls.Add(this.txtTestTargetExePath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Name = "RunnerForm";
            this.Text = "OpenCoverRunnerForm";
            this.Load += new System.EventHandler(this.RunnerForm_Load);
            this.grpSetting.ResumeLayout(false);
            this.grpSetting.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
    }
}

