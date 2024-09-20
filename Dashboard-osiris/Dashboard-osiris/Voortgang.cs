using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_osiris
{
    internal class Voortgang
    {
        //haal nu de voortgang uit de database helper class
        public string Student_ID { get; set; }
        public string Vak_ID { get; set; }
        public string Cijfer { get; set; }

        // zet elke voortgang in een list
        public List<Voortgang> Voortgangen = new List<Voortgang>();

        public void HaalVoortgangOp()
        {
            // Vul de lijst met voortgang vanuit de database
            DatabaseHelper databaseHelper = new DatabaseHelper();
            var dt = databaseHelper.getvoortgang();
            foreach (DataRow row in dt.Rows)
            {
                var voortgang = new Voortgang
                {
                    Student_ID = row["Student_ID"].ToString(),
                    Vak_ID = row["Vak_ID"].ToString(),
                    Cijfer = row["Cijfer"].ToString()
                };
                Voortgangen.Add(voortgang);
            }

            // haal nu alleen de voortgang van de ingelogde student op de ingelogde student is een static property van de student class dus niet voor de rest van de studenten

            var tempVoortgangen = new List<Voortgang>();
            var ingelogdeStudent = student.IngelogdeStudent;
            if (ingelogdeStudent != null)
            {
                foreach (var voortgang in Voortgangen)
                {
                    if (voortgang.Student_ID == ingelogdeStudent.Student_ID)
                    {
                        tempVoortgangen.Add(voortgang);
                    }
                }
            }
        }
    }
}
