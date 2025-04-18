using System;

namespace habilitations2024.model
{
    public class Profil
    {
        // 🔹 Propriétés privées
        private int idprofil;
        private string nom;

        // 🔹 Getter uniquement pour idprofil (lecture seule)
        public int Idprofil { get => idprofil; }

        // 🔹 Getter pour nom (lecture seule)
        public string Nom { get; }

        // 🔹 Constructeur pour valoriser les propriétés
        public Profil(int idprofil, string nom)
        {
            this.idprofil = idprofil;
            this.Nom = nom;
        }

        // 🔹 Redéfinition de ToString() pour afficher juste le nom
        public override string ToString()
        {
            return Nom;
        }
    }
}
