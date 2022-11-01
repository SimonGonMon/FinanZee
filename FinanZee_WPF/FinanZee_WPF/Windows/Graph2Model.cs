using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinanZee_WPF.Models.TransactionModel;

namespace FinanZee_WPF.Windows
{
    [ObservableObject]
    public partial class Graph2Model
    {
        public Graph2Model()
        {
            TransactionManagement transactionManagement = new TransactionManagement();

            Transaction[] transactionsPositive = new Transaction[] { };
            Transaction[] transactionsNegative = new Transaction[] { };

            var allTransactions = transactionManagement.DownloadTransactions();

            foreach (Transaction transaction in allTransactions)
            {
                if (transaction.type == "Activo")
                {
                    Array.Resize(ref transactionsPositive, transactionsPositive.Length + 1);
                    transactionsPositive[transactionsPositive.Length - 1] = transaction;
                }

                if (transaction.type == "Pasivo")
                {
                    Array.Resize(ref transactionsNegative, transactionsNegative.Length + 1);
                    transactionsNegative[transactionsNegative.Length - 1] = transaction;
                }
            }

            //sort the arrays by date
            Array.Sort(transactionsPositive, delegate (Transaction x, Transaction y)
            {
                return x.date.CompareTo(y.date);
            });

            Array.Sort(transactionsNegative, delegate (Transaction x, Transaction y)
            {
                return x.date.CompareTo(y.date);
            });

            Console.WriteLine("Positive transactions: " + "[" + transactionsPositive.Length + "]");
            foreach (Transaction transaction in transactionsPositive)
            {
                Console.WriteLine(transaction);
            }

            Console.WriteLine("Negative transactions: " + "[" + transactionsNegative.Length + "]");
            foreach (Transaction transaction in transactionsNegative)
            {
                Console.WriteLine(transaction);
            }

            YAxes = new[]
            {
                new Axis
                {
                    Name = "Monto",
                    NamePadding = new LiveChartsCore.Drawing.Padding(0, 15),

                    // Use the Labeler property to give format to the axis values 
                    // Now the Y axis we will display it as currency
                    // LiveCharts provides some common formatters
                    // in this case we are using the currency formatter.
                    Labeler = Labelers.Currency 

                    // you could also build your own currency formatter
                    // for example:
                    // Labeler = (value) => value.ToString("C")

                    // But the one that LiveCharts provides creates shorter labels when
                    // the amount is in millions or trillions
                }
            };

            XAxes = new[]
            {
                new Axis
                {
                    //Name = "Fecha",
                    NamePadding = new LiveChartsCore.Drawing.Padding(0, 15),
                    LabelsRotation = 45,

             
                    //Labeler = (value) => transactionsPositive[(int)value].date.ToString("dd/MM/yyyy")
                    



                }

            };



            SeriesCollection = new ISeries[]
            {
                new LineSeries<Transaction>
                {
                    Name = "Activos",
                    Values = transactionsPositive,
                    //Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 3 },
                    Fill = null,
                    //GeometryFill = null,
                    //GeometryStroke = null,
                    //GeometrySize = 20,
                    TooltipLabelFormatter = point => $"{point.Model.date.ToString("dd/MM/yyyy")} | Activo | ${point.Model.amount} | Extra: {point.Model.extra}",
                    Mapping = (Transaction, point) =>
                    {
                        point.PrimaryValue = (float)Transaction.amount;
                        point.SecondaryValue = point.Context.Index;
                    }
                },
                new LineSeries<Transaction>
                {
                    Name = "Pasivos",
                    Values = transactionsNegative,
                    //Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 3 },
                    Fill = null,
                    //GeometryFill = null,
                    //GeometryStroke = null,
                    //GeometrySize = 20,
                    TooltipLabelFormatter = point => $"{point.Model.date.ToString("dd/MM/yyyy")} | Pasivo | ${point.Model.amount} | Extra: {point.Model.extra}",
                    Mapping = (Transaction, point) =>
                    {
                        point.PrimaryValue = (float)Transaction.amount;
                        point.SecondaryValue = point.Context.Index;
                    }
                },


             };






        }

        public ISeries[] SeriesCollection { get; set; }
        public Axis[] YAxes { get; set; }

        public Axis[] XAxes { get; set; }



    }
}