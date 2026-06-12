namespace GSB_Frais.UI.Formulaires
{
    partial class FrmEditionFiche
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            
            // Tabs
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabForfait = new System.Windows.Forms.TabPage();
            this.tabHorsForfait = new System.Windows.Forms.TabPage();
            
            // Forfait controls
            this.dgvForfait = new System.Windows.Forms.DataGridView();
            
            // HorsForfait controls
            this.dgvHorsForfait = new System.Windows.Forms.DataGridView();
            this.pnlHorsForfaitButtons = new System.Windows.Forms.Panel();
            this.btnAddLigne = new System.Windows.Forms.Button();
            this.btnDeleteLigne = new System.Windows.Forms.Button();
            
            // Bottom panel
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblMontantTotal = new System.Windows.Forms.Label();
            this.txtMontantTotal = new System.Windows.Forms.TextBox();
            this.lblEtat = new System.Windows.Forms.Label();
            this.cboEtat = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            
            this.tcMain.SuspendLayout();
            this.tabForfait.SuspendLayout();
            this.tabHorsForfait.SuspendLayout();
            this.pnlHorsForfaitButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForfait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorsForfait)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // tcMain
            this.tcMain.Controls.Add(this.tabForfait);
            this.tcMain.Controls.Add(this.tabHorsForfait);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(900, 350);
            this.tcMain.TabIndex = 0;

            // tabForfait
            this.tabForfait.BackColor = System.Drawing.Color.White;
            this.tabForfait.Controls.Add(this.dgvForfait);
            this.tabForfait.Location = new System.Drawing.Point(4, 24);
            this.tabForfait.Name = "tabForfait";
            this.tabForfait.Padding = new System.Windows.Forms.Padding(3);
            this.tabForfait.Size = new System.Drawing.Size(892, 322);
            this.tabForfait.TabIndex = 0;
            this.tabForfait.Text = "Frais Forfaitaires";

            // dgvForfait
            this.dgvForfait.AllowUserToResizeRows = false;
            this.dgvForfait.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvForfait.BackgroundColor = System.Drawing.Color.White;
            this.dgvForfait.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvForfait.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvForfait.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForfait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvForfait.Location = new System.Drawing.Point(3, 3);
            this.dgvForfait.Name = "dgvForfait";
            this.dgvForfait.RowHeadersVisible = false;
            this.dgvForfait.Size = new System.Drawing.Size(886, 316);
            this.dgvForfait.TabIndex = 0;

            // tabHorsForfait
            this.tabHorsForfait.BackColor = System.Drawing.Color.White;
            this.tabHorsForfait.Controls.Add(this.dgvHorsForfait);
            this.tabHorsForfait.Controls.Add(this.pnlHorsForfaitButtons);
            this.tabHorsForfait.Location = new System.Drawing.Point(4, 24);
            this.tabHorsForfait.Name = "tabHorsForfait";
            this.tabHorsForfait.Padding = new System.Windows.Forms.Padding(3);
            this.tabHorsForfait.Size = new System.Drawing.Size(892, 322);
            this.tabHorsForfait.TabIndex = 1;
            this.tabHorsForfait.Text = "Frais Hors Forfait";

            // dgvHorsForfait
            this.dgvHorsForfait.AllowUserToAddRows = false;
            this.dgvHorsForfait.AllowUserToResizeRows = false;
            this.dgvHorsForfait.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHorsForfait.BackgroundColor = System.Drawing.Color.White;
            this.dgvHorsForfait.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHorsForfait.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHorsForfait.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorsForfait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHorsForfait.Location = new System.Drawing.Point(3, 3);
            this.dgvHorsForfait.Name = "dgvHorsForfait";
            this.dgvHorsForfait.RowHeadersVisible = false;
            this.dgvHorsForfait.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHorsForfait.Size = new System.Drawing.Size(750, 316);
            this.dgvHorsForfait.TabIndex = 0;

            // pnlHorsForfaitButtons
            this.pnlHorsForfaitButtons.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlHorsForfaitButtons.Controls.Add(this.btnAddLigne);
            this.pnlHorsForfaitButtons.Controls.Add(this.btnDeleteLigne);
            this.pnlHorsForfaitButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHorsForfaitButtons.Location = new System.Drawing.Point(753, 3);
            this.pnlHorsForfaitButtons.Name = "pnlHorsForfaitButtons";
            this.pnlHorsForfaitButtons.Padding = new System.Windows.Forms.Padding(5);
            this.pnlHorsForfaitButtons.Size = new System.Drawing.Size(136, 316);
            this.pnlHorsForfaitButtons.TabIndex = 1;

            // btnAddLigne
            this.btnAddLigne.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAddLigne.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddLigne.ForeColor = System.Drawing.Color.White;
            this.btnAddLigne.Location = new System.Drawing.Point(5, 10);
            this.btnAddLigne.Name = "btnAddLigne";
            this.btnAddLigne.Size = new System.Drawing.Size(126, 35);
            this.btnAddLigne.TabIndex = 0;
            this.btnAddLigne.Text = "Ajouter";
            this.btnAddLigne.UseVisualStyleBackColor = false;
            this.btnAddLigne.Click += new System.EventHandler(this.BtnAddLigne_Click);

            // btnDeleteLigne
            this.btnDeleteLigne.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDeleteLigne.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnDeleteLigne.ForeColor = System.Drawing.Color.White;
            this.btnDeleteLigne.Location = new System.Drawing.Point(5, 50);
            this.btnDeleteLigne.Name = "btnDeleteLigne";
            this.btnDeleteLigne.Size = new System.Drawing.Size(126, 35);
            this.btnDeleteLigne.TabIndex = 1;
            this.btnDeleteLigne.Text = "Supprimer";
            this.btnDeleteLigne.UseVisualStyleBackColor = false;
            this.btnDeleteLigne.Click += new System.EventHandler(this.BtnDeleteLigne_Click);

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlBottom.Controls.Add(this.lblMontantTotal);
            this.pnlBottom.Controls.Add(this.txtMontantTotal);
            this.pnlBottom.Controls.Add(this.lblEtat);
            this.pnlBottom.Controls.Add(this.cboEtat);
            this.pnlBottom.Controls.Add(this.btnSubmit);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 350);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Size = new System.Drawing.Size(900, 100);
            this.pnlBottom.TabIndex = 1;

            // lblMontantTotal
            this.lblMontantTotal.AutoSize = true;
            this.lblMontantTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMontantTotal.Location = new System.Drawing.Point(20, 20);
            this.lblMontantTotal.Name = "lblMontantTotal";
            this.lblMontantTotal.Size = new System.Drawing.Size(85, 15);
            this.lblMontantTotal.TabIndex = 0;
            this.lblMontantTotal.Text = "Montant Total:";

            // txtMontantTotal
            this.txtMontantTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontantTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMontantTotal.Location = new System.Drawing.Point(110, 20);
            this.txtMontantTotal.Name = "txtMontantTotal";
            this.txtMontantTotal.ReadOnly = true;
            this.txtMontantTotal.Size = new System.Drawing.Size(100, 23);
            this.txtMontantTotal.TabIndex = 1;
            this.txtMontantTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // lblEtat
            this.lblEtat.AutoSize = true;
            this.lblEtat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEtat.Location = new System.Drawing.Point(250, 20);
            this.lblEtat.Name = "lblEtat";
            this.lblEtat.Size = new System.Drawing.Size(34, 15);
            this.lblEtat.TabIndex = 2;
            this.lblEtat.Text = "État:";

            // cboEtat
            this.cboEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtat.Enabled = false;
            this.cboEtat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboEtat.FormattingEnabled = true;
            this.cboEtat.Location = new System.Drawing.Point(290, 20);
            this.cboEtat.Name = "cboEtat";
            this.cboEtat.Size = new System.Drawing.Size(120, 23);
            this.cboEtat.TabIndex = 3;

            // btnSubmit
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(650, 40);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 35);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Soumettre";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(760, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Fermer";
            this.btnCancel.UseVisualStyleBackColor = false;

            // FrmEditionFiche
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.pnlBottom);
            this.Name = "FrmEditionFiche";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edition de Fiche de Frais";
            this.Load += new System.EventHandler(this.FrmEditionFiche_Load);

            this.tcMain.ResumeLayout(false);
            this.tabForfait.ResumeLayout(false);
            this.tabHorsForfait.ResumeLayout(false);
            this.pnlHorsForfaitButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvForfait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorsForfait)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabForfait;
        private System.Windows.Forms.TabPage tabHorsForfait;
        private System.Windows.Forms.DataGridView dgvForfait;
        private System.Windows.Forms.DataGridView dgvHorsForfait;
        private System.Windows.Forms.Panel pnlHorsForfaitButtons;
        private System.Windows.Forms.Button btnAddLigne;
        private System.Windows.Forms.Button btnDeleteLigne;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblMontantTotal;
        private System.Windows.Forms.TextBox txtMontantTotal;
        private System.Windows.Forms.Label lblEtat;
        private System.Windows.Forms.ComboBox cboEtat;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}
