using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_osiris
{
    internal class Klas
    {
        // elk klas heeft een Klas_ID en een Klas_Naam
        public string Klas_ID { get; set; }
        public string Klas_Naam { get; set; }

        // zet elke klas in een list
        public List<Klas> klassen = new List<Klas>();
        public void HaalKlassenOp()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();

            // Vul de lijst met klassen vanuit de database
            var dt = databaseHelper.GetKlassen();
            foreach (DataRow row in dt.Rows)
            {
                var klas = new Klas
                {
                    Klas_ID = row["Klas_ID"].ToString(),
                    Klas_Naam = row["Klas_Naam"].ToString(),
                };
                klassen.Add(klas);
            }
        }
    }
}
