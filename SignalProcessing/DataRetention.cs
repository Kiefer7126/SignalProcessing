using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class DataRetention{
        public int windowLen = 1024;
        public const int TEXTDATA = 100;
        public const int WAVDATA = 101;

        //判定フラグ(TEXTDATA or WAVDATA)
        public int fileFormat;  
        //オリジナルデータ
        public double[] originalData;
        //オリジナルデータの長さ
        public int originalLen;
        //WindowLength分切り取ったデータ
        public double[] timeData;
    }
}
