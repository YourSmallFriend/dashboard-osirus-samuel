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
        }
    }
}
