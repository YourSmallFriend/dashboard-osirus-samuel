using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Dashboard_osiris
{
    public partial class dashboard_start : Form
    {
        public dashboard_start()
        {
            InitializeComponent();
            DatabaseHelper db = new DatabaseHelper();
            db.connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM docent", db.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                docent docent = new docent();
                while (reader.Read())
                {
                    docent.Docent_ID = reader.GetString(0);
                    docent.Naam = reader.GetString(1);
                    docent.Wachtwoord = reader.GetString(2);
                }

                //als de Docent_ID en wachtwoord overeenkomen met de ingevoerde gegevens dan zie je in een messagebox dat je bent ingelogd

                if (docent.Docent_ID == Txt_gebruikersnaam.Text && docent.Wachtwoord == Txt_wachtwoord.Text)
                {
                    MessageBox.Show("U bent ingelogd");
                }
                else
                {
                    MessageBox.Show("U bent niet ingelogd");
                }

                if (reader != null)
                {
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // laat de meldeing zien die de database terug geeft
                MessageBox.Show("Error: " + ex.Message);
            }
            db.connection.Close();
        }

    }
}
