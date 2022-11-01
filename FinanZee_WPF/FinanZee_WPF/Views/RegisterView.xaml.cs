using FinanZee_WPF.Models;
using FinanZee_WPF.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static FinanZee_WPF.Models.TransactionModel;

namespace FinanZee_WPF.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
            loadTransactionsData();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TransactionModel transactionModel = new TransactionModel();
            TransactionManagement transactionManagement = new TransactionManagement();

            lblStatusEmail.Content = "";
            string amount = textBoxAmount.Text.Trim();
            string type = comboBox.SelectedValue.ToString();
            DateTime transactionDate = datePickerReminder.SelectedDate.Value;

            if (amount == null || amount == "" || datePickerReminder.SelectedDate == null)
            {
                lblStatusEmail.Foreground = new BrushConverter().ConvertFromString("#cc0000") as SolidColorBrush;
                lblStatusEmail.Content = "* Rellena todos los campos";
            }
            else
            {
                Transaction transaction = new Transaction();
                transaction.amount = Convert.ToDouble(amount);
                transaction.type = type;
                transaction.date = transactionDate;

             

                transactionManagement.UploadTransaction(transaction);

                //make 15 random transactions with dates between september 2022 and march 2023 and amounts from 50000 to 760000 and random type from "Activo" "Pasivo" "Ingreso" or "Egreso"
                




                lblStatusEmail.Foreground = new BrushConverter().ConvertFromString("#FF009A1F") as SolidColorBrush;
                lblStatusEmail.Content = "* Transacción agregada con éxito";

                loadTransactionsData();

            }


        }

        private void loadTransactionsData()
        {
            UserRepository userRepository = new UserRepository();

            using (var connection = userRepository.GetConnection())
            using (var command = new MySqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT type,date,amount,extra FROM transactions WHERE user=@username";
                    command.Parameters.AddWithValue("@username", App.Current.Properties["user"]);


                    connection.Open();
                    MySqlDataAdapter adp = new MySqlDataAdapter(command);

                    DataSet ds = new DataSet();

                    adp.Fill(ds, "LoadDataBinding");
                    dataGridCalendar.DataContext = ds;



                    connection.Close();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            TransactionModel transactionModel = new TransactionModel();
            TransactionManagement transactionManagement = new TransactionManagement();

            lblStatusEmail.Content = "";
            string amount = textBoxAmount.Text.Trim();
            string type = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();
            string extra = textBoxDescription.Text.ToString();
            DateTime transactionDate = datePickerReminder.SelectedDate.Value;

            if (amount == null || amount == "" || datePickerReminder.SelectedDate == null)
            {
                lblStatusEmail.Foreground = new BrushConverter().ConvertFromString("#cc0000") as SolidColorBrush;
                lblStatusEmail.Content = "* Rellena todos los campos";
            }
            else
            {
                Transaction transaction = new Transaction();
                transaction.amount = Convert.ToDouble(amount);
                transaction.type = type;
                transaction.date = transactionDate;
                transaction.extra = extra; 

                transactionManagement.UploadTransaction(transaction);

                lblStatusEmail.Foreground = new BrushConverter().ConvertFromString("#FF009A1F") as SolidColorBrush;
                lblStatusEmail.Content = "* Transacción agregada con éxito";


                //for (int i = 0; i < 15; i++)
                //{
                //    Random rnd = new Random();
                //    double randomAmount = rnd.Next(50000, 760000);
                //    string randomType = "";
                //    int randomTypeInt = rnd.Next(1, 5);
                //    if (randomTypeInt == 1)
                //    {
                //        randomType = "Activo";
                //    }
                //    else if (randomTypeInt == 2)
                //    {
                //        randomType = "Pasivo";
                //    }
                //    else if (randomTypeInt == 3)
                //    {
                //        randomType = "Ingreso";
                //    }
                //    else if (randomTypeInt == 4)
                //    {
                //        randomType = "Egreso";
                //    }
                //    int randomDay = rnd.Next(1, 30);
                //    int randomMonth = rnd.Next(9, 12);
                //    int randomYear = rnd.Next(2022, 2023);
                //    DateTime randomDate = new DateTime(randomYear, randomMonth, randomDay);

                //    Transaction randomTransaction = new Transaction();
                //    randomTransaction.amount = randomAmount;
                //    randomTransaction.type = randomType.ToString();
                //    randomTransaction.date = randomDate;
                //    randomTransaction.extra = "internal test transaction " + i;

                //    Console.WriteLine(randomTransaction);

                //    transactionManagement.UploadTransaction(randomTransaction);
                //}


                

                loadTransactionsData();

                textBoxAmount.Clear();
                textBoxDescription.Clear();

            }


        }
    }
}
