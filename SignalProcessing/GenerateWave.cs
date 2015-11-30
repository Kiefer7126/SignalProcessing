using System;
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
         * @param flag
         * @return なし
         */

        public void Processing (DataRetention data, int flag)
        {
            data.originalLen = data.windowLen;
            data.originalData = new double[data.windowLen];

            for (int n = 0; n < data.originalLen; n++)
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
                    case DataRetention.SINE2:

                        if(n < 300) data.originalData[n] = data.amplitude * Math.Sin((2.0 * Math.PI * data.fundamentalFreq * n) / data.samplingFreq);
                        else if (n < 700) data.originalData[n] = data.amplitude * Math.Sin((2.0 * Math.PI * 700 * n) / data.samplingFreq);
                        else data.originalData[n] = data.amplitude * Math.Sin((2.0 * Math.PI * 900 * n) / data.samplingFreq);
                        break;
                }
            }
            data.ofSmpf = (int)data.samplingFreq;
            PutInTimeData(data);
        }

        /*
         * beat
         * 概要：波を生成する処理
         * @param data
         * @param flag
         * @return なし
         */

        public double[] beat(DataRetention data) 
        {
            double[] beatStructure = new double[data.originalData.Length];
            int i = 0;
            int j = 0;
            int count = 0;
            int noteLength = 1500;
            Boolean flag = false;

            for (i = 0; i < data.originalData.Length; i++)
            {
                if ((float)i * data.msPerSampling >= data.metricalData[j, 0] * 10)
                {
                    System.Diagnostics.Debug.WriteLine("True");
                    flag = true;
                    count = 0;
                    
                    while(flag)
                    {
                        switch (data.metricalData[j,2])
                        {
                            case DataRetention.FIRSTMETRIC:
                                beatStructure[i] = data.originalData[count] = data.amplitude * Math.Sin((2.0 * Math.PI * DataRetention.FIRSTMETRIC * count) / data.samplingFreq);
                                break;
                            case DataRetention.SECONDMETRIC:
                                beatStructure[i] = data.originalData[count] = data.amplitude * Math.Sin((2.0 * Math.PI *  2*DataRetention.SECONDMETRIC * count) / data.samplingFreq);;
                                break;
                            case DataRetention.THERDMETRIC:
                                beatStructure[i] = data.originalData[count] = data.amplitude * Math.Sin((2.0 * Math.PI * 2*DataRetention.THERDMETRIC * count) / data.samplingFreq);;
                                break;
                            case DataRetention.FORTHMETRIC:
                                beatStructure[i] = data.originalData[count] = data.amplitude * Math.Sin((2.0 * Math.PI * 2*DataRetention.FORTHMETRIC * count) / data.samplingFreq);;
                                break;
                        }
                        count++;
                        i++;

                        if (count >= noteLength) { flag = false; }
                    }
                    j++;
                }
                else
                {
                    beatStructure[i] = 0.0;
                }
            }
            /*
            for (i = 0; i < beatStructure.Length; i++)
            {
                System.Diagnostics.Debug.WriteLine(beatStructure[i]);
            }
             */
             
                return beatStructure;
        }

        /*
         * PutInTimeData
         * 概要：originalDataをtimeDataにコピーする
         * @param data
         * @return なし
         */

        public void PutInTimeData(DataRetention data)
        {
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
