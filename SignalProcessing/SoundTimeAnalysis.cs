using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class SoundTimeAnalysis
    {
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
            d = new double[numberOfWindow + 1, freqBand];


            //各時刻における立ち上がり成分の合計(指定された周波数帯域)
            double[] sumD;
            sumD = new double[numberOfWindow + 1];

            for (int t = 2; t < numberOfWindow - 1; t++)
            {
                for (int f = 1; f < freqResolution; f++)
                {

                    double ppTemp1 = Math.Max(p[t - 1, f + freqFromNumber], p[t - 1, f - 1 + freqFromNumber]);
                    double ppTemp2 = Math.Max(p[t - 1, f + 1 + freqFromNumber], p[t - 2, f + freqFromNumber]);
                    double pp = Math.Max(ppTemp1, ppTemp2);

                    double npTemp1 = Math.Min(p[t + 1, f - 1 + freqFromNumber], p[t + 1, f + 1 + freqFromNumber]);
                    double np = Math.Min(p[t + 1, f], npTemp1);


                    if (p[t, f] > pp && np > pp)
                    {
                        d[t, f] = p[t, f] - pp + Math.Max(0, p[t + 1, f + freqFromNumber] - p[t, f + freqFromNumber]);
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

    }
}
