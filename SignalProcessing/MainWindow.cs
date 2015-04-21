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
    }
}
