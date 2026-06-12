using System;
using System.Windows.Forms;
using GSB_Frais.Metier.Services;
using GSB_Frais.UI.Utilitaires;

namespace GSB_Frais.UI.Formulaires
{
    /// <summary>
    /// Formulaire de validation détaillée d'une fiche
    /// Permet la validation complète, refus complet, ou refus partiel
    /// </summary>
    public partial class FrmValidationFiche : Form
    {
        private readonly ValidationService _validationService;
        private readonly FicheFraisService _ficheFraisService;
        private readonly int _idFiche;

        public FrmValidationFiche(int idFiche, FicheFraisService ficheFraisService)
        {
            InitializeComponent();
            _validationService = new ValidationService();
            _ficheFraisService = ficheFraisService;
            _idFiche = idFiche;
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private async void FrmValidationFiche_Load(object sender, EventArgs e)
        {
            try
            {
                var fiche = await _ficheFraisService.GetFicheByIdAsync(_idFiche);
                if (fiche == null)
                {
                    ExceptionManager.ShowWarning("Fiche non trouvée", "Erreur");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                lblFiche.Text = $"Fiche du mois {fiche.Mois} - Montant: {fiche.MontantTotal:C2}";
                txtMontantTotal.Text = fiche.MontantTotal.ToString("C2");

                // Afficher toutes les lignes (forfait + hors forfait)
                var lignes = new System.Collections.Generic.List<dynamic>();
                foreach (var ligne in fiche.LignesForfait)
                {
                    lignes.Add(new
                    {
                        Type = "Forfait",
                        Libelle = ligne.TypeFrais?.Libelle,
                        Quantite = ligne.Quantite,
                        Montant = ligne.MontantLigne
                    });
                }

                foreach (var ligne in fiche.LignesHorsForfait)
                {
                    lignes.Add(new
                    {
                        Type = "Hors Forfait",
                        Libelle = ligne.Libelle,
                        Quantite = "—",
                        Montant = ligne.Montant
                    });
                }

                dgvLignes.DataSource = lignes;
                if (dgvLignes.Columns.Count > 0)
                {
                    dgvLignes.Columns["Montant"].DefaultCellStyle.Format = "C2";
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
        /// Valider complètement la fiche
        /// </summary>
        private async void BtnValidateComplete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ExceptionManager.ConfirmAction("Êtes-vous sûr de vouloir valider complètement cette fiche?", "Confirmation"))
                    return;

                bool success = await _validationService.ValidateCompleteFicheAsync(_idFiche);
                
                if (success)
                {
                    ExceptionManager.ShowInfo("Fiche validée avec succès", "Succès");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la validation");
            }
        }

        /// <summary>
        /// Refuser complètement la fiche
        /// </summary>
        private async void BtnRejectComplete_Click(object sender, EventArgs e)
        {
            try
            {
                var motif = PromptForReason("Motif du refus complet:");
                if (string.IsNullOrEmpty(motif))
                    return;

                bool success = await _validationService.RejectCompleteFicheAsync(_idFiche, motif);
                
                if (success)
                {
                    ExceptionManager.ShowInfo("Fiche refusée", "Succès");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors du refus");
            }
        }

        /// <summary>
        /// Refus partiel de la fiche
        /// </summary>
        private async void BtnValidatePartial_Click(object sender, EventArgs e)
        {
            try
            {
                var motif = PromptForReason("Motif du refus partiel (quelles lignes sont refusées):");
                if (string.IsNullOrEmpty(motif))
                    return;

                bool success = await _validationService.ValidatePartialFicheAsync(_idFiche, motif);
                
                if (success)
                {
                    ExceptionManager.ShowInfo("Fiche validée partiellement", "Succès");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la validation partielle");
            }
        }

        /// <summary>
        /// Affiche une boîte de dialogue pour saisir un motif
        /// </summary>
        private string PromptForReason(string prompt)
        {
            var form = new Form
            {
                Text = "Motif",
                Width = 400,
                Height = 150,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var label = new Label { Text = prompt, Left = 20, Top = 20, Width = 360 };
            var textBox = new TextBox { Left = 20, Top = 50, Width = 360, Multiline = true, Height = 50 };
            var okButton = new Button { Text = "OK", Left = 200, Top = 110, Width = 80, DialogResult = DialogResult.OK };
            var cancelButton = new Button { Text = "Annuler", Left = 290, Top = 110, Width = 80, DialogResult = DialogResult.Cancel };

            form.Controls.Add(label);
            form.Controls.Add(textBox);
            form.Controls.Add(okButton);
            form.Controls.Add(cancelButton);
            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            return form.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}
