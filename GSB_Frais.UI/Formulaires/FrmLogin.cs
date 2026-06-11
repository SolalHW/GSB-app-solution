using System;
using System.Windows.Forms;
using GSB_Frais.Metier.Services;
using GSB_Frais.UI.Utilitaires;

namespace GSB_Frais.UI.Formulaires
{
    /// <summary>
    /// Formulaire de connexion GSB Frais
    /// Gère l'authentification et la redirection selon le rôle
    /// </summary>
    public partial class FrmLogin : Form
    {
        private readonly AuthService _authService;

        public FrmLogin()
        {
            InitializeComponent();
            _authService = new AuthService();
            SetupFormStyle();
        }

        /// <summary>
        /// Configure l'apparence du formulaire
        /// </summary>
        private void SetupFormStyle()
        {
            // Center the form
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Set focus on login field
            this.Load += (s, e) => txtLogin.Focus();
            
            // Allow Enter key to submit form
            this.AcceptButton = btnLogin;
            this.CancelButton = btnExit;
        }

        /// <summary>
        /// Événement click sur le bouton Connexion
        /// </summary>
        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            await PerformLoginAsync();
        }

        /// <summary>
        /// Effectue la connexion
        /// </summary>
        private async System.Threading.Tasks.Task PerformLoginAsync()
        {
            try
            {
                // Valider les entrées
                if (!ValidateInput())
                    return;

                // Afficher le statut
                lblStatus.Text = "Vérification des identifiants...";
                lblStatus.ForeColor = System.Drawing.Color.Orange;
                Application.DoEvents();

                // Appeler le service d'authentification
                string login = txtLogin.Text.Trim();
                string password = txtPassword.Text;

                var utilisateur = await _authService.AuthenticateAsync(login, password);

                if (utilisateur == null)
                {
                    lblStatus.Text = "Identifiants invalides";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    ExceptionManager.ShowWarning("Login ou mot de passe incorrect", "Authentification échouée");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // Authentification réussie
                lblStatus.Text = "Authentification réussie...";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                
                // Sauvegarder la session
                SessionManager.UtilisateurCourant = utilisateur;

                // Redirection selon le rôle
                RedirectByRole(utilisateur.Role);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la connexion");
                lblStatus.Text = "Erreur de connexion";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// Redirige vers le formulaire approprié selon le rôle
        /// </summary>
        private void RedirectByRole(string role)
        {
            Form nextForm = null;

            switch (role)
            {
                case "ADMIN":
                    ExceptionManager.ShowInfo($"Bienvenue {SessionManager.UtilisateurCourant.NomComplet} (Admin)");
                    nextForm = new FrmMenuAdmin();
                    break;

                case "COMPTABLE":
                    ExceptionManager.ShowInfo($"Bienvenue {SessionManager.UtilisateurCourant.NomComplet} (Comptable)");
                    // nextForm = new FrmMenuComptable();
                    ExceptionManager.ShowWarning("FrmMenuComptable n'est pas encore implémenté");
                    return;

                case "VISITEUR":
                    ExceptionManager.ShowInfo($"Bienvenue {SessionManager.UtilisateurCourant.NomComplet} (Visiteur)");
                    // nextForm = new FrmMesFiches();
                    ExceptionManager.ShowWarning("FrmMesFiches n'est pas encore implémenté");
                    return;

                default:
                    ExceptionManager.ShowWarning("Rôle utilisateur non reconnu");
                    return;
            }

            if (nextForm != null)
            {
                this.Hide();
                nextForm.ShowDialog();
                this.Show();
            }
        }

        /// <summary>
        /// Valide les champs de saisie
        /// </summary>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                ExceptionManager.ShowWarning("Veuillez saisir votre login", "Champ obligatoire");
                txtLogin.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ExceptionManager.ShowWarning("Veuillez saisir votre mot de passe", "Champ obligatoire");
                txtPassword.Focus();
                return false;
            }

            if (txtLogin.Text.Length < 3)
            {
                ExceptionManager.ShowWarning("Le login doit contenir au moins 3 caractères", "Données invalides");
                txtLogin.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Événement click sur le bouton Quitter
        /// </summary>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Événement fermeture du formulaire
        /// </summary>
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Confirmer la fermeture
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!ExceptionManager.ConfirmAction("Êtes-vous sûr de vouloir quitter?", "Confirmation"))
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
