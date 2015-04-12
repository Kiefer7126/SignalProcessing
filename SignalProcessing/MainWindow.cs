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


        }
    }
}
