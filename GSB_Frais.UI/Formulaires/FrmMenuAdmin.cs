using System;
using System.Windows.Forms;
using GSB_Frais.UI.Utilitaires;

namespace GSB_Frais.UI.Formulaires
{
    /// <summary>
    /// Menu principal pour l'administrateur
    /// </summary>
    public partial class FrmMenuAdmin : Form
    {
        public FrmMenuAdmin()
        {
            InitializeComponent();
            LoadUserInfo();
        }

        /// <summary>
        /// Charge les informations de l'utilisateur connecté
        /// </summary>
        private void LoadUserInfo()
        {
            if (SessionManager.UtilisateurCourant != null)
            {
                lblUser.Text = $"Connecté: {SessionManager.UtilisateurCourant.NomComplet}";
            }
        }

        /// <summary>
        /// Bouton Gestion des Utilisateurs
        /// </summary>
        private void BtnGestionUtilisateurs_Click(object sender, EventArgs e)
        {
            var frmGestion = new FrmGestionUtilisateurs();
            frmGestion.ShowDialog();
        }

        /// <summary>
        /// Bouton Gestion des Types de Frais
        /// </summary>
        private void BtnGestionTypesFrais_Click(object sender, EventArgs e)
        {
            var frmGestion = new FrmGestionTypesFrais();
            frmGestion.ShowDialog();
        }

        /// <summary>
        /// Déconnexion
        /// </summary>
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (ExceptionManager.ConfirmAction("Êtes-vous sûr de vouloir vous déconnecter?", "Confirmation"))
            {
                SessionManager.Disconnect();
                this.Close();
            }
        }

        /// <summary>
        /// Retour à la connexion
        /// </summary>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            BtnLogout_Click(null, null);
        }
    }
}
