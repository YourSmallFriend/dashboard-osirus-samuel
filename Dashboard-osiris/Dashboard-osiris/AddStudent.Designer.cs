namespace Dashboard_osiris
{
    partial class AddStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNaam = new System.Windows.Forms.TextBox();
            this.txtWachtwoord = new System.Windows.Forms.TextBox();
            this.btnAddStudentToDatabase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnKlasA = new System.Windows.Forms.RadioButton();
            this.rbtnKlasB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtNaam
            // 
            this.txtNaam.Location = new System.Drawing.Point(297, 164);
            this.txtNaam.Name = "txtNaam";
            this.txtNaam.Size = new System.Drawing.Size(100, 22);
            this.txtNaam.TabIndex = 0;
            // 
            // txtWachtwoord
            // 
            this.txtWachtwoord.Location = new System.Drawing.Point(297, 192);
            this.txtWachtwoord.Name = "txtWachtwoord";
            this.txtWachtwoord.Size = new System.Drawing.Size(100, 22);
            this.txtWachtwoord.TabIndex = 1;
            // 
            // btnAddStudentToDatabase
            // 
            this.btnAddStudentToDatabase.Location = new System.Drawing.Point(297, 220);
            this.btnAddStudentToDatabase.Name = "btnAddStudentToDatabase";
            this.btnAddStudentToDatabase.Size = new System.Drawing.Size(100, 23);
            this.btnAddStudentToDatabase.TabIndex = 2;
            this.btnAddStudentToDatabase.Text = "add";
            this.btnAddStudentToDatabase.UseVisualStyleBackColor = true;
            this.btnAddStudentToDatabase.Click += new System.EventHandler(this.btnAddStudentToDatabase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Naam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Wachtwoord";
            // 
            // rbtnKlasA
            // 
            this.rbtnKlasA.AutoSize = true;
            this.rbtnKlasA.Location = new System.Drawing.Point(412, 164);
            this.rbtnKlasA.Name = "rbtnKlasA";
            this.rbtnKlasA.Size = new System.Drawing.Size(66, 20);
            this.rbtnKlasA.TabIndex = 5;
            this.rbtnKlasA.TabStop = true;
            this.rbtnKlasA.Text = "Klas A";
            this.rbtnKlasA.UseVisualStyleBackColor = true;
            // 
            // rbtnKlasB
            // 
            this.rbtnKlasB.AutoSize = true;
            this.rbtnKlasB.Location = new System.Drawing.Point(412, 194);
            this.rbtnKlasB.Name = "rbtnKlasB";
            this.rbtnKlasB.Size = new System.Drawing.Size(66, 20);
            this.rbtnKlasB.TabIndex = 6;
            this.rbtnKlasB.TabStop = true;
            this.rbtnKlasB.Text = "Klas B";
            this.rbtnKlasB.UseVisualStyleBackColor = true;
            // 
            // AddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbtnKlasB);
            this.Controls.Add(this.rbtnKlasA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddStudentToDatabase);
            this.Controls.Add(this.txtWachtwoord);
            this.Controls.Add(this.txtNaam);
            this.Name = "AddStudent";
            this.Text = "AddStudent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNaam;
        private System.Windows.Forms.TextBox txtWachtwoord;
        private System.Windows.Forms.Button btnAddStudentToDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnKlasA;
        private System.Windows.Forms.RadioButton rbtnKlasB;
    }
}