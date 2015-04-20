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
        //フーリエ変換後の複素数データ
        public double[] realData;
        public double[] imagData;
        //周波数軸グラフ(パワー)描画に用いるデータ
        public double[] powerData;
        //周波数軸グラフ(dB)描画に用いるデータ
        public double[] dBData;
        //dBの最大値
        public double dBDataMax;
        //周波数軸グラフ(位相)描画に用いるデータ
        public double[] phaseData;
        //位相の最大値
        public double phaseDataMax;

        //wavの実チャンクデータ
        public byte[] orChunkId;
        public int orChunkSize;
        public byte[] orFormat;
        public byte[] ofChunkId;
        public int ofChunkSize;
        public short ofAudio;
        public short ofCh;
        public int ofSmpf;
        public int ofByteRate;
        public short ofBlockSize;
        public short ofBits;
        public byte[] odChunkId;
        public int odChunkSize;
    }
}
