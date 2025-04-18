using System;

namespace habilitations2024.model
{
    public class Developpeur
    {
        // Propriété en lecture seule pour l'ID,
        // accessible en lecture partout mais uniquement modifiable en interne via le setter privé.
        public int Iddeveloppeur { get; private set; }

        // Propriétés automatiques pour faciliter l'utilisation avec un initialiseur d'objet
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public Profil Profil { get; set; }

        // Constructeur par défaut
        // Permet de créer un objet sans fournir immédiatement les 6 paramètres.
        public Developpeur()
        {
            Iddeveloppeur = 0;
            Nom = string.Empty;
            Prenom = string.Empty;
            Tel = string.Empty;
            Mail = string.Empty;
            Profil = null;
        }

        // Constructeur complet, au cas où vous disposeriez de toutes les informations dès le départ.
        public Developpeur(int id, string nom, string prenom, string tel, string mail, Profil profil)
        {
            Iddeveloppeur = id;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
            Mail = mail;
            Profil = profil;
        }
    }
}
