using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using GSB_Frais.Models;
using GSB_Frais.DAL.Config;

namespace GSB_Frais.DAL.Repositories
{
    /// <summary>
    /// Repository pour gérer les types de frais en base de données
    /// </summary>
    public class TypeFraisRepository
    {
        public async Task<TypeFrais> GetByIdAsync(int id)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idTypeFrais, libelle, tarif, type, dateCreation, dateModification " +
                    "FROM TYPE_FRAIS WHERE idTypeFrais = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapToTypeFrais(reader);
                    }
                }
            }
            return null;
        }

        public async Task<List<TypeFrais>> GetAllAsync()
        {
            var types = new List<TypeFrais>();
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idTypeFrais, libelle, tarif, type, dateCreation, dateModification " +
                    "FROM TYPE_FRAIS ORDER BY libelle", conn);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        types.Add(MapToTypeFrais(reader));
                    }
                }
            }
            return types;
        }

        public async Task<List<TypeFrais>> GetByTypeAsync(string type)
        {
            var types = new List<TypeFrais>();
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "SELECT idTypeFrais, libelle, tarif, type, dateCreation, dateModification " +
                    "FROM TYPE_FRAIS WHERE type = @type ORDER BY libelle", conn);
                cmd.Parameters.AddWithValue("@type", type);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        types.Add(MapToTypeFrais(reader));
                    }
                }
            }
            return types;
        }

        public async Task<int> AddAsync(TypeFrais typeFrais)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "INSERT INTO TYPE_FRAIS (libelle, tarif, type) " +
                    "VALUES (@libelle, @tarif, @type); " +
                    "SELECT LAST_INSERT_ID();", conn);

                cmd.Parameters.AddWithValue("@libelle", typeFrais.Libelle);
                cmd.Parameters.AddWithValue("@tarif", typeFrais.Tarif);
                cmd.Parameters.AddWithValue("@type", typeFrais.Type);

                var id = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(id);
            }
        }

        public async Task<bool> UpdateAsync(TypeFrais typeFrais)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand(
                    "UPDATE TYPE_FRAIS SET libelle = @libelle, tarif = @tarif, type = @type, " +
                    "dateModification = NOW() WHERE idTypeFrais = @id", conn);

                cmd.Parameters.AddWithValue("@id", typeFrais.IdTypeFrais);
                cmd.Parameters.AddWithValue("@libelle", typeFrais.Libelle);
                cmd.Parameters.AddWithValue("@tarif", typeFrais.Tarif);
                cmd.Parameters.AddWithValue("@type", typeFrais.Type);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var conn = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand("DELETE FROM TYPE_FRAIS WHERE idTypeFrais = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        private TypeFrais MapToTypeFrais(MySqlDataReader reader)
        {
            return new TypeFrais
            {
                IdTypeFrais = reader.GetInt32("idTypeFrais"),
                Libelle = reader.GetString("libelle"),
                Tarif = reader.GetDecimal("tarif"),
                Type = reader.GetString("type"),
                DateCreation = reader.GetDateTime("dateCreation"),
                DateModification = reader.GetDateTime("dateModification")
            };
        }
    }
}
