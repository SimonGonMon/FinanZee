using System;
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
            _connectionString = "server=0.0.0.0;user=xx;database=xx;port=3306;password=xx";
        }
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        
    }


}
