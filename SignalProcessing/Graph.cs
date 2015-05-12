﻿using System;
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
                        /*
                            g.DrawLine(Pens.Green,
                            xZero + i * xStep,
                            yZero,
                            xZero + i * xStep,
                            yZero - (float)data[i] * yStep);
                         */

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
            int i, time;
            float xStep, yStep;
            float dataMax = 0;
            float dataMin = 0;
       
            xStep = (float)((picture.Width * data.windowLen * 1.01) / (data.originalLen+1));
            yStep = System.Math.Abs((float)(0 - picture.Height * 3) / (data.windowLen + 1));

            try
            {

                picture.Refresh();
                picture.Image = new Bitmap(picture.Width, picture.Height);
                g = Graphics.FromImage(picture.Image);
                myFont = new Font("Arial", 9);

                //グラフの描画

                    int hsv;
                    int red = 0;
                    int green = 0;
                    int brue = 255;

                    for (time = 0; time < (data.originalLen / data.windowLen); time++)
                    {

                        for (i = 0; i < data.windowLen; i++)
                        {
                            if (dataMax < data.stftData[time, i]) dataMax = (float)data.stftData[time, i];
                            if (dataMin > data.stftData[time, i]) dataMin = (float)data.stftData[time, i];
                        }

                        for (i = 0; i < data.windowLen; i++)
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

                            Pen p = new Pen(Color.FromArgb(red, green, brue));

                             
                            g.DrawLine(p,
                                 (float)(xStep * time),
                                 (float)(picture.Height - i * yStep),
                                 (float)(xStep * (time + 1)),
                                 (float)(picture.Height - i * yStep));
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


    }
}
