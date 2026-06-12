namespace GSB_Frais.UI.Formulaires
{
    partial class FrmGestionUtilisateurs
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
            
            // Panels
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            
            // DataGridView
            this.dgvUtilisateurs = new System.Windows.Forms.DataGridView();
            
            this.pnlTop.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilisateurs)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 50;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(900, 50);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Gestion des Utilisateurs";

            // pnlButtons
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Height = 60;
            this.pnlButtons.Location = new System.Drawing.Point(0, 50);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10);
            this.pnlButtons.Size = new System.Drawing.Size(900, 60);
            this.pnlButtons.TabIndex = 1;

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(10, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // btnEdit
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(100, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Modifier";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(190, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(280, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 40);
            this.btnRefresh.TabIndex = 3;
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
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Fermer";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);

            // dgvUtilisateurs
            this.dgvUtilisateurs.AllowUserToAddRows = false;
            this.dgvUtilisateurs.AllowUserToDeleteRows = false;
            this.dgvUtilisateurs.AllowUserToOrderColumns = true;
            this.dgvUtilisateurs.AllowUserToResizeRows = false;
            this.dgvUtilisateurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUtilisateurs.BackgroundColor = System.Drawing.Color.White;
            this.dgvUtilisateurs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUtilisateurs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUtilisateurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUtilisateurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUtilisateurs.Location = new System.Drawing.Point(0, 110);
            this.dgvUtilisateurs.Name = "dgvUtilisateurs";
            this.dgvUtilisateurs.ReadOnly = true;
            this.dgvUtilisateurs.RowHeadersVisible = false;
            this.dgvUtilisateurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUtilisateurs.Size = new System.Drawing.Size(900, 390);
            this.dgvUtilisateurs.TabIndex = 2;
            this.dgvUtilisateurs.DoubleClick += new System.EventHandler(this.BtnEdit_Click);

            // FrmGestionUtilisateurs
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dgvUtilisateurs);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmGestionUtilisateurs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSB Frais - Gestion des Utilisateurs";
            this.Load += new System.EventHandler(this.FrmGestionUtilisateurs_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilisateurs)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvUtilisateurs;
    }
}
