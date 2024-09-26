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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnAddStudentToDatabase_Click(object sender, EventArgs e)
        {
            // Voeg een student toe aan de database in de tabel studenten met de gegevens die zijn ingevuld in de textboxen en de radio buttons hiervoor word een query uitgevoerd
            DatabaseHelper databaseHelper = new DatabaseHelper();
            databaseHelper.connection.Open();
            //radio buttons voor klas, rbtnKlasA is voor de Klas_ID 1 en rbtnKlasB is voor de Klas_ID 2
            string klas = "";
            if (rbtnKlasA.Checked)
            {
                klas = "1";
            }
            else if (rbtnKlasB.Checked)
            {
                klas = "2";
            }

            string query = "INSERT INTO studenten (Naam, Wachtwoord, Klas_ID) VALUES ('" + txtNaam.Text + "', '" + txtWachtwoord.Text + "', '" + klas + "')";
            MySqlCommand cmd = new MySqlCommand(query, databaseHelper.connection);
            cmd.ExecuteNonQuery();
            databaseHelper.connection.Close();
            MessageBox.Show("Student toegevoegd aan de database");
            this.Hide();

        }
    }
}
