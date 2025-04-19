using System;
using System.Collections.Generic;
using System.Windows.Forms;
using habilitations2024.model;

namespace habilitations2024.dal
{
    public class DeveloppeurAccess
    {
        // Instance unique de l'accès aux données
        private readonly Access access;

        // Constructeur qui initialise l’accès aux données
        public DeveloppeurAccess()
        {
            access = Access.GetInstance();
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
                      AND d.pwd = SHA2(@pwd, 256)
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

        // Méthode de suppression d'un développeur
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

        // Méthode d'ajout d'un développeur
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

        // Méthode de modification d'un développeur
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

        // Méthode de mise à jour du mot de passe d'un développeur
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
    }
}
