﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalProcessing
{
    public class GenerateWave
    {
        /*
         * Processing
         * 概要：波を生成する処理
         * @param data
         *        flag
         * @return なし
         */
        public void Processing (DataRetention data, int flag)
        {
            data.originalData = new double[data.windowLen];
            data.originalLen = data.windowLen;

            
            for (int n = 0; n < data.windowLen; n++)
            {
                switch (flag)
                {
                    case DataRetention.SINE:
                        data.originalData[n] = data.amplitude * Math.Sin((2.0 * Math.PI * data.fundamentalFreq * n) / data.samplingFreq);
                        break;
                    case DataRetention.SAW:
                        for (int i = 1; i <= data.harmonic; i++)
                        {
                            data.originalData[n] = data.originalData[n] + (data.amplitude / i) * Math.Sin(2.0 * Math.PI * data.fundamentalFreq * i * n / data.samplingFreq);
                        } 
                        break;
                    case DataRetention.SQUARE:
                        for (int i = 1; i <= data.harmonic; i++)
                        {
                            data.originalData[n] = data.originalData[n] + (data.amplitude / (2 * i - 1)) * Math.Sin(2.0 * Math.PI * data.fundamentalFreq * (2 * i - 1) * n / data.samplingFreq);
                        } 
                        break;
                }
            }

            //時間軸データ用にオリジナルデータをコピーする
            data.timeData = new double[data.windowLen];

            for (int i = 0; i < data.windowLen; i++)
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
