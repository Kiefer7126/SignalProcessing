using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SignalProcessing
{
    class FileWriter
    {
        /*
         * SaveFile
         * 概要：ファイル保存ダイアログを表示する
         * 引数：flag DataRetention.TEXTDATA -> テキストファイル
         * 　　　　　 DataRetention.WAVDATA -> wavファイル
         * 戻り値：string 保存ファイル名
         *         ダイアログがキャンセルされた場合は空文字を返す
         */
        private string SaveFile(int flag)
        {
            string filename = "";
            SaveFileDialog dialog = new SaveFileDialog();

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
                filename = dialog.FileName;
            }

            return filename;
        }

        /*
         * WriteFile
         * 概要：テキスト形式で書き込む
         * 引数：data 対象データ格納用
         *       flag DataRetention.TIMEGRAPH -> 時間軸グラフのデータを書き込む
         * 　　　　　 DataRetention.FREQGRAPH -> 周波数軸グラフのデータを書き込む
         * 戻り値：なし
         */

        public void WriteFile(DataRetention data, int flag)
        {
            string filename = "";

            int i = 0;

            filename = SaveFile(DataRetention.TEXTDATA);

            if (filename == "" || filename == null)
            {
                //スルー
            }
            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        if (flag == DataRetention.TIMEGRAPH)
                        {
                            for (i = 0; i < data.windowLen; i++)
                            {
                                sw.WriteLine(data.timeData[i]);
                            }
                        }
                        else
                        {
                            for (i = 0; i < data.windowLen; i++)
                            {
                                sw.WriteLine(data.dBData[i]);
                            }
                        }
                        sw.Close();
                    }
                }
                catch (Exception e)
                {
                    //例外処理
                }
            }
        }
    }
}
