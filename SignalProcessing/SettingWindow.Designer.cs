namespace SignalProcessing
{
    partial class SettingWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.winLenGroupBox = new System.Windows.Forms.GroupBox();
            this.windowRadioButton4 = new System.Windows.Forms.RadioButton();
            this.windowRadioButton5 = new System.Windows.Forms.RadioButton();
            this.windowRadioButton3 = new System.Windows.Forms.RadioButton();
            this.windowRadioButton2 = new System.Windows.Forms.RadioButton();
            this.windowRadioButton1 = new System.Windows.Forms.RadioButton();
            this.winLenLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shiftRadioButton4 = new System.Windows.Forms.RadioButton();
            this.shiftRadioButton5 = new System.Windows.Forms.RadioButton();
            this.shiftRadioButton3 = new System.Windows.Forms.RadioButton();
            this.shiftRadioButton2 = new System.Windows.Forms.RadioButton();
            this.shiftRadioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sigmaRadioButton5 = new System.Windows.Forms.RadioButton();
            this.sigmaRadioButton4 = new System.Windows.Forms.RadioButton();
            this.sigmaRadioButton3 = new System.Windows.Forms.RadioButton();
            this.sigmaRadioButton2 = new System.Windows.Forms.RadioButton();
            this.sigmaRadioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.winLenGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // winLenGroupBox
            // 
            this.winLenGroupBox.Controls.Add(this.windowRadioButton4);
            this.winLenGroupBox.Controls.Add(this.windowRadioButton5);
            this.winLenGroupBox.Controls.Add(this.windowRadioButton3);
            this.winLenGroupBox.Controls.Add(this.windowRadioButton2);
            this.winLenGroupBox.Controls.Add(this.windowRadioButton1);
            this.winLenGroupBox.Location = new System.Drawing.Point(12, 30);
            this.winLenGroupBox.Name = "winLenGroupBox";
            this.winLenGroupBox.Size = new System.Drawing.Size(77, 119);
            this.winLenGroupBox.TabIndex = 0;
            this.winLenGroupBox.TabStop = false;
            // 
            // windowRadioButton4
            // 
            this.windowRadioButton4.AutoSize = true;
            this.windowRadioButton4.Location = new System.Drawing.Point(6, 75);
            this.windowRadioButton4.Name = "windowRadioButton4";
            this.windowRadioButton4.Size = new System.Drawing.Size(47, 16);
            this.windowRadioButton4.TabIndex = 4;
            this.windowRadioButton4.TabStop = true;
            this.windowRadioButton4.Text = "2048";
            this.windowRadioButton4.UseVisualStyleBackColor = true;
            // 
            // windowRadioButton5
            // 
            this.windowRadioButton5.AutoSize = true;
            this.windowRadioButton5.Location = new System.Drawing.Point(6, 97);
            this.windowRadioButton5.Name = "windowRadioButton5";
            this.windowRadioButton5.Size = new System.Drawing.Size(47, 16);
            this.windowRadioButton5.TabIndex = 3;
            this.windowRadioButton5.TabStop = true;
            this.windowRadioButton5.Text = "4096";
            this.windowRadioButton5.UseVisualStyleBackColor = true;
            // 
            // windowRadioButton3
            // 
            this.windowRadioButton3.AutoSize = true;
            this.windowRadioButton3.Location = new System.Drawing.Point(7, 53);
            this.windowRadioButton3.Name = "windowRadioButton3";
            this.windowRadioButton3.Size = new System.Drawing.Size(47, 16);
            this.windowRadioButton3.TabIndex = 2;
            this.windowRadioButton3.TabStop = true;
            this.windowRadioButton3.Text = "1024";
            this.windowRadioButton3.UseVisualStyleBackColor = true;
            // 
            // windowRadioButton2
            // 
            this.windowRadioButton2.AutoSize = true;
            this.windowRadioButton2.Location = new System.Drawing.Point(7, 31);
            this.windowRadioButton2.Name = "windowRadioButton2";
            this.windowRadioButton2.Size = new System.Drawing.Size(41, 16);
            this.windowRadioButton2.TabIndex = 1;
            this.windowRadioButton2.TabStop = true;
            this.windowRadioButton2.Text = "256";
            this.windowRadioButton2.UseVisualStyleBackColor = true;
            // 
            // windowRadioButton1
            // 
            this.windowRadioButton1.AutoSize = true;
            this.windowRadioButton1.Location = new System.Drawing.Point(7, 9);
            this.windowRadioButton1.Name = "windowRadioButton1";
            this.windowRadioButton1.Size = new System.Drawing.Size(35, 16);
            this.windowRadioButton1.TabIndex = 0;
            this.windowRadioButton1.TabStop = true;
            this.windowRadioButton1.Text = "64";
            this.windowRadioButton1.UseVisualStyleBackColor = true;
            // 
            // winLenLabel
            // 
            this.winLenLabel.AutoSize = true;
            this.winLenLabel.Location = new System.Drawing.Point(12, 12);
            this.winLenLabel.Name = "winLenLabel";
            this.winLenLabel.Size = new System.Drawing.Size(77, 12);
            this.winLenLabel.TabIndex = 1;
            this.winLenLabel.Text = "WindowLength";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(197, 155);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(116, 155);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shiftRadioButton4);
            this.groupBox1.Controls.Add(this.shiftRadioButton5);
            this.groupBox1.Controls.Add(this.shiftRadioButton3);
            this.groupBox1.Controls.Add(this.shiftRadioButton2);
            this.groupBox1.Controls.Add(this.shiftRadioButton1);
            this.groupBox1.Location = new System.Drawing.Point(95, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(77, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // shiftRadioButton4
            // 
            this.shiftRadioButton4.AutoSize = true;
            this.shiftRadioButton4.Location = new System.Drawing.Point(6, 75);
            this.shiftRadioButton4.Name = "shiftRadioButton4";
            this.shiftRadioButton4.Size = new System.Drawing.Size(47, 16);
            this.shiftRadioButton4.TabIndex = 4;
            this.shiftRadioButton4.TabStop = true;
            this.shiftRadioButton4.Text = "1024";
            this.shiftRadioButton4.UseVisualStyleBackColor = true;
            // 
            // shiftRadioButton5
            // 
            this.shiftRadioButton5.AutoSize = true;
            this.shiftRadioButton5.Location = new System.Drawing.Point(6, 97);
            this.shiftRadioButton5.Name = "shiftRadioButton5";
            this.shiftRadioButton5.Size = new System.Drawing.Size(47, 16);
            this.shiftRadioButton5.TabIndex = 3;
            this.shiftRadioButton5.TabStop = true;
            this.shiftRadioButton5.Text = "2048";
            this.shiftRadioButton5.UseVisualStyleBackColor = true;
            // 
            // shiftRadioButton3
            // 
            this.shiftRadioButton3.AutoSize = true;
            this.shiftRadioButton3.Location = new System.Drawing.Point(7, 53);
            this.shiftRadioButton3.Name = "shiftRadioButton3";
            this.shiftRadioButton3.Size = new System.Drawing.Size(41, 16);
            this.shiftRadioButton3.TabIndex = 2;
            this.shiftRadioButton3.TabStop = true;
            this.shiftRadioButton3.Text = "512";
            this.shiftRadioButton3.UseVisualStyleBackColor = true;
            // 
            // shiftRadioButton2
            // 
            this.shiftRadioButton2.AutoSize = true;
            this.shiftRadioButton2.Location = new System.Drawing.Point(7, 31);
            this.shiftRadioButton2.Name = "shiftRadioButton2";
            this.shiftRadioButton2.Size = new System.Drawing.Size(41, 16);
            this.shiftRadioButton2.TabIndex = 1;
            this.shiftRadioButton2.TabStop = true;
            this.shiftRadioButton2.Text = "128";
            this.shiftRadioButton2.UseVisualStyleBackColor = true;
            // 
            // shiftRadioButton1
            // 
            this.shiftRadioButton1.AutoSize = true;
            this.shiftRadioButton1.Location = new System.Drawing.Point(7, 9);
            this.shiftRadioButton1.Name = "shiftRadioButton1";
            this.shiftRadioButton1.Size = new System.Drawing.Size(35, 16);
            this.shiftRadioButton1.TabIndex = 0;
            this.shiftRadioButton1.TabStop = true;
            this.shiftRadioButton1.Text = "32";
            this.shiftRadioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "ShiftLength";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sigmaRadioButton5);
            this.groupBox2.Controls.Add(this.sigmaRadioButton4);
            this.groupBox2.Controls.Add(this.sigmaRadioButton3);
            this.groupBox2.Controls.Add(this.sigmaRadioButton2);
            this.groupBox2.Controls.Add(this.sigmaRadioButton1);
            this.groupBox2.Location = new System.Drawing.Point(178, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(77, 119);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // sigmaRadioButton5
            // 
            this.sigmaRadioButton5.AutoSize = true;
            this.sigmaRadioButton5.Location = new System.Drawing.Point(7, 97);
            this.sigmaRadioButton5.Name = "sigmaRadioButton5";
            this.sigmaRadioButton5.Size = new System.Drawing.Size(37, 16);
            this.sigmaRadioButton5.TabIndex = 4;
            this.sigmaRadioButton5.TabStop = true;
            this.sigmaRadioButton5.Text = "8.0";
            this.sigmaRadioButton5.UseVisualStyleBackColor = true;
            // 
            // sigmaRadioButton4
            // 
            this.sigmaRadioButton4.AutoSize = true;
            this.sigmaRadioButton4.Location = new System.Drawing.Point(7, 75);
            this.sigmaRadioButton4.Name = "sigmaRadioButton4";
            this.sigmaRadioButton4.Size = new System.Drawing.Size(37, 16);
            this.sigmaRadioButton4.TabIndex = 3;
            this.sigmaRadioButton4.TabStop = true;
            this.sigmaRadioButton4.Text = "4.0";
            this.sigmaRadioButton4.UseVisualStyleBackColor = true;
            // 
            // sigmaRadioButton3
            // 
            this.sigmaRadioButton3.AutoSize = true;
            this.sigmaRadioButton3.Location = new System.Drawing.Point(7, 53);
            this.sigmaRadioButton3.Name = "sigmaRadioButton3";
            this.sigmaRadioButton3.Size = new System.Drawing.Size(37, 16);
            this.sigmaRadioButton3.TabIndex = 2;
            this.sigmaRadioButton3.TabStop = true;
            this.sigmaRadioButton3.Text = "2.0";
            this.sigmaRadioButton3.UseVisualStyleBackColor = true;
            // 
            // sigmaRadioButton2
            // 
            this.sigmaRadioButton2.AutoSize = true;
            this.sigmaRadioButton2.Location = new System.Drawing.Point(7, 31);
            this.sigmaRadioButton2.Name = "sigmaRadioButton2";
            this.sigmaRadioButton2.Size = new System.Drawing.Size(37, 16);
            this.sigmaRadioButton2.TabIndex = 1;
            this.sigmaRadioButton2.TabStop = true;
            this.sigmaRadioButton2.Text = "1.0";
            this.sigmaRadioButton2.UseVisualStyleBackColor = true;
            // 
            // sigmaRadioButton1
            // 
            this.sigmaRadioButton1.AutoSize = true;
            this.sigmaRadioButton1.Location = new System.Drawing.Point(7, 9);
            this.sigmaRadioButton1.Name = "sigmaRadioButton1";
            this.sigmaRadioButton1.Size = new System.Drawing.Size(37, 16);
            this.sigmaRadioButton1.TabIndex = 0;
            this.sigmaRadioButton1.TabStop = true;
            this.sigmaRadioButton1.Text = "0.5";
            this.sigmaRadioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sigma";
            // 
            // SettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 193);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.winLenLabel);
            this.Controls.Add(this.winLenGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingWindow";
            this.Text = "Preferences";
            this.winLenGroupBox.ResumeLayout(false);
            this.winLenGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox winLenGroupBox;
        private System.Windows.Forms.RadioButton windowRadioButton5;
        private System.Windows.Forms.RadioButton windowRadioButton3;
        private System.Windows.Forms.RadioButton windowRadioButton2;
        private System.Windows.Forms.RadioButton windowRadioButton1;
        private System.Windows.Forms.Label winLenLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton shiftRadioButton5;
        private System.Windows.Forms.RadioButton shiftRadioButton3;
        private System.Windows.Forms.RadioButton shiftRadioButton2;
        private System.Windows.Forms.RadioButton shiftRadioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton sigmaRadioButton4;
        private System.Windows.Forms.RadioButton sigmaRadioButton3;
        private System.Windows.Forms.RadioButton sigmaRadioButton2;
        private System.Windows.Forms.RadioButton sigmaRadioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton windowRadioButton4;
        private System.Windows.Forms.RadioButton shiftRadioButton4;
        private System.Windows.Forms.RadioButton sigmaRadioButton5;
    }
}