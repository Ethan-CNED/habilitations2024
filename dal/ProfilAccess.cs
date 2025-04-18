using System;
using System.Collections.Generic;
using habilitations2024.model;

namespace habilitations2024.dal
{
    public class ProfilAccess
    {
        // Instance unique de l'accès aux données
        private readonly Access access = null;

        // Constructeur qui initialise l’accès aux données
        public ProfilAccess()
        {
            access = Access.GetInstance();
        }

        // Récupère et retourne la liste des profils
        public List<Profil> GetLesProfils()
        {
            List<Profil> lesProfils = new List<Profil>();

            try
            {
                // Exécution de la requête SELECT avec le bon nom de table
                string query = "SELECT idprofil, nom FROM profil";
                List<object[]> records = access.Manager.ReqSelect(query);

                // Vérifier que la liste des résultats n'est pas vide
                if (records != null)
                {
                    foreach (object[] record in records)
                    {
                        // Création de l’objet Profil avec les valeurs extraites
                        Profil profil = new Profil(Convert.ToInt32(record[0]), record[1].ToString());

                        // Ajout du profil à la liste
                        lesProfils.Add(profil);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur lors de la récupération des profils : " + e.Message);
            }

            return lesProfils;
        }
    }
}
