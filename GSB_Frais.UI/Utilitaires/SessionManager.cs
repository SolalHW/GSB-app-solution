using System;
using System.Windows.Forms;

namespace GSB_Frais.UI.Utilitaires
{
    /// <summary>
    /// Gestionnaire de contexte utilisateur - Session utilisateur actuelle
    /// </summary>
    public static class SessionManager
    {
        public static GSB_Frais.Models.Utilisateur UtilisateurCourant { get; set; }

        public static bool IsConnected => UtilisateurCourant != null;

        public static bool IsAdmin => UtilisateurCourant?.Role == "ADMIN";
        public static bool IsComptable => UtilisateurCourant?.Role == "COMPTABLE";
        public static bool IsVisiteur => UtilisateurCourant?.Role == "VISITEUR";

        public static void Disconnect()
        {
            UtilisateurCourant = null;
        }
    }
}
