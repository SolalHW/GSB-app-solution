using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GSB_Frais.Metier.Services;
using GSB_Frais.Models;
using GSB_Frais.UI.Utilitaires;

namespace GSB_Frais.UI.Formulaires
{
    /// <summary>
    /// Formulaire de gestion des utilisateurs (Admin)
    /// Permet d'ajouter, modifier et supprimer des utilisateurs
    /// </summary>
    public partial class FrmGestionUtilisateurs : Form
    {
        private readonly UtilisateurService _utilisateurService;

        public FrmGestionUtilisateurs()
        {
            InitializeComponent();
            _utilisateurService = new UtilisateurService();
        }

        /// <summary>
        /// Chargement du formulaire - charge la liste des utilisateurs
        /// </summary>
        private async void FrmGestionUtilisateurs_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadUtilisateurs();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors du chargement des utilisateurs");
            }
        }

        /// <summary>
        /// Charge tous les utilisateurs dans le DataGridView
        /// </summary>
        private async System.Threading.Tasks.Task LoadUtilisateurs()
        {
            dgvUtilisateurs.DataSource = null;
            var utilisateurs = await _utilisateurService.GetAllUsersAsync();

            if (utilisateurs != null && utilisateurs.Count > 0)
            {
                dgvUtilisateurs.DataSource = utilisateurs;
                
                // Masquer les colonnes sensibles
                if (dgvUtilisateurs.Columns.Contains("MdpHash"))
                    dgvUtilisateurs.Columns["MdpHash"].Visible = false;
                
                // Renommer les colonnes pour meilleure lisibilité
                dgvUtilisateurs.Columns["IdUtilisateur"].HeaderText = "ID";
                dgvUtilisateurs.Columns["Nom"].HeaderText = "Nom";
                dgvUtilisateurs.Columns["Prenom"].HeaderText = "Prénom";
                dgvUtilisateurs.Columns["Login"].HeaderText = "Login";
                dgvUtilisateurs.Columns["Role"].HeaderText = "Rôle";
                dgvUtilisateurs.Columns["Actif"].HeaderText = "Actif";
                dgvUtilisateurs.Columns["DateCreation"].HeaderText = "Créé le";
                dgvUtilisateurs.Columns["DateModification"].HeaderText = "Modifié le";
            }
        }

        /// <summary>
        /// Bouton Ajouter - ouvre un formulaire de saisie
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var frmEdit = new FrmEditionUtilisateur(null, _utilisateurService);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                LoadUtilisateurs();
            }
        }

        /// <summary>
        /// Bouton Modifier - ouvre le formulaire d'édition pour la ligne sélectionnée
        /// </summary>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUtilisateurs.SelectedRows.Count == 0)
            {
                ExceptionManager.ShowWarning("Veuillez sélectionner un utilisateur à modifier", "Sélection requise");
                return;
            }

            try
            {
                var row = dgvUtilisateurs.SelectedRows[0];
                int idUtilisateur = (int)row.Cells["IdUtilisateur"].Value;
                
                var frmEdit = new FrmEditionUtilisateur(idUtilisateur, _utilisateurService);
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    LoadUtilisateurs();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de l'édition");
            }
        }

        /// <summary>
        /// Bouton Supprimer - supprime l'utilisateur sélectionné
        /// </summary>
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUtilisateurs.SelectedRows.Count == 0)
            {
                ExceptionManager.ShowWarning("Veuillez sélectionner un utilisateur à supprimer", "Sélection requise");
                return;
            }

            try
            {
                var row = dgvUtilisateurs.SelectedRows[0];
                int idUtilisateur = (int)row.Cells["IdUtilisateur"].Value;
                string nom = row.Cells["Nom"].Value.ToString();

                if (!ExceptionManager.ConfirmAction($"Êtes-vous sûr de vouloir supprimer {nom}?", "Confirmation de suppression"))
                    return;

                bool success = await _utilisateurService.DeleteUserAsync(idUtilisateur);
                
                if (success)
                {
                    ExceptionManager.ShowInfo("Utilisateur supprimé avec succès", "Suppression réussie");
                    await LoadUtilisateurs();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la suppression");
            }
        }

        /// <summary>
        /// Bouton Actualiser - recharge la liste
        /// </summary>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadUtilisateurs();
        }

        /// <summary>
        /// Bouton Fermer
        /// </summary>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
