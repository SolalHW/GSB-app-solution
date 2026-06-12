using System;
using System.Threading.Tasks;
using GSB_Frais.Models;
using GSB_Frais.DAL.Repositories;

namespace GSB_Frais.Metier.Services
{
    /// <summary>
    /// Service d'authentification - Gère la connexion des utilisateurs
    /// </summary>
    public class AuthService
    {
        private readonly UtilisateurRepository _utilisateurRepo;

        public AuthService()
        {
            _utilisateurRepo = new UtilisateurRepository();
        }

        /// <summary>
        /// Authentifie un utilisateur par login et mot de passe
        /// </summary>
        /// <returns>L'utilisateur authentifié ou null si les identifiants sont invalides</returns>
        public async Task<Utilisateur> AuthenticateAsync(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return null;

            try
            {
                var utilisateur = await _utilisateurRepo.GetByLoginAsync(login);

                if (utilisateur == null || !utilisateur.Actif)
                    return null;

                // Vérifier le mot de passe avec bcrypt
                if (!BCrypt.Net.BCrypt.Verify(password, utilisateur.MdpHash))
                    return null;

                return utilisateur;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Récupère un utilisateur par son ID
        /// </summary>
        public async Task<Utilisateur> GetUserByIdAsync(int id)
        {
            return await _utilisateurRepo.GetByIdAsync(id);
        }

        /// <summary>
        /// Récupère un utilisateur par son login
        /// </summary>
        public async Task<Utilisateur> GetUserByLoginAsync(string login)
        {
            return await _utilisateurRepo.GetByLoginAsync(login);
        }

        /// <summary>
        /// Crée un nouveau compte utilisateur
        /// </summary>
        public async Task<int> CreateUserAsync(string nom, string prenom, string login, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Login et mot de passe obligatoires");

            // Vérifier que le login n'existe pas déjà
            var existingUser = await _utilisateurRepo.GetByLoginAsync(login);
            if (existingUser != null)
                throw new InvalidOperationException("Ce login est déjà utilisé");

            // Hasher le mot de passe avec bcrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var utilisateur = new Utilisateur
            {
                Nom = nom,
                Prenom = prenom,
                Login = login,
                MdpHash = hashedPassword,
                Role = role,
                Actif = true
            };

            return await _utilisateurRepo.AddAsync(utilisateur);
        }

        /// <summary>
        /// Change le mot de passe d'un utilisateur
        /// </summary>
        public async Task<bool> ChangePasswordAsync(int idUtilisateur, string oldPassword, string newPassword)
        {
            var utilisateur = await _utilisateurRepo.GetByIdAsync(idUtilisateur);
            if (utilisateur == null)
                throw new InvalidOperationException("Utilisateur non trouvé");

            if (!BCrypt.Net.BCrypt.Verify(oldPassword, utilisateur.MdpHash))
                throw new InvalidOperationException("Ancien mot de passe incorrect");

            utilisateur.MdpHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            return await _utilisateurRepo.UpdateAsync(utilisateur);
        }
    }
}
