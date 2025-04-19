using System;
using habilitations2024.model;
using habilitations2024.dal;
using System.Collections.Generic;

namespace habilitations2024.controller
{
    public class FrmAuthentificationController
    {
        // Accès aux données pour vérifier l'authentification
        private readonly DeveloppeurAccess developpeurAccess;

        // Constructeur qui initialise la dépendance
        public FrmAuthentificationController()
        {
            // Si DeveloppeurAccess n'a pas de méthode GetInstance(), on l'instancie directement.
            developpeurAccess = new DeveloppeurAccess();
        }

        /// <summary>
        /// Vérifie l'authentification d'un administrateur.
        /// </summary>
        /// <param name="admin">Objet Admin contenant les identifiants.</param>
        /// <returns>True si l'authentification est réussie, sinon false.</returns>
        public bool ControleAuthentification(Admin admin)
        {
            if (admin == null)
                throw new ArgumentNullException(nameof(admin));

            // Appel de la méthode de validation sur l'instance developpeurAccess.
            return developpeurAccess.ControleAuthentification(admin);
        }
    }
}
