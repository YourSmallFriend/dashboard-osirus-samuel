using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_osiris {

    internal class student
    {
        // elk student heeft een Student_ID, een Naam, een Wachtwoord en een Klas_ID en zit ook vast aan een vak het vak heeft een vak_Naam haal die uit de databasehelper class
        public string Student_ID { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
        public string Klas_ID { get; set; }
        public static student IngelogdeStudent { get; set; }

        // zet elke student in een list
        public List<student> studenten = new List<student>();
        public void HaalStudentenOp()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();

            // Vul de lijst met docenten vanuit de database
            DataTable dt = databaseHelper.GetStudenten();
            foreach (DataRow row in dt.Rows)
            {
                student student = new student
                {
                    Student_ID = row["Student_ID"].ToString(),
                    Naam = row["Naam"].ToString(),
                    Wachtwoord = row["Wachtwoord"].ToString(),
                    Klas_ID = row["Klas_ID"].ToString(),
                };
                studenten.Add(student);
            }
        }
    } 
}
