using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using GSB_Frais.Models;
using GSB_Frais.DAL.Config;

namespace GSB_Frais.DAL.Repositories
{
    /// <summary>
    /// Repository pour gérer les fiches de frais en base de données
    /// </summary>
    public class FicheFraisRepository
    {
        private readonly LigneFraisRepository _ligneRepo;

        public FicheFraisRepository()
        {
            _ligneRepo = new LigneFraisRepository();
        }

        public async Task<FicheFrais> GetByIdAsync(int id)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idFiche, mois, etat, idUtilisateur, dateSaisie, dateModification, montantTotal, observations " +
                    "FROM FICHE_FRAIS WHERE idFiche = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var fiche = MapToFicheFrais(reader);
                        // Charger les lignes
                        fiche.LignesForfait = await _ligneRepo.GetLignesForfaitByFicheAsync(fiche.IdFiche);
                        fiche.LignesHorsForfait = await _ligneRepo.GetLignesHorsForfaitByFicheAsync(fiche.IdFiche);
                        return fiche;
                    }
                }
            }
            return null;
        }

        public async Task<FicheFrais> GetByUserAndMonthAsync(int idUtilisateur, string mois)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idFiche, mois, etat, idUtilisateur, dateSaisie, dateModification, montantTotal, observations " +
                    "FROM FICHE_FRAIS WHERE idUtilisateur = @idUser AND mois = @mois", conn);
                cmd.Parameters.AddWithValue("@idUser", idUtilisateur);
                cmd.Parameters.AddWithValue("@mois", mois);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var fiche = MapToFicheFrais(reader);
                        fiche.LignesForfait = await _ligneRepo.GetLignesForfaitByFicheAsync(fiche.IdFiche);
                        fiche.LignesHorsForfait = await _ligneRepo.GetLignesHorsForfaitByFicheAsync(fiche.IdFiche);
                        return fiche;
                    }
                }
            }
            return null;
        }

        public async Task<List<FicheFrais>> GetByUserAsync(int idUtilisateur)
        {
            var fiches = new List<FicheFrais>();
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idFiche, mois, etat, idUtilisateur, dateSaisie, dateModification, montantTotal, observations " +
                    "FROM FICHE_FRAIS WHERE idUtilisateur = @idUser ORDER BY mois DESC", conn);
                cmd.Parameters.AddWithValue("@idUser", idUtilisateur);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        fiches.Add(MapToFicheFrais(reader));
                    }
                }
            }
            return fiches;
        }

        public async Task<List<FicheFrais>> GetByEtatAsync(string etat)
        {
            var fiches = new List<FicheFrais>();
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idFiche, mois, etat, idUtilisateur, dateSaisie, dateModification, montantTotal, observations " +
                    "FROM FICHE_FRAIS WHERE etat = @etat ORDER BY dateSaisie DESC", conn);
                cmd.Parameters.AddWithValue("@etat", etat);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        fiches.Add(MapToFicheFrais(reader));
                    }
                }
            }
            return fiches;
        }

        public async Task<int> AddAsync(FicheFrais fiche)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "INSERT INTO FICHE_FRAIS (mois, etat, idUtilisateur, montantTotal, observations) " +
                    "VALUES (@mois, @etat, @idUtilisateur, @montantTotal, @observations); " +
                    "SELECT LAST_INSERT_ID();", conn);

                cmd.Parameters.AddWithValue("@mois", fiche.Mois);
                cmd.Parameters.AddWithValue("@etat", fiche.Etat ?? "EN_COURS");
                cmd.Parameters.AddWithValue("@idUtilisateur", fiche.IdUtilisateur);
                cmd.Parameters.AddWithValue("@montantTotal", fiche.MontantTotal);
                cmd.Parameters.AddWithValue("@observations", fiche.Observations ?? "");

                var id = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(id);
            }
        }

        public async Task<bool> UpdateAsync(FicheFrais fiche)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "UPDATE FICHE_FRAIS SET mois = @mois, etat = @etat, montantTotal = @montantTotal, " +
                    "observations = @observations, dateModification = NOW() WHERE idFiche = @id", conn);

                cmd.Parameters.AddWithValue("@id", fiche.IdFiche);
                cmd.Parameters.AddWithValue("@mois", fiche.Mois);
                cmd.Parameters.AddWithValue("@etat", fiche.Etat ?? "EN_COURS");
                cmd.Parameters.AddWithValue("@montantTotal", fiche.MontantTotal);
                cmd.Parameters.AddWithValue("@observations", fiche.Observations ?? "");

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        public async Task<bool> UpdateEtatAsync(int idFiche, string nouvelEtat)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "UPDATE FICHE_FRAIS SET etat = @etat, dateModification = NOW() WHERE idFiche = @id", conn);

                cmd.Parameters.AddWithValue("@id", idFiche);
                cmd.Parameters.AddWithValue("@etat", nouvelEtat);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        private FicheFrais MapToFicheFrais(MySqlDataReader reader)
        {
            return new FicheFrais
            {
                IdFiche = reader.GetInt32("idFiche"),
                Mois = reader.GetString("mois"),
                Etat = reader.GetString("etat"),
                IdUtilisateur = reader.GetInt32("idUtilisateur"),
                DateSaisie = reader.GetDateTime("dateSaisie"),
                DateModification = reader.GetDateTime("dateModification"),
                MontantTotal = reader.GetDecimal("montantTotal"),
                Observations = reader.IsDBNull("observations") ? "" : reader.GetString("observations")
            };
        }
    }
}
