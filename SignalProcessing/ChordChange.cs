using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class ChordChange
    {
        /**
         * ChordPeekDetection
         * 概要：ピークを検出する
         * @param p ピークを検出する対象である周波数データ
         * @param numberOfWindow 窓の数
         * @param freqBand
         * @return p[t,f] ピークである周波数成分
         */
        public double[,] ChordPeekDetection(double[,] data)
        {

            //ピークを保存する配列
            double[,] chordDataPeek;
            chordDataPeek = new double[data.GetLength(0), data.GetLength(1)];

            for (int n = 0; n < data.GetLength(0); n++)
            {
                for (int f = 1; f < data.GetLength(1) - 1; f++)
                {
                    if (data[n, f] >= Math.Max(data[n, f - 1], data[n, f + 1]))
                    {
                        chordDataPeek[n, f] = data[n, f];
                    }
                    else
                    {
                        chordDataPeek[n, f] = 0.0;
                    }
                }
            }
            return chordDataPeek;
        }


        /**
         * ToHistogramData
         * 概要：ビート間隔の短冊に分割する
         * @param data 分割する対象であるデータ
         * @return p[t,f] 分割されたデータ
         */

        public double[,] ToHistogramData(double[,] data, int beatInterval)
        {
            double[,] chordData = new double[data.GetLength(0) / beatInterval + 1, data.GetLength(1)];

            //短冊内のスペクトルの時間軸方向の和
            for (int i = 0; i < data.GetLength(1); i++)
            {
                int t = 0;
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    chordData[t, i] = chordData[t, i] + data[j, i];
                    if (j % beatInterval == 0 && j != 0)
                    {
                        t++;
                    }
                }
            }
            return chordData;
        }

    }
}
