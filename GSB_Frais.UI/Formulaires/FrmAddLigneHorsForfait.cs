using System;
using System.Windows.Forms;
using GSB_Frais.Metier.Services;
using GSB_Frais.UI.Utilitaires;

namespace GSB_Frais.UI.Formulaires
{
    /// <summary>
    /// Formulaire d'ajout d'une ligne de frais hors forfait
    /// </summary>
    public partial class FrmAddLigneHorsForfait : Form
    {
        private readonly FicheFraisService _ficheFraisService;
        private readonly int _idFiche;

        public FrmAddLigneHorsForfait(int idFiche, FicheFraisService ficheFraisService)
        {
            InitializeComponent();
            _ficheFraisService = ficheFraisService;
            _idFiche = idFiche;
        }

        /// <summary>
        /// Validation du formulaire
        /// </summary>
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                ExceptionManager.ShowWarning("Le libellé est obligatoire", "Validation");
                txtLibelle.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMontant.Text, out decimal montant) || montant <= 0)
            {
                ExceptionManager.ShowWarning("Le montant doit être un nombre positif", "Validation");
                txtMontant.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Ajouter la ligne
        /// </summary>
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                    return;

                await _ficheFraisService.AddLigneHorsForfaitAsync(
                    _idFiche,
                    txtLibelle.Text.Trim(),
                    decimal.Parse(txtMontant.Text)
                );

                ExceptionManager.ShowInfo("Ligne ajoutée avec succès", "Succès");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de l'ajout de la ligne");
            }
        }
    }
}
