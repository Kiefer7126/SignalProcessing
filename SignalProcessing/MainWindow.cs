using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalProcessing
{
    public partial class MainWindow : Form
    {
        public DataRetention data;
        private SettingWindow dialog;
        private FileReader reader;
        private Graph graphic;
        private FourierAnalysis fourier;
        private FileWriter writer;
        private GenerateWave generate;
        private WindowFunction window;
        private WaveletAnalysis wavelet;
        private SoundTimeAnalysis soundTime;
        private ChangeOfChordWindow chordDialog;

        double[] soundTimeData1, soundTimeData2, soundTimeData3, soundTimeData4, soundTimeData5, soundTimeData6, soundTimeData7;
        double[] peekTime1, peekTime2, peekTime3, peekTime4, peekTime5, peekTime6, peekTime7, sumPeekTime;

        int beatInterval;
        int gap;

        /**
         * MainWindow
         * 概要：コンストラクタ
         */

        public MainWindow()
        {
            InitializeComponent();
            this.data = new DataRetention();
            this.dialog = new SettingWindow(this.data);
            this.reader = new FileReader();
            this.graphic = new Graph();
            this.fourier = new FourierAnalysis();
            this.writer = new FileWriter();
            this.generate = new GenerateWave();
            this.window = new WindowFunction();
            this.wavelet = new WaveletAnalysis();
            this.soundTime = new SoundTimeAnalysis();

            // 初期表示時に、先頭の項目を選択
            this.waveKindComboBox.SelectedIndex = 0;
         }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
         * preferencesToolStripMenuItem_Click
         * 概要：[File] -> [Preferences]
         * @param sender
         * @param e
         * @return なし
         * 
         */

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dialog.ShowDialog();

        }

        /**
         * textToolStripMenuItem_Click
         * 概要：[File] -> [Import] -> [Text]
         * @param sender
         * @param e
         * @return なし
         */

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.data.fileFormat = DataRetention.TEXTDATA;
            this.reader.ReadTextFile(this.data);
            this.graphic.PlotWaveForm(this.timeGraphPictureBox, this.data);
        }

        /**
        * metricalStructureToolStripMenuItem_Click
        * 概要：[File] -> [Import] -> [metricalStructure]
        * @param sender
        * @param e
        * @return なし
        */
        private void metricalStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.data.fileFormat = DataRetention.TEXTDATA;
            this.reader.ReadMetricalStructure(this.data);
        }

        /**
         * dFTToolStripMenuItem_Click
         * 概要：[Frequency] -> [DFT]
         * @param sender
         * @param e
         * @return なし
         */

        private void dFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double item;

            item = System.Convert.ToDouble(samplingComboBox.SelectedItem);

            int numberOfWindow = data.originalLen / data.shiftLen;
            data.stftData = new double[numberOfWindow , data.windowLen];

            this.fourier.CalDFT(this.data, 0);

            //this.graphic.PlotdBChar(item, this.dBGraphPictureBox, this.data);
            //this.graphic.PlotPhaseChar(item, this.phaseGraphPictureBox, this.data);
            this.graphic.PlotSpectrogram(item, this.spectrogramPictureBox, this.data);
            this.graphic.PlotLegend(this.legendPictureBox, this.data);
        }

        /**
         * wavReadToolStripMenuItem_Click
         * 概要：[File] -> [Import] -> [wav]
         * @param sender 
         * @param e 
         * @return なし
         */

        private void wavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //読み込んだデータ形式のセット
            this.data.fileFormat = DataRetention.WAVDATA;

            //wavデータの読み込み
            this.reader.ReadWavFile(this.data);

            //時間軸グラフ表示
            this.graphic.PlotWaveForm(this.timeGraphPictureBox, this.data);

            //Menuの有効・無効
            if (this.data.originalData != null)
            {
                frequencyToolStripMenuItem.Enabled = true;
                filterToolStripMenuItem.Enabled = false;
                beatTrackingToolStripMenuItem.Enabled = false;
                correlationToolStripMenuItem.Enabled = false;
                chordChangeToolStripMenuItem.Enabled = false;
            }
            
        }

        /**
         * samplingComboBox_SelectedIndexChanged
         * 概要：サンプリング周波数の選択時の処理
         * @param sender 
         * @param e 
         * @return なし
         */

        private void samplingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double item;

            //現在選択されているサンプリング周波数の項目を取得する
            item = System.Convert.ToDouble(samplingComboBox.SelectedItem);

            //dB軸グラフ、位相軸グラフのデータがあれば、
            //サンプリング周波数に合わせて再描画する。
            if (this.data.dBData != null && this.data.phaseData != null)
            {
                //dB軸グラフ表示
                //this.graphic.PlotdBChar(item, this.dBGraphPictureBox, this.data);

                //位相軸グラフ表示
                //this.graphic.PlotPhaseChar(item, this.phaseGraphPictureBox, this.data);
                
                //スペクトログラム表示
                this.graphic.PlotSpectrogram(item, this.spectrogramPictureBox, this.data);
            }
        }

        /**
         * timeGraphToolStripMenuItem_Click
         * 概要：[File] -> [Export] -> [text] -> [TimeGraph]
         * @param sender 
         * @param e 
         * @return なし
         */

        private void timeGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.writer.WriteTextFile(this.data.originalData, DataRetention.TIMEGRAPH);
        }

        /**
         * timeGraphToolStripMenuItem_Click
         * 概要：[File] -> [Export] -> [text] -> [DbGraph]
         * @param sender 
         * @param e 
         * @return なし
         */

        private void dBGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.writer.WriteTextFile(this.data.dBData, DataRetention.FREQGRAPH);
        }

        /**
        * waveKindComboBox_SelectedIndexChanged
        * 概要：生成する波の種類の選択時の処理
        * @param sender 
        * @param e 
        * @return なし
        */

        private void waveKindComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            index = waveKindComboBox.SelectedIndex;

            switch (index)
            {
                case 0:
                    this.data.waveKind = DataRetention.SINE;
                    break;
                case 1:
                    this.data.waveKind = DataRetention.SAW;
                    break;
                case 2:
                    this.data.waveKind = DataRetention.SQUARE;
                    break;
                case 3:
                    this.data.waveKind = DataRetention.SINE2;
                    break;
                case 4:
                    this.data.waveKind = DataRetention.CLICK;
                    break;
                default:
                    break;
            }
        }

        /**
        * generateButton_Click
        * 概要：Generateボタンを押した時の処理
        * @param sender 
        * @param e 
        * @return なし
        */

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (this.data.waveKind == DataRetention.CLICK)
            {
                double[] beatStructure = new double[data.metricalData.Length]; 
                beatStructure = generate.beat(this.data);
                this.writer.WriteClick(44.1, beatStructure);
                this.writer.WriteTextFile(beatStructure, DataRetention.TIMEGRAPH);
            }
            else 
            {
                generate.Processing(this.data, this.data.waveKind);
                this.graphic.PlotWaveForm(this.timeGraphPictureBox, this.data);

                //Menuの有効・無効
                if (this.data.originalData != null)
                {
                    frequencyToolStripMenuItem.Enabled = true;
                    filterToolStripMenuItem.Enabled = false;
                    beatTrackingToolStripMenuItem.Enabled = false;
                    correlationToolStripMenuItem.Enabled = false;
                }
            }

            //MessageBox.Show("waveKind: " + this.data.waveKind);
        }

        /*
         * wavToolStripMenuItem1_Click
         * 概要：[File] -> [Export] -> [wav]
         * @param sender 
         * @param e 
         * @return なし
         */

        private void wavToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            double item;

            //現在選択されているサンプリング周波数の項目を取得する
            item = System.Convert.ToDouble(samplingComboBox.SelectedItem);

            this.writer.WriteWavFile(item, this.data);
        }

        /*
         * hammingToolStripMenuItem_Click
         * 概要：[Frequency] -> [Window] -> [Hamming]
         * @param sender
         * @param e
         * @return なし
         */

        private void hammingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.window.WindowHamming(this.data, 0, 0);
            this.graphic.PlotWaveForm(this.timeGraphPictureBox, this.data);
        }

        /*
         * hanningToolStripMenuItem_Click
         * 概要：[Frequency] -> [Window] -> [Hanning]
         * @param sender
         * @param e
         * @return なし
         */
        private void hanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.window.WindowHanning(this.data, 0, 0);
            this.graphic.PlotWaveForm(this.timeGraphPictureBox, this.data);
        }

        /*
         * gaussianToolStripMenuItem_Click
         * 概要：[Frequency] -> [Window] -> [Gaussian]
         * @param sender
         * @param e
         * @return なし
         */
        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.window.WindowGaussian(this.data, 0, 0);
            this.graphic.PlotWaveForm(this.timeGraphPictureBox, this.data);
        }

        /*
         * sTFTToolStripMenuItem_Click
         * 概要：[Frequency] -> [STFT]
         * @param sender
         * @param e
         * @return なし
         */

        private void sTFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double item;
            item = System.Convert.ToDouble(samplingComboBox.SelectedItem);
            int numberOfWindow = data.originalLen / data.shiftLen;

            if (data.stftData == null)
            {
                data.stftData = new double[numberOfWindow + 1, data.windowLen];

                this.fourier.CalSTFT(this.data);
            }

            //グラフ描画
            //this.graphic.PlotdBChar(item, this.dBGraphPictureBox, this.data);
            //this.graphic.PlotPhaseChar(item, this.phaseGraphPictureBox, this.data);
            this.graphic.PlotSpectrogram(item, this.spectrogramPictureBox, this.data);
            this.graphic.PlotLegend(this.legendPictureBox, this.data);

            //beatTrackingを有効化
            beatTrackingToolStripMenuItem.Enabled = true;
        }

        /*
         * fFTToolStripMenuItem_Click
         * 概要：[Frequency] -> [FFT]
         * @param sender
         * @param e
         * @return なし
         */
        private void fFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double item;
            item = System.Convert.ToDouble(samplingComboBox.SelectedItem);

            int numberOfWindow = data.originalLen / data.shiftLen;
            data.stftData = new double[numberOfWindow + 1, data.windowLen];

            this.fourier.CalFFT(this.data, 0);
            
            //this.graphic.PlotdBChar(item, this.dBGraphPictureBox, this.data);
            //this.graphic.PlotPhaseChar(item, this.phaseGraphPictureBox, this.data);
            this.graphic.PlotSpectrogram(item, this.spectrogramPictureBox, this.data);
            this.graphic.PlotLegend(this.legendPictureBox, this.data);
        }

        /*
         * fWTToolStripMenuItem_Click
         * 概要：[Frequency] -> [FWT]
         * @param sender
         * @param e
         * @return なし
         */

        private void fWTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double item;
            item = System.Convert.ToDouble(samplingComboBox.SelectedItem);

            
            //this.wavelet.CalGWT(this.data);

            //ウェーブレット変換
            this.wavelet.CalFWT(data.originalData, data.originalLen);

            //レベル1グラフの描画
            this.graphic.PlotWaveletGraph(this.waveletGraphLevel1PictureBox, wavelet.w1, data.windowLen/2);

            //ウェーブレット変換
            this.wavelet.CalFWT(wavelet.s1, data.originalLen/2);

            //レベル2グラフの描画
            this.graphic.PlotWaveletGraph(this.waveletGraphLevel2PictureBox, wavelet.w1, data.windowLen / 4);
 
            //ウェーブレット変換
            this.wavelet.CalFWT(wavelet.s1, data.originalLen / 4);

            //レベル3グラフの描画
            this.graphic.PlotWaveletGraph(this.waveletGraphLevel3PictureBox, wavelet.w1, data.windowLen / 8);
 
            //ウェーブレット変換
            this.wavelet.CalFWT(wavelet.s1, data.originalLen / 8);

            //レベル4グラフの描画
            this.graphic.PlotWaveletGraph(this.waveletGraphLevel4PictureBox, wavelet.w1, data.windowLen / 16);

            this.wavelet.CalGWT(this.data.originalData, this.data.originalLen, this.data.ofSmpf, this.data.shiftLen, this.data.sigma);
            this.graphic.PlotSpectrogramEdit(this.data.ofSmpf, this.spectrogramPictureBox, this.wavelet.wt, this.wavelet.numberOfWindow, this.data.shiftLen, this.wavelet.freqLen);

            //this.graphic.PlotLegend(this.legendPictureBox, this.data);
        }

        /*
          * soundTimeAnalysisToolStripMenuItem_Click
          * 概要：[BeatTracking] -> [SoundTimeAnalysis]
          * @param sender
          * @param e
          * @return なし
          */

        private void soundTimeAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
             int numberOfWindow = data.originalLen / data.shiftLen;
             soundTimeData1 = new double[numberOfWindow + 1];
             soundTimeData2 = new double[numberOfWindow + 1];
             soundTimeData3 = new double[numberOfWindow + 1];
             soundTimeData4 = new double[numberOfWindow + 1];
             soundTimeData5 = new double[numberOfWindow + 1];
             soundTimeData6 = new double[numberOfWindow + 1];
             soundTimeData7 = new double[numberOfWindow + 1];

            //0-125の発音時間
             soundTimeData1 = this.soundTime.RisingComponentAnalysis(data.stftData, numberOfWindow + 1, data.windowLen, 0, 125, this.data.ofSmpf);
             this.graphic.PlotSoundTimeGraph(this.soundTimeTo125PictureBox, soundTimeData1, numberOfWindow + 1);

             //125-250の発音時間
             soundTimeData2 = this.soundTime.RisingComponentAnalysis(data.stftData, numberOfWindow + 1, data.windowLen, 125, 250, this.data.ofSmpf);
             this.graphic.PlotSoundTimeGraph(this.soundTimeTo250PictureBox, soundTimeData2, numberOfWindow + 1);

             //250-500の発音時間
             soundTimeData3 = this.soundTime.RisingComponentAnalysis(data.stftData, numberOfWindow + 1, data.windowLen, 250, 500, this.data.ofSmpf);
             this.graphic.PlotSoundTimeGraph(this.soundTimeTo500PictureBox, soundTimeData3, numberOfWindow + 1);

             //500-1kの発音時間
             soundTimeData4 = this.soundTime.RisingComponentAnalysis(data.stftData, numberOfWindow + 1, data.windowLen, 500, 1000, this.data.ofSmpf);
             this.graphic.PlotSoundTimeGraph(this.soundTimeTo1kPictureBox, soundTimeData4, numberOfWindow + 1);

             //1k-2kの発音時間
             soundTimeData5 = this.soundTime.RisingComponentAnalysis(data.stftData, numberOfWindow + 1, data.windowLen, 1000, 2000, this.data.ofSmpf);
             this.graphic.PlotSoundTimeGraph(this.soundTimeTo2kPictureBox, soundTimeData5, numberOfWindow + 1);

             //2k-4kの発音時間
             soundTimeData6 = this.soundTime.RisingComponentAnalysis(data.stftData, numberOfWindow + 1, data.windowLen, 2000, 4000, this.data.ofSmpf);
             this.graphic.PlotSoundTimeGraph(this.soundTimeTo4kPictureBox, soundTimeData6, numberOfWindow + 1);

             //4k-11kの発音時間
             soundTimeData7 = this.soundTime.RisingComponentAnalysis(data.stftData, numberOfWindow + 1, data.windowLen, 4000, 11000, this.data.ofSmpf);
             this.graphic.PlotSoundTimeGraph(this.soundTimeTo11kPictureBox, soundTimeData7, numberOfWindow + 1);

             //Filterを有効化
             filterToolStripMenuItem.Enabled = true;
        }

        /*
         * sGFToolStripMenuItem_Click
         * 概要：[Filter] -> [SGF]
         * @param sender
         * @param e
         * @return なし
         */

        private void sGFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int smoothingNumber = 11;
            int numberOfWindow = data.originalLen / data.shiftLen;
            peekTime1 = new double[numberOfWindow + 1];
            peekTime2 = new double[numberOfWindow + 1];
            peekTime3 = new double[numberOfWindow + 1];
            peekTime4 = new double[numberOfWindow + 1];
            peekTime5 = new double[numberOfWindow + 1];
            peekTime6 = new double[numberOfWindow + 1];
            peekTime7 = new double[numberOfWindow + 1];
            sumPeekTime = new double[numberOfWindow + 1];

            //0-125の発音時間
            peekTime1 = this.soundTime.SavitzkyGolayFilter(soundTimeData1, smoothingNumber, numberOfWindow + 1);
            peekTime1 = this.soundTime.PeekDetection(peekTime1, numberOfWindow + 1);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo125PictureBox, peekTime1, numberOfWindow + 1);

            //125-250の発音時間
            peekTime2 = this.soundTime.SavitzkyGolayFilter(soundTimeData2, smoothingNumber, numberOfWindow + 1);
            peekTime2 = this.soundTime.PeekDetection(peekTime2, numberOfWindow + 1);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo250PictureBox, peekTime2, numberOfWindow + 1);

            //250-500の発音時間
            peekTime3 = this.soundTime.SavitzkyGolayFilter(soundTimeData3, smoothingNumber, numberOfWindow + 1);
            peekTime3 = this.soundTime.PeekDetection(peekTime3, numberOfWindow + 1);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo500PictureBox, peekTime3, numberOfWindow + 1);

            //500-1kの発音時間
            peekTime4 = this.soundTime.SavitzkyGolayFilter(soundTimeData4, smoothingNumber, numberOfWindow + 1);
            peekTime4 = this.soundTime.PeekDetection(peekTime4, numberOfWindow + 1);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo1kPictureBox, peekTime4, numberOfWindow + 1);

            //1k-2kの発音時間
            peekTime5 = this.soundTime.SavitzkyGolayFilter(soundTimeData5, smoothingNumber, numberOfWindow + 1);
            peekTime5 = this.soundTime.PeekDetection(peekTime5, numberOfWindow + 1);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo2kPictureBox, peekTime5, numberOfWindow + 1);

            //2k-4kの発音時間
            peekTime6 = this.soundTime.SavitzkyGolayFilter(soundTimeData6, smoothingNumber, numberOfWindow + 1);
            peekTime6 = this.soundTime.PeekDetection(peekTime6, numberOfWindow + 1);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo4kPictureBox, peekTime6, numberOfWindow + 1);

            //4k-11kの発音時間
            peekTime7 = this.soundTime.SavitzkyGolayFilter(soundTimeData7, smoothingNumber, numberOfWindow + 1);
            peekTime7 = this.soundTime.PeekDetection(peekTime7, numberOfWindow + 1);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo11kPictureBox, peekTime7, numberOfWindow + 1);
        
            //自己相関の有効化
            correlationToolStripMenuItem.Enabled = true;


            //発音時刻ベクトルの全次元の要素の和
            for(int i = 0; i < sumPeekTime.Length; i++)
            {
                sumPeekTime[i] = (peekTime1[i] + peekTime2[i] + peekTime3[i] + peekTime4[i] + peekTime5[i] + peekTime6[i] + peekTime7[i])/7;
            }

            this.graphic.PlotSoundTimeGraph(this.soundTimeSumPictureBox, sumPeekTime, sumPeekTime.Length);
        }

        /*
         * autocorrelationToolStripMenuItem_Click
         * 概要：[BeatTracking] -> [Autocorrelation]
         * @param sender
         * @param e
         * @return なし
         */

        private void autocorrelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int numberOfWindow = data.originalLen / data.shiftLen;
            int smoothingNumber = 11;
            double[] R1 = new double[numberOfWindow + 1];
            double[] R2 = new double[numberOfWindow + 1];
            double[] R3 = new double[numberOfWindow + 1];
            double[] R4 = new double[numberOfWindow + 1];
            double[] R5 = new double[numberOfWindow + 1];
            double[] R6 = new double[numberOfWindow + 1];
            double[] R7 = new double[numberOfWindow + 1];
            double[] Rsum = new double[numberOfWindow + 1];
            double[] beat4 = new double[numberOfWindow + 1];
            double[] Rbeat4 = new double[numberOfWindow + 1];

            R1 = this.soundTime.AutocorrelationFunction(R1.Length, peekTime1, peekTime1);
            //R1 = this.soundTime.SavitzkyGolayFilter(R1, smoothingNumber, R1.Length);
            //R1 = this.soundTime.PeekDetection(R1, R1.Length);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo125PictureBox, R1, R1.Length);

            R2 = this.soundTime.AutocorrelationFunction(R2.Length, peekTime2, peekTime2);
            //R2 = this.soundTime.SavitzkyGolayFilter(R2, smoothingNumber, R2.Length);
            //R2 = this.soundTime.PeekDetection(R2, R2.Length);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo250PictureBox, R2, R2.Length);

            R3 = this.soundTime.AutocorrelationFunction(R3.Length, peekTime3, peekTime3);
            //R3 = this.soundTime.SavitzkyGolayFilter(R3, smoothingNumber, R3.Length);
            //R3 = this.soundTime.PeekDetection(R3, R3.Length);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo500PictureBox, R3, R3.Length);

            R4 = this.soundTime.AutocorrelationFunction(R4.Length, peekTime4, peekTime4);
            //R4 = this.soundTime.SavitzkyGolayFilter(R4, smoothingNumber, R4.Length);
            //R4 = this.soundTime.PeekDetection(R4, R4.Length);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo1kPictureBox, R4, R4.Length);

            R5 = this.soundTime.AutocorrelationFunction(R5.Length, peekTime5, peekTime5);
            //R5 = this.soundTime.SavitzkyGolayFilter(R5, smoothingNumber, R5.Length);
            //R5 = this.soundTime.PeekDetection(R5, R5.Length);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo2kPictureBox, R5, R5.Length);

            R6 = this.soundTime.AutocorrelationFunction(R6.Length, peekTime6, peekTime6);
            //R6 = this.soundTime.SavitzkyGolayFilter(R6, smoothingNumber, R6.Length);
            //R7 = this.soundTime.PeekDetection(R6, R6.Length);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo4kPictureBox, R6, R6.Length);

            R7 = this.soundTime.AutocorrelationFunction(R7.Length, peekTime7, peekTime7);
            //R7 = this.soundTime.SavitzkyGolayFilter(R7, smoothingNumber, R7.Length);
            //R7 = this.soundTime.PeekDetection(R7, R7.Length);
            this.graphic.PlotSoundTimeGraph(this.soundTimeTo11kPictureBox, R7, R7.Length);

            Rsum = this.soundTime.AutocorrelationFunction(Rsum.Length, sumPeekTime, sumPeekTime);
            Rsum = this.soundTime.SavitzkyGolayFilter(Rsum, smoothingNumber, Rsum.Length);
            Rsum = this.soundTime.PeekDetection(Rsum, Rsum.Length);
            this.graphic.PlotSoundTimeGraph(this.soundTimeSumPictureBox, Rsum, Rsum.Length);


            //ビート時刻系列の作成
            beatInterval = this.soundTime.BeetTimeDetection(Rsum);
            beat4 = this.soundTime.makeBeat(beat4, 0, beatInterval);

            //ビート時刻系列と全次元発音時刻ベクトルとのズレ
            Rbeat4 = this.soundTime.AutocorrelationFunction(beat4.Length, beat4, sumPeekTime);
            Rbeat4 = this.soundTime.SavitzkyGolayFilter(Rbeat4, smoothingNumber, Rbeat4.Length);
            Rbeat4 = this.soundTime.PeekDetection(Rbeat4, Rbeat4.Length);
            gap = this.soundTime.BeetTimeDetection(Rbeat4);

            //ビート時刻系列の上書き
            beat4 = this.soundTime.makeBeat(beat4, gap, beatInterval);
            this.graphic.PlotSoundTimeGraph(this.beatTimePictureBox, beat4, beat4.Length);

            //ChordChangeメニューの有効化
            chordChangeToolStripMenuItem.Enabled = true;
        }

        private void chordChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chordDialog = new ChangeOfChordWindow(this.gap, this.beatInterval, this.data.stftData);
            this.chordDialog.ShowDialog();
        }
    }
}
