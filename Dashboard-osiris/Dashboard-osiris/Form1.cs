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
using System.Data.SqlClient;

namespace Dashboard_osiris
{
    public partial class dashboard_start : Form
    {
        public dashboard_start()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //maak een nieuwe instantie van de docent class en haal de docenten op
            docent docent = new docent();
            docent.HaalDocentenOp();

            //als er een docent is uit de list docenten die het docent_ID en wachtwoord heeft die de gebruiker heeft ingevoerd dan wordt de gebruiker doorgestuurd naar het een nieuwe form
            if (docent.docenten.Any(x => x.Docent_ID == Txt_gebruikersnaam.Text && x.Wachtwoord == Txt_wachtwoord.Text))
            {
                Form DocentenScherm = new DocentenScherm();
                DocentenScherm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Docent ID of wachtwoord is onjuist");
            }
        }
    }
}