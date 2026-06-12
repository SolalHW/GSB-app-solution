using System;
using System.Threading.Tasks;
using GSB_Frais.Models;
using GSB_Frais.DAL.Repositories;

namespace GSB_Frais.Metier.Services
{
    /// <summary>
    /// Service pour la validation des fiches de frais (rôle comptable)
    /// </summary>
    public class ValidationService
    {
        private readonly FicheFraisRepository _ficheFraisRepo;

        public ValidationService()
        {
            _ficheFraisRepo = new FicheFraisRepository();
        }

        /// <summary>
        /// Valide complètement une fiche de frais
        /// </summary>
        public async Task<bool> ValidateCompleteFicheAsync(int idFiche)
        {
            var fiche = await _ficheFraisRepo.GetByIdAsync(idFiche);
            if (fiche == null || !fiche.EstEnAttente)
                throw new InvalidOperationException("Cette fiche ne peut pas être validée");

            fiche.Etat = "VALIDEE";
            return await _ficheFraisRepo.UpdateAsync(fiche);
        }

        /// <summary>
        /// Refuse complètement une fiche de frais
        /// </summary>
        public async Task<bool> RejectCompleteFicheAsync(int idFiche, string motifRefus)
        {
            var fiche = await _ficheFraisRepo.GetByIdAsync(idFiche);
            if (fiche == null || !fiche.EstEnAttente)
                throw new InvalidOperationException("Cette fiche ne peut pas être refusée");

            fiche.Etat = "REFUSEE";
            fiche.Observations = $"REFUS: {motifRefus}";
            return await _ficheFraisRepo.UpdateAsync(fiche);
        }

        /// <summary>
        /// Valide une fiche en refusant certaines lignes (refus partiel)
        /// </summary>
        public async Task<bool> ValidatePartialFicheAsync(int idFiche, string observationsRefus)
        {
            var fiche = await _ficheFraisRepo.GetByIdAsync(idFiche);
            if (fiche == null || !fiche.EstEnAttente)
                throw new InvalidOperationException("Cette fiche ne peut pas être validée partiellement");

            fiche.Etat = "REFUS_PARTIEL";
            fiche.Observations = $"REFUS PARTIEL: {observationsRefus}";
            return await _ficheFraisRepo.UpdateAsync(fiche);
        }

        /// <summary>
        /// Vérifie si une fiche peut être validée (montant, format, etc.)
        /// </summary>
        public bool ValidateFicheFormat(FicheFrais fiche)
        {
            if (fiche == null)
                return false;

            if (string.IsNullOrWhiteSpace(fiche.Mois) || fiche.Mois.Length != 6)
                return false;

            if (!int.TryParse(fiche.Mois.Substring(0, 4), out int annee) || annee < 2000 || annee > 2100)
                return false;

            if (!int.TryParse(fiche.Mois.Substring(4, 2), out int mois) || mois < 1 || mois > 12)
                return false;

            if (fiche.MontantTotal < 0)
                return false;

            return true;
        }
    }
}
