using habilitations2024.dal;
using habilitations2024.model;
using habilitations2024.controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace habilitations2024.view
{
    public class FrmAuthentifications : Form
    {
        // Instance unique de l'accès aux données
        private readonly Access access;
        private FrmAuthentificationController _controlleur;
        // Constructeur qui initialise l’accès aux données
        public FrmAuthentifications()
        {
            InitializeComponent();
            access = Access.GetInstance();
            _controlleur = new FrmAuthentificationController();

        }

        // Méthode de contrôle de l'authentification d'un administrateur
        public bool ControleAuthentification(Admin admin)
        {
            try
            {
                // Requête SQL avec jointure pour vérifier si l'utilisateur est bien un administrateur
                string query = @"
                    SELECT COUNT(*) 
                    FROM developpeur d
                    JOIN profil p ON d.idprofil = p.idprofil
                    WHERE d.nom = @nom
                    AND d.prenom = @prenom
                    AND d.pwd = SHA2(@pwd, 256)  -- Comparaison avec le mot de passe haché
                    AND p.nom = 'admin'";

                // Paramètres sécurisés pour éviter l'injection SQL
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@nom", admin.Nom },
                    { "@prenom", admin.Prenom },
                    { "@pwd", admin.Password }
                };

                // Exécuter la requête et récupérer le nombre de correspondances
                int count = Convert.ToInt32(access.Manager.ReqSelectScalar(query, parameters));

                // Si une ligne correspond, l'authentification est réussie
                return count > 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors de l'authentification : " + e.Message);
                return false;
            }
        }

        // Récupère et retourne la liste des développeurs avec le vrai nom de leur profil
        public List<Developpeur> GetLesDeveloppeur()
        {
            List<Developpeur> lesDeveloppeurs = new List<Developpeur>();

            try
            {
                // Requête avec jointure pour récupérer le nom réel du profil via la table "profil"
                string query = @"
                    SELECT d.iddeveloppeur, d.nom, d.prenom, d.tel, d.mail, 
                           p.idprofil, p.nom AS nomProfil
                    FROM developpeur d
                    JOIN profil p ON d.idprofil = p.idprofil";

                List<object[]> records = access.Manager.ReqSelect(query);

                if (records != null)
                {
                    foreach (object[] record in records)
                    {
                        int id = Convert.ToInt32(record[0]);
                        string nom = record[1]?.ToString() ?? "Nom inconnu";
                        string prenom = record[2]?.ToString() ?? "Prénom inconnu";
                        string tel = record[3]?.ToString() ?? "Téléphone inconnu";
                        string mail = record[4]?.ToString() ?? "Mail inconnu";
                        int idProfil = Convert.ToInt32(record[5]);
                        string nomProfil = record[6]?.ToString() ?? "Nom inconnu";

                        // Création de l'objet Profil avec le nom correct récupéré via la jointure
                        Profil profil = new Profil(idProfil, nomProfil);

                        // Création de l'objet Developpeur en lui affectant son Profil complet
                        Developpeur developpeur = new Developpeur(id, nom, prenom, tel, mail, profil);
                        lesDeveloppeurs.Add(developpeur);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur SQL : " + e.Message);
            }

            return lesDeveloppeurs;
        }

        // Méthodes de gestion des développeurs (ajout, suppression, mise à jour)
        public void DelDeveloppeur(Developpeur developpeur)
        {
            try
            {
                string query = "DELETE FROM developpeur WHERE iddeveloppeur = @idDeveloppeur";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@idDeveloppeur", developpeur.Iddeveloppeur }
                };
                access.Manager.ReqUpdate(query, parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur suppression : " + e.Message);
            }
        }

        public void AddDeveloppeur(Developpeur developpeur)
        {
            try
            {
                string query = "INSERT INTO developpeur (nom, prenom, tel, mail, idprofil) VALUES (@nom, @prenom, @tel, @mail, @idProfil)";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@nom", developpeur.Nom },
                    { "@prenom", developpeur.Prenom },
                    { "@tel", developpeur.Tel },
                    { "@mail", developpeur.Mail },
                    { "@idProfil", developpeur.Profil.Idprofil }
                };
                access.Manager.ReqUpdate(query, parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur ajout : " + e.Message);
            }
        }

        public void UpdateDeveloppeur(Developpeur developpeur)
        {
            try
            {
                string query = "UPDATE developpeur SET nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, idprofil = @idProfil WHERE iddeveloppeur = @idDeveloppeur";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@nom", developpeur.Nom },
                    { "@prenom", developpeur.Prenom },
                    { "@tel", developpeur.Tel },
                    { "@mail", developpeur.Mail },
                    { "@idProfil", developpeur.Profil.Idprofil },
                    { "@idDeveloppeur", developpeur.Iddeveloppeur }
                };
                access.Manager.ReqUpdate(query, parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur modification : " + e.Message);
            }
        }

        public void UpdatePwd(Developpeur developpeur, string newPwd)
        {
            try
            {
                string query = "UPDATE developpeur SET pwd = SHA2(@pwd, 256) WHERE iddeveloppeur = @idDeveloppeur";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@pwd", newPwd },
                    { "@idDeveloppeur", developpeur.Iddeveloppeur }
                };
                access.Manager.ReqUpdate(query, parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur changement de mot de passe : " + e.Message);
            }
        }

        private void InitializeComponent()
        {
            this.textBox_Nom_Admin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Prénom_Admin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_pwd_admin = new System.Windows.Forms.TextBox();
            this.btn_Connecter = new System.Windows.Forms.Button();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Nom_Admin
            // 
            this.textBox_Nom_Admin.Location = new System.Drawing.Point(52, -3);
            this.textBox_Nom_Admin.Name = "textBox_Nom_Admin";
            this.textBox_Nom_Admin.Size = new System.Drawing.Size(323, 20);
            this.textBox_Nom_Admin.TabIndex = 0;
            this.textBox_Nom_Admin.TextChanged += new System.EventHandler(this.textBox_Nom_Admin_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom";
            this.label1.Click += new System.EventHandler(this.label_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prénom";
            // 
            // textBox_Prénom_Admin
            // 
            this.textBox_Prénom_Admin.Location = new System.Drawing.Point(52, 33);
            this.textBox_Prénom_Admin.Name = "textBox_Prénom_Admin";
            this.textBox_Prénom_Admin.Size = new System.Drawing.Size(323, 20);
            this.textBox_Prénom_Admin.TabIndex = 2;
            this.textBox_Prénom_Admin.TextChanged += new System.EventHandler(this.textBox_Prénom_Admin_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "pwd";
            // 
            // textBox_pwd_admin
            // 
            this.textBox_pwd_admin.Location = new System.Drawing.Point(52, 71);
            this.textBox_pwd_admin.Name = "textBox_pwd_admin";
            this.textBox_pwd_admin.Size = new System.Drawing.Size(323, 20);
            this.textBox_pwd_admin.TabIndex = 4;
            // 
            // btn_Connecter
            // 
            this.btn_Connecter.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_Connecter.Location = new System.Drawing.Point(6, 108);
            this.btn_Connecter.Name = "btn_Connecter";
            this.btn_Connecter.Size = new System.Drawing.Size(168, 23);
            this.btn_Connecter.TabIndex = 6;
            this.btn_Connecter.Text = "Connecter";
            this.btn_Connecter.UseVisualStyleBackColor = false;
            this.btn_Connecter.Click += new System.EventHandler(this.btn_Connecter_Click);
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.label1);
            this.Panel4.Controls.Add(this.btn_Connecter);
            this.Panel4.Controls.Add(this.textBox_Nom_Admin);
            this.Panel4.Controls.Add(this.label3);
            this.Panel4.Controls.Add(this.textBox_Prénom_Admin);
            this.Panel4.Controls.Add(this.textBox_pwd_admin);
            this.Panel4.Controls.Add(this.label2);
            this.Panel4.Location = new System.Drawing.Point(12, 12);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(403, 142);
            this.Panel4.TabIndex = 7;
            // 
            // FrmAuthentifications
            // 
            this.ClientSize = new System.Drawing.Size(427, 244);
            this.Controls.Add(this.Panel4);
            this.Name = "FrmAuthentifications";
            this.Load += new System.EventHandler(this.FrmAuthentifications_Load);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        private TextBox textBox_Nom_Admin;
        private Label label1;

        private void label_Click(object sender, EventArgs e)
        {

        }

        private Label label2;
        private TextBox textBox_Prénom_Admin;
        private Label label3;
        private TextBox textBox_pwd_admin;
        private Button btn_Connecter;

        // Gestionnaire de clic pour le bouton de connexion.
        private void btn_Connecter_Click(object sender, EventArgs e)
        {
            // Vérification que tous les champs sont remplis.
            if (string.IsNullOrWhiteSpace(textBox_Nom_Admin.Text) ||
                string.IsNullOrWhiteSpace(textBox_Prénom_Admin.Text) ||
                string.IsNullOrWhiteSpace(textBox_pwd_admin.Text))
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Création de l'objet Admin à partir des informations saisies.
            Admin admin = new Admin(
                textBox_Nom_Admin.Text.Trim(),
                textBox_Prénom_Admin.Text.Trim(),
                textBox_pwd_admin.Text
            );

            // Demande au contrôleur de vérifier l'authentification.
            bool authentificationReussie = _controlleur.ControleAuthentification(admin);

            if (authentificationReussie)
            {
                // Si l'authentification est correcte, créer et afficher FrmHabilitations.
                MessageBox.Show("Authentification réussie !");
                FrmHabilitations frmHabilitations = new FrmHabilitations();
                frmHabilitations.Show();

                // Optionnel : Vous pouvez masquer ou fermer le formulaire d'authentification
                this.Hide(); // ou bien this.Close();
            }
            else
            {
                // Si l'authentification échoue, afficher un message d'erreur.
                MessageBox.Show("Identifiants incorrects. Veuillez réessayer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox_Nom_Admin_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Prénom_Admin_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmAuthentifications_Load(object sender, EventArgs e)
        {
            // Assurez-vous que la zone de saisie du mot de passe existe et est nommée correctement.
            textBox_pwd_admin.PasswordChar = '*';
        }

        private Panel Panel4;
    }
}
