using FinanZee_WPF.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinanZee_WPF.Views
{
    /// <summary>
    /// Interaction logic for MetricsView.xaml
    /// </summary>
    public partial class MetricsView : UserControl
    {
        int windowCounter;
        
        public MetricsView()
        {
            InitializeComponent();
            windowCounter = 0;
            lblTitle.Content = "Ingresos / Egresos";
            wndGraph1.Visibility = Visibility.Visible;
            wndGraph2.Visibility = Visibility.Collapsed;
            wndGraph3.Visibility = Visibility.Collapsed;
            wndGraph4.Visibility = Visibility.Collapsed;


        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            windowCounter++;

            if (windowCounter == 5)
            {
                windowCounter = 4;
            }

            //for each value of windowCounter set opacity of such wndGraph to 0 or 100
            //and set opacity of the other to 100 or 0
            switch (windowCounter)
            {
                case 1:
                    wndGraph1.Visibility = Visibility.Visible;
                    lblTitle.Content = "Ingresos / Egresos";
                    wndGraph2.Visibility = Visibility.Collapsed;
                    wndGraph3.Visibility = Visibility.Collapsed;
                    wndGraph4.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    wndGraph1.Visibility = Visibility.Collapsed;
                    wndGraph2.Visibility = Visibility.Visible;
                    lblTitle.Content = "Activos / Pasivos";
                    wndGraph3.Visibility = Visibility.Collapsed;
                    wndGraph4.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    wndGraph1.Visibility = Visibility.Collapsed;
                    wndGraph2.Visibility = Visibility.Collapsed;
                    wndGraph3.Visibility = Visibility.Visible;
                    lblTitle.Content = "Distribucion Ingresos / Egresos";
                    wndGraph4.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    wndGraph1.Visibility = Visibility.Collapsed;
                    wndGraph2.Visibility = Visibility.Collapsed;
                    wndGraph3.Visibility = Visibility.Collapsed;
                    wndGraph4.Visibility = Visibility.Visible;
                    lblTitle.Content = "Distribucion Activos / Pasivos";
                    break;
                default:
                    windowCounter = 0;
                    wndGraph1.Visibility = Visibility.Visible;
                    wndGraph2.Visibility = Visibility.Collapsed;
                    wndGraph3.Visibility = Visibility.Collapsed;
                    wndGraph4.Visibility = Visibility.Collapsed;
                    break;
            }

        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            
            windowCounter--;

            if (windowCounter < 0)
            {
                windowCounter = 0;
            }

            switch (windowCounter)
            {
                case 1:
                    wndGraph1.Visibility = Visibility.Visible;
                    lblTitle.Content = "Ingresos / Egresos";
                    wndGraph2.Visibility = Visibility.Collapsed;
                    wndGraph3.Visibility = Visibility.Collapsed;
                    wndGraph4.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    wndGraph1.Visibility = Visibility.Collapsed;
                    wndGraph2.Visibility = Visibility.Visible;
                    lblTitle.Content = "Activos / Pasivos";
                    wndGraph3.Visibility = Visibility.Collapsed;
                    wndGraph4.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    wndGraph1.Visibility = Visibility.Collapsed;
                    wndGraph2.Visibility = Visibility.Collapsed;
                    wndGraph3.Visibility = Visibility.Visible;
                    lblTitle.Content = "Distribucion Ingresos / Egresos";
                    wndGraph4.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    wndGraph1.Visibility = Visibility.Collapsed;
                    wndGraph2.Visibility = Visibility.Collapsed;
                    wndGraph3.Visibility = Visibility.Collapsed;
                    wndGraph4.Visibility = Visibility.Visible;
                    lblTitle.Content = "Distribucion Activos / Pasivos";
                    break;
                default:
                    windowCounter = 0;
                    wndGraph1.Visibility = Visibility.Visible;
                    wndGraph2.Visibility = Visibility.Collapsed;
                    wndGraph3.Visibility = Visibility.Collapsed;
                    wndGraph4.Visibility = Visibility.Collapsed;
                    break;
            }

        }
    }
}
