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
        //wavの書き込み用チャンクデータ
        //16bit,1ch
        //RIFFチャンク
        private byte[] rChunkId = { (byte)'R', (byte)'I', (byte)'F', (byte)'F' };
        private byte[] rFormat = { (byte)'W', (byte)'A', (byte)'V', (byte)'E' };
        //fmtチャンク
        private byte[] fChunkId = { (byte)'f', (byte)'m', (byte)'t', (byte)' ' };
        private int fChunkSize = 16;  //リニアPCM→16(10 00 00 00)
        private short fAudio = 1;     //リニアPCM(01 00)
        private short fCh = 1;        //モノラル(01 00)
        private short fBlockSize = 2; //16bit モノラル→2×1 = 2(02 00)
        private short fBits = 16;     //16bit→16(10 00)
        //dataチャンク
        private byte[] dChunkId = { (byte)'d', (byte)'a', (byte)'t', (byte)'a' };

        /**
         * WriteWavFile
         * 概要：wavファイルを書き込む
         * 引数：samplingFreq サンプリング周波数
         *       data wavデータ格納用
         * 戻り値：なし
         */

        public void WriteWavFile(double samplingFreq, DataRetention data)
        {
            //書き込むファイル名
            string filename = "";
            int i = 0;
            double wavemax = 0.0;

            //ファイルサイズ、データ速度、dataチャンクのサイズ、サンプリング周波数(Hz)
            int rChunkSize, fByteRate, dChunkSize, fSmpf;

            //書き込むファイル名の取得
            filename = SaveFile(DataRetention.WAVDATA);

            if (filename == "" || filename == null)
            {
                //ファイル名が取得されていなければ、処理を続行しない
            }
            else
            {
                try
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fs))
                        {
                            //元データ書き込み
                            /*bw.Write(data.orChunkId);
                            bw.Write(data.orChunkSize);
                            bw.Write(data.orFormat);
                            bw.Write(data.ofChunkId);
                            bw.Write(data.ofChunkSize);
                            bw.Write(data.ofAudio);
                            bw.Write(data.ofCh);
                            bw.Write(data.ofSmpf);
                            bw.Write(data.ofByteRate);
                            bw.Write(data.ofBlockSize);
                            bw.Write(data.ofBits);
                            bw.Write(data.odChunkId);
                            bw.Write(data.odChunkSize);

                            for (i = 0; i < data.odChunkSize / 2; i++)
                            {
                                bw.Write(Convert.ToInt16(data.originalData[i]));
                            }*/


                            //サンプリング周波数をkHzからHzに直す
                            fSmpf = (int)(samplingFreq * 1000);
                            //ファイルサイズの計算(チャンクサイズ[44byte] + windowLength * 2byte - 8)
                            rChunkSize = 44 + (data.windowLen * 2) - 8;
                            //データ速度の計算（サンプリング周波数[Hz]*16bit[2]*モノラル[1]）
                            fByteRate = fSmpf * 2 * 1;
                            //dataチャンクのサイズ(windowLength * 2byte)
                            dChunkSize = data.windowLen * 2;

                            //RIFFチャンク
                            bw.Write(this.rChunkId);
                            bw.Write(rChunkSize);
                            bw.Write(this.rFormat);
                            //fmtチャンク
                            bw.Write(this.fChunkId);
                            bw.Write(this.fChunkSize);
                            bw.Write(this.fAudio);
                            bw.Write(this.fCh);
                            bw.Write(fSmpf);
                            bw.Write(fByteRate);
                            bw.Write(this.fBlockSize);
                            bw.Write(this.fBits);
                            //dataチャンク
                            bw.Write(this.dChunkId);
                            bw.Write(dChunkSize);

                            /* wavemax を32000になるようにする　*/
                            for (i = 0; i < dChunkSize / 2; i++)
                            {
                                if (wavemax < Math.Abs(data.timeData[i]))
                                {
                                    wavemax = Math.Abs(data.timeData[i]);
                                }
                            }
                            for (i = 0; i < dChunkSize / 2; i++)
                            {
                                bw.Write(Convert.ToInt16(data.timeData[i] / wavemax * 32767));
                            }

                            bw.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    //例外処理
                }
            }
        }

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
