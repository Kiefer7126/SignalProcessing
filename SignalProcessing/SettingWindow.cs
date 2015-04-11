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
        private int radioButtonCheck = 3;

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
            
            switch (radioButtonCheck)
            {
                case 1:
                    this.radioButton1.Checked = true;
                    break;

                case 2:
                    this.radioButton2.Checked = true;
                    break;

                case 3:
                    this.radioButton3.Checked = true;
                    break;

                case 4:
                    this.radioButton4.Checked = true;
                    break;
                
                default:
                    this.radioButton3.Checked = true;
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
                this.radioButtonCheck = 1;
                this.data.windowLen = Convert.ToInt32(this.radioButton1.Text);

                this.Close();
            }
            else if (this.radioButton2.Checked)
            {
                this.radioButtonCheck = 2;
                this.data.windowLen = Convert.ToInt32(this.radioButton2.Text);

                this.Close();
            }
            else if (this.radioButton3.Checked)
            {
                this.radioButtonCheck = 3;
                this.data.windowLen = Convert.ToInt32(this.radioButton3.Text);

                this.Close();
            }
            else if (this.radioButton4.Checked)
            {
                this.radioButtonCheck = 4;
                this.data.windowLen = Convert.ToInt32(this.radioButton4.Text);

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
