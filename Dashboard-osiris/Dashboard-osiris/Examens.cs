using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_osiris
{
    public class Examens
    {
        // elke examen heeft een examen_ID, Naam, Datum en een Vak_ID
        public string Examen_ID { get; set; }
        public string Naam { get; set; }
        public string Datum { get; set; }
        public string Vak_ID { get; set; }
        public string Vak_Naam { get; set; }

        // zet elke examen in een list
        public List<Examens> examens = new List<Examens>();

        public void HaalExamensOp()
        {
            // Vul de lijst met examens vanuit de database
            DatabaseHelper databaseHelper = new DatabaseHelper();
            DataTable dt = databaseHelper.getExams();
            foreach (DataRow row in dt.Rows)
            {
                Examens examen = new Examens
                {
                    Examen_ID = row["Examen_ID"].ToString(),
                    Naam = row["Naam"].ToString(),
                    Datum = row["Datum"].ToString(),
                    Vak_ID = row["Vak_ID"].ToString()
                };
                examens.Add(examen);
            }


            // Haal de vaknaam op door in de vakkenlist te kijken en de vaknaam te matchen met de vak_ID
            Vakken vakken = new Vakken();
            vakken.HaalVakkenOp();
            foreach (var vak in vakken.vakken)
            {
                if (vak.Vak_ID == Vak_ID)
                {
                    Vak_Naam = vak.Vak_Naam;
                }
            }

            // filter de examens op basis van de ingelogde student
            student student = new student();
            student.HaalStudentenOp();
            foreach (var studenten in student.studenten)
            {
                if (studenten.Student_ID == student.IngelogdeStudent.Student_ID)
                {
                    foreach (var examen in examens)
                    {
                        if (examen.Vak_ID == studenten.Klas_ID)
                        {
                            Console.WriteLine("Examen: " + examen.Naam + " Datum: " + examen.Datum);
                        }
                    }
                }
            }
        }
    }
}
