﻿using System;
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

        // laat de naam van de ingelogde docent zien op de LblDocentNaam label en laat Docent.Vak_Naam zien op de LblVakNaam label
        private void DocentenScherm_Load(object sender, EventArgs e)
        {
            docent docent = new docent();
            docent.HaalDocentenOp();
            LblNaam.Text = docent.IngelogdeDocent.Naam;
        }
    }
}
