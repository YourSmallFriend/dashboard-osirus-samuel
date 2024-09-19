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
        }

        
        private void StudentenScherm_Load(object sender, EventArgs e)
        {
            student student = new student();

            //zet alle informatie van de student die is ingelogd in de textbox
            textBox1.Text = "Student ID: " + student.IngelogdeStudent.Student_ID + Environment.NewLine + "Naam: " + student.IngelogdeStudent.Naam + Environment.NewLine + "Klas ID: " + student.IngelogdeStudent.Klas_ID;
            student.IngelogdeStudent = student;
        }
    }
}
