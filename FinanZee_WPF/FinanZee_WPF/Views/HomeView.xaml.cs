using System;
using System.Collections.Generic;
using System.Globalization;
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
using static FinanZee_WPF.Models.TransactionModel;

namespace FinanZee_WPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            BasicLogic();
        }

        public void BasicLogic()
        {
            TransactionManagement transactionManagement = new TransactionManagement();

            Transaction[] activos = new Transaction[] { };
            Transaction[] pasivos = new Transaction[] { };
            Transaction[] ingresos = new Transaction[] { };
            Transaction[] egresos = new Transaction[] { };

            var allTransactions = transactionManagement.DownloadTransactions();

            double totalIngresos = 0;
            double totalEgresos = 0;
            double totalActivos = 0;
            double totalPasivos = 0;

            foreach (Transaction transaction in allTransactions)
            {
                //check if the date is from the current month
                if (transaction.type == "Activo")
                {
                    totalActivos += transaction.amount;
                }
                else if (transaction.type == "Pasivo")
                {
                    totalPasivos += transaction.amount;
                }
                else if (transaction.type == "Ingreso" && transaction.date.Month == DateTime.Now.Month)
                {
                    totalIngresos += transaction.amount;
                }
                else if (transaction.type == "Egreso" && transaction.date.Month == DateTime.Now.Month)
                {
                    totalEgresos += transaction.amount;
                }


            }

            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            culture.NumberFormat.CurrencyNegativePattern = 1;

            //format to currency
            string Ingresos = totalIngresos.ToString("C", CultureInfo.CurrentCulture);
            string Egresos = totalEgresos.ToString("C", CultureInfo.CurrentCulture);
            string Activos = totalActivos.ToString("C", CultureInfo.CurrentCulture);
            string Pasivos = totalPasivos.ToString("C", CultureInfo.CurrentCulture);

            var patrimonio = totalActivos - totalPasivos;
            var rentabilidad = totalIngresos - totalEgresos;

            //format to currency
            string Patrimonio=patrimonio.ToString("C", culture);
            string Rentabilidad=rentabilidad.ToString("C", culture);


            lblIngresos.Content = Ingresos;
            lblEgresos.Content = Egresos;
            lblActivos.Content = Activos;
            lblPasivos.Content = Pasivos;
            lblPatrimonio.Content = Patrimonio;
            lblRentabilidad.Content = Rentabilidad;





        }
    }
}
