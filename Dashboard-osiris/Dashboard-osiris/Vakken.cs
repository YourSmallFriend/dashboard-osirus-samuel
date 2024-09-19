using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_osiris
{
    internal class Vakken
    {
        // elke vak heeft een Vak_ID,Vak_Naam en een Docent_ID
        public string Docent_ID { get; set; }
        public string Vak_ID { get; set; }
        public string Vak_Naam { get; set; }
        public string Docent_Naam { get; set; }
        // zet elke vak in een list
        public List<Vakken> vakken = new List<Vakken>();

        public void HaalVakkenOp()
        {
            // Vul de lijst met vakken vanuit de database
            DatabaseHelper databaseHelper = new DatabaseHelper();
            var dt = databaseHelper.GetVakken();
            foreach (DataRow row in dt.Rows)
            {
                var vak = new Vakken
                {
                    Docent_ID = row["Docent_ID"].ToString(),
                    Vak_ID = row["Vak_ID"].ToString(),
                    Vak_Naam = row["Vak_Naam"].ToString()
                };
                vakken.Add(vak);
            }
        }
    }
}
