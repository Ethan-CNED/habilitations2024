using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace habilitations2024.bddmanager
{
    /// Singleton : connexion à la base de données et exécution des requêtes
    public class BddManager
    {
        /// Instance unique de la classe
        private static BddManager instance = null;
        /// Objet de connexion à la BDD à partir d'une chaîne de connexion
        private readonly MySqlConnection connection;

        /// Constructeur pour créer la connexion à la BDD et l'ouvrir
        private BddManager(string stringConnect)
        {
            connection = new MySqlConnection(stringConnect);
            connection.Open();
        }

        /// Création d'une seule instance de la classe
        public static BddManager GetInstance(string stringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(stringConnect);
            }
            return instance;
        }

        /// Exécution d'une requête autre que "select"
        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// Exécution d'une requête "SELECT"
        public List<object[]> ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
        {
            List<object[]> records = new List<object[]>(); // Liste des résultats

            MySqlCommand command = new MySqlCommand(stringQuery, connection);

            // Ajout des paramètres à la requête si nécessaires
            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }

            command.Prepare();

            // Exécuter la requête et récupérer les résultats
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                int nbCols = reader.FieldCount; // Nombre de colonnes

                while (reader.Read()) // Parcourt chaque ligne du résultat
                {
                    object[] attributs = new object[nbCols]; // Création d'un tableau d'objets
                    reader.GetValues(attributs); // Remplissage du tableau avec les valeurs
                    records.Add(attributs); // Ajout à la liste
                }
            }

            return records; // Retourne la liste des résultats
        }

        /// Exécution d'une requête "SELECT" qui retourne une seule valeur (exemple : COUNT(*))
        public object ReqSelectScalar(string stringQuery, Dictionary<string, object> parameters = null)
        {
            object result = null;

            MySqlCommand command = new MySqlCommand(stringQuery, connection);

            // Ajout des paramètres à la requête si nécessaires
            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }

            command.Prepare();
            result = command.ExecuteScalar(); // Récupère la valeur scalaire

            return result;
        }
    }
}
