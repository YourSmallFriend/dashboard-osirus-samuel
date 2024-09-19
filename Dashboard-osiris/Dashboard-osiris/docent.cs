using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_osiris
{
    
    public class docent
    {
        // elke docent heeft een Docent_I, Naam en een Wachtwoord en zit ook vast aan een vak het vak heeft een vak_Naam haal die uit de databasehelper class
        DatabaseHelper databaseHelper = new DatabaseHelper();
        public string Docent_ID { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
        public string Vak_Naam { get; set; }
        public static docent IngelogdeDocent { get; set; }

        // zet elke docent in een list
        public List<docent> docenten = new List<docent>();

        public void HaalDocentenOp()
        {
            // Vul de lijst met docenten vanuit de database
            DataTable dt = databaseHelper.GetDocenten();
            foreach (DataRow row in dt.Rows)
            {
                docent docent = new docent
                {
                    Docent_ID = row["Docent_ID"].ToString(),
                    Naam = row["Naam"].ToString(),
                    Wachtwoord = row["Wachtwoord"].ToString()
                };
                docenten.Add(docent);
            }
        }
        //kijk in de vakken class welke vakken bij de IngelogdeDocent horen door de Docent_ID te vergelijken met de Docent_ID in de vakken class
        public void HaalVakkenOp()
        {
            Vakken vakken = new Vakken();
            vakken.HaalVakkenOp();
            foreach (var vak in vakken.vakken)
            {
                if (vak.Docent_ID == IngelogdeDocent.Docent_ID)
                {
                    Vak_Naam = vak.Vak_Naam;
                }
            }
        }
    }
}
