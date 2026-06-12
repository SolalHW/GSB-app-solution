using System;
using System.Windows.Forms;

namespace GSB_Frais.UI.Utilitaires
{
    /// <summary>
    /// Gestionnaire centralisé des exceptions et messages d'erreur
    /// </summary>
    public static class ExceptionManager
    {
        public static void HandleException(Exception ex, string context = "")
        {
            string title = "Erreur";
            string message = "Une erreur est survenue";

            if (ex is InvalidOperationException)
            {
                message = ex.Message;
                title = "Erreur de validation";
            }
            else if (ex is ArgumentException)
            {
                message = ex.Message;
                title = "Données invalides";
            }
            else if (ex is UnauthorizedAccessException)
            {
                message = "Vous n'avez pas les droits nécessaires";
                title = "Accès refusé";
            }
            else
            {
                message = "Une erreur inattendue s'est produite. Veuillez contacter l'administrateur.";
                if (!string.IsNullOrEmpty(context))
                    message = $"{context}\n{message}";
            }

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ConfirmAction(string message, string title = "Confirmation")
        {
            var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        public static void ShowInfo(string message, string title = "Information")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string message, string title = "Attention")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
