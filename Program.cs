using System;
using System.Windows.Forms;
using habilitations2024.model;
using habilitations2024.view;

namespace habilitations2024
{
    static class Program
    {
        // Propriété statique accessible dans toute l'application.
        // L'instance est créée avant l'exécution du Main.
        // Dans Program.cs ou dans une autre classe d'initialisation
        public static Developpeur GlobalDeveloppeur { get; private set; } = new Developpeur
        {
            Nom = "Default Name",   // Par exemple, ou string.Empty
            Prenom = string.Empty,
            Tel = string.Empty,
            Mail = string.Empty,
            // Vous pouvez initialiser Profil avec un profil par défaut si nécessaire.
            Profil = null
        };


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmHabilitations());
        }
    }
}
