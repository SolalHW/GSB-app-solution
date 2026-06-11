using System;
using System.Windows.Forms;
using GSB_Frais.Metier.Services;
using GSB_Frais.Models;
using GSB_Frais.UI.Utilitaires;

namespace GSB_Frais.UI.Formulaires
{
    /// <summary>
    /// Formulaire d'édition d'un type de frais
    /// </summary>
    public partial class FrmEditionTypeFrais : Form
    {
        private readonly TypeFraisService _typeFraisService;
        private int? _idTypeFrais;
        private TypeFrais _typeFraisActuel;

        public FrmEditionTypeFrais(int? idTypeFrais, TypeFraisService typeFraisService)
        {
            InitializeComponent();
            _typeFraisService = typeFraisService;
            _idTypeFrais = idTypeFrais;

            if (idTypeFrais.HasValue)
            {
                this.Text = "Modification d'un type de frais";
            }
            else
            {
                this.Text = "Ajout d'un nouveau type de frais";
            }
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private async void FrmEditionTypeFrais_Load(object sender, EventArgs e)
        {
            try
            {
                if (_idTypeFrais.HasValue)
                {
                    // Mode modification
                    _typeFraisActuel = await _typeFraisService.GetTypeByIdAsync(_idTypeFrais.Value);
                    if (_typeFraisActuel != null)
                    {
                        txtLibelle.Text = _typeFraisActuel.Libelle;
                        txtTarif.Text = _typeFraisActuel.Tarif.ToString("F2");
                        cboType.SelectedItem = _typeFraisActuel.Type;
                    }
                }
                else
                {
                    // Mode ajout
                    cboType.SelectedIndex = 0;
                    txtTarif.Text = "0";
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

            if (!decimal.TryParse(txtTarif.Text, out decimal tarif) || tarif < 0)
            {
                ExceptionManager.ShowWarning("Le tarif doit être un nombre positif", "Validation");
                txtTarif.Focus();
                return false;
            }

            if (cboType.SelectedItem == null)
            {
                ExceptionManager.ShowWarning("Veuillez sélectionner un type", "Validation");
                cboType.Focus();
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

                if (_idTypeFrais.HasValue)
                {
                    await ModifyTypeAsync();
                }
                else
                {
                    await AddTypeAsync();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la sauvegarde");
            }
        }

        /// <summary>
        /// Ajoute un nouveau type
        /// </summary>
        private async System.Threading.Tasks.Task AddTypeAsync()
        {
            var typeFrais = new TypeFrais
            {
                Libelle = txtLibelle.Text.Trim(),
                Tarif = decimal.Parse(txtTarif.Text),
                Type = cboType.SelectedItem.ToString()
            };

            int newId = await _typeFraisService.AddTypeAsync(typeFrais);
            ExceptionManager.ShowInfo("Type créé avec succès", "Succès");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Modifie un type existant
        /// </summary>
        private async System.Threading.Tasks.Task ModifyTypeAsync()
        {
            _typeFraisActuel.Libelle = txtLibelle.Text.Trim();
            _typeFraisActuel.Tarif = decimal.Parse(txtTarif.Text);
            _typeFraisActuel.Type = cboType.SelectedItem.ToString();

            bool success = await _typeFraisService.UpdateTypeAsync(_typeFraisActuel);

            if (success)
            {
                ExceptionManager.ShowInfo("Type modifié avec succès", "Succès");
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
