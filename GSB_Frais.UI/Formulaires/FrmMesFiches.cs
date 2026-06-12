using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GSB_Frais.Metier.Services;
using GSB_Frais.Models;
using GSB_Frais.UI.Utilitaires;

namespace GSB_Frais.UI.Formulaires
{
    /// <summary>
    /// Formulaire affichant toutes les fiches du visiteur connecté
    /// </summary>
    public partial class FrmMesFiches : Form
    {
        private readonly FicheFraisService _ficheFraisService;

        public FrmMesFiches()
        {
            InitializeComponent();
            _ficheFraisService = new FicheFraisService();
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private async void FrmMesFiches_Load(object sender, EventArgs e)
        {
            try
            {
                lblUser.Text = $"Connecté: {SessionManager.UtilisateurCourant.NomComplet}";
                await LoadFiches();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors du chargement");
            }
        }

        /// <summary>
        /// Charge toutes les fiches de l'utilisateur
        /// </summary>
        private async System.Threading.Tasks.Task LoadFiches()
        {
            dgvFiches.DataSource = null;
            var fiches = await _ficheFraisService.GetFichesByUserAsync(SessionManager.UtilisateurCourant.IdUtilisateur);

            if (fiches != null && fiches.Count > 0)
            {
                dgvFiches.DataSource = fiches;
                
                // Renommer les colonnes
                dgvFiches.Columns["IdFiche"].HeaderText = "ID";
                dgvFiches.Columns["Mois"].HeaderText = "Mois";
                dgvFiches.Columns["Etat"].HeaderText = "État";
                dgvFiches.Columns["MontantTotal"].HeaderText = "Montant";
                dgvFiches.Columns["DateSaisie"].HeaderText = "Date Saisie";
                dgvFiches.Columns["DateModification"].HeaderText = "Date Modification";
                
                // Masquer certaines colonnes
                if (dgvFiches.Columns.Contains("IdUtilisateur"))
                    dgvFiches.Columns["IdUtilisateur"].Visible = false;
                if (dgvFiches.Columns.Contains("Utilisateur"))
                    dgvFiches.Columns["Utilisateur"].Visible = false;
                if (dgvFiches.Columns.Contains("LignesForfait"))
                    dgvFiches.Columns["LignesForfait"].Visible = false;
                if (dgvFiches.Columns.Contains("LignesHorsForfait"))
                    dgvFiches.Columns["LignesHorsForfait"].Visible = false;
                
                // Formater le montant en devise
                dgvFiches.Columns["MontantTotal"].DefaultCellStyle.Format = "C2";
            }
        }

        /// <summary>
        /// Nouvelle fiche - crée une fiche pour le mois actuel
        /// </summary>
        private async void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                string moisActuel = DateTime.Now.ToString("yyyyMM");
                var fiche = await _ficheFraisService.GetOrCreateFicheAsync(
                    SessionManager.UtilisateurCourant.IdUtilisateur, 
                    moisActuel
                );

                if (fiche != null)
                {
                    var frmEdit = new FrmEditionFiche(fiche);
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        await LoadFiches();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la création de la fiche");
            }
        }

        /// <summary>
        /// Ouvrir une fiche
        /// </summary>
        private async void BtnOpen_Click(object sender, EventArgs e)
        {
            if (dgvFiches.SelectedRows.Count == 0)
            {
                ExceptionManager.ShowWarning("Veuillez sélectionner une fiche", "Sélection requise");
                return;
            }

            try
            {
                var row = dgvFiches.SelectedRows[0];
                int idFiche = (int)row.Cells["IdFiche"].Value;
                
                var fiche = await _ficheFraisService.GetFicheByIdAsync(idFiche);
                if (fiche != null)
                {
                    var frmEdit = new FrmEditionFiche(fiche);
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        await LoadFiches();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de l'ouverture de la fiche");
            }
        }

        /// <summary>
        /// Actualiser la liste
        /// </summary>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadFiches();
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
        /// Fermer le formulaire
        /// </summary>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            BtnLogout_Click(null, null);
        }
    }
}
