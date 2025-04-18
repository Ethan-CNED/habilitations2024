using habilitations2024.bddmanager;
using System;

namespace habilitations2024.dal
{
    public class Access
    {
        // Chaine de connexion à la base de données
        private static readonly string connectionString = "server=localhost;database=habilitations;user=habilitations;password=V*HwzslwSq0dkWFw";

        // Instance unique de la classe Access (singleton)
        private static Access instance = null;

        // Propriété pour accéder au gestionnaire de BDD (BddManager)
        public BddManager Manager { get; }

        // Constructeur privé (singleton) qui initialise la connexion
        private Access()
        {
            try
            {
                Manager = BddManager.GetInstance(connectionString);
            }
            catch (Exception)
            {
                Environment.Exit(0); // Quitte l'application en cas d'échec de connexion
            }
        }

        // Méthode statique pour récupérer l'instance unique de Access
        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }
    }
}
