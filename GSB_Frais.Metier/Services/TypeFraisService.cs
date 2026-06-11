using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSB_Frais.Models;
using GSB_Frais.DAL.Repositories;

namespace GSB_Frais.Metier.Services
{
    /// <summary>
    /// Service métier pour gérer les types de frais
    /// </summary>
    public class TypeFraisService
    {
        private readonly TypeFraisRepository _typeFraisRepo;

        public TypeFraisService()
        {
            _typeFraisRepo = new TypeFraisRepository();
        }

        /// <summary>
        /// Récupère tous les types de frais
        /// </summary>
        public async Task<List<TypeFrais>> GetAllTypesAsync()
        {
            return await _typeFraisRepo.GetAllAsync();
        }

        /// <summary>
        /// Récupère les types de frais par type (FORFAIT ou HORS_FORFAIT)
        /// </summary>
        public async Task<List<TypeFrais>> GetTypesByTypeAsync(string type)
        {
            return await _typeFraisRepo.GetByTypeAsync(type);
        }

        /// <summary>
        /// Récupère tous les types forfait
        /// </summary>
        public async Task<List<TypeFrais>> GetAllForfaitTypesAsync()
        {
            return await _typeFraisRepo.GetByTypeAsync("FORFAIT");
        }

        /// <summary>
        /// Récupère un type de frais par son ID
        /// </summary>
        public async Task<TypeFrais> GetTypeByIdAsync(int id)
        {
            return await _typeFraisRepo.GetByIdAsync(id);
        }

        /// <summary>
        /// Ajoute un nouveau type de frais
        /// </summary>
        public async Task<int> AddTypeAsync(TypeFrais typeFrais)
        {
            if (string.IsNullOrWhiteSpace(typeFrais.Libelle))
                throw new ArgumentException("Libellé obligatoire");

            if (typeFrais.Tarif < 0)
                throw new ArgumentException("Le tarif doit être positif");

            return await _typeFraisRepo.AddAsync(typeFrais);
        }

        /// <summary>
        /// Met à jour un type de frais
        /// </summary>
        public async Task<bool> UpdateTypeAsync(TypeFrais typeFrais)
        {
            if (string.IsNullOrWhiteSpace(typeFrais.Libelle))
                throw new ArgumentException("Libellé obligatoire");

            if (typeFrais.Tarif < 0)
                throw new ArgumentException("Le tarif doit être positif");

            return await _typeFraisRepo.UpdateAsync(typeFrais);
        }

        /// <summary>
        /// Supprime un type de frais
        /// </summary>
        public async Task<bool> DeleteTypeAsync(int id)
        {
            return await _typeFraisRepo.DeleteAsync(id);
        }
    }
}
