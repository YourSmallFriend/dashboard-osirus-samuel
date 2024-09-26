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

            //als je een student selecteerd in de comboboxStudentdan word die in een variable gezet en dan worden de examens van die student in de comboboxExamens gezet
            var selectedStudent = student.studenten[comboboxStudent.SelectedIndex];
            Examens examens = new Examens();
            examens.HaalExamensOp();
            foreach (var examen in examens.examens)
            {
                if (examen.Vak_ID == selectedStudent.Klas_ID)
                {
                    comboboxExamen.Items.Add(examen.Naam);
                }
            }
        }
        private void bntUpdateStudent_Click(object sender, EventArgs e)
        {
            //in textboxCijfer kan je het cijfer invullen en daarnaa kan je op de button klikken om het cijfer te updaten in de database
            var selectedStudent = student.studenten[comboboxStudent.SelectedIndex];
            Examens selectedExamen = Examens.examens[comboboxExamen.SelectedIndex];

            var cijfer = txtCijfer.Text;
            if (selectedStudent != null)
            {
                DatabaseHelper databaseHelper = new DatabaseHelper();
                databaseHelper.connection.Open();
                string query = "UPDATE voortgang SET Cijfer = @cijfer WHERE Student_ID = @student_id AND Examen_ID = @examen_id";
                MySqlCommand cmd = new MySqlCommand(query, databaseHelper.connection);
                cmd.Parameters.AddWithValue("@cijfer", cijfer);
                cmd.Parameters.AddWithValue("@student_id", selectedStudent.Student_ID);
                cmd.Parameters.AddWithValue("@examen_id", selectedExamen.Examen_ID);
                cmd.ExecuteNonQuery();
                databaseHelper.connection.Close();
            }
        }
    }
}
