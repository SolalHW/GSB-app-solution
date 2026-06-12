using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GSB_Frais.Metier.Services;
using GSB_Frais.Models;
using GSB_Frais.UI.Utilitaires;

namespace GSB_Frais.UI.Formulaires
{
    /// <summary>
    /// Formulaire de gestion des types de frais (Admin)
    /// </summary>
    public partial class FrmGestionTypesFrais : Form
    {
        private readonly TypeFraisService _typeFraisService;

        public FrmGestionTypesFrais()
        {
            InitializeComponent();
            _typeFraisService = new TypeFraisService();
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private async void FrmGestionTypesFrais_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadTypesFrais();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors du chargement");
            }
        }

        /// <summary>
        /// Charge tous les types de frais
        /// </summary>
        private async System.Threading.Tasks.Task LoadTypesFrais()
        {
            dgvTypesFrais.DataSource = null;
            var types = await _typeFraisService.GetAllTypesAsync();

            if (types != null && types.Count > 0)
            {
                dgvTypesFrais.DataSource = types;
                
                // Renommer les colonnes
                dgvTypesFrais.Columns["IdTypeFrais"].HeaderText = "ID";
                dgvTypesFrais.Columns["Libelle"].HeaderText = "Libellé";
                dgvTypesFrais.Columns["Tarif"].HeaderText = "Tarif";
                dgvTypesFrais.Columns["Type"].HeaderText = "Type";
                dgvTypesFrais.Columns["DateCreation"].HeaderText = "Créé le";
                dgvTypesFrais.Columns["DateModification"].HeaderText = "Modifié le";
                
                // Formater la colonne Tarif en devise
                dgvTypesFrais.Columns["Tarif"].DefaultCellStyle.Format = "C2";
            }
        }

        /// <summary>
        /// Ajouter un type
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var frmEdit = new FrmEditionTypeFrais(null, _typeFraisService);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                LoadTypesFrais();
            }
        }

        /// <summary>
        /// Modifier un type
        /// </summary>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTypesFrais.SelectedRows.Count == 0)
            {
                ExceptionManager.ShowWarning("Veuillez sélectionner un type à modifier", "Sélection requise");
                return;
            }

            try
            {
                var row = dgvTypesFrais.SelectedRows[0];
                int idType = (int)row.Cells["IdTypeFrais"].Value;
                
                var frmEdit = new FrmEditionTypeFrais(idType, _typeFraisService);
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    LoadTypesFrais();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de l'édition");
            }
        }

        /// <summary>
        /// Supprimer un type
        /// </summary>
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTypesFrais.SelectedRows.Count == 0)
            {
                ExceptionManager.ShowWarning("Veuillez sélectionner un type à supprimer", "Sélection requise");
                return;
            }

            try
            {
                var row = dgvTypesFrais.SelectedRows[0];
                int idType = (int)row.Cells["IdTypeFrais"].Value;
                string libelle = row.Cells["Libelle"].Value.ToString();

                if (!ExceptionManager.ConfirmAction($"Êtes-vous sûr de vouloir supprimer {libelle}?", "Confirmation"))
                    return;

                bool success = await _typeFraisService.DeleteTypeAsync(idType);
                
                if (success)
                {
                    ExceptionManager.ShowInfo("Type supprimé avec succès", "Succès");
                    await LoadTypesFrais();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la suppression");
            }
        }

        /// <summary>
        /// Actualiser la liste
        /// </summary>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadTypesFrais();
        }

        /// <summary>
        /// Fermer le formulaire
        /// </summary>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
