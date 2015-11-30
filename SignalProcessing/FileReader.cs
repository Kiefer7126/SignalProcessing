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
         * ReadTextFile
         * 概要：テキストファイルを読み込む
         * @param data
         * @return なし
         */

        public void ReadTextFile(DataRetention data)
        {
            string loadFileName = "";

            loadFileName = OpenFileDialog(DataRetention.TEXTDATA);

            if (loadFileName == "" || loadFileName == null)
            {
                //Do nothing
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader(loadFileName))
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
                    String errorMessage = e.ToString();
                    Debug.ShowMessage("IndexOutOfRangeException", errorMessage);
                }
                catch (FormatException e)
                {
                    String errorMessage = e.ToString();
                    Debug.ShowMessage("FormatException", errorMessage);
                }
                catch (Exception e)
                {
                    String errorMessage = e.ToString();
                    Debug.ShowMessage("NewException", errorMessage); 
                }
            }
        }

        /**
         * ReadMetricalStructure
         * 概要：テキストファイルを読み込む
         * @param data
         * @return なし
         */

        public void ReadMetricalStructure(DataRetention data)
        {
            string loadFileName = "";

            loadFileName = OpenFileDialog(DataRetention.TEXTDATA);
            
            if (loadFileName == "" || loadFileName == null)
            {
                //Do nothing
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader(loadFileName))
                    {
                        
                        string readData = "";
                        string[] splitData;
                        string[] splitElement;
                        int i = 0;
                        int j = 0;
                        readData = sr.ReadToEnd();
                        splitData = readData.Split(System.Environment.NewLine.ToCharArray());
                                                
                        data.metricalData = new int[splitData.Length-1, 3];

                        for (i = 0; i < splitData.Length - 1; i++)
                        {
                            //System.Diagnostics.Debug.WriteLine(splitData[i]);
                            splitElement = splitData[i].Split("\t".ToCharArray());
                                                        
                            for (j = 0; j < splitElement.Length; j++)
                            {
                                //System.Diagnostics.Debug.WriteLine(splitElement[j]);
                                //splitElement[j] = splitElement[j].Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("\0", "").Replace("\b", "").Replace(System.Environment.NewLine, "");
                                data.metricalData[i, j] = Convert.ToInt32(splitElement[j]);
                            }
                             
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    String errorMessage = e.ToString();
                    Debug.ShowMessage("IndexOutOfRangeException", errorMessage);
                }
                catch (FormatException e)
                {
                    String errorMessage = e.ToString();
                    Debug.ShowMessage("FormatException", errorMessage);
                }
                catch (Exception e)
                {
                    String errorMessage = e.ToString();
                    Debug.ShowMessage("NewException", errorMessage);
                }
            }
        }

        /**
         * ReadWavFile
         * 概要：wavファイルを読み込む
         * @param data wavデータ格納用
         * @return なし
         */

        public void ReadWavFile(DataRetention data) 
        {
            string loadFileName = "";
            int i = 0;

            loadFileName = OpenFileDialog(DataRetention.WAVDATA);

            if (loadFileName == "" || loadFileName == null) 
            {
               //Do nothing
            }
            else 
            {
                try 
                {
                    using (FileStream fs = new FileStream(loadFileName, FileMode.Open, FileAccess.Read)) 
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            //指定したファイルからwavデータを読み込む
                            //データ長だけ読み込み、指定の形式に変換する
                            data.orChunkId = br.ReadBytes(4);
                            data.orChunkSize = br.ReadInt32();
                            data.orFormat = br.ReadBytes(4);
                            data.ofChunkId = br.ReadBytes(4);
                            data.ofChunkSize = br.ReadInt32();
                            data.ofAudio = br.ReadInt16();
                            data.ofCh = br.ReadInt16();
                            data.ofSmpf = br.ReadInt32();
                            data.ofByteRate = br.ReadInt32();  //データ速度( B / sec)
                            data.ofBlockSize = br.ReadInt16();
                            data.ofBits = br.ReadInt16();      //サンプルあたりのビット数( bit / sample )
                            data.odChunkId = br.ReadBytes(4);
                            data.odChunkSize = br.ReadInt32(); //波形データのバイト数 

                            //データのサンプル数
                            data.originalLen = data.odChunkSize / (data.ofBits / 8);

                            //データのサンプル数を時間変換(RLで標本化一回のためofChで除算する)
                            data.originalTime_s = (float)data.originalLen / (float)data.ofSmpf / (float)data.ofCh; 

                            data.originalData = new double[data.originalLen];

                            data.msPerSampling = (float)data.ofBits * 1000 / 8 / (float)data.ofByteRate;

                            //Debug
                            System.Diagnostics.Debug.WriteLine("Time / Sample [ms] = " + data.msPerSampling);
                            System.Diagnostics.Debug.WriteLine("originalLen = " + data.originalLen);
                            System.Diagnostics.Debug.WriteLine("originalTime_s = " + data.originalTime_s);
                            
                           
                            System.Diagnostics.Debug.WriteLine("orChunkId = " + data.orChunkId);
                            System.Diagnostics.Debug.WriteLine("orChunkSize = " + data.orChunkSize);
                            System.Diagnostics.Debug.WriteLine("orForma = " + data.orFormat);
                            System.Diagnostics.Debug.WriteLine("ofChunkId = " + data.ofChunkId);
                            System.Diagnostics.Debug.WriteLine("ofChunkSize = " + data.ofChunkSize);
                            System.Diagnostics.Debug.WriteLine("ofAudio = " + data.ofAudio);
                            System.Diagnostics.Debug.WriteLine("ofCh = " + data.ofCh);
                            System.Diagnostics.Debug.WriteLine("ofSmpf = " + data.ofSmpf);
                            System.Diagnostics.Debug.WriteLine("ofByteRate = " + data.ofByteRate);
                            System.Diagnostics.Debug.WriteLine("ofBlockSize = " + data.ofBlockSize);
                            System.Diagnostics.Debug.WriteLine("ofBits = " + data.ofBits);
                            System.Diagnostics.Debug.WriteLine("odChunkId = " + data.odChunkId);
                            System.Diagnostics.Debug.WriteLine("odChunkSize = " + data.odChunkSize);


                            //ステレオファイルはRLRL…の順に入っているので一つ飛ばしで読み込む？
                            for (i = 0; i < data.originalLen ; i = i + 1)
                            {
                                data.originalData[i] = Convert.ToDouble(br.ReadInt16());
                            }

                            //時間軸データ用にオリジナルデータをコピーする
                            data.timeData = new double[data.windowLen];

                            for (i = 0; i < data.windowLen; i++)
                            {
                                //オリジナルデータ数がwindowLengthより少なかったら0を入れる
                                if (i <= data.originalLen)
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
                }
                catch (Exception e)
                {
                    String errorMessage = e.ToString();
                    Debug.ShowMessage("NewException", errorMessage);
                }
            }
        }


        /**
         * OpenFileDialog
         * 概要：ファイル読み込みダイアログを表示する
         * @param flag DataRetention.TEXTDATA -> テキストファイル
         *             DataRetention.WAVDATA -> wavファイル
         * @return String 読み込むファイル名
         *                キャンセルされた場合は空文字
         */

        private string OpenFileDialog(int flag)
        {
            string loadFileName = "";
            OpenFileDialog dialog = new OpenFileDialog();

            //この記述をしないとOSがハングアップする
            dialog.ShowHelp = true;

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
                loadFileName = dialog.FileName;

            }
            return loadFileName;
        }
    }
}
