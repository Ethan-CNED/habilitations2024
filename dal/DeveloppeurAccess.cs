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
        public List<Developpeur> GetLesDeveloppeur(string filtreProfil = null, bool testMode = false)
        {
            List<Developpeur> lesDeveloppeurs = new List<Developpeur>();

            try
            {
                string query = @"
        SELECT d.iddeveloppeur, d.nom, d.prenom, d.tel, d.mail, 
               p.idprofil, p.nom AS nomProfil
        FROM developpeur d
        JOIN profil p ON d.idprofil = p.idprofil";

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                if (!string.IsNullOrWhiteSpace(filtreProfil))
                {
                    query += " WHERE p.nom = @profil";
                    parameters.Add("@profil", filtreProfil);
                }

                List<object[]> records = access.Manager.ReqSelect(query, parameters);

                foreach (object[] record in records)
                {
                    int id = Convert.ToInt32(record[0]);
                    string nom = record[1]?.ToString() ?? "Nom inconnu";
                    string prenom = record[2]?.ToString() ?? "Prénom inconnu";
                    string tel = record[3]?.ToString() ?? "Téléphone inconnu";
                    string mail = record[4]?.ToString() ?? "Mail inconnu";
                    int idProfil = Convert.ToInt32(record[5]);
                    string nomProfil = record[6]?.ToString() ?? "Profil inconnu";

                    Profil profil = new Profil(idProfil, nomProfil);
                    Developpeur developpeur = new Developpeur(id, nom, prenom, tel, mail, profil);
                    lesDeveloppeurs.Add(developpeur);
                }

                // Validation automatique avec CountDeveloppeurs
                if (testMode)
                {
                    int expectedCount = CountDeveloppeurs(filtreProfil);  // Appelle automatiquement pour obtenir le nombre attendu

                    if (lesDeveloppeurs.Count != expectedCount)
                    {
                        throw new Exception($"Test échoué : Attendu {expectedCount}, trouvé {lesDeveloppeurs.Count}.");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur SQL ou validation : " + e.Message);
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
        public int CountDeveloppeurs(string filtreProfil = null)
        {
            try
            {
                string query = @"
        SELECT COUNT(*)
        FROM developpeur d
        JOIN profil p ON d.idprofil = p.idprofil";

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                if (!string.IsNullOrWhiteSpace(filtreProfil))
                {
                    query += " WHERE p.nom = @profil";
                    parameters.Add("@profil", filtreProfil);
                }

                List<object[]> result = access.Manager.ReqSelect(query, parameters);

                // Retourne le résultat de la requête COUNT(*)
                return Convert.ToInt32(result[0][0]);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors du comptage des développeurs : " + e.Message);
                return 0;
            }
        }

        public void LancerTests(string filtreProfil)
        {
            var developpeurAccess = new DeveloppeurAccess();

            try
            {
                // Indiquer quel test est en cours en fonction du filtre
                if (!string.IsNullOrWhiteSpace(filtreProfil))
                {
                    Console.WriteLine($"\nTest : Vérification pour le profil '{filtreProfil}'...");
                }
                else
                {
                    Console.WriteLine("\nTest : Vérification sans filtre (tous les développeurs)...");
                }

                // Exécuter le test unitaire avec ou sans filtre
                developpeurAccess.GetLesDeveloppeur(filtreProfil, true);

                // Afficher un message de réussite en fonction du filtre
                if (!string.IsNullOrWhiteSpace(filtreProfil))
                {
                    Console.WriteLine("Test réussi : Le nombre de développeurs pour le profil '{filtreProfil}' est correct.");
                }
                else
                {
                    Console.WriteLine("Test réussi : Le nombre total de développeurs est correct.");
                }
            }
            catch (Exception ex)
            {
                // En cas d'échec, afficher une erreur avec le contexte
                if (!string.IsNullOrWhiteSpace(filtreProfil))
                {
                    Console.WriteLine("Test échoué pour le profil '{filtreProfil}' : {ex.Message}");
                }
                else
                {
                    Console.WriteLine("Test échoué pour tous les développeurs : {ex.Message}");
                }
            }
        }


    }
}
