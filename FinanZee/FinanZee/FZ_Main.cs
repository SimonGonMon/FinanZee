using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;

namespace FinanZee
{
    public partial class FZ_Main : Form
    {
        public FZ_Main()
        {
            InitializeComponent();
            pieChart1.Series = new ISeries[]
{
    new PieSeries<double> { Values = new double[] { 2 } },
    new PieSeries<double> { Values = new double[] { 4 } },
    new PieSeries<double> { Values = new double[] { 1 } },
    new PieSeries<double> { Values = new double[] { 4 } },
    new PieSeries<double> { Values = new double[] { 3 } }
};

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pieChart1_Load(object sender, EventArgs e)
        {

        }
    }
}
