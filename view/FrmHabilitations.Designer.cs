namespace habilitations2024.view
{
    partial class FrmHabilitations
    {
        /// Variable nécessaire au concepteur.
        private System.ComponentModel.IContainer components = null;

        /// Nettoyage des ressources utilisées.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.modifier = new System.Windows.Forms.Button();
            this.supprimer = new System.Windows.Forms.Button();
            this.changer_pwd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Prénom = new System.Windows.Forms.TextBox();
            this.textBox_Mail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Tel = new System.Windows.Forms.TextBox();
            this.cboProfils = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.annuler = new System.Windows.Forms.Button();
            this.enregistrer = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.annuler_pwd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.Enregistrer_pwd = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFiltre = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(702, 240);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // modifier
            // 
            this.modifier.BackColor = System.Drawing.Color.DarkGray;
            this.modifier.Location = new System.Drawing.Point(7, 270);
            this.modifier.Name = "modifier";
            this.modifier.Size = new System.Drawing.Size(141, 23);
            this.modifier.TabIndex = 1;
            this.modifier.Text = "modifier";
            this.modifier.UseVisualStyleBackColor = false;
            this.modifier.Click += new System.EventHandler(this.modifier_Click);
            // 
            // supprimer
            // 
            this.supprimer.BackColor = System.Drawing.Color.DarkGray;
            this.supprimer.Location = new System.Drawing.Point(154, 270);
            this.supprimer.Name = "supprimer";
            this.supprimer.Size = new System.Drawing.Size(141, 23);
            this.supprimer.TabIndex = 2;
            this.supprimer.Text = "supprimer";
            this.supprimer.UseVisualStyleBackColor = false;
            this.supprimer.Click += new System.EventHandler(this.supprimer_Click);
            // 
            // changer_pwd
            // 
            this.changer_pwd.BackColor = System.Drawing.Color.DarkGray;
            this.changer_pwd.Location = new System.Drawing.Point(301, 270);
            this.changer_pwd.Name = "changer_pwd";
            this.changer_pwd.Size = new System.Drawing.Size(141, 23);
            this.changer_pwd.TabIndex = 3;
            this.changer_pwd.Text = "changer pwd";
            this.changer_pwd.UseVisualStyleBackColor = false;
            this.changer_pwd.Click += new System.EventHandler(this.changer_pwd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "les développeurs";
            // 
            // textbox_Name
            // 
            this.textbox_Name.Location = new System.Drawing.Point(52, 21);
            this.textbox_Name.Name = "textbox_Name";
            this.textbox_Name.Size = new System.Drawing.Size(390, 20);
            this.textbox_Name.TabIndex = 5;
            this.textbox_Name.TextChanged += new System.EventHandler(this.textbox_Name_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "nom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "prenom";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox_Prénom
            // 
            this.textBox_Prénom.Location = new System.Drawing.Point(52, 60);
            this.textBox_Prénom.Name = "textBox_Prénom";
            this.textBox_Prénom.Size = new System.Drawing.Size(390, 20);
            this.textBox_Prénom.TabIndex = 7;
            this.textBox_Prénom.TextChanged += new System.EventHandler(this.textBox_Prénom_TextChanged);
            // 
            // textBox_Mail
            // 
            this.textBox_Mail.Location = new System.Drawing.Point(479, 21);
            this.textBox_Mail.Name = "textBox_Mail";
            this.textBox_Mail.Size = new System.Drawing.Size(243, 20);
            this.textBox_Mail.TabIndex = 9;
            this.textBox_Mail.TextChanged += new System.EventHandler(this.textBox_Mail_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "mail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(448, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "tel";
            // 
            // textBox_Tel
            // 
            this.textBox_Tel.Location = new System.Drawing.Point(479, 60);
            this.textBox_Tel.Name = "textBox_Tel";
            this.textBox_Tel.Size = new System.Drawing.Size(185, 20);
            this.textBox_Tel.TabIndex = 11;
            this.textBox_Tel.TextChanged += new System.EventHandler(this.textBox_Tel_TextChanged);
            // 
            // cboProfils
            // 
            this.cboProfils.FormattingEnabled = true;
            this.cboProfils.Location = new System.Drawing.Point(479, 96);
            this.cboProfils.Name = "cboProfils";
            this.cboProfils.Size = new System.Drawing.Size(185, 21);
            this.cboProfils.TabIndex = 13;
            this.cboProfils.SelectedIndexChanged += new System.EventHandler(this.cboProfils_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(448, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "profil";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cboFiltre);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.modifier);
            this.panel1.Controls.Add(this.supprimer);
            this.panel1.Controls.Add(this.changer_pwd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 303);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.annuler);
            this.panel2.Controls.Add(this.enregistrer);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textbox_Name);
            this.panel2.Controls.Add(this.cboProfils);
            this.panel2.Controls.Add(this.textBox_Prénom);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox_Tel);
            this.panel2.Controls.Add(this.textBox_Mail);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(12, 321);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 157);
            this.panel2.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "ajoutez un développeur";
            // 
            // annuler
            // 
            this.annuler.BackColor = System.Drawing.Color.DarkGray;
            this.annuler.Location = new System.Drawing.Point(154, 128);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(141, 23);
            this.annuler.TabIndex = 15;
            this.annuler.Text = "annuler";
            this.annuler.UseVisualStyleBackColor = false;
            this.annuler.Click += new System.EventHandler(this.annuler_Click);
            // 
            // enregistrer
            // 
            this.enregistrer.BackColor = System.Drawing.Color.DarkGray;
            this.enregistrer.Location = new System.Drawing.Point(7, 128);
            this.enregistrer.Name = "enregistrer";
            this.enregistrer.Size = new System.Drawing.Size(141, 23);
            this.enregistrer.TabIndex = 5;
            this.enregistrer.Text = "enregistrer";
            this.enregistrer.UseVisualStyleBackColor = false;
            this.enregistrer.Click += new System.EventHandler(this.enregistrer_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.annuler_pwd);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.Enregistrer_pwd);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(12, 484);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(736, 107);
            this.panel3.TabIndex = 17;
            // 
            // annuler_pwd
            // 
            this.annuler_pwd.BackColor = System.Drawing.Color.DarkGray;
            this.annuler_pwd.Location = new System.Drawing.Point(154, 67);
            this.annuler_pwd.Name = "annuler_pwd";
            this.annuler_pwd.Size = new System.Drawing.Size(141, 23);
            this.annuler_pwd.TabIndex = 17;
            this.annuler_pwd.Text = "annuler";
            this.annuler_pwd.UseVisualStyleBackColor = false;
            this.annuler_pwd.Click += new System.EventHandler(this.annuler_pwd_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(310, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "encore";
            // 
            // Enregistrer_pwd
            // 
            this.Enregistrer_pwd.BackColor = System.Drawing.Color.DarkGray;
            this.Enregistrer_pwd.Location = new System.Drawing.Point(7, 67);
            this.Enregistrer_pwd.Name = "Enregistrer_pwd";
            this.Enregistrer_pwd.Size = new System.Drawing.Size(141, 23);
            this.Enregistrer_pwd.TabIndex = 16;
            this.Enregistrer_pwd.Text = "Enregistrer";
            this.Enregistrer_pwd.UseVisualStyleBackColor = false;
            this.Enregistrer_pwd.Click += new System.EventHandler(this.Enregistrer_pwd_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(356, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(273, 20);
            this.textBox2.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "pwd";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(36, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "changer le mot de passe";
            // 
            // cboFiltre
            // 
            this.cboFiltre.FormattingEnabled = true;
            this.cboFiltre.Location = new System.Drawing.Point(547, 270);
            this.cboFiltre.Name = "cboFiltre";
            this.cboFiltre.Size = new System.Drawing.Size(161, 21);
            this.cboFiltre.TabIndex = 5;
            this.cboFiltre.SelectedIndexChanged += new System.EventHandler(this.cboFiltre_SelectedIndexChanged);
            // 
            // FrmHabilitations
            // 
            this.ClientSize = new System.Drawing.Size(773, 597);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmHabilitations";
            this.Load += new System.EventHandler(this.FrmHabilitations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button modifier;
        private System.Windows.Forms.Button supprimer;
        private System.Windows.Forms.Button changer_pwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Prénom;
        private System.Windows.Forms.TextBox textBox_Mail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Tel;
        private System.Windows.Forms.ComboBox cboProfils;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button enregistrer;
        private System.Windows.Forms.Button annuler;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button annuler_pwd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Enregistrer_pwd;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cboFiltre;
    }
}

