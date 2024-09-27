namespace Dashboard_osiris
{
    partial class UpdateCijferScherm
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
            this.comboboxStudent = new System.Windows.Forms.ComboBox();
            this.comboboxExamen = new System.Windows.Forms.ComboBox();
            this.txtCijfer = new System.Windows.Forms.TextBox();
            this.bntUpdateStudent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboboxStudent
            // 
            this.comboboxStudent.FormattingEnabled = true;
            this.comboboxStudent.Location = new System.Drawing.Point(12, 12);
            this.comboboxStudent.Name = "comboboxStudent";
            this.comboboxStudent.Size = new System.Drawing.Size(121, 24);
            this.comboboxStudent.TabIndex = 0;
            // 
            // comboboxExamen
            // 
            this.comboboxExamen.FormattingEnabled = true;
            this.comboboxExamen.Location = new System.Drawing.Point(139, 12);
            this.comboboxExamen.Name = "comboboxExamen";
            this.comboboxExamen.Size = new System.Drawing.Size(121, 24);
            this.comboboxExamen.TabIndex = 1;
            // 
            // txtCijfer
            // 
            this.txtCijfer.Location = new System.Drawing.Point(266, 12);
            this.txtCijfer.Multiline = true;
            this.txtCijfer.Name = "txtCijfer";
            this.txtCijfer.Size = new System.Drawing.Size(100, 24);
            this.txtCijfer.TabIndex = 2;
            // 
            // bntUpdateStudent
            // 
            this.bntUpdateStudent.Location = new System.Drawing.Point(372, 12);
            this.bntUpdateStudent.Name = "bntUpdateStudent";
            this.bntUpdateStudent.Size = new System.Drawing.Size(100, 25);
            this.bntUpdateStudent.TabIndex = 3;
            this.bntUpdateStudent.Text = "Update";
            this.bntUpdateStudent.UseVisualStyleBackColor = true;
            this.bntUpdateStudent.Click += new System.EventHandler(this.bntUpdateStudent_Click);
            // 
            // UpdateCijferScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 55);
            this.Controls.Add(this.bntUpdateStudent);
            this.Controls.Add(this.txtCijfer);
            this.Controls.Add(this.comboboxExamen);
            this.Controls.Add(this.comboboxStudent);
            this.Name = "UpdateCijferScherm";
            this.Text = "UpdateCijferScherm";
            this.Load += new System.EventHandler(this.UpdateCijferScherm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboboxStudent;
        private System.Windows.Forms.ComboBox comboboxExamen;
        private System.Windows.Forms.TextBox txtCijfer;
        private System.Windows.Forms.Button bntUpdateStudent;
    }
}