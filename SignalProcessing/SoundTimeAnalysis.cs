﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class SoundTimeAnalysis
    {

        /**
         * AutocorrelationFunction
         * 概要：自己相関を求める
         * @param data 自己相関を求める対象データ
         * @param dataLen 対象データの大きさ
         * @return R[] 自己相関配列
         */
        public double[] AutocorrelationFunction(int dataLen, double[] data1, double[] data2)
        {
            double[] R = new double[dataLen];

            for (int j = 0; j < dataLen; j++)
            {
                for (int i = 0; i < dataLen - j; i++)
                {
                    R[j] = R[j] + data1[i] * data2[i + j];
                }
                R[j] = R[j] / (dataLen - j);
            }
            return R;
        }

        /**
         * RisingComponentAnalysis
         * 概要：立ち上がり成分を抽出する
         * @param p 立ち上がり成分を抽出する対象であるFFT後の周波数成分
         * @param numberOfWindow 窓の数
         * @param freqBand
         * @return p[t,f] パワーが増加し続けている周波数成分
         */
        public double[] RisingComponentAnalysis(double[,] p, int numberOfWindow, int windowLen, int freqFrom, int freqTo, int samplingFreq)
        {
            
            int freqBand = freqTo - freqFrom;

            //周波数帯域の始点(Hz -> 周波数番号)
            int freqFromNumber = freqFrom / (samplingFreq / windowLen);

            //周波数分解能(Hz -> 周波数番号)
            int freqResolution = freqBand / (samplingFreq / windowLen);

            //立ち上がりの度合い
            double[,] d;
            d = new double[numberOfWindow + 1, freqResolution];

            //各時刻における立ち上がり成分の合計(指定された周波数帯域)
            double[] sumD;
            sumD = new double[numberOfWindow + 1];

            for (int t = 2; t < numberOfWindow - 1; t++)
            {
                for (int f = 1; f < freqResolution; f++)
                {

                    //double ppTemp1 = Math.Max(p[t - 1, f + freqFromNumber], p[t - 1, f - 1 + freqFromNumber]);
                    //double ppTemp2 = Math.Max(p[t - 1, f + 1 + freqFromNumber], p[t - 2, f + freqFromNumber]);
                    //double pp = Math.Max(ppTemp1, ppTemp2);

                    double ppTemp1 = Math.Max(p[t - 1, f + freqFromNumber], p[t - 1, f - 1 + freqFromNumber]);
                    double pp = Math.Max(ppTemp1, p[t - 1, f + 1 + freqFromNumber]);

                    double npTemp1 = Math.Min(p[t + 1, f - 1 + freqFromNumber], p[t + 1, f + 1 + freqFromNumber]);
                    double np = Math.Min(p[t + 1, f + freqFromNumber], npTemp1);


                    //if (p[t, f] > pp && np > pp)
                    if (Math.Min(p[t, f + freqFromNumber], p[t + 1, f + freqFromNumber]) > pp)
                    {
                       //d[t, f] = p[t, f + freqFromNumber] - pp + Math.Max(0, p[t + 1, f + freqFromNumber] - p[t, f + freqFromNumber]);
                        d[t, f] = Math.Max(p[t + 1, f + freqFromNumber], p[t, f + freqFromNumber]) - pp;
                    }
                    else
                    {
                        d[t, f] = 0;
                    }
                    sumD[t] = sumD[t] + d[t, f];
                }
            }
            return sumD;
        }

        /**
         * SavitzkyGolayFilter
         * 概要：2次多項式適合による平滑化微分
         * @param data            平滑化する対象データ
         * @param smoothingNumber 平常化の時間幅
         * @param dataLen         対象データの長さ
         * @return newData        平滑化後のデータ
         */
        public double[] SavitzkyGolayFilter(double[] data, int smoothingNumber, int dataLen)
        {
            double[] newData;
            newData = new double[dataLen];

            int Nomalization = 0;
            int[] W5  = { -3,  12, 17,  12,  -3};
            int[] W7 = { -2, 3, 6, 7, 6, 3, -2 };
            int[] W9 = { -21, 14, 39, 54, 59, 54, 39, 14, -21 };
            int[] W11 = { -36, 9, 44, 69, 84, 89, 84, 69, 44, 9, -36 };
            int[] W13 = { -11, 0, 9, 16, 21, 24, 25, 24, 21, 16, 9, 0, -11 };
            int[] W15 = { -78, -13, 42, 87, 122, 147, 162, 167, 162, 147, 122, 87, 42, -13, -78 };


            switch (smoothingNumber)
            {
                case 5:
                    Nomalization = 35;
                    newData = SavitzkyGolayCalc(data, smoothingNumber, dataLen, W5, Nomalization);
                    break;

                case 7:
                    Nomalization = 21;
                    newData = SavitzkyGolayCalc(data, smoothingNumber, dataLen, W7, Nomalization);
                    break;

                case 9:
                    Nomalization = 231;
                    newData = SavitzkyGolayCalc(data, smoothingNumber, dataLen, W9, Nomalization);
                    break;

                case 11:
                    Nomalization = 429;
                    newData = SavitzkyGolayCalc(data, smoothingNumber, dataLen, W11, Nomalization);
                    break;

                case 13:
                    Nomalization = 143;
                    newData = SavitzkyGolayCalc(data, smoothingNumber, dataLen, W13, Nomalization);
                    break;

                case 15:
                    Nomalization = 1105;
                    newData = SavitzkyGolayCalc(data, smoothingNumber, dataLen, W15, Nomalization);
                    break;
            }
                 

            return newData;
        }

        /**
         * SavitzkyGolayCalc
         * 概要：S-GFilterの計算部分
         * @param data            平滑化する対象データ
         * @param n               平常化の時間幅
         * @param dataLen         対象データの長さ
         * @param W               重みとなるS-G係数
         * @param N               正規化定数
         * @return newData        平滑化後のデータ
         */
        public double[] SavitzkyGolayCalc(double[] data, int n, int dataLen, int[] W, int N)
        {
            double[] newData;
            newData = new double[dataLen];
            
            for (int i = 0; i < dataLen; i++)
            {
                for (int j = -(n - 1) / 2; j < (n - 1) / 20; j++)
                {
                    if (i + j < 0)
                    {
                        newData[i] = data[i];
                    }
                    else
                    {
                        newData[i] = newData[i] + W[(n-1)/2 + j] * data[i + j];
                    }
                }
                newData[i] = newData[i] / N;
            }

            return newData;
        }

        /**
         * PeekDetection
         * 概要：ピークの検出
         * @param data            ピークを求める対象データ(微分済み)
         * @param dataLen         対象データの長さ
         * @return peekTime        平滑化後のデータ
         */
        public double [] PeekDetection(double[] data, int dataLen)
        {
            double[] peekTime;
            peekTime = new double[dataLen];
            double maxPeek;

            //最近得られた最大のピーク値で正規化
            maxPeek = 0;

            for (int i = 0; i < dataLen - 1; i++)
            {
                if (data[i] > 0 && data[i + 1] < 0)
                {
                        if (maxPeek < data[i])
                        {
                            maxPeek = data[i];
                        }

                        peekTime[i] = data[i] / maxPeek;

                 }
                 else
                 {
                        peekTime[i] = 0.0;
                 }  
            }
                return peekTime;
        }

        /**
         * BeetTimeDetection
         * 概要： ビート時刻の検出
         * @param data            ビート時刻を求める対象データ
         * @return beetTime       ビート時刻系列
         */

        public int BeetTimeDetection(double[] data)
        {
            double [] beetTime = new double[data.Length];
            int oldBeet = 0;
            int beatInterval;
        
            ArrayList beatIntervalArray = new ArrayList();

            //ビート間隔を格納
            for (int i = 0; i < data.Length; i++) 
            {
                if (data[i] > 0.0)
                {
                    beatInterval = i - oldBeet;

                    oldBeet = i;

                    beatIntervalArray.Add(beatInterval);
    
                }
            }
             
            //最頻値を求める
            int mode = 0;
            int count = 0;
            int tempCount;

            for (int i = 0; i < beatIntervalArray.Count; i++)
            {
                tempCount = 1;
                for (int j = i + 1; j < beatIntervalArray.Count; j++)
                {
                    if ((int)beatIntervalArray[i] == (int)beatIntervalArray[j])
                    {
                        tempCount++;
                    }
                }

                if (tempCount > count)
                {
                    count = tempCount;
                    mode = (int)beatIntervalArray[i];
                }
            }

            beatInterval = mode;
            
          return beatInterval;
        }

        public double[] makeBeat(double[] beatTime, int gap, int beatInterval)
        {
            for (int i = 0; i < beatTime.Length; i++)
            {
                beatTime[i] = 0.0;
            }

            for (int i = gap; i < beatTime.Length; i = i + beatInterval)
            {
                beatTime[i] = 1.0;
            }

            return beatTime; 
        }
    }
}
