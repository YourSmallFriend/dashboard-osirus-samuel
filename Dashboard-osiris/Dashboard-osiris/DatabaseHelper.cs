using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Dashboard_osiris
{
    public class DatabaseHelper
    {
        public string connectionString = "server=localhost;database=schoolvoortgang;user=root";
        public MySqlConnection connection;

    }
}
