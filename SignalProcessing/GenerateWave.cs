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
         *        flag
         * @return なし
         */
        public void Processing (DataRetention data, int flag)
        {
            data.timeData = new double[data.windowLen];

            for (int n = 0; n < data.windowLen; n++)
            {
                switch (flag)
                {
                    case DataRetention.SINE:
                        data.timeData[n] = data.amplitude * Math.Sin((2.0 * Math.PI * data.fundamentalFreq * n) / data.samplingFreq);
                        break;
                    case DataRetention.SAW:
                        for (int i = 1; i <= data.harmonic; i++)
                        {
                            data.timeData[n] = data.timeData[n] + (data.amplitude / i) * Math.Sin(2.0 * Math.PI * data.fundamentalFreq * i * n / data.samplingFreq);
                        } 
                        break;
                    case DataRetention.SQUARE:
                        for (int i = 1; i <= data.harmonic; i++)
                        {
                            data.timeData[n] = data.timeData[n] + (data.amplitude / (2 * i - 1) ) * Math.Sin(2.0 * Math.PI * data.fundamentalFreq * (2 * i - 1) * n / data.samplingFreq);
                        } 
                        break;
                }
            }
        }
    }
}
