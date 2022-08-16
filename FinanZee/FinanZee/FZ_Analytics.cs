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

namespace FinanZee
{
    public partial class FZ_Analytics : Form
    {
        public FZ_Analytics()
        {
            InitializeComponent();
            cartesianChart1.Series = new ISeries[]
{
                new LineSeries<double>
                {
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null
                }
};

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void cartesianChart1_Load(object sender, EventArgs e)
        {

        }
    }
}
