namespace GSB_Frais.UI.Formulaires
{
    partial class FrmMesFiches
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
            this.lblUser = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            
            // Buttons
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            
            // DataGridView
            this.dgvFiches = new System.Windows.Forms.DataGridView();
            
            this.pnlHeader.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiches)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 80);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Mes Fiches";

            // lblUser
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(20, 45);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 15);
            this.lblUser.TabIndex = 1;

            // btnLogout
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(800, 25);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 35);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Déconnexion";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);

            // pnlButtons
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlButtons.Controls.Add(this.btnNew);
            this.pnlButtons.Controls.Add(this.btnOpen);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Height = 60;
            this.pnlButtons.Location = new System.Drawing.Point(0, 80);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10);
            this.pnlButtons.Size = new System.Drawing.Size(900, 60);
            this.pnlButtons.TabIndex = 1;

            // btnNew
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(10, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 40);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Nouvelle";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);

            // btnOpen
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(100, 10);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(80, 40);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Ouvrir";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(190, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Actualiser";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(800, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Fermer";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);

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
            this.dgvFiches.Location = new System.Drawing.Point(0, 140);
            this.dgvFiches.Name = "dgvFiches";
            this.dgvFiches.ReadOnly = true;
            this.dgvFiches.RowHeadersVisible = false;
            this.dgvFiches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiches.Size = new System.Drawing.Size(900, 360);
            this.dgvFiches.TabIndex = 2;
            this.dgvFiches.DoubleClick += new System.EventHandler(this.BtnOpen_Click);

            // FrmMesFiches
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dgvFiches);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmMesFiches";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSB Frais - Mes Fiches";
            this.Load += new System.EventHandler(this.FrmMesFiches_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiches)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvFiches;
    }
}
