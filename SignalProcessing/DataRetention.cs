using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class DataRetention{
        
        public const int TEXTDATA = 100;
        public const int WAVDATA = 101;
        public const int TIMEGRAPH = 200;
        public const int FREQGRAPH = 201;
        public const int SINE = 300;
        public const int SAW = 301;
        public const int SQUARE = 302;
        public const int SPECTRO = 401;

        //注意：FFTの処理でFFTとIFFTの値を使用する
        public const int FFT = 1;
        public const int IFFT = -1;
        
        //window幅
        public int windowLen = 1024;
        //シフト幅
        public int shiftLen = 512;
        //短時間フーリエ変換結果
        public double[,] stftData;
        //判定フラグ(TEXTDATA or WAVDATA)
        public int fileFormat;  
        //オリジナルデータ
        public double[] originalData;
        //オリジナルデータの長さ[byte]
        public int originalLen;
        //オリジナルデータの長さ[s]
        public int originalTime_s;
        //周波数の間隔[Hz]
        public float fScale_Hz;
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

        //生成したデータ
        public double[] generatingData;
        //判定フラグ(SINE, SAW or SQUARE)
        public int waveKind;
        //振幅
        public double amplitude = 500.0;
        //基本周波数
        public double fundamentalFreq = 250.0;
        //
        public double harmonic = 10000.0;
        //サンプリング周波数
        public double samplingFreq = 8000.0;
    }
}
