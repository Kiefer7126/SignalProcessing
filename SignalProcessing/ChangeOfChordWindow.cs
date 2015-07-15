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
    public partial class ChangeOfChordWindow : Form
    {
        private Graph graphic;
        private ChordChange chord;

        private double[,] chordData;

        private double gap;
        private int beatInterval;

        public ChangeOfChordWindow(int gap, int beatInterval, double[,] stftData)
        {
            InitializeComponent();
            this.graphic = new Graph();
            this.chord = new ChordChange();

            this.gap = (double)gap / (double)stftData.GetLength(0);
            this.beatInterval = beatInterval;

            chordData = new double[stftData.GetLength(0) / beatInterval, stftData.GetLength(1)];

            chordData = this.chord.ToHistogramData(stftData, beatInterval);
            this.graphic.PlotHistogram(histogramPictureBox, chordData, this.gap, beatInterval);
        }

        private void peekDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] peekChordData = new double[chordData.GetLength(0), chordData.GetLength(1)];
            peekChordData = this.chord.ChordPeekDetection(chordData);
            this.graphic.PlotHistogram(histogramPictureBox, peekChordData, gap, beatInterval);
        }
    }
}
