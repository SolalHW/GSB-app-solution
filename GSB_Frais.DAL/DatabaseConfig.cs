namespace GSB_Frais.DAL.Config
{
    /// <summary>
    /// Configuration centralisée pour l'accès à la base de données
    /// </summary>
    public static class DatabaseConfig
    {
        public static string ConnectionString { get; set; } = 
            "Server=localhost;Port=3306;Database=GSB_FRAIS;Uid=root;Pwd=;";

        /// <summary>
        /// Permet de configurer la chaîne de connexion au démarrage
        /// </summary>
        public static void SetConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
