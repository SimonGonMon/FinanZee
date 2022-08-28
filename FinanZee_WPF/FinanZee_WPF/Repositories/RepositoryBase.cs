﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySqlConnector;

namespace FinanZee_WPF.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            //_connectionString = "Server=158.101.15.14:3306; Database=FinanZee_Login; Integrated Security=true";
            //add username: simon to the string and password: Admin123
            _connectionString = "server=158.101.15.14;user=simon;database=FinanZee_Login;port=3306;password=Coder2003@";
        }
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        //create a new function to open a connection to a mysql server
    }
}