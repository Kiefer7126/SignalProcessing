﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class WaveletAnalysis
    {
        private FourierAnalysis fourier;
        private const double freq0 = 110; //下限周波数
        private const int cent_div = 100;
        private const int octave_div = 12;
        private const int octave = 5;
        public int cent_interval = 25;
        public int cent_max = cent_div * octave_div * octave;

        //ガボールウェーブレット変換結果
        public double[,] wt;
        public int freqLen;

        /*分解信号*/
        public double[] s1;
        public double[] w1;

        /*ドベシィの数列(N=2)*/
        private double[] p = {0.482962913145, 
                              0.836516303738, 
                              0.224143868042,
                             -0.129409522551};
        public double[] q;

        public int pLen = 4;

        public int numberOfWindow;
        /**
        * CalGWT
        * 概要：ガボールウェーブレット変換を行う
        * @param data GWTの対象データ
        * @return なし
        */
        public void CalGWT(double[] data, int originalLen, int samplingFreq, int shiftLen, double sigma)
        {
            freqLen = cent_max / cent_interval;
            numberOfWindow = originalLen / shiftLen;

            wt = new double[numberOfWindow, freqLen];

            for (int x = 1; x < numberOfWindow; x++)
            {
                for (int y = 0 ; y < freqLen; y++)
                {
                    double freq = freq0 * Math.Pow(2.0, (double)y * cent_interval / (cent_div * octave_div));
                    double a = 1.0 / freq;
                    double dt = a * sigma * Math.Sqrt(-2.0 * Math.Log10(0.01)); //窓幅(s)
                    int dx = (int)(dt * samplingFreq);

                    // 窓幅の範囲を積分
		            double real_wt = 0;
		            double imag_wt = 0;
		            
                    for (int m = -dx; m <= dx; m++)
		            {
			            int n = x * shiftLen + m; // 信号のサンプル位置

                        if (n >= 0 && n < originalLen)
			            {
				            double t = (double)m / samplingFreq / a;
				            double gauss = 1.0 / Math.Sqrt(2.0 * Math.PI * sigma * sigma) * Math.Exp(-t * t / (2.0 * sigma * sigma)); // ガウス関数
				            double omega_t = 2.0 * Math.PI * t; // ωt
				            real_wt += (double)data[n] * gauss * Math.Cos(omega_t);
                            imag_wt += (double)data[n] * gauss * Math.Sin(omega_t);
			            }
		            }
                    wt[x, y] = 1.0 / Math.Sqrt(a) * Math.Sqrt(real_wt * real_wt + imag_wt * imag_wt);
                }
            }   
        }

        /**
         * CalDaubechiesSeries
         * 概要：ドベシィの数列(q)を生成する
         * @param なし
         * @return なし
         */
        public void CalDaubechiesSeries()
        {
            q = new double[pLen];

            for(int i = 0; i < pLen; i++)
            {
                q[i] = Math.Pow(-1, i) * p[pLen - i - 1];
            }
        }

        /**
        * CalFWT
        * 概要：高速ウェーブレット変換を行う
        * @param data FWTの対象データ
        * @return なし
        */

        public void CalFWT(double[] s0, int originalLen)
        {
            int index;

            s1 = new double[originalLen/2];
            w1 = new double[originalLen/2];

            //ドベシィの数列(q)を生成する
            CalDaubechiesSeries();
     
            //分解
            for(int k = 0; k < originalLen / 2; k++)
            {
                s1[k] = 0.0;
                w1[k] = 0.0;
                
                for(int n = 0; n < pLen; n++)
                {
                    index = (n + 2 * k) % originalLen;

                    s1[k] += p[n] * s0[index];
                    w1[k] += q[n] * s0[index];
                }
            }
        }
    }
}
