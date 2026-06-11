namespace GSB_Frais.UI.Formulaires
{
    partial class FrmMenuAdmin
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
            
            // Main Panel
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            
            // Content Panel
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            
            // Buttons
            this.btnGestionUtilisateurs = new System.Windows.Forms.Button();
            this.btnGestionTypesFrais = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 80);
            this.pnlHeader.TabIndex = 0;

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(20, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(150, 25);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Menu Administration";

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
            this.btnLogout.Location = new System.Drawing.Point(500, 25);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 35);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Déconnexion";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);

            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.lblTitle);
            this.pnlContent.Controls.Add(this.btnGestionUtilisateurs);
            this.pnlContent.Controls.Add(this.btnGestionTypesFrais);
            this.pnlContent.Controls.Add(this.btnExit);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(600, 420);
            this.pnlContent.TabIndex = 1;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sélectionnez une action:";

            // btnGestionUtilisateurs
            this.btnGestionUtilisateurs.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnGestionUtilisateurs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGestionUtilisateurs.ForeColor = System.Drawing.Color.White;
            this.btnGestionUtilisateurs.Height = 80;
            this.btnGestionUtilisateurs.Location = new System.Drawing.Point(50, 80);
            this.btnGestionUtilisateurs.Name = "btnGestionUtilisateurs";
            this.btnGestionUtilisateurs.Size = new System.Drawing.Size(200, 80);
            this.btnGestionUtilisateurs.TabIndex = 1;
            this.btnGestionUtilisateurs.Text = "Gestion des\nUtilisateurs";
            this.btnGestionUtilisateurs.UseVisualStyleBackColor = false;
            this.btnGestionUtilisateurs.Click += new System.EventHandler(this.BtnGestionUtilisateurs_Click);

            // btnGestionTypesFrais
            this.btnGestionTypesFrais.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnGestionTypesFrais.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGestionTypesFrais.ForeColor = System.Drawing.Color.White;
            this.btnGestionTypesFrais.Height = 80;
            this.btnGestionTypesFrais.Location = new System.Drawing.Point(350, 80);
            this.btnGestionTypesFrais.Name = "btnGestionTypesFrais";
            this.btnGestionTypesFrais.Size = new System.Drawing.Size(200, 80);
            this.btnGestionTypesFrais.TabIndex = 2;
            this.btnGestionTypesFrais.Text = "Gestion des\nTypes de Frais";
            this.btnGestionTypesFrais.UseVisualStyleBackColor = false;
            this.btnGestionTypesFrais.Click += new System.EventHandler(this.BtnGestionTypesFrais_Click);

            // btnExit
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(200, 250);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Retour à la connexion";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);

            // FrmMenuAdmin
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmMenuAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSB Frais - Menu Admin";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnGestionUtilisateurs;
        private System.Windows.Forms.Button btnGestionTypesFrais;
        private System.Windows.Forms.Button btnExit;
    }
}
