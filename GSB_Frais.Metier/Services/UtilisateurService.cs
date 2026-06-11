using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSB_Frais.Models;
using GSB_Frais.DAL.Repositories;

namespace GSB_Frais.Metier.Services
{
    /// <summary>
    /// Service métier pour gérer les utilisateurs (admin)
    /// </summary>
    public class UtilisateurService
    {
        private readonly UtilisateurRepository _utilisateurRepo;

        public UtilisateurService()
        {
            _utilisateurRepo = new UtilisateurRepository();
        }

        /// <summary>
        /// Récupère tous les utilisateurs
        /// </summary>
        public async Task<List<Utilisateur>> GetAllUsersAsync()
        {
            return await _utilisateurRepo.GetAllAsync();
        }

        /// <summary>
        /// Récupère les utilisateurs par rôle
        /// </summary>
        public async Task<List<Utilisateur>> GetUsersByRoleAsync(string role)
        {
            return await _utilisateurRepo.GetByRoleAsync(role);
        }

        /// <summary>
        /// Récupère un utilisateur par son ID
        /// </summary>
        public async Task<Utilisateur> GetUserByIdAsync(int id)
        {
            return await _utilisateurRepo.GetByIdAsync(id);
        }

        /// <summary>
        /// Ajoute un nouvel utilisateur
        /// </summary>
        public async Task<int> AddUserAsync(Utilisateur utilisateur)
        {
            if (string.IsNullOrWhiteSpace(utilisateur.Login) || string.IsNullOrWhiteSpace(utilisateur.MdpHash))
                throw new ArgumentException("Login et mot de passe obligatoires");

            return await _utilisateurRepo.AddAsync(utilisateur);
        }

        /// <summary>
        /// Met à jour un utilisateur
        /// </summary>
        public async Task<bool> UpdateUserAsync(Utilisateur utilisateur)
        {
            return await _utilisateurRepo.UpdateAsync(utilisateur);
        }

        /// <summary>
        /// Supprime un utilisateur
        /// </summary>
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _utilisateurRepo.DeleteAsync(id);
        }

        /// <summary>
        /// Désactive/active un utilisateur
        /// </summary>
        public async Task<bool> ToggleUserStatusAsync(int id)
        {
            var utilisateur = await _utilisateurRepo.GetByIdAsync(id);
            if (utilisateur == null)
                throw new InvalidOperationException("Utilisateur non trouvé");

            utilisateur.Actif = !utilisateur.Actif;
            return await _utilisateurRepo.UpdateAsync(utilisateur);
        }
    }
}
