using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GSB_Frais.Metier.Services;
using GSB_Frais.Models;
using GSB_Frais.UI.Utilitaires;

namespace GSB_Frais.UI.Formulaires
{
    /// <summary>
    /// Formulaire d'édition d'une fiche de frais
    /// Onglet Forfait: modifie les quantités des frais forfaitaires
    /// Onglet HorsForfait: ajoute/supprime les frais hors forfait
    /// </summary>
    public partial class FrmEditionFiche : Form
    {
        private readonly FicheFraisService _ficheFraisService;
        private readonly LigneFraisRepository _ligneRepo;
        private FicheFrais _fiche;

        public FrmEditionFiche(FicheFrais fiche)
        {
            InitializeComponent();
            _ficheFraisService = new FicheFraisService();
            _ligneRepo = new LigneFraisRepository();
            _fiche = fiche;
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private void FrmEditionFiche_Load(object sender, EventArgs e)
        {
            try
            {
                // Formater le titre
                this.Text = $"Fiche de Frais - {_fiche.Mois} - {_fiche.Etat}";
                
                // Remplir l'état
                cboEtat.Items.Add("EN_COURS");
                cboEtat.Items.Add("EN_ATTENTE");
                cboEtat.SelectedItem = _fiche.Etat;
                
                // Charger les données
                LoadForfait();
                LoadHorsForfait();
                UpdateMontantTotal();
                
                // Désactiver la modification si la fiche n'est pas en EN_COURS
                if (!_fiche.EstModifiable)
                {
                    dgvForfait.ReadOnly = true;
                    btnAddLigne.Enabled = false;
                    btnDeleteLigne.Enabled = false;
                    btnSubmit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors du chargement de la fiche");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// Charge les frais forfaitaires
        /// </summary>
        private void LoadForfait()
        {
            // Créer une liste affichable pour le DataGridView
            var displayList = new List<dynamic>();
            foreach (var ligne in _fiche.LignesForfait)
            {
                displayList.Add(new
                {
                    IdLFF = ligne.IdLFF,
                    Libelle = ligne.TypeFrais?.Libelle,
                    Tarif = ligne.TypeFrais?.Tarif ?? 0m,
                    Quantite = ligne.Quantite,
                    Montant = ligne.MontantLigne
                });
            }

            dgvForfait.DataSource = displayList;
            
            if (dgvForfait.Columns.Count > 0)
            {
                dgvForfait.Columns["IdLFF"].Visible = false;
                dgvForfait.Columns["Libelle"].ReadOnly = true;
                dgvForfait.Columns["Tarif"].ReadOnly = true;
                dgvForfait.Columns["Montant"].ReadOnly = true;
                dgvForfait.Columns["Tarif"].DefaultCellStyle.Format = "C2";
                dgvForfait.Columns["Montant"].DefaultCellStyle.Format = "C2";
            }

            // Événement pour mettre à jour le montant total quand on change une quantité
            dgvForfait.CellEndEdit += async (s, e) =>
            {
                if (e.ColumnIndex == dgvForfait.Columns["Quantite"].Index)
                {
                    try
                    {
                        int idLFF = (int)dgvForfait.Rows[e.RowIndex].Cells["IdLFF"].Value;
                        if (int.TryParse(dgvForfait.Rows[e.RowIndex].Cells["Quantite"].Value?.ToString() ?? "0", out int quantite))
                        {
                            await _ficheFraisService.UpdateLigneForfaitQuantityAsync(idLFF, quantite);
                            await ReloadFiche();
                            UpdateMontantTotal();
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionManager.HandleException(ex, "Erreur lors de la modification");
                    }
                }
            };
        }

        /// <summary>
        /// Charge les frais hors forfait
        /// </summary>
        private void LoadHorsForfait()
        {
            var displayList = new List<dynamic>();
            foreach (var ligne in _fiche.LignesHorsForfait)
            {
                displayList.Add(new
                {
                    IdLHFF = ligne.IdLHFF,
                    Libelle = ligne.Libelle,
                    Montant = ligne.Montant,
                    Justificatif = ligne.Justificatif
                });
            }

            dgvHorsForfait.DataSource = displayList;

            if (dgvHorsForfait.Columns.Count > 0)
            {
                dgvHorsForfait.Columns["IdLHFF"].Visible = false;
                dgvHorsForfait.Columns["Montant"].DefaultCellStyle.Format = "C2";
            }
        }

        /// <summary>
        /// Ajouter une ligne de frais hors forfait
        /// </summary>
        private async void BtnAddLigne_Click(object sender, EventArgs e)
        {
            var frmAdd = new FrmAddLigneHorsForfait(_fiche.IdFiche, _ficheFraisService);
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                await ReloadFiche();
                LoadHorsForfait();
                UpdateMontantTotal();
            }
        }

        /// <summary>
        /// Supprimer une ligne de frais hors forfait
        /// </summary>
        private async void BtnDeleteLigne_Click(object sender, EventArgs e)
        {
            if (dgvHorsForfait.SelectedRows.Count == 0)
            {
                ExceptionManager.ShowWarning("Veuillez sélectionner une ligne à supprimer", "Sélection requise");
                return;
            }

            try
            {
                var row = dgvHorsForfait.SelectedRows[0];
                int idLHFF = (int)row.Cells["IdLHFF"].Value;

                if (!ExceptionManager.ConfirmAction("Êtes-vous sûr de vouloir supprimer cette ligne?", "Confirmation"))
                    return;

                bool success = await _ficheFraisService.DeleteLigneHorsForfaitAsync(idLHFF);
                
                if (success)
                {
                    await ReloadFiche();
                    LoadHorsForfait();
                    UpdateMontantTotal();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la suppression");
            }
        }

        /// <summary>
        /// Soumettre la fiche (passer en EN_ATTENTE)
        /// </summary>
        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_fiche.LignesForfait.Count == 0 && _fiche.LignesHorsForfait.Count == 0)
                {
                    ExceptionManager.ShowWarning("La fiche doit contenir au moins une ligne de frais", "Validation");
                    return;
                }

                if (!ExceptionManager.ConfirmAction("Êtes-vous sûr de vouloir soumettre cette fiche?", "Confirmation"))
                    return;

                bool success = await _ficheFraisService.SubmitFicheAsync(_fiche.IdFiche);

                if (success)
                {
                    ExceptionManager.ShowInfo("Fiche soumise avec succès", "Succès");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, "Erreur lors de la soumission");
            }
        }

        /// <summary>
        /// Recharge la fiche depuis la base de données
        /// </summary>
        private async System.Threading.Tasks.Task ReloadFiche()
        {
            _fiche = await _ficheFraisService.GetFicheByIdAsync(_fiche.IdFiche);
        }

        /// <summary>
        /// Met à jour l'affichage du montant total
        /// </summary>
        private void UpdateMontantTotal()
        {
            decimal montant = _ficheFraisService.CalculateMontantTotal(_fiche);
            txtMontantTotal.Text = montant.ToString("C2");
        }
    }
}
