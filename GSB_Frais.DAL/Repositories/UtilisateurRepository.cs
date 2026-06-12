using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using GSB_Frais.Models;
using GSB_Frais.DAL.Config;

namespace GSB_Frais.DAL.Repositories
{
    /// <summary>
    /// Repository pour gérer les utilisateurs en base de données
    /// </summary>
    public class UtilisateurRepository
    {
        public async Task<Utilisateur> GetByIdAsync(int id)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idUtilisateur, nom, prenom, login, mdpHash, role, dateCreation, dateModification, actif " +
                    "FROM UTILISATEUR WHERE idUtilisateur = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapToUtilisateur(reader);
                    }
                }
            }
            return null;
        }

        public async Task<Utilisateur> GetByLoginAsync(string login)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idUtilisateur, nom, prenom, login, mdpHash, role, dateCreation, dateModification, actif " +
                    "FROM UTILISATEUR WHERE login = @login", conn);
                cmd.Parameters.AddWithValue("@login", login);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapToUtilisateur(reader);
                    }
                }
            }
            return null;
        }

        public async Task<List<Utilisateur>> GetAllAsync()
        {
            var utilisateurs = new List<Utilisateur>();
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idUtilisateur, nom, prenom, login, mdpHash, role, dateCreation, dateModification, actif " +
                    "FROM UTILISATEUR ORDER BY nom, prenom", conn);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        utilisateurs.Add(MapToUtilisateur(reader));
                    }
                }
            }
            return utilisateurs;
        }

        public async Task<List<Utilisateur>> GetByRoleAsync(string role)
        {
            var utilisateurs = new List<Utilisateur>();
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idUtilisateur, nom, prenom, login, mdpHash, role, dateCreation, dateModification, actif " +
                    "FROM UTILISATEUR WHERE role = @role ORDER BY nom, prenom", conn);
                cmd.Parameters.AddWithValue("@role", role);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        utilisateurs.Add(MapToUtilisateur(reader));
                    }
                }
            }
            return utilisateurs;
        }

        public async Task<int> AddAsync(Utilisateur utilisateur)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "INSERT INTO UTILISATEUR (nom, prenom, login, mdpHash, role, actif) " +
                    "VALUES (@nom, @prenom, @login, @mdpHash, @role, @actif); " +
                    "SELECT LAST_INSERT_ID();", conn);

                cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
                cmd.Parameters.AddWithValue("@prenom", utilisateur.Prenom);
                cmd.Parameters.AddWithValue("@login", utilisateur.Login);
                cmd.Parameters.AddWithValue("@mdpHash", utilisateur.MdpHash);
                cmd.Parameters.AddWithValue("@role", utilisateur.Role);
                cmd.Parameters.AddWithValue("@actif", utilisateur.Actif ? 1 : 0);

                var id = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(id);
            }
        }

        public async Task<bool> UpdateAsync(Utilisateur utilisateur)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "UPDATE UTILISATEUR SET nom = @nom, prenom = @prenom, login = @login, " +
                    "mdpHash = @mdpHash, role = @role, actif = @actif, dateModification = NOW() " +
                    "WHERE idUtilisateur = @id", conn);

                cmd.Parameters.AddWithValue("@id", utilisateur.IdUtilisateur);
                cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
                cmd.Parameters.AddWithValue("@prenom", utilisateur.Prenom);
                cmd.Parameters.AddWithValue("@login", utilisateur.Login);
                cmd.Parameters.AddWithValue("@mdpHash", utilisateur.MdpHash);
                cmd.Parameters.AddWithValue("@role", utilisateur.Role);
                cmd.Parameters.AddWithValue("@actif", utilisateur.Actif ? 1 : 0);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand("DELETE FROM UTILISATEUR WHERE idUtilisateur = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        private Utilisateur MapToUtilisateur(MySqlDataReader reader)
        {
            return new Utilisateur
            {
                IdUtilisateur = reader.GetInt32("idUtilisateur"),
                Nom = reader.GetString("nom"),
                Prenom = reader.GetString("prenom"),
                Login = reader.GetString("login"),
                MdpHash = reader.GetString("mdpHash"),
                Role = reader.GetString("role"),
                DateCreation = reader.GetDateTime("dateCreation"),
                DateModification = reader.GetDateTime("dateModification"),
                Actif = reader.GetBoolean("actif")
            };
        }
    }
}
