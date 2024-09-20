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

        // kijk met een query welke docent welk vak geeft door de docent_ID te vergelijken met de docent_ID in de vakken tabel
        public DataTable GetDocenten2()
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                string query = "SELECT docenten.Docent_ID, docenten.Naam, vakken.Vak_Naam FROM docenten INNER JOIN vakken ON docenten.Docent_ID = vakken.Docent_ID";

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

        // haal de studenten op uit de database en zet ze in een datatable zodat ze makkelijk te gebruiken zijn
        public DataTable GetStudenten()
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                string query = "SELECT * FROM studenten";

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

        public DataTable getExams()
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                string query = "SELECT * FROM examens";

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

        public DataTable GetVakken()
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                string query = "SELECT * FROM vakken";

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

        //haal de voortgang van de ingelogde student op door de student_ID te vergelijken met de student_ID in de voortgang tabel. voortgang heeft een student_ID vak_ID, cijfer, en een examen_ID
        public DataTable getvoortgang()
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                string query = "SELECT * FROM voortgang";

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
