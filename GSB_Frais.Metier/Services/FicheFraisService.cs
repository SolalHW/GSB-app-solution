using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSB_Frais.Models;
using GSB_Frais.DAL.Repositories;

namespace GSB_Frais.Metier.Services
{
    /// <summary>
    /// Service métier pour gérer les fiches de frais
    /// </summary>
    public class FicheFraisService
    {
        private readonly FicheFraisRepository _ficheFraisRepo;
        private readonly LigneFraisRepository _ligneRepo;
        private readonly TypeFraisRepository _typeFraisRepo;

        public FicheFraisService()
        {
            _ficheFraisRepo = new FicheFraisRepository();
            _ligneRepo = new LigneFraisRepository();
            _typeFraisRepo = new TypeFraisRepository();
        }

        /// <summary>
        /// Récupère toutes les fiches d'un utilisateur
        /// </summary>
        public async Task<List<FicheFrais>> GetFichesByUserAsync(int idUtilisateur)
        {
            return await _ficheFraisRepo.GetByUserAsync(idUtilisateur);
        }

        /// <summary>
        /// Récupère une fiche de frais par son ID
        /// </summary>
        public async Task<FicheFrais> GetFicheByIdAsync(int idFiche)
        {
            return await _ficheFraisRepo.GetByIdAsync(idFiche);
        }

        /// <summary>
        /// Récupère ou crée la fiche de frais pour un mois donné
        /// </summary>
        public async Task<FicheFrais> GetOrCreateFicheAsync(int idUtilisateur, string mois)
        {
            var fiche = await _ficheFraisRepo.GetByUserAndMonthAsync(idUtilisateur, mois);
            
            if (fiche == null)
            {
                // Créer une nouvelle fiche avec les types de frais forfait par défaut
                fiche = new FicheFrais
                {
                    IdUtilisateur = idUtilisateur,
                    Mois = mois,
                    Etat = "EN_COURS",
                    MontantTotal = 0
                };
                fiche.IdFiche = await _ficheFraisRepo.AddAsync(fiche);

                // Initialiser avec tous les types de frais forfait
                var typeForfait = await _typeFraisRepo.GetByTypeAsync("FORFAIT");
                foreach (var type in typeForfait)
                {
                    var ligne = new LigneFraisForfait
                    {
                        IdFiche = fiche.IdFiche,
                        IdTypeFrais = type.IdTypeFrais,
                        Quantite = 0
                    };
                    await _ligneRepo.AddLigneForfaitAsync(ligne);
                }

                fiche.LignesForfait = await _ligneRepo.GetLignesForfaitByFicheAsync(fiche.IdFiche);
                fiche.LignesHorsForfait = new List<LigneFraisHorsForfait>();
            }

            return fiche;
        }

        /// <summary>
        /// Soumet une fiche (passe l'état de EN_COURS à EN_ATTENTE)
        /// </summary>
        public async Task<bool> SubmitFicheAsync(int idFiche)
        {
            var fiche = await _ficheFraisRepo.GetByIdAsync(idFiche);
            if (fiche == null || !fiche.EstModifiable)
                throw new InvalidOperationException("Cette fiche ne peut pas être soumise");

            // Calculer le montant total
            decimal montant = 0;
            foreach (var ligne in fiche.LignesForfait)
            {
                montant += ligne.MontantLigne;
            }
            foreach (var ligne in fiche.LignesHorsForfait)
            {
                montant += ligne.Montant;
            }

            fiche.MontantTotal = montant;
            fiche.Etat = "EN_ATTENTE";

            return await _ficheFraisRepo.UpdateAsync(fiche);
        }

        /// <summary>
        /// Ajoute une ligne de frais hors forfait
        /// </summary>
        public async Task<int> AddLigneHorsForfaitAsync(int idFiche, string libelle, decimal montant, string justificatif = "")
        {
            if (montant <= 0)
                throw new ArgumentException("Le montant doit être positif");

            var ligne = new LigneFraisHorsForfait
            {
                IdFiche = idFiche,
                Libelle = libelle,
                Montant = montant,
                Justificatif = justificatif
            };

            return await _ligneRepo.AddLigneHorsForfaitAsync(ligne);
        }

        /// <summary>
        /// Modifie une ligne de frais forfait (quantité)
        /// </summary>
        public async Task<bool> UpdateLigneForfaitQuantityAsync(int idLFF, int quantite)
        {
            if (quantite < 0)
                throw new ArgumentException("La quantité doit être positive");

            var ligne = await _ligneRepo.GetLigneForfaitByIdAsync(idLFF);
            if (ligne == null)
                throw new InvalidOperationException("Ligne non trouvée");

            ligne.Quantite = quantite;
            return await _ligneRepo.UpdateLigneForfaitAsync(ligne);
        }

        /// <summary>
        /// Supprime une ligne de frais hors forfait
        /// </summary>
        public async Task<bool> DeleteLigneHorsForfaitAsync(int idLHFF)
        {
            return await _ligneRepo.DeleteLigneHorsForfaitAsync(idLHFF);
        }

        /// <summary>
        /// Récupère les fiches en attente de validation (pour les comptables)
        /// </summary>
        public async Task<List<FicheFrais>> GetFichesEnAttenteAsync()
        {
            return await _ficheFraisRepo.GetByEtatAsync("EN_ATTENTE");
        }

        /// <summary>
        /// Calcule le montant total d'une fiche
        /// </summary>
        public decimal CalculateMontantTotal(FicheFrais fiche)
        {
            decimal montant = 0;
            foreach (var ligne in fiche.LignesForfait)
            {
                montant += ligne.MontantLigne;
            }
            foreach (var ligne in fiche.LignesHorsForfait)
            {
                montant += ligne.Montant;
            }
            return montant;
        }
    }
}
