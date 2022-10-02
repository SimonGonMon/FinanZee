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
                    command.CommandText = "SELECT type,date,amount FROM transactions WHERE user=@username";
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
            string extra = "";
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

                loadTransactionsData();

                textBoxAmount.Clear();

            }


        }
    }
}
