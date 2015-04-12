using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SignalProcessing
{
    public class FileReader
    {

        /**
         * OpenFile
         * 概要：ファイル読み込みダイアログを表示する
         * 引数：flag DataRetention.TEXTDATA -> テキストファイル
         *            DataRetention.WAVDATA -> wavファイル
         * 戻り値：String 読み込むファイル名
         *         キャンセルされた場合は空文字
         */

        private string OpenFile(int flag)
        {
            string fileName = "";
            OpenFileDialog dialog = new OpenFileDialog();

            if (flag == DataRetention.TEXTDATA)
            {
                dialog.Filter = "テキストファイル(*.txt)|*.txt";
            }
            else
            {
                dialog.Filter = "wavファイル(*.wav)|*.wav";
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;

            }
            return fileName;
        }

        /**
         * ReadFile
         * 概要：テキストファイルを読み込む
         * 引数：data
         * 戻り値：なし
         */

        public void ReadFile(DataRetention data)
        {
            string fileName = "";

            fileName = OpenFile(DataRetention.TEXTDATA);

            if (fileName == "" || fileName == null)
            {
                //処理しない
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        string readData = "";
                        string[] splitData;
                        int i = 0;
                        int j = 0;
                        readData = sr.ReadToEnd();
                        splitData = readData.Split(System.Environment.NewLine.ToCharArray());
                        double[] sample = new double[splitData.Length];
                        for (i = 0; i < splitData.Length; i++)
                        {
                            if (splitData[i] != null && splitData[i] != "")
                            {
                                sample[j] = Convert.ToDouble(splitData[i]);
                                j++;
                            }
                        }

                        data.originalLen = j;
                        data.originalData = new double[j];
                        for (i = 0; i < j; i++)
                        {
                            data.originalData[i] = sample[i];
                        }
                        data.timeData = new double[data.windowLen];
                        for (i = 0; i < data.windowLen; i++)
                        {
                            if (i < data.originalLen)
                            {
                                data.timeData[i] = data.originalData[i];
                            }
                            else
                            {
                                data.timeData[i] = 0.00000;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    MessageBox.Show("IndexOutOfRangeException" + "\r\n\r\n" + "Detail:" + "\r\n\r\n" + e, "Exception");
                }
                catch (FormatException e)
                {
                    MessageBox.Show("FormatException" + "\r\n\r\n" + "Detail:" + "\r\n\r\n" + e, "Exception");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Detail:\r\n\r\n" + e, "Exception");
                }
            }
        }
    }
}
