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
         * @param picture　    グラフを描画するPictureBox
         * @param data　　  　 グラフ描画の対象データ
         * @param windowLen 　 windowLength
         * @param samplengFreq サンプリング周波数
         * @param 0            -> 時間軸グラフの描画
         * @param other        -> コンボボックスから取得したサンプリング周波数値
         * @return なし
         */

        private void PlotGraph(PictureBox picture, double[] data, int windowLen, double samplingFreq)
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

            yZero = (yMax + yMin) / 2;
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

                    for (i = 1; i < windowLen; i++)
                    {
                       g.DrawLine(Pens.Green,
                            xZero + (i - 1) * xStep,
                            yZero - (float)data[i - 1] * yStep,
                            xZero + i * xStep,
                            yZero - (float)data[i] * yStep);
                    }
                //Graphicsリソース解放
                g.Dispose(); 

            }
            catch (NullReferenceException e)
            {
                String errorMessage = e.ToString();
                Debug.ShowMessage("NullReferenceException", errorMessage); 
            }
            catch (OverflowException e)
            {
                String errorMessage = e.ToString();
                Debug.ShowMessage("OverflowException", errorMessage);
            }
            catch (IndexOutOfRangeException e)
            {
                String errorMessage = e.ToString();
                Debug.ShowMessage("IndexOutOfRangeException", errorMessage);
            }
            catch (Exception e)
            {
                String errorMessage = e.ToString();
                Debug.ShowMessage("NewException", errorMessage);
            }
        }

        /**
         * PlotWaveForm
         * 概要：時間軸のグラフを描画する
         * @param timeGraph 時間軸グラフを描画するPictureBox
         * @param data      グラフ描画の対象データ
         * @return なし
         */

        public void PlotWaveForm(PictureBox timeGraph, DataRetention data)
        {
            PlotGraph(timeGraph, data.timeData, data.windowLen, 0);
        }

        /**
         * PlotdBChar
         * 概要：dB軸のグラフを描画する
         * @param samplingFreq サンプリング周波数
         * @param dbGraph      dB軸グラフを描画するPictureBox
         * @param data         グラフ描画対象データ
         * @return なし
         */

        public void PlotdBChar(double samplingFreq, PictureBox dbGraph, DataRetention data)
        {
            PlotGraph(dbGraph, data.dBData, data.windowLen, samplingFreq);
        }

        /**
         * PlotPhaseChar
         * 概要：位相軸のグラフを描画する
         * @param samplingFreq サンプリング周波数
         * @param phaseGraph   位相軸グラフを描画するPictureBox
         * @param data         グラフ描画の対象データ
         * @return なし
         */

        public void PlotPhaseChar(double samplingFreq, PictureBox phaseGraph, DataRetention data)
        {
            PlotGraph(phaseGraph, data.phaseData, data.windowLen, samplingFreq);
        }

        /**
          * PlotLegend
          * 概要：スペクトログラムの凡例を描画する
          * @param picture   凡例を描画するPictureBox
          * @return なし
          */

        public void PlotLegend(PictureBox picture)
        {
            Graphics g;
            Font myFont;
            int i, xZero, yZero, xMax, yMax;
            float xStep, yStep;

            xZero = 0;
            yZero = picture.Height;
            xMax  = picture.Width;
            yMax  = 0;

             try
            {
                
                xStep = 0;
                yStep = (float)picture.Height / (float)1020;

                picture.Refresh();
                picture.Image = new Bitmap(picture.Width, picture.Height);
                g = Graphics.FromImage(picture.Image);
                myFont = new Font("Arial", 9);

                int hsv;
                    int red = 0;
                    int green = 0;
                    int brue = 255;


                        for (i = 0; i <= 1024; i++)
                        {

                            hsv = i;

                            switch (hsv / 255)
                            {
                                case 0:
                                    red = 0;
                                    green = 0 + (hsv % 255);
                                    brue = 255;
                                    break;

                                case 1:
                                    red = 0;
                                    green = 255;
                                    brue = 255 - (hsv % 255);
                                    break;

                                case 2:
                                    red = 0 + (hsv % 255);
                                    green = 255;
                                    brue = 0;
                                    break;

                                case 3:
                                    red = 255;
                                    green = 255 - (hsv % 255);
                                    brue = 0;
                                    break;

                            }

                            Pen p = new Pen(Color.FromArgb(red, green, brue), 1);

                             
                            g.DrawLine(p,
                                 (float)(xZero),
                                 (float)(yZero - i * yStep),
                                 (float)(xMax),
                                 (float)(yZero - i * yStep));
                    }
                    //Graphicsリソース解放
                    g.Dispose();

            }
             catch (NullReferenceException e)
             {
                 String errorMessage = e.ToString();
                 Debug.ShowMessage("NullReferenceException", errorMessage);
             }
             catch (OverflowException e)
             {
                 String errorMessage = e.ToString();
                 Debug.ShowMessage("OverflowException", errorMessage);
             }
             catch (IndexOutOfRangeException e)
             {
                 String errorMessage = e.ToString();
                 Debug.ShowMessage("IndexOutOfRangeException", errorMessage);
             }
             catch (Exception e)
             {
                 String errorMessage = e.ToString();
                 Debug.ShowMessage("NewException", errorMessage);
             }

        }

        /**
         * PlotSpectrogram
         * 概要：スペクトログラムを描画する
         * @param samplingFreq サンプリング周波数
         * @param spectrogram   スペクトログラムを描画するPictureBox
         * @param data         グラフ描画の対象データ
         * @return なし
         */

        public void PlotSpectrogram(double samplingFreq, PictureBox picture, DataRetention data)
        {

            Graphics g;
            Font myFont;
            int i, time, numberOfWindow, xZero, yZero, xMax, yMax;
            int margin = 40;
            int gramWidth  = picture.Width  - margin * 2;
            int gramHeight = picture.Height - margin * 2;
            int penSize = 15; //太くすると周波数が少ないときでも隙間なく描画される
            
            float xStep, yStep;
            float dataMax = 0;
            float dataMin = 0;

            String xLabel = "[ ms ]";
            String yLabel = "[ Hz ]";
            String xScaleLabel = ""; 
            String yScaleLabel = "";

            try
            {
                xZero = margin;
                yZero = picture.Height - margin;
                xMax  = picture.Width  - margin;
                yMax  = margin;

                numberOfWindow = data.originalLen / data.windowLen;
                xStep = (float)gramWidth / (float)(numberOfWindow);
                yStep = System.Math.Abs((float)gramHeight * 2 / data.windowLen);
                

                picture.Refresh();
                picture.Image = new Bitmap(picture.Width, picture.Height);
                g = Graphics.FromImage(picture.Image);
                myFont = new Font("Arial", 9);

                //x軸のラベル
                if (samplingFreq == 0)
                {
                    //xLabel = data.windowLen.ToString();
                    xScaleLabel = System.Convert.ToString(data.windowLen / 2);
                }
                else
                {
                    //xLabel = samplingFreq.ToString();
                    xScaleLabel = System.Convert.ToString((int)samplingFreq / 2);
                }

                g.DrawString(xLabel, myFont, Pens.Black.Brush, picture.Width / 2, yZero + (margin / 3) );



                //グラフの描画

                    int hsv;
                    int red = 0;
                    int green = 0;
                    int brue = 255;

                    for (time = 0; time < numberOfWindow ; time++)
                    {

                        for (i = 0; i <= data.windowLen / 2; i++)
                        {
                            if (dataMax < data.stftData[time, i]) dataMax = (float)data.stftData[time, i];
                            if (dataMin > data.stftData[time, i]) dataMin = (float)data.stftData[time, i];
                        }

                        for (i = 0; i <= data.windowLen / 2; i++)
                        {
                            
                            float bottomUp = System.Math.Abs(dataMin);

                            //int alpha = (int)(((data.stftData[time, i] + bottomUp) / (dataMax - dataMin)) * 255);
                            //Pen p = new Pen(Color.FromArgb(alpha, Color.Green));

                            hsv = (int)((data.stftData[time, i] + bottomUp) * 1020 / (dataMax - dataMin));

                            switch (hsv / 255)
                            {
                                case 0:
                                    red = 0;
                                    green = 0 + (hsv % 255);
                                    brue = 255;
                                    break;

                                case 1:
                                    red = 0;
                                    green = 255;
                                    brue = 255 - (hsv % 255);
                                    break;

                                case 2:
                                    red = 0 + (hsv % 255);
                                    green = 255;
                                    brue = 0;
                                    break;

                                case 3:
                                    red = 255;
                                    green = 255 - (hsv % 255);
                                    brue = 0;
                                    break;

                            }

                            Pen p = new Pen(Color.FromArgb(red, green, brue), penSize);

                             
                            g.DrawLine(p,
                                 (float)(xZero + xStep * time),
                                 (float)(yZero - i * yStep - penSize/2),
                                 (float)(xZero + xStep * (time + 1)),
                                 (float)(yZero - i * yStep - penSize/2));
                        }
                    }

                    g.DrawString("0", myFont, Pens.Black.Brush, 0, picture.Width - 2); //原点

                    g.DrawLine(Pens.Black, xZero, yZero, xMax, yZero); // x軸
                    g.DrawLine(Pens.Black, xZero, yZero, xZero, yMax - penSize); // y軸

                    //x軸のメモリ
                    //scale = (xMax + 20) / 2;
                    //g.DrawLine(Pens.Black, scale, yZero - 5, scale, yZero + 5);
                    //g.DrawLine(Pens.Black, xMax, yZero - 5, xMax, yZero + 5);
                    //g.DrawString(xScaleLabel, myFont, Pens.Black.Brush, scale, yZero);

                    //y軸のラベル
                    //g.DrawString(yMaxLabel, myFont, Pens.Black.Brush, xZero - 20, yMax - 15);
                    //g.DrawString(yMinLabel, myFont, Pens.Black.Brush, xZero - 20, yMin);
                    g.DrawString(yLabel, myFont, Pens.Black.Brush, 5, gramHeight / 2);

                    //y軸のメモリ
                    //g.DrawLine(Pens.Black, xZero - 2, yMax, xZero + 2, yMax);
                    //g.DrawLine(Pens.Black, xZero - 2, yZero, xZero + 2, yZero);

                //Graphicsリソース解放
                g.Dispose();

            }
            catch (NullReferenceException e)
            {
                String errorMessage = e.ToString();
                Debug.ShowMessage("NullReferenceException", errorMessage);
            }
            catch (OverflowException e)
            {
                String errorMessage = e.ToString();
                Debug.ShowMessage("OverflowException", errorMessage);
            }
            catch (IndexOutOfRangeException e)
            {
                String errorMessage = e.ToString();
                Debug.ShowMessage("IndexOutOfRangeException", errorMessage);
            }
            catch (Exception e)
            {
                String errorMessage = e.ToString();
                Debug.ShowMessage("NewException", errorMessage);
            }

        }


    }
}
