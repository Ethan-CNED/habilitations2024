using System;
using System.Windows.Forms;

namespace habilitations2024.view
{
    public partial class FrmAuthentification : Form
    {
        /// <summary>
        /// Variable requise par le concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel4;

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne pas modifier
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Connecter = new System.Windows.Forms.Button();
            this.textBox_Nom_Admin = new System.Windows.Forms.TextBox();
            this.textBox_Prénom_Admin = new System.Windows.Forms.TextBox();
            this.textBox_pwd_admin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Connecter
            // 
            this.btn_Connecter.Location = new System.Drawing.Point(298, 200);
            this.btn_Connecter.Name = "btn_Connecter";
            this.btn_Connecter.Size = new System.Drawing.Size(75, 23);
            this.btn_Connecter.TabIndex = 3;
            this.btn_Connecter.Text = "Login";
            this.btn_Connecter.UseVisualStyleBackColor = true;
            // Affectation de l'événement Click au gestionnaire btn_Connecter_Click
            // 
            // textBox_Nom_Admin
            // 
            this.textBox_Nom_Admin.Location = new System.Drawing.Point(250, 50);
            this.textBox_Nom_Admin.Name = "textBox_Nom_Admin";
            this.textBox_Nom_Admin.Size = new System.Drawing.Size(200, 20);
            this.textBox_Nom_Admin.TabIndex = 0;
            // 
            // textBox_Prénom_Admin
            // 
            this.textBox_Prénom_Admin.Location = new System.Drawing.Point(250, 100);
            this.textBox_Prénom_Admin.Name = "textBox_Prénom_Admin";
            this.textBox_Prénom_Admin.Size = new System.Drawing.Size(200, 20);
            this.textBox_Prénom_Admin.TabIndex = 1;
            // 
            // textBox_pwd_admin
            // 
            this.textBox_pwd_admin.Location = new System.Drawing.Point(250, 150);
            this.textBox_pwd_admin.Name = "textBox_pwd_admin";
            this.textBox_pwd_admin.PasswordChar = '*'; // Masquage du mot de passe
            this.textBox_pwd_admin.Size = new System.Drawing.Size(200, 20);
            this.textBox_pwd_admin.TabIndex = 2;
            // 
            // FrmAuthentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.textBox_pwd_admin);
            this.Controls.Add(this.textBox_Prénom_Admin);
            this.Controls.Add(this.textBox_Nom_Admin);
            this.Controls.Add(this.btn_Connecter);
            this.Name = "FrmAuthentification";
            this.Text = "Authentification";
            this.ResumeLayout(false);
            this.PerformLayout();

            // 
            // panel4
            // 
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel4.Location = new System.Drawing.Point(50, 220); 
            this.panel4.Size = new System.Drawing.Size(100, 50);         
            this.panel4.BackColor = System.Drawing.Color.Yellow;         
            this.panel4.Visible = true;                                  
            this.Controls.Add(this.panel4);

        }

        #endregion

        private System.Windows.Forms.Button btn_Connecter;
        private System.Windows.Forms.TextBox textBox_Nom_Admin;
        private System.Windows.Forms.TextBox textBox_Prénom_Admin;
        private System.Windows.Forms.TextBox textBox_pwd_admin;
    }
}
