using System;

namespace GSB_Frais.Models
{
    /// <summary>
    /// Modèle représentant une ligne de frais forfaitaire
    /// </summary>
    public class LigneFraisForfait
    {
        public int IdLFF { get; set; }
        public int Quantite { get; set; }
        public int IdFiche { get; set; }
        public int IdTypeFrais { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        // Navigation properties
        public FicheFrais FicheFrais { get; set; }
        public TypeFrais TypeFrais { get; set; }

        public decimal MontantLigne => TypeFrais?.Tarif * Quantite ?? 0m;

        public override string ToString() => $"{TypeFrais?.Libelle} (x{Quantite})";
    }
}
