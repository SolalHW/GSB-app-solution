using System;
using System.Windows.Forms;
using GSB_Frais.Metier.Services;
using GSB_Frais.Models;
using GSB_Frais.UI.Utilitaires;

namespace GSB_Frais.UI.Formulaires
{
    /// <summary>
    /// Formulaire d'édition d'un utilisateur (ajout ou modification)
    /// </summary>
    public partial class FrmEditionUtilisateur : Form
    {
        private readonly UtilisateurService _utilisateurService;
        private int? _idUtilisateur;
        private Utilisateur _utilisateurActuel;

        public FrmEditionUtilisateur(int? idUtilisateur, UtilisateurService utilisateurService)
        {
            InitializeComponent();
            _utilisateurService = utilisateurService;
            _idUtilisateur = idUtilisateur;

            if (idUtilisateur.HasValue)
            {
                this.Text = "Modification d'un utilisateur";
            }
            else
            {
                this.Text = "Ajout d'un nouvel utilisateur";
            }
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private async void FrmEditionUtilisateur_Load(object sender, EventArgs e)
        {
            try
            {
                if (_idUtilisateur.HasValue)
                {
                    // Mode modification - charger les données
                    _utilisateurActuel = await _utilisateurService.GetUserByIdAsync(_idUtilisateur.Value);
                    if (_utilisateurActuel != null)
                    {
                        txtNom.Text = _utilisateurActuel.Nom;
                        txtPrenom.Text = _utilisateurActuel.Prenom;
                        txtLogin.Text = _utilisateurActuel.Login;
                        txtLogin.ReadOnly = true; // Login ne peut pas être modifié
                        txtPassword.Text = ""; // Afficher vide pour sécurité
                        txtPassword.PlaceholderText = "Laisser vide pour ne pas changer";
                        cboRole.SelectedItem = _utilisateurActuel.Role;
                        chkActif.Checked = _utilisateurActuel.Actif;
                    }
                }
                else
                {
                    // Mode ajout
                    cboRole.SelectedIndex = 0; // ADMIN par défaut
                    chkActif.Checked = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors du chargement");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// Validation des données saisies
        /// </summary>
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                ExceptionManager.ShowWarning("Le nom est obligatoire", "Validation");
                txtNom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                ExceptionManager.ShowWarning("Le prénom est obligatoire", "Validation");
                txtPrenom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLogin.Text) || txtLogin.Text.Length < 3)
            {
                ExceptionManager.ShowWarning("Le login doit contenir au moins 3 caractères", "Validation");
                txtLogin.Focus();
                return false;
            }

            // Pour nouveau utilisateur, le mot de passe est obligatoire
            if (!_idUtilisateur.HasValue && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ExceptionManager.ShowWarning("Le mot de passe est obligatoire pour un nouvel utilisateur", "Validation");
                txtPassword.Focus();
                return false;
            }

            if (cboRole.SelectedItem == null)
            {
                ExceptionManager.ShowWarning("Veuillez sélectionner un rôle", "Validation");
                cboRole.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sauvegarde les données
        /// </summary>
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                    return;

                if (_idUtilisateur.HasValue)
                {
                    // Mode modification
                    await ModifyUserAsync();
                }
                else
                {
                    // Mode ajout
                    await AddUserAsync();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la sauvegarde");
            }
        }

        /// <summary>
        /// Ajoute un nouvel utilisateur
        /// </summary>
        private async System.Threading.Tasks.Task AddUserAsync()
        {
            // Hasher le mot de passe via le service
            var authService = new AuthService();
            int newId = await authService.CreateUserAsync(
                txtNom.Text.Trim(),
                txtPrenom.Text.Trim(),
                txtLogin.Text.Trim(),
                txtPassword.Text,
                cboRole.SelectedItem.ToString()
            );

            ExceptionManager.ShowInfo("Utilisateur créé avec succès", "Succès");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Modifie un utilisateur existant
        /// </summary>
        private async System.Threading.Tasks.Task ModifyUserAsync()
        {
            _utilisateurActuel.Nom = txtNom.Text.Trim();
            _utilisateurActuel.Prenom = txtPrenom.Text.Trim();
            _utilisateurActuel.Role = cboRole.SelectedItem.ToString();
            _utilisateurActuel.Actif = chkActif.Checked;

            // Changer le mot de passe si nouveau mot de passe saisi
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                _utilisateurActuel.MdpHash = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);
            }

            bool success = await _utilisateurService.UpdateUserAsync(_utilisateurActuel);

            if (success)
            {
                ExceptionManager.ShowInfo("Utilisateur modifié avec succès", "Succès");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ExceptionManager.ShowWarning("Erreur lors de la modification", "Erreur");
            }
        }
    }
}
