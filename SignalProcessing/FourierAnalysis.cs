﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class FourierAnalysis
    {
        private WindowFunction window;
        /**
         * CalSTFT
         * 概要：STFTを行う
         * @param data STFTの対象データ
         * @return なし
         */
        public void CalSTFT(DataRetention data)
        {
            int a;
            this.window = new WindowFunction();

            for (int time = 0; time < (data.originalLen / data.windowLen); time++)
            {
                //オリジナルデータをタイムデータにずらしながら格納
                for (int j = 0; j < data.windowLen; j++)
                {
                    a = j + (data.windowLen * time);

                    if (a > data.originalLen)
                    {
                        data.stftData[time, j] = 0.00000;
                        data.timeData[j] = 0.00000;
                    }
                        data.stftData[time, j] = data.originalData[a];
                        data.timeData[j] = data.originalData[a];
                    }

                //窓をかける
                this.window.WindowGaussian(data, time, DataRetention.SPECTRO);

                //フーリエ変換
                CalDFT(data, time, DataRetention.SPECTRO);

               }     
            }

        /**
         * CalDFT
         * 概要：DFTを行う
         * @param data DFTの対象データ
         * @return なし
         */

        public void CalDFT(DataRetention data, int time, int flag)
        {
            int i, j;

            try
            {
                if (data.timeData == null)
                {
                    throw new System.Exception();
                }

                data.realData = new double[data.windowLen];
                data.imagData = new double[data.windowLen];
                data.powerData = new double[data.windowLen];
                data.dBData = new double[data.windowLen];
                data.phaseData = new double[data.windowLen];

                for (i = 0; i < data.windowLen; i++)
                {
                    for (j = 0; j < data.windowLen; j++)
                    {
                       
                        //if(flag == DataRetention.SPECTRO) data.timeData[j] = data.stftData[time, j];

                            data.realData[i] += data.timeData[j] * System.Math.Cos((2 * System.Math.PI * i * j) / data.windowLen);
                            data.imagData[i] += data.timeData[j] * (-System.Math.Sin((2 * System.Math.PI * i * j) / data.windowLen));
                    }

                    data.realData[i] = data.realData[i] / data.windowLen;
                    data.imagData[i] = data.imagData[i] / data.windowLen;

                    //パワースペクトル算出
                    data.powerData[i] = (data.realData[i] * data.realData[i] + data.imagData[i] * data.imagData[i]) / data.windowLen;

                    //位相スペクトル算出
                    data.phaseData[i] = System.Math.Atan2(data.imagData[i], data.realData[i]);

                    //dB変換
                    if (data.powerData[i] > 0)
                    {
                        data.dBData[i] = 10 * System.Math.Log10(data.powerData[i]);
                    }
                    else
                    {
                        data.dBData[i] = 0.00000;
                    }

                     data.stftData[time, i] = data.dBData[i];
                }
            }
            catch (Exception e)
            {
                //例外処理
            }
        }
    }
}
