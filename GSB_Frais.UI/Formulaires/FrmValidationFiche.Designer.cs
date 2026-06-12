namespace GSB_Frais.UI.Formulaires
{
    partial class FrmValidationFiche
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
            
            // Header
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFiche = new System.Windows.Forms.Label();
            
            // Info Panel
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblMontantTotal = new System.Windows.Forms.Label();
            this.txtMontantTotal = new System.Windows.Forms.TextBox();
            
            // DataGridView
            this.dgvLignes = new System.Windows.Forms.DataGridView();
            
            // Action Panel
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnValidateComplete = new System.Windows.Forms.Button();
            this.btnRejectComplete = new System.Windows.Forms.Button();
            this.btnValidatePartial = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblFiche);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 60);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(150, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Validation Fiche";

            // lblFiche
            this.lblFiche.AutoSize = true;
            this.lblFiche.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFiche.ForeColor = System.Drawing.Color.White;
            this.lblFiche.Location = new System.Drawing.Point(20, 38);
            this.lblFiche.Name = "lblFiche";
            this.lblFiche.Size = new System.Drawing.Size(0, 15);
            this.lblFiche.TabIndex = 1;

            // pnlInfo
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlInfo.Controls.Add(this.lblMontantTotal);
            this.pnlInfo.Controls.Add(this.txtMontantTotal);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Height = 50;
            this.pnlInfo.Location = new System.Drawing.Point(0, 60);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(10);
            this.pnlInfo.Size = new System.Drawing.Size(800, 50);
            this.pnlInfo.TabIndex = 1;

            // lblMontantTotal
            this.lblMontantTotal.AutoSize = true;
            this.lblMontantTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMontantTotal.Location = new System.Drawing.Point(20, 15);
            this.lblMontantTotal.Name = "lblMontantTotal";
            this.lblMontantTotal.Size = new System.Drawing.Size(85, 15);
            this.lblMontantTotal.TabIndex = 0;
            this.lblMontantTotal.Text = "Montant Total:";

            // txtMontantTotal
            this.txtMontantTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontantTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMontantTotal.Location = new System.Drawing.Point(110, 15);
            this.txtMontantTotal.Name = "txtMontantTotal";
            this.txtMontantTotal.ReadOnly = true;
            this.txtMontantTotal.Size = new System.Drawing.Size(100, 23);
            this.txtMontantTotal.TabIndex = 1;
            this.txtMontantTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // dgvLignes
            this.dgvLignes.AllowUserToAddRows = false;
            this.dgvLignes.AllowUserToDeleteRows = false;
            this.dgvLignes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLignes.BackgroundColor = System.Drawing.Color.White;
            this.dgvLignes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLignes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLignes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLignes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLignes.Location = new System.Drawing.Point(0, 110);
            this.dgvLignes.Name = "dgvLignes";
            this.dgvLignes.ReadOnly = true;
            this.dgvLignes.RowHeadersVisible = false;
            this.dgvLignes.Size = new System.Drawing.Size(800, 290);
            this.dgvLignes.TabIndex = 2;

            // pnlActions
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlActions.Controls.Add(this.btnValidateComplete);
            this.pnlActions.Controls.Add(this.btnRejectComplete);
            this.pnlActions.Controls.Add(this.btnValidatePartial);
            this.pnlActions.Controls.Add(this.btnCancel);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Height = 60;
            this.pnlActions.Location = new System.Drawing.Point(0, 400);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlActions.Size = new System.Drawing.Size(800, 60);
            this.pnlActions.TabIndex = 3;

            // btnValidateComplete
            this.btnValidateComplete.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnValidateComplete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnValidateComplete.ForeColor = System.Drawing.Color.White;
            this.btnValidateComplete.Location = new System.Drawing.Point(10, 15);
            this.btnValidateComplete.Name = "btnValidateComplete";
            this.btnValidateComplete.Size = new System.Drawing.Size(100, 35);
            this.btnValidateComplete.TabIndex = 0;
            this.btnValidateComplete.Text = "Valider";
            this.btnValidateComplete.UseVisualStyleBackColor = false;
            this.btnValidateComplete.Click += new System.EventHandler(this.BtnValidateComplete_Click);

            // btnRejectComplete
            this.btnRejectComplete.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnRejectComplete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRejectComplete.ForeColor = System.Drawing.Color.White;
            this.btnRejectComplete.Location = new System.Drawing.Point(120, 15);
            this.btnRejectComplete.Name = "btnRejectComplete";
            this.btnRejectComplete.Size = new System.Drawing.Size(100, 35);
            this.btnRejectComplete.TabIndex = 1;
            this.btnRejectComplete.Text = "Refuser";
            this.btnRejectComplete.UseVisualStyleBackColor = false;
            this.btnRejectComplete.Click += new System.EventHandler(this.BtnRejectComplete_Click);

            // btnValidatePartial
            this.btnValidatePartial.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnValidatePartial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnValidatePartial.ForeColor = System.Drawing.Color.White;
            this.btnValidatePartial.Location = new System.Drawing.Point(230, 15);
            this.btnValidatePartial.Name = "btnValidatePartial";
            this.btnValidatePartial.Size = new System.Drawing.Size(130, 35);
            this.btnValidatePartial.TabIndex = 2;
            this.btnValidatePartial.Text = "Refus Partiel";
            this.btnValidatePartial.UseVisualStyleBackColor = false;
            this.btnValidatePartial.Click += new System.EventHandler(this.BtnValidatePartial_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(690, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Fermer";
            this.btnCancel.UseVisualStyleBackColor = false;

            // FrmValidationFiche
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.dgvLignes);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmValidationFiche";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSB Frais - Validation de Fiche";
            this.Load += new System.EventHandler(this.FrmValidationFiche_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFiche;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblMontantTotal;
        private System.Windows.Forms.TextBox txtMontantTotal;
        private System.Windows.Forms.DataGridView dgvLignes;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnValidateComplete;
        private System.Windows.Forms.Button btnRejectComplete;
        private System.Windows.Forms.Button btnValidatePartial;
        private System.Windows.Forms.Button btnCancel;
    }
}
