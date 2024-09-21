using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard_osiris
{
    public partial class StudentenScherm : Form
    {
        private List<string> displayedExams = new List<string>();

        public StudentenScherm()
        {
            InitializeComponent();
            this.Load += new EventHandler(StudentenScherm_Load);
        }

        private void StudentenScherm_Load(object sender, EventArgs e)
        {
            student student = new student();

            //laat de naam van de ingelogde student zien op LBLingelogdestudentnaam + de klass waar de student in zit door de klas id te vergelijken met de klas id in de klas class zit
            Klas klasInstance = new Klas();
            klasInstance.HaalKlassenOp();
            foreach (var klas in klasInstance.klassen)
            {
                if (klas.Klas_ID == student.IngelogdeStudent.Klas_ID)
                {
                    LBLingelogdestudentnaam.Text = student.IngelogdeStudent.Naam + " " + klas.Klas_Naam;
                }
            }

            //laat nu de voortgang zien van de ingelogde student waar de cijfers hoger zijn dan een 5.5 en maak van de cijfers die nu een string zijn een float
            Voortgang voortgang = new Voortgang();
            voortgang.HaalVoortgangOp();
            Examens examens = new Examens();
            examens.HaalExamensOp();
            Vakken vakkenInstance = new Vakken();
            vakkenInstance.HaalVakkenOp();

            foreach (var voortgangen in voortgang.Voortgangen)
            {
                if (voortgangen.Student_ID == student.IngelogdeStudent.Student_ID)
                {
                    //maak er een dropdown list van met de info van de examens die behaald zijn
                    if (float.TryParse(voortgangen.Cijfer, out float cijfer) && cijfer > 5.5)
                    {
                        foreach (var examen in examens.examens)
                        {
                            if (examen.Vak_ID == voortgangen.Vak_ID)
                            {
                                var matchingVak = vakkenInstance.vakken.FirstOrDefault(v => v.Vak_ID == examen.Vak_ID);
                                if (matchingVak != null)
                                {
                                    var examKey = examen.Naam + examen.Examen_ID;
                                    if (!displayedExams.Contains(examKey))
                                    {
                                        // Voeg de voortgang van de student toe aan de ComboBox als een nieuwe item
                                        comboBox1.Items.Add($"{matchingVak.Vak_Naam},{examen.Naam},{cijfer}");
                                        displayedExams.Add(examKey);
                                    }
                                }
                                break; // Exit the loop once a match is found
                            }
                        }
                    }
                }
            }

            //laat in combobox2 de examens zien waarin de student een onvoldoende heeft gehaald
            foreach (var voortgangen in voortgang.Voortgangen)
            {
                if (voortgangen.Student_ID == student.IngelogdeStudent.Student_ID)
                {
                    if (float.TryParse(voortgangen.Cijfer, out float cijfer) && cijfer < 5.5)
                    {
                        foreach (var examen in examens.examens)
                        {
                            if (examen.Vak_ID == voortgangen.Vak_ID)
                            {
                                var matchingVak = vakkenInstance.vakken.FirstOrDefault(v => v.Vak_ID == examen.Vak_ID);
                                if (matchingVak != null)
                                {
                                    var examKey = examen.Naam + examen.Examen_ID;
                                    if (!displayedExams.Contains(examKey))
                                    {
                                        // Voeg de voortgang van de student toe aan de ComboBox als een nieuwe item
                                        comboBox2.Items.Add($"{matchingVak.Vak_Naam},{examen.Naam},{cijfer}");
                                        displayedExams.Add(examKey);
                                    }
                                }
                                break; // Exit the loop once a match is found
                            }
                        }
                    }
                }
            }

            // laat in combobox3 de examens zien waarin de student nog geen cijfer heeft
            foreach (var examen in examens.examens)
            {
                var matchingVak = vakkenInstance.vakken.FirstOrDefault(v => v.Vak_ID == examen.Vak_ID);
                if (matchingVak != null)
                {
                    var examKey = examen.Naam + examen.Examen_ID;
                    if (!displayedExams.Contains(examKey))
                    {
                        // Voeg de voortgang van de student toe aan de ComboBox als een nieuwe item
                        comboBox3.Items.Add($"{matchingVak.Vak_Naam},{examen.Naam},Nog geen cijfer");
                        displayedExams.Add(examKey);
                    }
                }
            }

            // laat in de datagrid het gemiddelde cijfer zien van de ingelogde student per vak gebruik alleen de examens waar de student een cijfer voor heeft
            DataTable dt = new DataTable();
            dt.Columns.Add("Vak");
            dt.Columns.Add("Gemiddelde cijfer");
            dt.Columns.Add(new DataColumn("Vak_ID", typeof(string)) { ColumnMapping = MappingType.Hidden });
            foreach (var vak in vakkenInstance.vakken)
            {
                var cijfers = new List<float>();
                foreach (var voortgangen in voortgang.Voortgangen)
                {
                    if (voortgangen.Student_ID == student.IngelogdeStudent.Student_ID && voortgangen.Vak_ID == vak.Vak_ID)
                    {
                        if (float.TryParse(voortgangen.Cijfer, out float cijfer))
                        {
                            cijfers.Add(cijfer);
                        }
                    }
                }

                if (cijfers.Count > 0)
                {
                    var gemiddelde = cijfers.Average();
                    dt.Rows.Add(vak.Vak_Naam, gemiddelde, vak.Vak_ID);
                }
                else
                {
                    dt.Rows.Add(vak.Vak_Naam, "Nog geen cijfer", vak.Vak_ID);
                }
            }
            //zet de datagridview op de datagridview1
            dataGridView1.DataSource = dt;

            //alle rows bij elkaar moeten net zo breed zijn als de datagridview
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
    }
}
