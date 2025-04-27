using System;
using System.Collections.Generic;
using System.Windows.Forms;
using habilitations2024.controller;
using habilitations2024.model;
using habilitations2024.dal;

namespace habilitations2024.view
{
    public partial class FrmHabilitations : Form
    {
        private FrmHabilitationsController controller;
        private Developpeur newDev; // instance globale dans le formulaire
        private readonly Access access;

        public FrmHabilitations()
        {
            InitializeComponent();
            access = Access.GetInstance();
            controller = new FrmHabilitationsController();
            this.Load += FrmHabilitations_Load;
            // On instancie newDev avec le constructeur par défaut (avec des parenthèses)
            newDev = new Developpeur();
            textBox1.PasswordChar = '*';
            textBox2.PasswordChar = '*';

        }

        private void FrmHabilitations_Load(object sender, EventArgs e)
        {
            RemplirComboFiltre();
            LoadDeveloppeurs();
            LoadProfils();

        }

        private void LoadDeveloppeurs()
        {
            List<Developpeur> lesDeveloppeurs = controller.GetLesDeveloppeur();
            dataGridView1.DataSource = null;

            if (lesDeveloppeurs.Count > 0)
            {
                dataGridView1.DataSource = lesDeveloppeurs;
            }
            else
            {
                MessageBox.Show("Aucun développeur trouvé !");
            }
        }

        private void LoadProfils()
        {
            List<Profil> lesProfils = controller.GetLesProfil();

            if (lesProfils.Count > 0)
            {
                cboProfils.DataSource = lesProfils;
                cboProfils.DisplayMember = "Nom";
                cboProfils.ValueMember = "Idprofil";
            }
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            // Vérifier qu'une ligne est sélectionnée dans le DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Récupérer le développeur sélectionné à partir de la ligne
                Developpeur selectedDev = (Developpeur)dataGridView1.SelectedRows[0].DataBoundItem;

                // Vérifier que les champs obligatoires sont remplis
                if (!string.IsNullOrEmpty(textbox_Name.Text.Trim()) &&
                    !string.IsNullOrEmpty(textBox_Prénom.Text.Trim()) &&
                    cboProfils.SelectedItem != null)
                {
                    // Mettre à jour les propriétés du développeur avec les nouvelles valeurs
                    selectedDev.Nom = textbox_Name.Text.Trim();
                    selectedDev.Prenom = textBox_Prénom.Text.Trim();
                    selectedDev.Tel = textBox_Tel.Text.Trim();   // Si un numéro est disponible
                    selectedDev.Mail = textBox_Mail.Text.Trim();   // Si l'email est disponible
                    selectedDev.Profil = (Profil)cboProfils.SelectedItem;

                    // Appeler le contrôleur afin de mettre à jour le développeur dans la base
                    controller.UpdateDeveloppeur(selectedDev);

                    // Recharger la liste des développeurs pour refléter la modification
                    LoadDeveloppeurs();

                    // Affichage d'un message de confirmation
                    MessageBox.Show("Développeur modifié avec succès !");
                }
                else
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires avant de modifier.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un développeur à modifier.");
            }
        }


