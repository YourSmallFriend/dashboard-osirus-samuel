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
    public partial class DocentenScherm : Form
    {
        public DocentenScherm()
        {
            InitializeComponent();
        }

        private void DocentenScherm_Load(object sender, EventArgs e)
        {
            label1.Text = "Welkom " + docent.IngelogdeDocent.Naam;

            // Initialize the DataGridView with basic columns
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Student";
            dataGridView1.Columns[1].Name = "Vak";
            dataGridView1.Columns[2].Name = "Gemiddelde";

            // Fetch all subjects, progress, and exams
            Vakken vakken = new Vakken();
            vakken.HaalVakkenOp();
            Voortgang voortgang = new Voortgang();
            voortgang.HaalVoortgangOp();
            Examens examens = new Examens();
            examens.HaalExamensOp();

            // Dictionary to track student rows and their grades
            Dictionary<string, (DataGridViewRow row, List<double> grades)> studentRows = new Dictionary<string, (DataGridViewRow, List<double>)>();

            foreach (var vak in vakken.vakken)
            {
                if (vak.Docent_ID == docent.IngelogdeDocent.Docent_ID)
                {
                    foreach (var voortgangen in voortgang.Voortgangen)
                    {
                        if (voortgangen.Vak_ID == vak.Vak_ID)
                        {
                            // Match the student name with the student_id from progress
                            student student = new student();
                            student.HaalStudentenOp();
                            foreach (var studenten in student.studenten)
                            {
                                if (studenten.Student_ID == voortgangen.Student_ID)
                                {
                                    // Check if the student row already exists
                                    if (!studentRows.ContainsKey(studenten.Student_ID))
                                    {
                                        // Create a new row for the student
                                        DataGridViewRow row = new DataGridViewRow();
                                        row.CreateCells(dataGridView1);
                                        row.Cells[0].Value = studenten.Naam;
                                        row.Cells[1].Value = vak.Vak_Naam;
                                        dataGridView1.Rows.Add(row);
                                        studentRows[studenten.Student_ID] = (row, new List<double>());
                                    }

                                    // Add the progress of the exams to the data grid view
                                    foreach (var examen in examens.examens)
                                    {
                                        // Ensure the exam is for the correct subject
                                        if (examen.Vak_ID == vak.Vak_ID)
                                        {
                                            // Create a unique column for each exam
                                            string columnName = $"Examen_{examen.Examen_ID}";
                                            if (!dataGridView1.Columns.Contains(columnName))
                                            {
                                                dataGridView1.Columns.Add(columnName, examen.Naam);
                                            }

                                            // Add the exam result to the student's row
                                            DataGridViewRow studentRow = studentRows[studenten.Student_ID].row;
                                            if (double.TryParse(voortgangen.Cijfer, out double cijfer))
                                            {
                                                studentRow.Cells[dataGridView1.Columns[columnName].Index].Value = voortgangen.Cijfer;
                                                studentRows[studenten.Student_ID].grades.Add(cijfer);
                                            }
                                            else
                                            {
                                                // Handle the invalid format case, e.g., log an error or set a default value
                                                Console.WriteLine($"Invalid cijfer format: {voortgangen.Cijfer}");
                                            }
                                            // Make the columns as wide as the data grid view
                                            dataGridView1.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Set the subject name in label2
                    label2.Text = "Vak: " + vak.Vak_Naam;
                }
            }

            // Calculate and set the average grade for each student
            foreach (var studentEntry in studentRows)
            {
                var (row, grades) = studentEntry.Value;
                if (grades.Count > 0)
                {
                    double average = grades.Average();
                    row.Cells[2].Value = average.ToString("F2"); // Format to 2 decimal places
                }
            }
        }
    }
}
