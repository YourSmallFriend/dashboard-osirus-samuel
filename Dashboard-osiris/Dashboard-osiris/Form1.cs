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
            student student = new student();
            docent.HaalDocentenOp();
            student.HaalStudentenOp();

            //als er een docent is uit de list docenten die het docent_ID en wachtwoord heeft die de gebruiker heeft ingevoerd dan wordt de gebruiker doorgestuurd naar het een nieuwe form
            if (docent.docenten.Any(x => x.Docent_ID == Txt_gebruikersnaam.Text && x.Wachtwoord == Txt_wachtwoord.Text))
            {
                Form DocentenScherm = new DocentenScherm();
                DocentenScherm.Show();

                //sla de docent op die is ingelogd in een var
                docent.IngelogdeDocent = docent.docenten.FirstOrDefault(x => x.Docent_ID == Txt_gebruikersnaam.Text);

                this.Hide();
            }
            //als er een student is uit de list studenten die het student_ID en wachtwoord heeft die de gebruiker heeft ingevoerd dan wordt de gebruiker doorgestuurd naar het een nieuwe form
            else if (student.studenten.Any(x => x.Student_ID == Txt_gebruikersnaam.Text && x.Wachtwoord == Txt_wachtwoord.Text))
            {
                student.IngelogdeStudent = student.studenten.FirstOrDefault(x => x.Student_ID == Txt_gebruikersnaam.Text);
                Form StudentenScherm = new StudentenScherm();
                StudentenScherm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ID of wachtwoord is onjuist");
            }
        }
    }
}