        private void supprimer_Click(object sender, EventArgs e)
        {
            // Vérifie qu'une ligne est bien sélectionnée dans le DataGridView.
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Récupère l'objet Developpeur associé à la première ligne sélectionnée.
                Developpeur selectedDev = (Developpeur)dataGridView1.SelectedRows[0].DataBoundItem;

                // Affichage d'une boîte de dialogue de confirmation.
                DialogResult confirmation = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce développeur ?", "Confirmation",
                                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Vérifie la réponse
                if (confirmation == DialogResult.Yes)
                {
                    // Appel du contrôleur pour supprimer le développeur de la base.
                    controller.DelDeveloppeur(selectedDev);
                    // Recharge la liste des développeurs pour mettre à jour l'affichage.
                    LoadDeveloppeurs();
                    // Affichage d'un message de confirmation.
                    MessageBox.Show("Développeur supprimé avec succès.");
                }
            }
            else
            {
                // Avertir l'utilisateur qu'il doit sélectionner un développeur
                MessageBox.Show("Sélectionnez un développeur à supprimer.");
            }
        }


        private void enregistrer_Click(object sender, EventArgs e)
        {
            // Vous pouvez ajuster la vérification selon les champs obligatoires
            if (!string.IsNullOrEmpty(textbox_Name.Text.Trim()) &&
                !string.IsNullOrEmpty(textBox_Prénom.Text.Trim()) &&
                cboProfils.SelectedItem != null)
            {
                // Récupère le profil sélectionné depuis le ComboBox.
                Profil selectedProfil = (Profil)cboProfils.SelectedItem;

                // Crée une nouvelle instance de Developpeur avec les informations saisies.
                Developpeur newDev = new Developpeur()
                {
                    Nom = textbox_Name.Text.Trim(),
                    Prenom = textBox_Prénom.Text.Trim(),
                    Tel = textBox_Tel.Text.Trim(),   // S'il existe, sinon ""
                    Mail = textBox_Mail.Text.Trim(), // S'il existe, sinon ""
                    Profil = selectedProfil
                };

                // Appel à la méthode d'ajout dans le contrôleur.
                controller.AddDeveloppeur(newDev);

                // Recharge la liste des développeurs pour afficher le nouvel enregistrement.
                LoadDeveloppeurs();

                // Optionnel : affiche une confirmation.
                MessageBox.Show("Développeur ajouté avec succès.");
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires avant l'enregistrement.");
            }
        }


        private void changer_pwd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Activer le panel pour permettre la saisie
                panel3.Enabled = true;
                // Réinitialiser les champs de saisie
                textBox1.Text = "";
                textBox2.Text = "";
                // On peut s'assurer qu'ils masquent la saisie
                textBox1.PasswordChar = '*';
                textBox2.PasswordChar = '*';
            }
            else
            {
                MessageBox.Show("Sélectionnez un développeur pour changer son mot de passe.");
            }
        }

        private void Enregistrer_pwd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Vérifier que les zones de saisie ne sont pas vides et que les mots de passe correspondent
                if (!string.IsNullOrEmpty(textBox1.Text.Trim()) &&
                    textBox1.Text == textBox2.Text)
                {
                    Developpeur selectedDev = (Developpeur)dataGridView1.SelectedRows[0].DataBoundItem;
                    string newPwd = textBox1.Text.Trim();

                    // Appeler la méthode du contrôleur pour mettre à jour le mot de passe
                    controller.UpdatePwd(selectedDev, newPwd);

                    // On désactive le panel une fois l'opération terminée
                    panel3.Enabled = false;

                    MessageBox.Show("Mot de passe mis à jour avec succès !");
                }
                else
                {
                    MessageBox.Show("Les mots de passe ne correspondent pas ou sont vides !");
                }
            }
            else
            {
                MessageBox.Show("Sélectionnez un développeur pour changer son mot de passe.");
            }
        }

        private void RemplirComboFiltre()
        {
            cboFiltre.Items.Clear();
            cboFiltre.Items.Add(""); 

            try
            {
                // Récupérer tous les profils depuis la base
                string query = "SELECT nom FROM profil";
                List<object[]> records = access.Manager.ReqSelect(query, new Dictionary<string, object>()); 

                foreach (object[] record in records)
                {
                    cboFiltre.Items.Add(record[0]?.ToString());
                }

                // Laissez par défaut la première ligne vide quand l'application sera éxéctué 
                cboFiltre.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des profils : " + ex.Message);
            }
        }


        private void cboFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtreProfil = cboFiltre.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(filtreProfil))
            {
                filtreProfil = null; // Si aucun profil sélectionné, afficher tous les développeurs
            }

            ChargerListeDeveloppeurs(filtreProfil);

            var tests = new DeveloppeurAccess();
            tests.LancerTests(filtreProfil);
        }


        private void ChargerListeDeveloppeurs(string filtreProfil = null)
        {
            dataGridView1.DataSource = null;

            // Vérifie si filtreProfil est vide pour afficher tous les développeurs
            if (string.IsNullOrWhiteSpace(filtreProfil))
            {
                filtreProfil = null;  // Si aucun profil sélectionné, afficher tous les développeurs
            }

            // Récupérer les développeurs filtrés depuis le contrôleur
            List<Developpeur> developpeurs = controller.GetLesDeveloppeur(filtreProfil);

            if (developpeurs.Count > 0)
            {
                dataGridView1.DataSource = developpeurs;
            }
            else
            {
                MessageBox.Show("Aucun développeur trouvé avec ce profil !");
            }
        }




        private void annuler_pwd_Click(object sender, EventArgs e)
        {
            panel3.Enabled = false;
        }

        private void cboProfils_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Placeholder
        }

        private void textbox_Name_TextChanged(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void textBox_Prénom_TextChanged(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void textBox_Mail_TextChanged(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void textBox_Tel_TextChanged(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void SomeMethod()
        {
            // Exemple d'utilisation de l'instance globale dans le formulaire
            Program.GlobalDeveloppeur.Nom = textbox_Name.Text;
        }

    }
}
