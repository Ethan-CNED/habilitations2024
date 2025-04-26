using System;
using System.Collections.Generic;
using habilitations2024.model;
using habilitations2024.dal;

namespace habilitations2024.controller
{
    public class FrmHabilitationsController
    {
        // Objet d'accès aux opérations possibles sur Developpeur
        private readonly DeveloppeurAccess developpeurAccess;
        // Objet d'accès aux opérations possibles sur Profil
        private readonly ProfilAccess profilAccess;


        // Constructeur qui initialise l'accès aux données
        public FrmHabilitationsController()
        {
            developpeurAccess = new DeveloppeurAccess();
            profilAccess = new ProfilAccess();
        }

        // Récupère et retourne la liste des développeurs
        public List<Developpeur> GetLesDeveloppeur(string filtreProfil = null)
        {
            return developpeurAccess.GetLesDeveloppeur(filtreProfil); 
        }


        // Récupère et retourne la liste des profils
        public List<Profil> GetLesProfil()
        {
            return profilAccess.GetLesProfils();
        }

        // Demande de suppression d'un développeur
        public void DelDeveloppeur(Developpeur developpeur)
        {
            developpeurAccess.DelDeveloppeur(developpeur);
        }

        // Demande d'ajout d'un développeur
        public void AddDeveloppeur(Developpeur developpeur)
        {
            developpeurAccess.AddDeveloppeur(developpeur);
        }

        // Demande de modification d'un développeur
        public void UpdateDeveloppeur(Developpeur developpeur)
        {
            developpeurAccess.UpdateDeveloppeur(developpeur);
        }

        // Demande de changement de mot de passe
        public void UpdatePwd(Developpeur developpeur, string newPwd)
        {
            developpeurAccess.UpdatePwd(developpeur, newPwd);
        }
    }
}
