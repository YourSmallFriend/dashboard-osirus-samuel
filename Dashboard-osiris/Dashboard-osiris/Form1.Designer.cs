namespace Dashboard_osiris
{
    partial class dashboard_start
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Txt_wachtwoord = new System.Windows.Forms.TextBox();
            this.Lbl_gebruikersnaam = new System.Windows.Forms.Label();
            this.Lbl_wachtwoord = new System.Windows.Forms.Label();
            this.Txt_gebruikersnaam = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Txt_wachtwoord, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_gebruikersnaam, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_wachtwoord, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Txt_gebruikersnaam, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-2, -4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1478, 834);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Txt_wachtwoord
            // 
            this.Txt_wachtwoord.Location = new System.Drawing.Point(742, 420);
            this.Txt_wachtwoord.Name = "Txt_wachtwoord";
            this.Txt_wachtwoord.Size = new System.Drawing.Size(160, 22);
            this.Txt_wachtwoord.TabIndex = 3;
            // 
            // Lbl_gebruikersnaam
            // 
            this.Lbl_gebruikersnaam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_gebruikersnaam.AutoSize = true;
            this.Lbl_gebruikersnaam.Location = new System.Drawing.Point(623, 401);
            this.Lbl_gebruikersnaam.Name = "Lbl_gebruikersnaam";
            this.Lbl_gebruikersnaam.Size = new System.Drawing.Size(113, 16);
            this.Lbl_gebruikersnaam.TabIndex = 0;
            this.Lbl_gebruikersnaam.Text = "Gebruikers Naam";
            // 
            // Lbl_wachtwoord
            // 
            this.Lbl_wachtwoord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_wachtwoord.AutoSize = true;
            this.Lbl_wachtwoord.Location = new System.Drawing.Point(654, 417);
            this.Lbl_wachtwoord.Name = "Lbl_wachtwoord";
            this.Lbl_wachtwoord.Size = new System.Drawing.Size(82, 16);
            this.Lbl_wachtwoord.TabIndex = 1;
            this.Lbl_wachtwoord.Text = "Wachtwoord";
            // 
            // Txt_gebruikersnaam
            // 
            this.Txt_gebruikersnaam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Txt_gebruikersnaam.Location = new System.Drawing.Point(742, 392);
            this.Txt_gebruikersnaam.Name = "Txt_gebruikersnaam";
            this.Txt_gebruikersnaam.Size = new System.Drawing.Size(160, 22);
            this.Txt_gebruikersnaam.TabIndex = 2;
            // 
            // dashboard_start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1472, 827);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "dashboard_start";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox Txt_wachtwoord;
        private System.Windows.Forms.Label Lbl_gebruikersnaam;
        private System.Windows.Forms.Label Lbl_wachtwoord;
        private System.Windows.Forms.TextBox Txt_gebruikersnaam;
    }
}

