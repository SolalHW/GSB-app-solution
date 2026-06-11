using System;

namespace GSB_Frais.Models
{
    /// <summary>
    /// Modèle représentant une ligne de frais hors forfait
    /// </summary>
    public class LigneFraisHorsForfait
    {
        public int IdLHFF { get; set; }
        public string Libelle { get; set; }
        public decimal Montant { get; set; }
        public string Justificatif { get; set; }
        public int IdFiche { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        // Navigation properties
        public FicheFrais FicheFrais { get; set; }

        public override string ToString() => $"{Libelle} ({Montant:C})";
    }
}
