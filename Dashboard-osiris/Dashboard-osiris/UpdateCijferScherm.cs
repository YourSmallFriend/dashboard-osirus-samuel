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
    public partial class UpdateCijferScherm : Form
    {
        public UpdateCijferScherm()
        {
            InitializeComponent();
        }
        private void UpdateCijferScherm_Load(object sender, EventArgs e)
        {
            //alle studenten ophalen en in de combobox comboboxStudenten zetten
            student student = new student();
            student.HaalStudentenOp();
            foreach (var studenten in student.studenten)
            {
                comboboxStudent.Items.Add(studenten.Naam);
            }

            // in het examen combobox worden alle examens gezet die gerelateerd zijn aan het vak van de ingelogde docent laat de examen naam zien
            Examens examens = new Examens();
            examens.HaalExamensOp();
            docent docent = new docent();
            docent.HaalDocentenOp();
            Vakken vakken = new Vakken();
            vakken.HaalVakkenOp();
            foreach (var vak in vakken.vakken)
            {
                if (vak.Docent_ID == docent.IngelogdeDocent.Docent_ID)
                {
                    foreach (var examen in examens.examens)
                    {
                        if (examen.Vak_ID == vak.Vak_ID)
                        {
                            comboboxExamen.Items.Add(examen.Naam);
                        }
                    }
                }
            }

        }
        private void bntUpdateStudent_Click(object sender, EventArgs e)
        {
            //in textboxCijfer kan je het cijfer invullen en daarnaa kan je op de button klikken om het cijfer te updaten in de database
            Voortgang voortgang = new Voortgang();
            voortgang.HaalVoortgangOp();
            student student = new student();
            student.HaalStudentenOp();
            Examens examens = new Examens();
            examens.HaalExamensOp();
            foreach (var studenten in student.studenten)
            {
                if (studenten.Naam == comboboxStudent.SelectedItem.ToString())
                {
                    foreach (var examen in examens.examens)
                    {
                        if (examen.Naam == comboboxExamen.SelectedItem.ToString())
                        {
                            foreach (var voortgangen in voortgang.Voortgangen)
                            {
                                if (voortgangen.Student_ID == studenten.Student_ID && voortgangen.Vak_ID == examen.Vak_ID)
                                {
                                    UpdateCijfer(voortgangen.Student_ID, voortgangen.Vak_ID, Convert.ToDouble(txtCijfer.Text));
                                    MessageBox.Show("Cijfer is geupdate");
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Student heeft nog geen voortgang in dit vak");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void UpdateCijfer(string studentId, string vakId, double cijfer)
        {
            // Implement the logic to update the grade in the database
            DatabaseHelper databaseHelper = new DatabaseHelper();
            databaseHelper.connection.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE voortgang SET Cijfer = @cijfer WHERE Student_ID = @studentId AND Vak_ID = @vakId", databaseHelper.connection);
            cmd.Parameters.AddWithValue("@cijfer", cijfer);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            cmd.Parameters.AddWithValue("@vakId", vakId);
            cmd.ExecuteNonQuery();
            databaseHelper.connection.Close();
        }
    }
}