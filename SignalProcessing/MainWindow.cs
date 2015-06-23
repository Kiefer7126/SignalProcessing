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
         * 概要：[Frequency] -> [Import] -> [Text]
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
         * dFTToolStripMenuItem_Click
         * 概要：[File] -> [DFT]
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

            this.graphic.PlotdBChar(item, this.dBGraphPictureBox, this.data);
            this.graphic.PlotPhaseChar(item, this.phaseGraphPictureBox, this.data);
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
                this.graphic.PlotdBChar(item, this.dBGraphPictureBox, this.data);

                //位相軸グラフ表示
                this.graphic.PlotPhaseChar(item, this.phaseGraphPictureBox, this.data);
                //スペクトログラム表示
                this.graphic.PlotSpectrogram(item, this.spectrogramPictureBox, this.data);
            }
        }

        private void timeGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.writer.WriteTextFile(this.data, DataRetention.TIMEGRAPH);
        }

        private void dBGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.writer.WriteTextFile(this.data, DataRetention.FREQGRAPH);
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
            generate.Processing(this.data, this.data.waveKind);
            this.graphic.PlotWaveForm(this.timeGraphPictureBox, this.data);

            //MessageBox.Show("waveKind: " + this.data.waveKind);
        }

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
          
            data.stftData = new double[numberOfWindow+1, data.windowLen];

            this.fourier.CalSTFT(this.data);

            //グラフ描画
            this.graphic.PlotdBChar(item, this.dBGraphPictureBox, this.data);
            this.graphic.PlotPhaseChar(item, this.phaseGraphPictureBox, this.data);
            this.graphic.PlotSpectrogram(item, this.spectrogramPictureBox, this.data);
            this.graphic.PlotLegend(this.legendPictureBox, this.data);
        }

        private void fFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double item;
            item = System.Convert.ToDouble(samplingComboBox.SelectedItem);

            int numberOfWindow = data.originalLen / data.shiftLen;
            data.stftData = new double[numberOfWindow + 1, data.windowLen];

            this.fourier.CalFFT(this.data, 0);
            
            this.graphic.PlotdBChar(item, this.dBGraphPictureBox, this.data);
            this.graphic.PlotPhaseChar(item, this.phaseGraphPictureBox, this.data);
            this.graphic.PlotSpectrogram(item, this.spectrogramPictureBox, this.data);
            this.graphic.PlotLegend(this.legendPictureBox, this.data);
        }

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
    }
}
