namespace GSB_Frais.UI.Formulaires
{
    partial class FrmEditionTypeFrais
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
            
            this.pnlContent = new System.Windows.Forms.Panel();
            
            // Labels
            this.lblLibelle = new System.Windows.Forms.Label();
            this.lblTarif = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            
            // TextBoxes
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.txtTarif = new System.Windows.Forms.TextBox();
            
            // ComboBox
            this.cboType = new System.Windows.Forms.ComboBox();
            
            // Buttons
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.lblLibelle);
            this.pnlContent.Controls.Add(this.txtLibelle);
            this.pnlContent.Controls.Add(this.lblTarif);
            this.pnlContent.Controls.Add(this.txtTarif);
            this.pnlContent.Controls.Add(this.lblType);
            this.pnlContent.Controls.Add(this.cboType);
            this.pnlContent.Controls.Add(this.btnSave);
            this.pnlContent.Controls.Add(this.btnCancel);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(400, 300);
            this.pnlContent.TabIndex = 0;

            // lblLibelle
            this.lblLibelle.AutoSize = true;
            this.lblLibelle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLibelle.Location = new System.Drawing.Point(20, 20);
            this.lblLibelle.Name = "lblLibelle";
            this.lblLibelle.Size = new System.Drawing.Size(49, 15);
            this.lblLibelle.TabIndex = 0;
            this.lblLibelle.Text = "Libellé:";

            // txtLibelle
            this.txtLibelle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLibelle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLibelle.Location = new System.Drawing.Point(20, 40);
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(360, 23);
            this.txtLibelle.TabIndex = 0;

            // lblTarif
            this.lblTarif.AutoSize = true;
            this.lblTarif.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTarif.Location = new System.Drawing.Point(20, 75);
            this.lblTarif.Name = "lblTarif";
            this.lblTarif.Size = new System.Drawing.Size(40, 15);
            this.lblTarif.TabIndex = 2;
            this.lblTarif.Text = "Tarif:";

            // txtTarif
            this.txtTarif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTarif.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTarif.Location = new System.Drawing.Point(20, 95);
            this.txtTarif.Name = "txtTarif";
            this.txtTarif.Size = new System.Drawing.Size(360, 23);
            this.txtTarif.TabIndex = 1;
            this.txtTarif.Text = "0";

            // lblType
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblType.Location = new System.Drawing.Point(20, 130);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 15);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type:";

            // cboType
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] { "FORFAIT", "HORS_FORFAIT" });
            this.cboType.Location = new System.Drawing.Point(20, 150);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(360, 23);
            this.cboType.TabIndex = 2;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(140, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(250, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = false;

            // FrmEditionTypeFrais
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditionTypeFrais";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edition d'un type de frais";
            this.Load += new System.EventHandler(this.FrmEditionTypeFrais_Load);

            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblLibelle;
        private System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label lblTarif;
        private System.Windows.Forms.TextBox txtTarif;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
