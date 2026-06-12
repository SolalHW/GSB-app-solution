using System;
using System.Collections.Generic;

namespace GSB_Frais.Models
{
    /// <summary>
    /// Modèle représentant une fiche de frais mensuelle
    /// </summary>
    public class FicheFrais
    {
        public int IdFiche { get; set; }
        public string Mois { get; set; } // Format AAAAMM
        public string Etat { get; set; } // EN_COURS, EN_ATTENTE, VALIDEE, REFUSEE, REFUS_PARTIEL
        public int IdUtilisateur { get; set; }
        public DateTime DateSaisie { get; set; }
        public DateTime DateModification { get; set; }
        public decimal MontantTotal { get; set; }
        public string Observations { get; set; }

        // Navigation properties
        public Utilisateur Utilisateur { get; set; }
        public List<LigneFraisForfait> LignesForfait { get; set; } = new List<LigneFraisForfait>();
        public List<LigneFraisHorsForfait> LignesHorsForfait { get; set; } = new List<LigneFraisHorsForfait>();

        public bool EstModifiable => Etat == "EN_COURS";
        public bool EstEnAttente => Etat == "EN_ATTENTE";
        public bool EstValidee => Etat == "VALIDEE";
        public bool EstRefusee => Etat == "REFUSEE";

        public override string ToString() => $"Fiche {Mois} - {Etat}";
    }
}
