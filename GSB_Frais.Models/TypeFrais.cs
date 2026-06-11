using System;

namespace GSB_Frais.Models
{
    /// <summary>
    /// Modèle représentant un type de frais (forfaitaire ou hors forfait)
    /// </summary>
    public class TypeFrais
    {
        public int IdTypeFrais { get; set; }
        public string Libelle { get; set; }
        public decimal Tarif { get; set; }
        public string Type { get; set; } // FORFAIT ou HORS_FORFAIT
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        public bool IsForfait => Type == "FORFAIT";

        public override string ToString() => Libelle;
    }
}
