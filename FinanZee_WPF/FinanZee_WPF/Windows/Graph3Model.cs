using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinanZee_WPF.Models.TransactionModel;
using LiveChartsCore.SkiaSharpView.Painting;
using Newtonsoft.Json.Linq;
using SkiaSharp;
using System.Transactions;
using Transaction = FinanZee_WPF.Models.TransactionModel.Transaction;

namespace FinanZee_WPF.Windows
{
    public partial class Graph3Model
    {
        public Graph3Model()
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
                   if (transaction.type == "Activo")
                {
                    totalActivos += transaction.amount;
                }
                else if (transaction.type == "Pasivo")
                {
                    totalPasivos += transaction.amount;
                }
                else if (transaction.type == "Ingreso")
                {
                    totalIngresos += transaction.amount;
                }
                else if (transaction.type == "Egreso")
                {
                    totalEgresos += transaction.amount;
                }


            }

            var data = new double[] { totalActivos, totalPasivos, totalIngresos, totalEgresos };
            Console.WriteLine(data[0] + " " + data[1] + " " + data[2] + " " + data[3]);

            double totalTotal = totalActivos + totalPasivos + totalIngresos + totalEgresos;

            SeriesCollection = new ISeries[]
             {
                 new PieSeries<double> { Values = new double[] {totalIngresos}, Name = "Ingresos" },
                 new PieSeries<double> { Values = new double[] {totalEgresos}, Name = "Egresos" },

             };


        }

        public IEnumerable<ISeries> SeriesCollection { get; set; }


    }
}