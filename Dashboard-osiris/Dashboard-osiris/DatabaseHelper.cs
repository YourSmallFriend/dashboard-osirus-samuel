using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Data;

namespace Dashboard_osiris
{
    public class DatabaseHelper
    {
        public string connectionString = "server=localhost;database=osiris-dashboard_final;user=root";
        public MySqlConnection connection;

        // probberen connectie te maken met de database in een try catch block als de applicatie aan staat
        public DatabaseHelper()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // haal de docenten op uit de database en zet ze in een datatable zodat ze makkelijk te gebruiken zijn
        public DataTable GetDocenten()
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                string query = "SELECT * FROM docenten";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}
