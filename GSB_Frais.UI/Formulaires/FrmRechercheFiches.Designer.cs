namespace GSB_Frais.UI.Formulaires
{
    partial class FrmRechercheFiches
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
            this.btnLogout = new System.Windows.Forms.Button();
            
            // Search Panel
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblEtat = new System.Windows.Forms.Label();
            this.cboEtat = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            
            // DataGridView
            this.dgvFiches = new System.Windows.Forms.DataGridView();
            
            // Buttons
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiches)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Validation des Fiches";

            // btnLogout
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(800, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 30);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Déconnexion";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);

            // pnlSearch
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlSearch.Controls.Add(this.lblEtat);
            this.pnlSearch.Controls.Add(this.cboEtat);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Height = 50;
            this.pnlSearch.Location = new System.Drawing.Point(0, 60);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSearch.Size = new System.Drawing.Size(900, 50);
            this.pnlSearch.TabIndex = 1;

            // lblEtat
            this.lblEtat.AutoSize = true;
            this.lblEtat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEtat.Location = new System.Drawing.Point(20, 15);
            this.lblEtat.Name = "lblEtat";
            this.lblEtat.Size = new System.Drawing.Size(34, 15);
            this.lblEtat.TabIndex = 0;
            this.lblEtat.Text = "État:";

            // cboEtat
            this.cboEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboEtat.FormattingEnabled = true;
            this.cboEtat.Items.AddRange(new object[] { "EN_ATTENTE", "VALIDEE", "REFUSEE", "REFUS_PARTIEL" });
            this.cboEtat.Location = new System.Drawing.Point(70, 15);
            this.cboEtat.Name = "cboEtat";
            this.cboEtat.Size = new System.Drawing.Size(150, 23);
            this.cboEtat.TabIndex = 0;

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(230, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Rechercher";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            // dgvFiches
            this.dgvFiches.AllowUserToAddRows = false;
            this.dgvFiches.AllowUserToDeleteRows = false;
            this.dgvFiches.AllowUserToOrderColumns = true;
            this.dgvFiches.AllowUserToResizeRows = false;
            this.dgvFiches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiches.BackgroundColor = System.Drawing.Color.White;
            this.dgvFiches.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFiches.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFiches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiches.Location = new System.Drawing.Point(0, 110);
            this.dgvFiches.Name = "dgvFiches";
            this.dgvFiches.ReadOnly = true;
            this.dgvFiches.RowHeadersVisible = false;
            this.dgvFiches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiches.Size = new System.Drawing.Size(900, 330);
            this.dgvFiches.TabIndex = 2;

            // pnlButtons
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlButtons.Controls.Add(this.btnValidate);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height = 60;
            this.pnlButtons.Location = new System.Drawing.Point(0, 440);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10);
            this.pnlButtons.Size = new System.Drawing.Size(900, 60);
            this.pnlButtons.TabIndex = 3;

            // btnValidate
            this.btnValidate.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnValidate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnValidate.ForeColor = System.Drawing.Color.White;
            this.btnValidate.Location = new System.Drawing.Point(20, 15);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(100, 35);
            this.btnValidate.TabIndex = 0;
            this.btnValidate.Text = "Valider";
            this.btnValidate.UseVisualStyleBackColor = false;
            this.btnValidate.Click += new System.EventHandler(this.BtnValidate_Click);

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(800, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Fermer";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);

            // FrmRechercheFiches
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dgvFiches);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmRechercheFiches";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSB Frais - Validation des Fiches";
            this.Load += new System.EventHandler(this.FrmRechercheFiches_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiches)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblEtat;
        private System.Windows.Forms.ComboBox cboEtat;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvFiches;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnClose;
    }
}
