using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{
    public class Admin
    {
        // Propriétés en lecture seule (auto-property avec seulement "get")
        public string Nom { get; }
        public string Prenom { get; }
        public string Password { get; }

        // Constructeur qui valorise les propriétés
        public Admin(string nom, string prenom, string password)
        {
            Nom = nom;
            Prenom = prenom;
            Password = password;
        }
    }
}
