using System;

namespace GSB_Frais.Models
{
    /// <summary>
    /// Modèle représentant un utilisateur de l'application
    /// </summary>
    public class Utilisateur
    {
        public int IdUtilisateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string MdpHash { get; set; }
        public string Role { get; set; } // ADMIN, VISITEUR, COMPTABLE
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public bool Actif { get; set; }

        public string NomComplet => $"{Prenom} {Nom}";

        public override string ToString() => NomComplet;
    }
}
