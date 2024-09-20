using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard_osiris
{
    public partial class StudentenScherm : Form
    {
        public StudentenScherm()
        {
            InitializeComponent();
            this.Load += new EventHandler(StudentenScherm_Load);
        }

        private void StudentenScherm_Load(object sender, EventArgs e)
        {
            student student = new student();

            //zet alle informatie van de ingelogde student in de textbox
            student.HaalStudentenOp();
            foreach (var studenten in student.studenten)
            {
                if (studenten.Student_ID == student.IngelogdeStudent.Student_ID)
                {
                    textBox1.Text += "Naam: " + studenten.Naam + Environment.NewLine;
                    textBox1.Text += "Klas: " + studenten.Klas_ID + Environment.NewLine;
                }
            }

            //laat nu ook de voortgang van de student zien en de cijfers die daarbij horen die ook in de voortgang class staan laat alleen de cijferst zien van de ingelogde student
            Voortgang voortgang = new Voortgang();
            voortgang.HaalVoortgangOp();

            // Filter the voortgangen list to only include the logged-in student's grades
            var filteredVoortgangen = voortgang.Voortgangen
                .Where(v => v.Student_ID == student.IngelogdeStudent.Student_ID)
                .ToList();

            Examens examens = new Examens();
            examens.HaalExamensOp();

            Vakken vakken2 = new Vakken();
            vakken2.HaalVakkenOp();

            // Use a HashSet to keep track of displayed exams to avoid duplicates
            var displayedExams = new HashSet<string>();

            foreach (var voortgangen in filteredVoortgangen)
            {
                var matchingExamen = examens.examens.FirstOrDefault(ex => ex.Vak_ID == voortgangen.Vak_ID);
                if (matchingExamen != null)
                {
                    var matchingVak = vakken2.vakken.FirstOrDefault(v => v.Vak_ID == matchingExamen.Vak_ID);
                    if (matchingVak != null)
                    {
                        // Create a unique key for the exam to check for duplicates
                        var examKey = matchingVak.Vak_Naam + matchingExamen.Naam;
                        if (!displayedExams.Contains(examKey))
                        {
                            textBox3.Text += "Vak: " + matchingVak.Vak_Naam + " Examen: " + matchingExamen.Naam + " Cijfer: " + voortgangen.Cijfer + Environment.NewLine;
                            displayedExams.Add(examKey);
                        }
                    }
                }
            }
        }
    }
}
