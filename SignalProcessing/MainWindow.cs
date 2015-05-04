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
         * 引数：sender
         *          e
         * 戻り値：なし
         * 
         */

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dialog.ShowDialog();

        }

        /**
         * textToolStripMenuItem_Click
         * 概要：[Frequency] -> [Import] -> [Text]
         * 引数：sender
         *          e
         * 戻り値：なし
         */

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.data.fileFormat = DataRetention.TEXTDATA;
            this.reader.ReadFile(this.data);
            this.graphic.PlotWaveForm(this.timeGraphPictureBox, this.data);
        }

        /**
         * dFTToolStripMenuItem_Click
         * 概要：[File] -> [DFT]
         * 引数：sender
         *          e
         * 戻り値：なし
         */

        private void dFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double item;

            item = System.Convert.ToDouble(samplingComboBox.SelectedItem);

            this.fourier.CalDFT(this.data);

            this.graphic.PlotdBChar(item, this.dBGraphPictureBox, this.data);
            this.graphic.PlotPhaseChar(item, this.phaseGraphPictureBox, this.data);
            this.graphic.PlotSpectrogram(item, this.spectrogramPictureBox, this.data, DataRetention.SPECTRO);

        }

        /**
         * wavReadToolStripMenuItem_Click
         * 概要：[File] -> [Import] -> [wav]
         * 引数：sender 
         *       e 
         * 戻り値：なし
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
         * 引数：sender 
         *       e 
         * 戻り値：なし
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

                this.graphic.PlotSpectrogram(item, this.spectrogramPictureBox, this.data, DataRetention.SPECTRO);
            }
        }

        private void timeGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.writer.WriteFile(this.data, DataRetention.TIMEGRAPH);
        }

        private void dBGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.writer.WriteFile(this.data, DataRetention.FREQGRAPH);
        }

        /**
        * waveKindComboBox_SelectedIndexChanged
        * 概要：生成する波の種類の選択時の処理
        * 引数：sender 
        *       e 
        * 戻り値：なし
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
                default:
                    break;
            }
        }

        /**
        * generateButton_Click
        * 概要：Generateボタンを押した時の処理
        * 引数：sender 
        *       e 
        * 戻り値：なし
        */

        private void generateButton_Click(object sender, EventArgs e)
        {
            generate.Processing(this.data, this.data.waveKind);
            this.graphic.PlotWaveForm(this.timeGraphPictureBox, this.data);

            //MessageBox.Show("waveKind: " + this.data.waveKind);
        }
    }
}
