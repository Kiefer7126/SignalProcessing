using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalProcessing
{
    public partial class SettingWindow : Form
    {
        public DataRetention data;
        private string windowLenRadioButtonCheck = "1024";
        private string shiftLenRadioButtonCheck = "128";
        private string sigmaRadioButtonCheck = "1.0";

        /**
         * コンストラクタ
         * 概要：設定ダイアログの生成と値設定
         * 引数：data DataRetentionクラスのオブジェクト
         * 
         * WindowLengthのデフォルト値を取得
         * 
         */

        public SettingWindow(DataRetention data)
        {
            this.data = data;            
            InitializeComponent();

            switch (windowLenRadioButtonCheck)
            {
                case "64":
                    this.radioButton1.Checked = true;
                    break;

                case "256":
                    this.radioButton2.Checked = true;
                    break;

                case "1024":
                    this.radioButton3.Checked = true;
                    break;

                case "4096":
                    this.radioButton4.Checked = true;
                    break;
                
                default:
                    this.radioButton3.Checked = true;
                    break;
            }

            switch (shiftLenRadioButtonCheck)
            {
                case "32":
                    this.radioButton5.Checked = true;
                    break;

                case "128":
                    this.radioButton6.Checked = true;
                    break;

                case "512":
                    this.radioButton7.Checked = true;
                    break;

                case "2048":
                    this.radioButton8.Checked = true;
                    break;

                default:
                    this.radioButton6.Checked = true;
                    break;
            }

            switch (sigmaRadioButtonCheck)
            {
                case "0.5":
                    this.radioButton9.Checked = true;
                    break;

                case "1.0":
                    this.radioButton10.Checked = true;
                    break;

                case "2.0":
                    this.radioButton11.Checked = true;
                    break;

                case "4.0":
                    this.radioButton12.Checked = true;
                    break;

                default:
                    this.radioButton10.Checked = true;
                    break;
            }
        }

        /**
         * okButton_Click
         * 概要：設定ダイアログでOKボタンが押下
         * 引数：sender
         *         e 
         * 戻り値：なし        
         * 
         */

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.windowLenRadioButtonCheck = this.radioButton1.Text;
                this.data.windowLen = Convert.ToInt32(this.radioButton1.Text);

                this.Close();
            }
            else if (this.radioButton2.Checked)
            {
                this.windowLenRadioButtonCheck = this.radioButton2.Text;
                this.data.windowLen = Convert.ToInt32(this.radioButton2.Text);

                this.Close();
            }
            else if (this.radioButton3.Checked)
            {
                this.windowLenRadioButtonCheck = this.radioButton3.Text;
                this.data.windowLen = Convert.ToInt32(this.radioButton3.Text);

                this.Close();
            }
            else if (this.radioButton4.Checked)
            {
                this.windowLenRadioButtonCheck = this.radioButton4.Text;
                this.data.windowLen = Convert.ToInt32(this.radioButton4.Text);

                this.Close();
            }
           
            if (this.radioButton5.Checked)
            {
                this.windowLenRadioButtonCheck = this.radioButton5.Text;
                this.data.shiftLen = Convert.ToInt32(this.radioButton5.Text);

                this.Close();
            }
            else if (this.radioButton6.Checked)
            {
                this.windowLenRadioButtonCheck = this.radioButton6.Text;
                this.data.shiftLen = Convert.ToInt32(this.radioButton6.Text);

                this.Close();
            }
            else if (this.radioButton7.Checked)
            {
                this.windowLenRadioButtonCheck = this.radioButton7.Text;
                this.data.shiftLen = Convert.ToInt32(this.radioButton7.Text);

                this.Close();
            }
            else if (this.radioButton8.Checked)
            {
                this.windowLenRadioButtonCheck = this.radioButton8.Text;
                this.data.shiftLen = Convert.ToInt32(this.radioButton8.Text);

                this.Close();
            }

            if (this.radioButton9.Checked)
            {
                this.sigmaRadioButtonCheck = this.radioButton9.Text;
                this.data.sigma = Convert.ToDouble(this.radioButton9.Text);

                this.Close();
            }
            else if (this.radioButton10.Checked)
            {
                this.sigmaRadioButtonCheck = this.radioButton10.Text;
                this.data.sigma = Convert.ToDouble(this.radioButton10.Text);

                this.Close();
            }
            else if (this.radioButton11.Checked)
            {
                this.sigmaRadioButtonCheck = this.radioButton11.Text;
                this.data.sigma = Convert.ToDouble(this.radioButton11.Text);

                this.Close();
            }
            else if (this.radioButton12.Checked)
            {
                this.sigmaRadioButtonCheck = this.radioButton12.Text;
                this.data.sigma = Convert.ToDouble(this.radioButton12.Text);

                this.Close();
            }

            else
            {
                MessageBox.Show("Set WindowLength.");
            }
        }

        /**
        * cancelButton_Click
        * 概要：設定ダイアログでCancelボタンが押下
        * 引数：sender
        *         e 
        * 戻り値：なし        
        * 
        */

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
