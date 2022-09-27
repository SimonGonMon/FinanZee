using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using FinanZee_WPF.Models;
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinanZee_WPF.Repositories
{

    public class UserRepository : RepositoryBase, IUserRepository
    {
        public string user;
        public string email;
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                try {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM user WHERE Usuario=@username AND Contraseña=@password";
                    command.Parameters.AddWithValue("@username", credential.UserName);
                    command.Parameters.AddWithValue("@password", credential.Password);
                    validUser = command.ExecuteScalar() == null ? false : true;
                } catch (MySqlException ex)
                {
                    MessageBox.Show("Conexión a base de datos TIMEOUT");
                    return false;
                }
                
            }
            if (validUser) {
                App.Current.Properties["user"] = credential.UserName;
            }
            return validUser;
        }

        public void InsertTransaction(string serializedTransaction)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO transactions (`user`, `transaction`) VALUES (@user, @transaction)";
                command.Parameters.AddWithValue("@user", App.Current.Properties["user"]);
                command.Parameters.AddWithValue("@transaction", serializedTransaction);
                command.ExecuteNonQuery();
            }

        }

        public void InsertReminder(DateTime date, String info)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO reminders (`user`, `date`, `reminder`) VALUES (@user, @date, @reminder)";
                command.Parameters.AddWithValue("@user", App.Current.Properties["user"]);
                command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@reminder", info);
                command.ExecuteNonQuery();
            }

        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }
        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ArrayList GetTransactions()
        {
            var transactionsJSON = new ArrayList();
            
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT transaction FROM transactions WHERE user=@username";
                command.Parameters.AddWithValue("@username", user);
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        transactionsJSON.Add(reader["transaction"]);
                    
                        
                    }
                }
            }

            return transactionsJSON;

                    


        }
        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM user WHERE Usuario=@username";
                command.Parameters.AddWithValue("@username", username);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        App.Current.Properties["email"] = reader[5].ToString();

                            string gravatarHash = StringExtensions.HashEmailForGravatar(reader[5].ToString());

                            user = new UserModel()
                            {
                                Id = reader[0].ToString(),
                                Username = reader[1].ToString(),
                                Password = string.Empty,
                                Name = reader[3].ToString(),
                                LastName = reader[4].ToString(),
                                Email = reader[5].ToString(),
                                ProfilePicture = ("https://www.gravatar.com/avatar/" + gravatarHash+".jpg?s=35&d=retro")
                                

                            };
                        
                    }
                }
            }
            
            return user;
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }


    }


    public static class StringExtensions
    {
        public static string HashEmailForGravatar(string email)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.  
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.  
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email));

            // Create a new Stringbuilder to collect the bytes  
            // and create a string.  
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string.  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();  // Return the hexadecimal string. 
        }
    }
}
