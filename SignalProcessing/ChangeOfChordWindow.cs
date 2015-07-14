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

        public ChangeOfChordWindow(int gap, int beatInterval, double[,] stftData)
        {
            InitializeComponent();
            this.graphic = new Graph();

            this.graphic.PlotHistogram(histogramPictureBox, stftData, gap, beatInterval);
        }
    }
}
