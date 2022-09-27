
using FinanZee_WPF.Models;
using FinanZee_WPF.Properties;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinanZee_WPF.Views
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {
        public CalendarView()
        {
            InitializeComponent();

            loadCalendarData();



        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblStatusEmail.Content = " ";

            EmailControl emailControl = new EmailControl();
            UserRepository userRepository = new UserRepository();

            string reminderData = textBoxReminder.Text.Trim();
            DateTime reminderDate = datePickerReminder.SelectedDate.Value;

            if (reminderData == null || reminderData == "" || datePickerReminder.SelectedDate == null)
            {

                lblStatusEmail.Foreground = new BrushConverter().ConvertFromString("#cc0000") as SolidColorBrush;
                lblStatusEmail.Content = "* Rellena todos los campos";

            }
            else
            {

                emailControl.SendEmailICS((string)App.Current.Properties["email"], reminderDate, reminderData);
                userRepository.InsertReminder(reminderDate, reminderData);

                textBoxReminder.Clear();

                lblStatusEmail.Foreground = new BrushConverter().ConvertFromString("#FF009A1F") as SolidColorBrush;
                lblStatusEmail.Content = "* Recordatorio enviado con éxito";

                loadCalendarData();

            }



        }

        private void textBoxReminder_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblStatusEmail.Content = " ";
        }

        private void loadCalendarData()
        {
            UserRepository userRepository = new UserRepository();

            using (var connection = userRepository.GetConnection())
            using (var command = new MySqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT date,reminder FROM reminders WHERE user=@username";
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


    }
}
