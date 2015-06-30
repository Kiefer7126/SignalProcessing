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
        private string windowLenRadioButtonCheck = "2048";
        private string shiftLenRadioButtonCheck = "512";
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
                    this.windowRadioButton1.Checked = true;
                    break;

                case "256":
                    this.windowRadioButton2.Checked = true;
                    break;

                case "1024":
                    this.windowRadioButton3.Checked = true;
                    break;

                case "2048":
                    this.windowRadioButton4.Checked = true;
                    break;

                case "4096":
                    this.windowRadioButton5.Checked = true;
                    break;
                
                default:
                    this.windowRadioButton4.Checked = true;
                    break;
            }

            switch (shiftLenRadioButtonCheck)
            {
                case "32":
                    this.shiftRadioButton1.Checked = true;
                    break;

                case "128":
                    this.shiftRadioButton2.Checked = true;
                    break;

                case "512":
                    this.shiftRadioButton3.Checked = true;
                    break;

                case "1024":
                    this.shiftRadioButton4.Checked = true;
                    break;

                case "2048":
                    this.shiftRadioButton5.Checked = true;
                    break;

                default:
                    this.shiftRadioButton3.Checked = true;
                    break;
            }

            switch (sigmaRadioButtonCheck)
            {
                case "0.5":
                    this.sigmaRadioButton1.Checked = true;
                    break;

                case "1.0":
                    this.sigmaRadioButton2.Checked = true;
                    break;

                case "2.0":
                    this.sigmaRadioButton3.Checked = true;
                    break;

                case "4.0":
                    this.sigmaRadioButton4.Checked = true;
                    break;

                case "8.0":
                    this.sigmaRadioButton5.Checked = true;
                    break;

                default:
                    this.sigmaRadioButton2.Checked = true;
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
            if (this.windowRadioButton1.Checked)
            {
                this.windowLenRadioButtonCheck = this.windowRadioButton1.Text;
                this.data.windowLen = Convert.ToInt32(this.windowRadioButton1.Text);

                this.Close();
            }
            else if (this.windowRadioButton2.Checked)
            {
                this.windowLenRadioButtonCheck = this.windowRadioButton2.Text;
                this.data.windowLen = Convert.ToInt32(this.windowRadioButton2.Text);

                this.Close();
            }
            else if (this.windowRadioButton3.Checked)
            {
                this.windowLenRadioButtonCheck = this.windowRadioButton3.Text;
                this.data.windowLen = Convert.ToInt32(this.windowRadioButton3.Text);

                this.Close();
            }
            else if (this.windowRadioButton4.Checked)
            {
                this.windowLenRadioButtonCheck = this.windowRadioButton4.Text;
                this.data.windowLen = Convert.ToInt32(this.windowRadioButton4.Text);

                this.Close();
            }
            else if (this.windowRadioButton5.Checked)
            {
                this.windowLenRadioButtonCheck = this.windowRadioButton5.Text;
                this.data.windowLen = Convert.ToInt32(this.windowRadioButton5.Text);

                this.Close();
            }
           
            if (this.shiftRadioButton5.Checked)
            {
                this.windowLenRadioButtonCheck = this.shiftRadioButton5.Text;
                this.data.shiftLen = Convert.ToInt32(this.shiftRadioButton5.Text);

                this.Close();
            }
            else if (this.shiftRadioButton4.Checked)
            {
                this.windowLenRadioButtonCheck = this.shiftRadioButton4.Text;
                this.data.shiftLen = Convert.ToInt32(this.shiftRadioButton4.Text);

                this.Close();
            }
            else if (this.shiftRadioButton3.Checked)
            {
                this.windowLenRadioButtonCheck = this.shiftRadioButton3.Text;
                this.data.shiftLen = Convert.ToInt32(this.shiftRadioButton3.Text);

                this.Close();
            }
            else if (this.shiftRadioButton2.Checked)
            {
                this.windowLenRadioButtonCheck = this.shiftRadioButton2.Text;
                this.data.shiftLen = Convert.ToInt32(this.shiftRadioButton2.Text);

                this.Close();
            }
            else if (this.shiftRadioButton1.Checked)
            {
                this.windowLenRadioButtonCheck = this.shiftRadioButton1.Text;
                this.data.shiftLen = Convert.ToInt32(this.shiftRadioButton1.Text);

                this.Close();
            }

            if (this.sigmaRadioButton5.Checked)
            {
                this.sigmaRadioButtonCheck = this.sigmaRadioButton5.Text;
                this.data.sigma = Convert.ToDouble(this.sigmaRadioButton5.Text);

                this.Close();
            }
            else if (this.sigmaRadioButton4.Checked)
            {
                this.sigmaRadioButtonCheck = this.sigmaRadioButton4.Text;
                this.data.sigma = Convert.ToDouble(this.sigmaRadioButton4.Text);

                this.Close();
            }
            else if (this.sigmaRadioButton3.Checked)
            {
                this.sigmaRadioButtonCheck = this.sigmaRadioButton3.Text;
                this.data.sigma = Convert.ToDouble(this.sigmaRadioButton3.Text);

                this.Close();
            }
            else if (this.sigmaRadioButton2.Checked)
            {
                this.sigmaRadioButtonCheck = this.sigmaRadioButton2.Text;
                this.data.sigma = Convert.ToDouble(this.sigmaRadioButton2.Text);

                this.Close();
            }
            else if (this.sigmaRadioButton1.Checked)
            {
                this.sigmaRadioButtonCheck = this.sigmaRadioButton1.Text;
                this.data.sigma = Convert.ToDouble(this.sigmaRadioButton1.Text);

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
