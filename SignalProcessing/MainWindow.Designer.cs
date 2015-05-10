namespace SignalProcessing
{
    partial class MainWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timeGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wavToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iFFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hammingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hanningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.samplingComboBox = new System.Windows.Forms.ComboBox();
            this.samplingLabel = new System.Windows.Forms.Label();
            this.timeGraphPictureBox = new System.Windows.Forms.PictureBox();
            this.dBGraphPictureBox = new System.Windows.Forms.PictureBox();
            this.phaseGraphPictureBox = new System.Windows.Forms.PictureBox();
            this.timeGraphLabel = new System.Windows.Forms.Label();
            this.dBGraphLabel = new System.Windows.Forms.Label();
            this.phaseGraphLabel = new System.Windows.Forms.Label();
            this.spectrogramPictureBox = new System.Windows.Forms.PictureBox();
            this.spectrogramLabel = new System.Windows.Forms.Label();
            this.waveKindComboBox = new System.Windows.Forms.ComboBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeGraphPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBGraphPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phaseGraphPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spectrogramPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.frequencyToolStripMenuItem,
            this.filterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.wavToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // wavToolStripMenuItem
            // 
            this.wavToolStripMenuItem.Name = "wavToolStripMenuItem";
            this.wavToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.wavToolStripMenuItem.Text = "Wav";
            this.wavToolStripMenuItem.Click += new System.EventHandler(this.wavToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem1,
            this.wavToolStripMenuItem1});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // textToolStripMenuItem1
            // 
            this.textToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeGraphToolStripMenuItem,
            this.dBGraphToolStripMenuItem});
            this.textToolStripMenuItem1.Name = "textToolStripMenuItem1";
            this.textToolStripMenuItem1.Size = new System.Drawing.Size(97, 22);
            this.textToolStripMenuItem1.Text = "Text";
            // 
            // timeGraphToolStripMenuItem
            // 
            this.timeGraphToolStripMenuItem.Name = "timeGraphToolStripMenuItem";
            this.timeGraphToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.timeGraphToolStripMenuItem.Text = "TimeGraph";
            this.timeGraphToolStripMenuItem.Click += new System.EventHandler(this.timeGraphToolStripMenuItem_Click);
            // 
            // dBGraphToolStripMenuItem
            // 
            this.dBGraphToolStripMenuItem.Name = "dBGraphToolStripMenuItem";
            this.dBGraphToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.dBGraphToolStripMenuItem.Text = "dBGraph";
            this.dBGraphToolStripMenuItem.Click += new System.EventHandler(this.dBGraphToolStripMenuItem_Click);
            // 
            // wavToolStripMenuItem1
            // 
            this.wavToolStripMenuItem1.Name = "wavToolStripMenuItem1";
            this.wavToolStripMenuItem1.Size = new System.Drawing.Size(97, 22);
            this.wavToolStripMenuItem1.Text = "Wav";
            this.wavToolStripMenuItem1.Click += new System.EventHandler(this.wavToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // frequencyToolStripMenuItem
            // 
            this.frequencyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dFTToolStripMenuItem,
            this.fFTToolStripMenuItem,
            this.iDFTToolStripMenuItem,
            this.iFFTToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.frequencyToolStripMenuItem.Name = "frequencyToolStripMenuItem";
            this.frequencyToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.frequencyToolStripMenuItem.Text = "Frequency";
            // 
            // dFTToolStripMenuItem
            // 
            this.dFTToolStripMenuItem.Name = "dFTToolStripMenuItem";
            this.dFTToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.dFTToolStripMenuItem.Text = "DFT";
            this.dFTToolStripMenuItem.Click += new System.EventHandler(this.dFTToolStripMenuItem_Click);
            // 
            // fFTToolStripMenuItem
            // 
            this.fFTToolStripMenuItem.Name = "fFTToolStripMenuItem";
            this.fFTToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.fFTToolStripMenuItem.Text = "FFT";
            // 
            // iDFTToolStripMenuItem
            // 
            this.iDFTToolStripMenuItem.Name = "iDFTToolStripMenuItem";
            this.iDFTToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.iDFTToolStripMenuItem.Text = "IDFT";
            // 
            // iFFTToolStripMenuItem
            // 
            this.iFFTToolStripMenuItem.Name = "iFFTToolStripMenuItem";
            this.iFFTToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.iFFTToolStripMenuItem.Text = "IFFT";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hammingToolStripMenuItem,
            this.hanningToolStripMenuItem,
            this.gaussianToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // hammingToolStripMenuItem
            // 
            this.hammingToolStripMenuItem.Name = "hammingToolStripMenuItem";
            this.hammingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hammingToolStripMenuItem.Text = "Hamming";
            this.hammingToolStripMenuItem.Click += new System.EventHandler(this.hammingToolStripMenuItem_Click);
            // 
            // hanningToolStripMenuItem
            // 
            this.hanningToolStripMenuItem.Name = "hanningToolStripMenuItem";
            this.hanningToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hanningToolStripMenuItem.Text = "Hanning";
            this.hanningToolStripMenuItem.Click += new System.EventHandler(this.hanningToolStripMenuItem_Click);
            // 
            // gaussianToolStripMenuItem
            // 
            this.gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            this.gaussianToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gaussianToolStripMenuItem.Text = "Gaussian";
            this.gaussianToolStripMenuItem.Click += new System.EventHandler(this.gaussianToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIRToolStripMenuItem,
            this.iIRToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // fIRToolStripMenuItem
            // 
            this.fIRToolStripMenuItem.Name = "fIRToolStripMenuItem";
            this.fIRToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.fIRToolStripMenuItem.Text = "FIR";
            // 
            // iIRToolStripMenuItem
            // 
            this.iIRToolStripMenuItem.Name = "iIRToolStripMenuItem";
            this.iIRToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.iIRToolStripMenuItem.Text = "IIR";
            // 
            // samplingComboBox
            // 
            this.samplingComboBox.FormattingEnabled = true;
            this.samplingComboBox.Items.AddRange(new object[] {
            "8",
            "11.025",
            "16",
            "22.05",
            "44.1"});
            this.samplingComboBox.Location = new System.Drawing.Point(697, 31);
            this.samplingComboBox.Name = "samplingComboBox";
            this.samplingComboBox.Size = new System.Drawing.Size(121, 20);
            this.samplingComboBox.TabIndex = 1;
            this.samplingComboBox.SelectedIndexChanged += new System.EventHandler(this.samplingComboBox_SelectedIndexChanged);
            // 
            // samplingLabel
            // 
            this.samplingLabel.AutoSize = true;
            this.samplingLabel.Location = new System.Drawing.Point(583, 34);
            this.samplingLabel.Name = "samplingLabel";
            this.samplingLabel.Size = new System.Drawing.Size(108, 12);
            this.samplingLabel.TabIndex = 2;
            this.samplingLabel.Text = "Sampling Frequency";
            // 
            // timeGraphPictureBox
            // 
            this.timeGraphPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.timeGraphPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timeGraphPictureBox.Location = new System.Drawing.Point(23, 69);
            this.timeGraphPictureBox.Name = "timeGraphPictureBox";
            this.timeGraphPictureBox.Size = new System.Drawing.Size(360, 180);
            this.timeGraphPictureBox.TabIndex = 3;
            this.timeGraphPictureBox.TabStop = false;
            // 
            // dBGraphPictureBox
            // 
            this.dBGraphPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.dBGraphPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dBGraphPictureBox.Location = new System.Drawing.Point(23, 278);
            this.dBGraphPictureBox.Name = "dBGraphPictureBox";
            this.dBGraphPictureBox.Size = new System.Drawing.Size(360, 180);
            this.dBGraphPictureBox.TabIndex = 4;
            this.dBGraphPictureBox.TabStop = false;
            // 
            // phaseGraphPictureBox
            // 
            this.phaseGraphPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.phaseGraphPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.phaseGraphPictureBox.Location = new System.Drawing.Point(23, 489);
            this.phaseGraphPictureBox.Name = "phaseGraphPictureBox";
            this.phaseGraphPictureBox.Size = new System.Drawing.Size(360, 180);
            this.phaseGraphPictureBox.TabIndex = 5;
            this.phaseGraphPictureBox.TabStop = false;
            // 
            // timeGraphLabel
            // 
            this.timeGraphLabel.AutoSize = true;
            this.timeGraphLabel.Location = new System.Drawing.Point(23, 51);
            this.timeGraphLabel.Name = "timeGraphLabel";
            this.timeGraphLabel.Size = new System.Drawing.Size(30, 12);
            this.timeGraphLabel.TabIndex = 6;
            this.timeGraphLabel.Text = "Time";
            // 
            // dBGraphLabel
            // 
            this.dBGraphLabel.AutoSize = true;
            this.dBGraphLabel.Location = new System.Drawing.Point(23, 263);
            this.dBGraphLabel.Name = "dBGraphLabel";
            this.dBGraphLabel.Size = new System.Drawing.Size(19, 12);
            this.dBGraphLabel.TabIndex = 7;
            this.dBGraphLabel.Text = "dB";
            // 
            // phaseGraphLabel
            // 
            this.phaseGraphLabel.AutoSize = true;
            this.phaseGraphLabel.Location = new System.Drawing.Point(23, 474);
            this.phaseGraphLabel.Name = "phaseGraphLabel";
            this.phaseGraphLabel.Size = new System.Drawing.Size(36, 12);
            this.phaseGraphLabel.TabIndex = 8;
            this.phaseGraphLabel.Text = "Phase";
            // 
            // spectrogramPictureBox
            // 
            this.spectrogramPictureBox.BackColor = System.Drawing.Color.Black;
            this.spectrogramPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spectrogramPictureBox.Location = new System.Drawing.Point(407, 69);
            this.spectrogramPictureBox.Name = "spectrogramPictureBox";
            this.spectrogramPictureBox.Size = new System.Drawing.Size(411, 600);
            this.spectrogramPictureBox.TabIndex = 9;
            this.spectrogramPictureBox.TabStop = false;
            // 
            // spectrogramLabel
            // 
            this.spectrogramLabel.AutoSize = true;
            this.spectrogramLabel.Location = new System.Drawing.Point(405, 51);
            this.spectrogramLabel.Name = "spectrogramLabel";
            this.spectrogramLabel.Size = new System.Drawing.Size(69, 12);
            this.spectrogramLabel.TabIndex = 10;
            this.spectrogramLabel.Text = "Spectrogram";
            // 
            // waveKindComboBox
            // 
            this.waveKindComboBox.FormattingEnabled = true;
            this.waveKindComboBox.Items.AddRange(new object[] {
            "Sine",
            "Saw",
            "Square"});
            this.waveKindComboBox.Location = new System.Drawing.Point(23, 26);
            this.waveKindComboBox.Name = "waveKindComboBox";
            this.waveKindComboBox.Size = new System.Drawing.Size(121, 20);
            this.waveKindComboBox.TabIndex = 11;
            this.waveKindComboBox.SelectedIndexChanged += new System.EventHandler(this.waveKindComboBox_SelectedIndexChanged);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(150, 25);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 12;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(830, 681);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.waveKindComboBox);
            this.Controls.Add(this.spectrogramLabel);
            this.Controls.Add(this.spectrogramPictureBox);
            this.Controls.Add(this.phaseGraphLabel);
            this.Controls.Add(this.dBGraphLabel);
            this.Controls.Add(this.timeGraphLabel);
            this.Controls.Add(this.phaseGraphPictureBox);
            this.Controls.Add(this.dBGraphPictureBox);
            this.Controls.Add(this.timeGraphPictureBox);
            this.Controls.Add(this.samplingLabel);
            this.Controls.Add(this.samplingComboBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "SignalProcessing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeGraphPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBGraphPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phaseGraphPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spectrogramPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wavToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem timeGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wavToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dFTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDFTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iFFTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hammingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hanningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fIRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iIRToolStripMenuItem;
        private System.Windows.Forms.ComboBox samplingComboBox;
        private System.Windows.Forms.Label samplingLabel;
        private System.Windows.Forms.PictureBox timeGraphPictureBox;
        private System.Windows.Forms.PictureBox dBGraphPictureBox;
        private System.Windows.Forms.PictureBox phaseGraphPictureBox;
        private System.Windows.Forms.Label timeGraphLabel;
        private System.Windows.Forms.Label dBGraphLabel;
        private System.Windows.Forms.Label phaseGraphLabel;
        private System.Windows.Forms.PictureBox spectrogramPictureBox;
        private System.Windows.Forms.Label spectrogramLabel;
        private System.Windows.Forms.ComboBox waveKindComboBox;
        private System.Windows.Forms.Button generateButton;
    }
}

