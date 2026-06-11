using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using GSB_Frais.Models;
using GSB_Frais.DAL.Config;

namespace GSB_Frais.DAL.Repositories
{
    /// <summary>
    /// Repository pour gérer les lignes de frais (forfait et hors forfait)
    /// </summary>
    public class LigneFraisRepository
    {
        private readonly TypeFraisRepository _typeFraisRepo = new();

        // ====== LIGNES FORFAIT ======
        public async Task<List<LigneFraisForfait>> GetLignesForfaitByFicheAsync(int idFiche)
        {
            var lignes = new List<LigneFraisForfait>();
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT lf.idLFF, lf.quantite, lf.idFiche, lf.idTypeFrais, lf.dateCreation, lf.dateModification " +
                    "FROM LIGNE_FRAIS_FORFAIT lf WHERE lf.idFiche = @idFiche", conn);
                cmd.Parameters.AddWithValue("@idFiche", idFiche);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var ligne = MapToLigneForfait(reader);
                        ligne.TypeFrais = await _typeFraisRepo.GetByIdAsync(ligne.IdTypeFrais);
                        lignes.Add(ligne);
                    }
                }
            }
            return lignes;
        }

        public async Task<LigneFraisForfait> GetLigneForfaitByIdAsync(int id)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idLFF, quantite, idFiche, idTypeFrais, dateCreation, dateModification " +
                    "FROM LIGNE_FRAIS_FORFAIT WHERE idLFF = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var ligne = MapToLigneForfait(reader);
                        ligne.TypeFrais = await _typeFraisRepo.GetByIdAsync(ligne.IdTypeFrais);
                        return ligne;
                    }
                }
            }
            return null;
        }

        public async Task<int> AddLigneForfaitAsync(LigneFraisForfait ligne)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "INSERT INTO LIGNE_FRAIS_FORFAIT (quantite, idFiche, idTypeFrais) " +
                    "VALUES (@quantite, @idFiche, @idTypeFrais) " +
                    "ON DUPLICATE KEY UPDATE quantite = @quantite, dateModification = NOW(); " +
                    "SELECT LAST_INSERT_ID();", conn);

                cmd.Parameters.AddWithValue("@quantite", ligne.Quantite);
                cmd.Parameters.AddWithValue("@idFiche", ligne.IdFiche);
                cmd.Parameters.AddWithValue("@idTypeFrais", ligne.IdTypeFrais);

                var id = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(id ?? ligne.IdLFF);
            }
        }

        public async Task<bool> UpdateLigneForfaitAsync(LigneFraisForfait ligne)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "UPDATE LIGNE_FRAIS_FORFAIT SET quantite = @quantite, dateModification = NOW() WHERE idLFF = @id", conn);

                cmd.Parameters.AddWithValue("@id", ligne.IdLFF);
                cmd.Parameters.AddWithValue("@quantite", ligne.Quantite);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteLigneForfaitAsync(int id)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand("DELETE FROM LIGNE_FRAIS_FORFAIT WHERE idLFF = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        // ====== LIGNES HORS FORFAIT ======
        public async Task<List<LigneFraisHorsForfait>> GetLignesHorsForfaitByFicheAsync(int idFiche)
        {
            var lignes = new List<LigneFraisHorsForfait>();
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idLHFF, libelle, montant, justificatif, idFiche, dateCreation, dateModification " +
                    "FROM LIGNE_FRAIS_HORS_FORFAIT WHERE idFiche = @idFiche", conn);
                cmd.Parameters.AddWithValue("@idFiche", idFiche);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lignes.Add(MapToLigneHorsForfait(reader));
                    }
                }
            }
            return lignes;
        }

        public async Task<LigneFraisHorsForfait> GetLigneHorsForfaitByIdAsync(int id)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idLHFF, libelle, montant, justificatif, idFiche, dateCreation, dateModification " +
                    "FROM LIGNE_FRAIS_HORS_FORFAIT WHERE idLHFF = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapToLigneHorsForfait(reader);
                    }
                }
            }
            return null;
        }

        public async Task<int> AddLigneHorsForfaitAsync(LigneFraisHorsForfait ligne)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "INSERT INTO LIGNE_FRAIS_HORS_FORFAIT (libelle, montant, justificatif, idFiche) " +
                    "VALUES (@libelle, @montant, @justificatif, @idFiche); " +
                    "SELECT LAST_INSERT_ID();", conn);

                cmd.Parameters.AddWithValue("@libelle", ligne.Libelle);
                cmd.Parameters.AddWithValue("@montant", ligne.Montant);
                cmd.Parameters.AddWithValue("@justificatif", ligne.Justificatif ?? "");
                cmd.Parameters.AddWithValue("@idFiche", ligne.IdFiche);

                var id = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(id);
            }
        }

        public async Task<bool> UpdateLigneHorsForfaitAsync(LigneFraisHorsForfait ligne)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "UPDATE LIGNE_FRAIS_HORS_FORFAIT SET libelle = @libelle, montant = @montant, " +
                    "justificatif = @justificatif, dateModification = NOW() WHERE idLHFF = @id", conn);

                cmd.Parameters.AddWithValue("@id", ligne.IdLHFF);
                cmd.Parameters.AddWithValue("@libelle", ligne.Libelle);
                cmd.Parameters.AddWithValue("@montant", ligne.Montant);
                cmd.Parameters.AddWithValue("@justificatif", ligne.Justificatif ?? "");

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteLigneHorsForfaitAsync(int id)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand("DELETE FROM LIGNE_FRAIS_HORS_FORFAIT WHERE idLHFF = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        private LigneFraisForfait MapToLigneForfait(MySqlDataReader reader)
        {
            return new LigneFraisForfait
            {
                IdLFF = reader.GetInt32("idLFF"),
                Quantite = reader.GetInt32("quantite"),
                IdFiche = reader.GetInt32("idFiche"),
                IdTypeFrais = reader.GetInt32("idTypeFrais"),
                DateCreation = reader.GetDateTime("dateCreation"),
                DateModification = reader.GetDateTime("dateModification")
            };
        }

        private LigneFraisHorsForfait MapToLigneHorsForfait(MySqlDataReader reader)
        {
            return new LigneFraisHorsForfait
            {
                IdLHFF = reader.GetInt32("idLHFF"),
                Libelle = reader.GetString("libelle"),
                Montant = reader.GetDecimal("montant"),
                Justificatif = reader.IsDBNull("justificatif") ? "" : reader.GetString("justificatif"),
                IdFiche = reader.GetInt32("idFiche"),
                DateCreation = reader.GetDateTime("dateCreation"),
                DateModification = reader.GetDateTime("dateModification")
            };
        }
    }
}
