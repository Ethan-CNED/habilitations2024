using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace habilitations2024.bddmanager
{
    /// Singleton : connexion à la base de données et exécution des requêtes
    public class BddManager
    {
        /// instance unique de la classe
        private static BddManager instance = null;
        /// objet de connexion à la BDD à partir d'une chaîne de connexion
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
        /// <param name="stringQuery">requête autre que select</param>
        /// <param name="parameters">dictionnire contenant les parametres</param>
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

    }
}
