using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace SignalProcessing
{
    public class Graph
    {

        /**
         * PlotGraph
         * 概要：グラフ描画
         * 引数：picture　    グラフを描画するPictureBox
         *       data　　  　 グラフ描画の対象データ
         *       windowLen 　 windowLength
         *       samplengFreq サンプリング周波数
         *       0 -> 時間軸グラフの描画
         *       other -> コンボボックスから取得したサンプリング周波数値
         * 戻り値：なし
         */

        private void PlotGraph(PictureBox picture, double[] data, int windowLen, double samplingFreq, int flag)
        {
            Graphics g;
            Font myFont;
            int i, xZero, yZero, xMin, yMin, xMax, yMax, scale;
            float xStep, yStep;
            String xLabel = "";
            String yMaxLabel = "";
            String yMinLabel = "";
            String xScaleLabel = "";
            float dataMax = 0;
            float dataMin = 0;

            xMin = 20;
            xMax = picture.Width - 20;
            yMax = 20;
            yMin = picture.Height - 20;

            //spectrogramの場合は中心ではなく下から始める
            if (flag == DataRetention.SPECTRO) { yZero = yMin; }
            else { yZero = (yMax + yMin) / 2; }
            
            xZero = xMin;

            xStep = (float)(xMax - xMin) / (windowLen + 1);
            yStep = 0;
            scale = 0;

            try
            {
                picture.Refresh();
                picture.Image = new Bitmap(picture.Width, picture.Height);
                g = Graphics.FromImage(picture.Image);
                myFont = new Font("Arial", 9);

                for (i = 0; i < windowLen; i++)
                {
                    if (dataMax < data[i]) dataMax = (float)data[i];
                    if (dataMin > data[i]) dataMin = (float)data[i];
                }

                if (System.Math.Abs(dataMax) <= System.Math.Abs(dataMin))
                {
                    yStep = (float)(yMin - yMax) / System.Math.Abs(dataMin) / 2;
                    yMaxLabel = System.Math.Abs(dataMin).ToString();
                    yMinLabel = (-1 * System.Math.Abs(dataMin)).ToString();
                    
                }
                else
                {
                    yStep = (float)(yMin - yMax) / System.Math.Abs(dataMax) / 2;

                    yMaxLabel = System.Math.Abs(dataMax).ToString();
                    yMinLabel = (-1 * System.Math.Abs(dataMax)).ToString();

                }

                //spectrogramの場合のy軸はx軸と同じ？
                if (flag == DataRetention.SPECTRO)
                {
                    yMaxLabel = windowLen.ToString();
                    yMinLabel = "0";
                    yStep = (float)(yMax - yMin) / (windowLen + 1);
                }

                g.DrawString("0", myFont, Pens.Black.Brush, xZero - 20, yZero - 2);

                g.DrawLine(Pens.Black, xMin, yZero, xMax, yZero); // x軸
                g.DrawLine(Pens.Black, xZero, yMin, xZero, yMax); // y軸

                //x軸のラベル
                if (samplingFreq == 0)
                {
                    xLabel = windowLen.ToString();
                    xScaleLabel = System.Convert.ToString(windowLen / 2);
                }
                else
                {
                    xLabel = samplingFreq.ToString();
                    xScaleLabel = System.Convert.ToString((int)samplingFreq / 2);
                }

                g.DrawString(xLabel, myFont, Pens.Black.Brush, xMax - 15, yZero);

                //x軸のメモリ
                scale = (xMax + 20) / 2;
                g.DrawLine(Pens.Black, scale, yZero - 5, scale, yZero + 5);
                g.DrawLine(Pens.Black, xMax, yZero - 5, xMax, yZero + 5);
                g.DrawString(xScaleLabel, myFont, Pens.Black.Brush, scale, yZero);

                //y軸のラベル
                g.DrawString(yMaxLabel, myFont, Pens.Black.Brush, xZero - 20, yMax - 15);
                g.DrawString(yMinLabel, myFont, Pens.Black.Brush, xZero - 20, yMin);

                //y軸のメモリ
                g.DrawLine(Pens.Black, xZero - 2, yMax, xZero + 2, yMax);
                g.DrawLine(Pens.Black, xZero - 2, yMin, xZero + 2, yMin);

                //グラフの描画

                if (flag == DataRetention.SPECTRO)
                {
                    for (i = 1; i < windowLen; i++)
                    {
                        float bottomUp = System.Math.Abs( dataMin );
                        int alpha = (int)( ( ( data[i] + bottomUp ) / (dataMax - dataMin) ) * 255);
                        Pen p = new Pen(Color.FromArgb(alpha, Color.Green));
                        g.DrawLine(p,
                             xZero, yMin + (i - 1) * yStep, xMax, yMin + (i - 1) * yStep);
                    }
                }
                else
                {
                    for (i = 1; i < windowLen; i++)
                    {
                        g.DrawLine(Pens.Green,
                            xZero + (i - 1) * xStep,
                            yZero - (float)data[i - 1] * yStep,
                            xZero + i * xStep,
                            yZero - (float)data[i] * yStep);
                    }
                }

                //Graphicsリソース解放
                g.Dispose(); 

            }
            catch (NullReferenceException)
            {
                //MessageBox.Show("NullReferenceException" + "\r\n\r\n" + "Detail:" + "\r\n\r\n" + e, "Exception");
            }
            catch (OverflowException e)
            {
                MessageBox.Show("OverflowException" + "\r\n\r\n" + "Detail:" + "\r\n\r\n" + e, "Exception");
            }
            catch (IndexOutOfRangeException e)
            {
                MessageBox.Show("IndexOutOfRangeException" + "\r\n\r\n" + "Detail:" + "\r\n\r\n" + e, "Exception");
            }
            catch (Exception e)
            {
                MessageBox.Show("Detail:\r\n\r\n" + e, "Exception");
            }
        }

        /**
         * PlotWaveForm
         * 概要：時間軸のグラフを描画する
         * 引数：timeGraph 時間軸グラフを描画するPictureBox
         *       data      グラフ描画の対象データ
         * 戻り値：なし
         */

        public void PlotWaveForm(PictureBox timeGraph, DataRetention data)
        {
            PlotGraph(timeGraph, data.timeData, data.windowLen, 0, 0);
        }

        /**
         * PlotdBChar
         * 概要：dB軸のグラフを描画する
         * 引数：samplingFreq サンプリング周波数
         *       dbGraph      dB軸グラフを描画するPictureBox
         *       data         グラフ描画対象データ
         * 戻り値：なし
         */

        public void PlotdBChar(double samplingFreq, PictureBox dbGraph, DataRetention data)
        {
            PlotGraph(dbGraph, data.dBData, data.windowLen, samplingFreq, 0);
        }

        /**
         * PlotPhaseChar
         * 概要：位相軸のグラフを描画する
         * 引数：samplingFreq サンプリング周波数
         *       phaseGraph   位相軸グラフを描画するPictureBox
         *       data         グラフ描画の対象データ
         * 戻り値：なし
         */

        public void PlotPhaseChar(double samplingFreq, PictureBox phaseGraph, DataRetention data)
        {
            PlotGraph(phaseGraph, data.phaseData, data.windowLen, samplingFreq,0);
        }

        /**
         * PlotSpectrogram
         * 概要：スペクトログラムを描画する
         * 引数：samplingFreq サンプリング周波数
         *       spectrogram   スペクトログラムを描画するPictureBox
         *       data         グラフ描画の対象データ
         * 戻り値：なし
         */

        public void PlotSpectrogram(double samplingFreq, PictureBox spectrogram, DataRetention data, int flag)
        {
            PlotGraph(spectrogram, data.dBData, data.windowLen, samplingFreq, flag);
        }

    }
}
