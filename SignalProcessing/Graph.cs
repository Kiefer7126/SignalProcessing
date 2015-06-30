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

        private int plotData;
        private int red;
        private int green;
        private int blue;

         /**
         * GetMax
         * 概要：最大値を求める
         * @param data　　  　 最大値を求める対象データ
         * @param windowLen 　 windowLength
         * @return dataMax
         */

        private float GetMax(double[] data, int windowLen)
        {
            float dataMax = 0;
            for (int i = 0; i < windowLen; i++)
            {
                if (dataMax < data[i]) dataMax = (float)data[i];
            }
            return dataMax;
        }

        /**
       　* GetMax
         * 概要：最小値を求める
         * @param data　　  　 最小値を求める対象データ
         * @param windowLen 　 windowLength
         * @return dataMin
         */

        private float GetMin(double[] data, int windowLen)
        {
            float dataMin = 0;

            for (int i = 0; i < windowLen; i++)
            {
                if (dataMin > data[i]) dataMin = (float)data[i];
            }

            return dataMin;
        }

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

        private void PlotGraph(PictureBox picture, double[] data, int windowLen, double samplingFreq, Boolean isWevelet)
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

                    //dataMax = GetMax(data, windowLen);

                    for (i = 0; i < windowLen; i++)
                    {
                        if (dataMax < data[i]) dataMax = (float)data[i];
                        if (dataMin > data[i]) dataMin = (float)data[i];
                    }

                    //dataMin = GetMin(data, windowLen);
                
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

                    for (i = 0; i < windowLen - 1; i++)
                    {

                        if (isWevelet)
                        {
                            g.DrawLine(Pens.Green,
                                 (float)((float)xZero + (float)i * xStep),
                                 (float)((float)yZero),
                                 (float)((float)xZero + (float)i * xStep),
                                 (float)((float)yZero - (float)data[i + 1] * yStep));
                        }
                        else
                        {
                         
                            g.DrawLine(Pens.Green,
                                 (float)((float)xZero + (float)i * xStep),
                                 (float)((float)yZero - (float)data[i] * yStep),
                                 (float)((float)xZero + (float)(i + 1) * xStep),
                                 (float)((float)yZero - (float)data[i + 1] * yStep));
                        }

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
            PlotGraph(timeGraph, data.originalData, data.windowLen, 0, false);
        }

        /**
         * PlotWaveletGraph
         * 概要：ウェーブレット変換した周波数軸のグラフを描画する
         * @param waveletGraph ウェーブレットグラフを描画するPictureBox
         * @param data      グラフ描画の対象データ
         * @return なし
         */

        public void PlotWaveletGraph(PictureBox waveletGraph, double[] w1, int originalLen)
        {
            PlotGraph(waveletGraph, w1, originalLen, 0, true);
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
            PlotGraph(dbGraph, data.dBData, data.windowLen, samplingFreq, false);
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
            PlotGraph(phaseGraph, data.phaseData, data.windowLen, samplingFreq, false);
        }

         /**
          * PlotLegend
          * 概要：スペクトログラムの凡例を描画する
          * @param picture   凡例を描画するPictureBox
          * @return なし
          */

        public void PlotLegend(PictureBox picture, DataRetention data)
        {
            Graphics g;
            Font myFont;
            int i, xZero, yZero, xMax, yMax, marginRight, marginTop, yScaleNumber, yScaleValue;
            float xStep, yStep, yScale, dBDataMax, dBDataMin;
            String yScaleLabel;

            try
            {
                picture.Refresh();
                picture.Image = new Bitmap(picture.Width, picture.Height);
                g = Graphics.FromImage(picture.Image);
                myFont = new Font("Arial", 9);
                marginRight = 30;
                marginTop = 0;

                xZero = 0;
                yZero = picture.Height;
                xMax  = picture.Width - marginRight;
                yMax  = marginTop;
                xStep = 0;
                yStep = (float)(picture.Height - marginTop) / (float)1275;

                yScaleLabel = "";

                for (i = 0; i <= 1275; i++)
                    //1024
                    //1275
                {
                    plotData = i;

                    ToHsv(plotData);

                    Pen p = new Pen(Color.FromArgb(red, green, blue), 1);
                             
                    g.DrawLine(p,
                              (float)(xZero),
                              (float)(yZero - i * yStep),
                              (float)(xMax),
                              (float)(yZero - i * yStep));
                }

                //y軸の目盛り
                yScaleNumber = 8;
                yScale = (picture.Height + marginTop) / yScaleNumber;

                dBDataMax = GetMax(data.dBData, data.windowLen);
                dBDataMin = GetMin(data.dBData, data.windowLen);

                for (i = 0; i <= yScaleNumber; i++)
                {
                    g.DrawLine(Pens.Black,
                       (float)(xMax - 5),
                       (float)(yZero - yScale * i),
                       (float)(xMax + 5),
                       (float)(yZero - yScale * i));

                    yScaleValue = (int)(dBDataMin + (System.Math.Abs(dBDataMax - dBDataMin) / yScaleNumber) * i);
                    yScaleLabel = yScaleValue.ToString();
                    g.DrawString(yScaleLabel, myFont, Pens.Black.Brush, xMax + 7, yZero - yScale * i - 3);
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
         * ToHsv
         * 概要：Hsvに変換する
         * @param red 
         * @param green  
         * @param blue
         * @return なし
         */

        public void ToHsv(int plotHsvData)
        {
            switch (plotHsvData / 255)
            {
                case 0:
                    red = 0;
                    green = 0;
                    blue = 0 + (plotHsvData % 255);
                    break;

                case 1:
                    red = 0;
                    green = 0 + (plotHsvData % 255);
                    blue = 255;
                    break;

                case 2:
                    red = 0;
                    green = 255;
                    blue = 255 - (plotHsvData % 255);
                    break;

                case 3:
                    red = 0 + (plotHsvData % 255);
                    green = 255;
                    blue = 0;
                    break;

                case 4:
                    red = 255;
                    green = 255 - (plotHsvData % 255);
                    blue = 0;
                    break;
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
            int i, time, numberOfWindow, xZero, yZero, xMax, yMax, marginRight, marginLeft, marginTop, marginBottom, gramWidth, gramHeight, yScaleNumber, yScaleValue;
            int spectroScale = 2; //大きくすると表示する周波数が減る
            int penSize = 15; //太くすると周波数が少ないときでも隙間なく描画される
            float xStep, yStep, xScale, yScale;
            float dataMax = 0;
            float dataMin = 0;
            float fMax_Hz = 0;

            String xLabel = "";
            String yLabel = "";
            String xScaleLabel = ""; 
            String yScaleLabel = "";
            String yMaxLabel = "";

            try
            {
                picture.Refresh();
                picture.Image = new Bitmap(picture.Width, picture.Height);
                g = Graphics.FromImage(picture.Image);
                myFont = new Font("Arial", 9);

                xLabel = "[ s ]";
                yLabel = "[ kHz ]";
                marginRight = 10;
                marginLeft = 65;
                marginTop = 10;
                marginBottom = 40;
                gramWidth = picture.Width - (marginRight + marginLeft);
                gramHeight = picture.Height - (marginTop + marginBottom);

                xZero = marginLeft;
                yZero = picture.Height - marginBottom;
                xMax  = picture.Width  - marginRight;
                yMax  = marginTop;

                numberOfWindow = data.originalLen / data.shiftLen;
                xStep = (float)gramWidth / (float)(numberOfWindow - 1);
                yStep = System.Math.Abs((float)gramHeight * 2 * spectroScale / data.windowLen);

                //グラフの描画

                    for (time = 0; time < numberOfWindow - 1 ; time++)
                    {
                        for (i = 0; i <= data.windowLen / (2 * spectroScale); i++)
                        {
                            if (dataMax < data.stftData[time, i]) dataMax = (float)data.stftData[time, i];
                            if (dataMin > data.stftData[time, i]) dataMin = (float)data.stftData[time, i];
                        }

                        for (i = 0; i <= data.windowLen / (2 * spectroScale); i++)
                        {      
                            float bottomUp = System.Math.Abs(dataMin);

                            plotData = (int)((data.stftData[time, i] + bottomUp) * 255 * 5 / (dataMax - dataMin));
                            ToHsv(plotData);

                            Pen p = new Pen(Color.FromArgb(red, green, blue), penSize);
                            
                             
                            g.DrawLine(p,
                                 (float)(xZero + xStep * time),
                                 (float)(yZero - i * yStep - penSize/2),
                                 (float)(xZero + xStep * (time + 1)),
                                 (float)(yZero - i * yStep - penSize/2));
                        }
                    }

                    Pen whitePen = new Pen(Color.White, penSize);
                    g.DrawLine(whitePen,
                        (float)(xZero),
                        (float)(yMax) - penSize / 2,
                        (float)(xMax),
                        (float)(yMax) - penSize / 2);

                    g.DrawString("0", myFont, Pens.Black.Brush, 0, picture.Width - 2); //原点
                    g.DrawLine(Pens.Black, xZero, yZero, xMax, yZero); // x軸
                    g.DrawLine(Pens.Black, xZero, yZero, xZero, yMax); // y軸

                    //x軸のラベル
                    g.DrawString(xLabel, myFont, Pens.Black.Brush, picture.Width / 2, yZero + (marginBottom / 2));

                    xScale = gramWidth / data.originalTime_s;

                    for (i = 0; i <= data.originalTime_s; i++)
                    {
                        g.DrawLine(Pens.Black,
                            (float)(xZero + xScale * i),
                            (float)(yZero - 5),
                            (float)(xZero + xScale * i),
                            (float)(yZero + 5));

                        xScaleLabel = i.ToString();
                        g.DrawString(xScaleLabel, myFont, Pens.Black.Brush, xZero + xScale * i - 4, yZero + 4);
                    }

                    
                    //y軸のラベル
                    g.DrawString(yLabel, myFont, Pens.Black.Brush, 5, gramHeight / 2);

                    //y軸の目盛り
                    //yScaleNumber = 8;
                    //data.fScale_Hz = data.ofSmpf / data.windowLen;
                    //fMax_Hz = (data.fScale_Hz * data.windowLen) / 2;
                    //yScale = gramHeight / yScaleNumber;

                    yScaleNumber = data.ofSmpf / (1000 * spectroScale);
                    fMax_Hz = data.ofSmpf / 2;
                    yScale = ((float)gramHeight / (float)data.ofSmpf) * 1000 * 2 * spectroScale;   
                
                    for (i = 0; i <= yScaleNumber / 2; i++)
                    {
                        g.DrawLine(Pens.Black,
                           (float)(xZero - 5),
                           (float)(yZero - yScale * i),
                           (float)(xZero + 5),
                           (float)(yZero - yScale * i));

                        //yScaleValue = (int)((fMax_Hz / yScaleNumber) * i) / 1000;
                        yScaleValue = i;

                        yScaleLabel = yScaleValue.ToString();
                        g.DrawString(yScaleLabel, myFont, Pens.Black.Brush, xZero - 20, yZero - yScale * i - 7);
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

        public void PlotSpectrogramEdit(double samplingFreq, PictureBox picture, double[,] data, int numberOfWindow, int shiftLen, int freqLen)
        {
            Graphics g;
            Font myFont;
            int i, time, xZero, yZero, xMax, yMax, marginRight, marginLeft, marginTop, marginBottom, gramWidth, gramHeight, yScaleNumber, yScaleValue;

            int penSize = 15; //太くすると周波数が少ないときでも隙間なく描画される
            float xStep, yStep, xScale, yScale;
            float dataMax = 0;
            float dataMin = 0;
            float fMax_Hz = 0;

            String xLabel = "";
            String yLabel = "";
            String xScaleLabel = "";
            String yScaleLabel = "";
            String yMaxLabel = "";

            try
            {
                picture.Refresh();
                picture.Image = new Bitmap(picture.Width, picture.Height);
                g = Graphics.FromImage(picture.Image);
                myFont = new Font("Arial", 9);

                xLabel = "[ s ]";
                yLabel = "[ kHz ]";
                marginRight = 10;
                marginLeft = 65;
                marginTop = 10;
                marginBottom = 40;
                gramWidth = picture.Width - (marginRight + marginLeft);
                gramHeight = picture.Height - (marginTop + marginBottom);

                xZero = marginLeft;
                yZero = picture.Height - marginBottom;
                xMax = picture.Width - marginRight;
                yMax = marginTop;

                xStep = (float)gramWidth / (float)(numberOfWindow - 2);
                yStep = System.Math.Abs((float)gramHeight / freqLen);

                //グラフの描画

                for (time = 1; time < numberOfWindow - 1; time++)
                {
                    for (i = 0; i < freqLen; i++)
                    {
                        if (dataMax < data[time, i]) dataMax = (float)data[time, i];
                        if (dataMin > data[time, i]) dataMin = (float)data[time, i];
                    }

                    for (i =0; i < freqLen; i++)
                    {
                        float bottomUp = System.Math.Abs(dataMin);

                        plotData = (int)((data[time, i] + bottomUp) * 255 * 5 / (dataMax - dataMin));
                        ToHsv(plotData);

                        Pen p = new Pen(Color.FromArgb(red, green, blue), penSize);

                        g.DrawLine(p,
                             (float)(xZero + xStep * (time - 1)),
                             (float)(yZero - i * yStep - penSize / 2),
                             (float)(xZero + xStep * (time)),
                             (float)(yZero - i * yStep - penSize / 2));
                        
                    }
                    //Debug.ShowMessage("DEBUG", "time = " + time);
                }

                /*
                Pen whitePen = new Pen(Color.White, penSize);
                g.DrawLine(whitePen,
                    (float)(xZero),
                    (float)(yMax) - penSize / 2,
                    (float)(xMax),
                    (float)(yMax) - penSize / 2);
                */

                g.DrawString("0", myFont, Pens.Black.Brush, 0, picture.Width - 2); //原点
                g.DrawLine(Pens.Black, xZero, yZero, xMax, yZero); // x軸
                g.DrawLine(Pens.Black, xZero, yZero, xZero, yMax); // y軸

                //x軸のラベル
                g.DrawString(xLabel, myFont, Pens.Black.Brush, picture.Width / 2, yZero + (marginBottom / 2));

                /*
                xScale = gramWidth / data.originalTime_s;

                for (i = 0; i <= data.originalTime_s; i++)
                {
                    g.DrawLine(Pens.Black,
                        (float)(xZero + xScale * i),
                        (float)(yZero - 5),
                        (float)(xZero + xScale * i),
                        (float)(yZero + 5));

                    xScaleLabel = i.ToString();
                    g.DrawString(xScaleLabel, myFont, Pens.Black.Brush, xZero + xScale * i - 4, yZero + 4);
                }

                */

                //y軸のラベル
                g.DrawString(yLabel, myFont, Pens.Black.Brush, 5, gramHeight / 2);

                //y軸の目盛り
                //yScaleNumber = 8;
                //data.fScale_Hz = data.ofSmpf / data.windowLen;
                //fMax_Hz = (data.fScale_Hz * data.windowLen) / 2;
                //yScale = gramHeight / yScaleNumber;

                /*
                yScaleNumber = data.ofSmpf / 1000;
                fMax_Hz = data.ofSmpf / 2;
                yScale = ((float)gramHeight / (float)data.ofSmpf) * 1000 * 2;

                for (i = 0; i <= yScaleNumber / 2; i++)
                {
                    g.DrawLine(Pens.Black,
                       (float)(xZero - 5),
                       (float)(yZero - yScale * i),
                       (float)(xZero + 5),
                       (float)(yZero - yScale * i));

                    //yScaleValue = (int)((fMax_Hz / yScaleNumber) * i) / 1000;
                    yScaleValue = i;

                    yScaleLabel = yScaleValue.ToString();
                    g.DrawString(yScaleLabel, myFont, Pens.Black.Brush, xZero - 20, yZero - yScale * i - 7);
                }
                 */

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
         * PlotWeveletSpectrogram
         * 概要：スペクトログラムを描画する
         * @param samplingFreq サンプリング周波数
         * @param spectrogram   スペクトログラムを描画するPictureBox
         * @param data         グラフ描画の対象データ
         * @return なし
         */

        public void PlotWeveletSpectrogram(PictureBox picture, double[] data, int windowLen)
        {

            Graphics g;
            Font myFont;
            int i;

            int penSize = 15; //太くすると周波数が少ないときでも隙間なく描画される
            float xStep;
            float dataMax = 0;
            float dataMin = 0;

            try
            {
                picture.Refresh();
                picture.Image = new Bitmap(picture.Width, picture.Height);
                g = Graphics.FromImage(picture.Image);
                myFont = new Font("Arial", 9);

                xStep = (float)picture.Width / (float)(windowLen);

                //グラフの描画

                    for (i = 0; i < windowLen; i++)
                    {
                        if (dataMax < data[i]) dataMax = (float)data[i];
                        if (dataMin > data[i]) dataMin = (float)data[i];
                    }

                    for (i = 0; i < windowLen; i++)
                    {
                        float bottomUp = System.Math.Abs(dataMin);

                        plotData = (int)((data[i] + bottomUp) * 255 * 5 / (dataMax - dataMin));
                        ToHsv(plotData);

                        Pen p = new Pen(Color.FromArgb(red, green, blue), penSize);

                        g.DrawLine(p,
                             (float)(xStep * i),
                             (float)(picture.Height),
                             (float)(xStep * i),
                             (float)(0));
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
         * PlotSoundTimeGraph
         * 概要：発音時刻を示した時間軸のグラフを描画する
         * @param soundTimeGraph 発音時刻を描画するPictureBox
         * @param data      グラフ描画の対象データ
         * @return なし
         */

        public void PlotSoundTimeGraph(PictureBox soundTimeGraph, double[] data, int dataLen)
        {
            PlotGraphEdit(soundTimeGraph, data, dataLen, 0);
        }

        private void PlotGraphEdit(PictureBox picture, double[] data, int dataLen, double samplingFreq)
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

            xMin = 0;
            xMax = picture.Width;
            yMax = 0;
            yMin = picture.Height;

            yZero = yMin;
            xZero = xMin;
            xStep = (float)(xMax - xMin) / (dataLen + 1);
            yStep = 0;
            scale = 0;

            try
            {
                picture.Refresh();
                picture.Image = new Bitmap(picture.Width, picture.Height);
                g = Graphics.FromImage(picture.Image);
                myFont = new Font("Arial", 9);

                //dataMax = GetMax(data, windowLen);

                for (i = 0; i < dataLen; i++)
                {
                    if (dataMax < data[i]) dataMax = (float)data[i];
                    if (dataMin > data[i]) dataMin = (float)data[i];
                }

                //dataMin = GetMin(data, windowLen);

                if (System.Math.Abs(dataMax) <= System.Math.Abs(dataMin))
                {
                    yStep = (float)(yMin - yMax) / System.Math.Abs(dataMin);
                    yMaxLabel = System.Math.Abs(dataMin).ToString();
                    yMinLabel = (-1 * System.Math.Abs(dataMin)).ToString();

                }
                else
                {
                    yStep = (float)(yMin - yMax) / System.Math.Abs(dataMax);

                    yMaxLabel = System.Math.Abs(dataMax).ToString();
                    yMinLabel = (-1 * System.Math.Abs(dataMax)).ToString();

                }

                for (i = 0; i < dataLen - 1; i++)
                {
                        g.DrawLine(Pens.Green,
                             (float)((float)xZero + (float)i * xStep),
                             (float)((float)yZero),
                             (float)((float)xZero + (float)i * xStep),
                             (float)((float)yZero - (float)data[i + 1] * yStep));
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
    }



}
