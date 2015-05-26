using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class FourierAnalysis
    {

        private WindowFunction window;

        /**
         * DivideWindowLen
         * 概要：originalDataをずらしながらstftDataとtimeDataに格納
         * @param data 分割する対象データ
         * @return なし
         */

        public void DivideWindowLen(DataRetention data, int time)
        {
            int timeStep;

            for (int i = 0; i < data.windowLen; i++)
            {
                timeStep = i + (data.shiftLen * time);

                if (timeStep  >= data.originalLen)
                {
                    data.stftData[time, i] = 0.00000;
                    data.timeData[i] = 0.00000;
                }
                else
                {
                    data.stftData[time, i] = data.originalData[timeStep];
                    data.timeData[i] = data.originalData[timeStep];
                }
            }
        }

        /**
         * CalSTFT
         * 概要：STFTを行う
         * @param data STFTの対象データ
         * @return なし
         */
        public void CalSTFT(DataRetention data)
        {
            
            int numberOfWindow = data.originalLen / data.shiftLen ;
            this.window = new WindowFunction();

            for (int time = 0; time < numberOfWindow - 1; time++)
            {
                //windowLenで分割する
                DivideWindowLen(data, time);

                //窓をかける
                this.window.WindowGaussian(data, time, DataRetention.SPECTRO);

                //離散フーリエ変換
                //CalDFT(data, time);

                //高速フーリエ変換
                CalFFT(data, time);

               }     
            }

        /**
         * CalDFT
         * 概要：DFTを行う
         * @param data DFTの対象データ
         * @return なし
         */

        public void CalDFT(DataRetention data, int time)
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

        /**
         * CalFFT
         * 概要：FFTを行う
         * 引数：data FFTの対象データ
         * 戻り値：なし
         */
        public void CalFFT(DataRetention data, int time)
        {
            int i;

            try
            {
                //時間軸データが存在しない場合は例外発生
                if (data.timeData == null)
                {
                    throw new System.Exception();
                }

                //時間軸グラフに描画したデータからの実数と虚数部格納用
                data.realData = new double[data.windowLen];
                data.imagData = new double[data.windowLen];

                //周波数軸(パワー)グラフのデータ格納用(FFT後のデータ)
                data.powerData = new double[data.windowLen];
                //周波数軸(dB)グラフのデータ格納用(FFT後のデータ)
                data.dBData = new double[data.windowLen];
                //周波数軸(位相)グラフのデータ格納用(FFT後のデータ)
                data.phaseData = new double[data.windowLen];

                //FFT
                this.FFTMain(DataRetention.FFT, data);

                for (i = 0; i < data.windowLen; i++)
                {
                    //パワースペクトル算出
                    //数が大きくなるので、windowLengthで割る
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
            catch (Exception ex)
            {
            }
        }

        /**
         * FFTMain
         * 概要：FFTおよびIFFTの計算を行う
         * 引数：flag 
         *       data FFTおよびIFFTの対象データ
         * 戻り値：なし
         */

        private void FFTMain(int flag, DataRetention data)
        {
            int i, j, k, h, m, kp;

            //回転因子格納用
            double[] twiddleFactor = new double[data.windowLen];

            //回転因子用の値を一時格納する変数
            double wtmpr;
            double wtmpi;

            //ビッド反転の値を一時格納する変数
            double tmpr;
            double tmpi;

            //バタフライ演算用の値を一時格納する変数
            double vtmpr;
            double vtmpi;

            //windowLengthが2の何乗であるかを求める
            int power = (int)System.Math.Log(data.windowLen, 2);

            try
            {
                //FFTの場合には時間軸データから実数部を取得する
                if (flag == DataRetention.FFT)
                {
                    //データの入れ替え（時間軸データを実数部にコピー）
                    for (i = 0; i < data.windowLen; i++)
                        data.realData[i] = data.timeData[i] / data.windowLen;
                }

                //回転因子の計算
                for (j = 0; j < data.windowLen / 2; j++)
                {
                    twiddleFactor[j] = System.Math.Cos(2 * j * System.Math.PI / data.windowLen);
                    //FFTとIFFTでは符号が逆になる
                    twiddleFactor[j + (data.windowLen / 2)] = (-flag) * System.Math.Sin(2 * j * System.Math.PI / data.windowLen);
                }

                //ビット反転
                j = 0;
                for (i = 0; i <= data.windowLen - 2; i++)
                {
                    if (i < j)
                    {
                        //実数部のビット反転
                        tmpr = data.realData[j];
                        data.realData[j] = data.realData[i];
                        data.realData[i] = tmpr;

                        //虚数部のビット反転
                        tmpi = data.imagData[j];
                        data.imagData[j] = data.imagData[i];
                        data.imagData[i] = tmpi;
                    }
                    k = data.windowLen / 2;
                    while (k <= j)
                    {
                        j = j - k;
                        k = k / 2;
                    }
                    j = j + k;
                }

                //バタフライ演算
                for (i = 1; i <= power; i++)
                {
                    m = (int)System.Math.Pow(2, i);
                    h = m / 2;

                    for (j = 0; j < h; j++)
                    {
                        wtmpr = twiddleFactor[j * (data.windowLen / m)];
                        wtmpi = twiddleFactor[j * (data.windowLen / m) + data.windowLen / 2];

                        for (k = j; k < data.windowLen; k += m)
                        {
                            kp = k + h;
                            vtmpr = data.realData[kp] * wtmpr - data.imagData[kp] * wtmpi;
                            vtmpi = data.realData[kp] * wtmpi + data.imagData[kp] * wtmpr;

                            //実数部のビット反転
                            tmpr = data.realData[k] + vtmpr;
                            data.realData[kp] = data.realData[k] - vtmpr;
                            data.realData[k] = tmpr;

                            //虚数部のビット反転
                            tmpi = data.imagData[k] + vtmpi;
                            data.imagData[kp] = data.imagData[k] - vtmpi;
                            data.imagData[k] = tmpi;
                        }
                    }
                }

                //IFFTの場合の処理
                if (flag == DataRetention.IFFT)
                {
                    //時間軸データ格納用配列に実数部データを格納
                    data.timeData = new double[data.windowLen];
                    for (i = 0; i < data.windowLen; i++)
                    {
                        //時間軸データ格納用配列に実数部データを格納
                        data.timeData[i] = data.realData[i];
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
