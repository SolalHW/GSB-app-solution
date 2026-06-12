using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GSB_Frais.Metier.Services;
using GSB_Frais.UI.Utilitaires;

namespace GSB_Frais.UI.Formulaires
{
    /// <summary>
    /// Formulaire de recherche et validation des fiches pour les comptables
    /// </summary>
    public partial class FrmRechercheFiches : Form
    {
        private readonly FicheFraisService _ficheFraisService;

        public FrmRechercheFiches()
        {
            InitializeComponent();
            _ficheFraisService = new FicheFraisService();
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private void FrmRechercheFiches_Load(object sender, EventArgs e)
        {
            try
            {
                cboEtat.SelectedIndex = 0; // EN_ATTENTE par défaut
                BtnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors du chargement");
            }
        }

        /// <summary>
        /// Recherche les fiches par état
        /// </summary>
        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvFiches.DataSource = null;
                string etat = cboEtat.SelectedItem?.ToString();
                
                if (string.IsNullOrEmpty(etat))
                    return;

                var fiches = await _ficheFraisService.GetFichesEnAttenteAsync();

                if (fiches != null && fiches.Count > 0)
                {
                    dgvFiches.DataSource = fiches;
                    
                    // Renommer les colonnes
                    dgvFiches.Columns["IdFiche"].HeaderText = "ID";
                    dgvFiches.Columns["Mois"].HeaderText = "Mois";
                    dgvFiches.Columns["Etat"].HeaderText = "État";
                    dgvFiches.Columns["MontantTotal"].HeaderText = "Montant";
                    dgvFiches.Columns["MontantTotal"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la recherche");
            }
        }

        /// <summary>
        /// Valider une fiche
        /// </summary>
        private void BtnValidate_Click(object sender, EventArgs e)
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
                
                var frmValidation = new FrmValidationFiche(idFiche, _ficheFraisService);
                if (frmValidation.ShowDialog() == DialogResult.OK)
                {
                    BtnSearch_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la validation");
            }
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
