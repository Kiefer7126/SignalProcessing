using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class WindowFunction
    {
        /*
         * WindowHamming
         * 概要：ハミング窓をかける
         * @param data 
         * @return なし
         */

        public void WindowHamming (DataRetention data)
        {
            int i;
            //ハミング窓関数データ
            double[] hamming;
            //ハミング窓をかけた後のデータの一時格納用
            double[] windowData;

            try
            {
                if (data.timeData == null)
                {
                    throw new System.Exception();
                }

                hamming = new double[data.windowLen];
                windowData = new double[data.windowLen];

                for (i = 0; i < data.windowLen; i++)
                {
                    hamming[i] = 0.54 - 0.46 * (System.Math.Cos( (2 * System.Math.PI * i) / (data.windowLen - 1) ) );

                    windowData[i] = hamming[i] * data.timeData[i];
                    data.timeData[i] = windowData[i];
                }

            }
            catch (Exception e)
            {

            }
        }

        /*
         * WindowHanning
         * 概要：ハニング窓をかける
         * @param data 
         * @return なし
         */

        public void WindowHanning(DataRetention data)
        {
            int i;
            //ハニング窓関数データ
            double[] hanning;
            //ハニング窓をかけた後のデータの一時格納用
            double[] windowData;

            try
            {
                if (data.timeData == null)
                {
                    throw new System.Exception();
                }

                hanning = new double[data.windowLen];
                windowData = new double[data.windowLen];

                for (i = 0; i < data.windowLen; i++)
                {
                    hanning[i] = 0.5 - 0.5 * (System.Math.Cos((2 * System.Math.PI * i) / (data.windowLen - 1)));

                    windowData[i] = hanning[i] * data.timeData[i];
                    data.timeData[i] = windowData[i];
                }

            }
            catch (Exception e)
            {

            }
        }

        /*
         * WindowGaussian
         * 概要：ガウス窓をかける
         * @param data
         * @return なし
         */

        public void WindowGaussian(DataRetention data)
        {
            int i;
            //ガウス窓関数データ
            double[] gaussian;
            //ガウス窓をかけた後のデータの一時格納用
            double[] windowData;

            try
            {
                if (data.timeData == null)
                {
                    throw new System.Exception();
                }

                gaussian = new double[data.windowLen];
                windowData = new double[data.windowLen];

                for (i = 0; i < data.windowLen; i++)
                {
                    //gaussian[i] = System.Math.Exp((-0.2 / System.Math.Sqrt(data.windowLen)) * System.Math.Sqrt((i - (data.windowLen / 2)) * (i - (data.windowLen / 2))));

                    gaussian[i] = System.Math.Exp((-20.0 / ((data.windowLen - 1) * (data.windowLen - 1))) * ((i - ((data.windowLen - 1) / 2)) * (i - ((data.windowLen - 1) / 2))));

                    windowData[i] = gaussian[i] * data.timeData[i];
                    data.timeData[i] = windowData[i];
                }

            }
            catch (Exception e)
            {

            }
        }

    }
}
