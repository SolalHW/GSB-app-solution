using System;
using System.Windows.Forms;
using GSB_Frais.DAL.Config;
using GSB_Frais.UI.Formulaires;

namespace GSB_Frais.UI
{
    /// <summary>
    /// Point d'entrée principal de l'application GSB Frais WinForms
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialisation de l'application WinForms
            Application.EnableVisualStyles();
            Application.DefaultFont = new System.Drawing.Font("Segoe UI", 9F);
            Application.SetCompatibleTextRenderingDefault(false);

            // Configurer la chaîne de connexion (à adapter selon votre configuration)
            // Format: Server=host;Port=port;Database=dbname;Uid=user;Pwd=password;
            DatabaseConfig.SetConnectionString(
                "Server=localhost;Port=3306;Database=GSB_FRAIS;Uid=root;Pwd=;"
            );

            // Lancer l'application avec le formulaire de connexion
            try
            {
                Application.Run(new FrmLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erreur fatale lors du démarrage de l'application:\n{ex.Message}\n{ex.StackTrace}",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
