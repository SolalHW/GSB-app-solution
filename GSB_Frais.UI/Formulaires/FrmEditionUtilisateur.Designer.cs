namespace GSB_Frais.UI.Formulaires
{
    partial class FrmEditionUtilisateur
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
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblActif = new System.Windows.Forms.Label();
            
            // TextBoxes
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            
            // ComboBox
            this.cboRole = new System.Windows.Forms.ComboBox();
            
            // Checkbox
            this.chkActif = new System.Windows.Forms.CheckBox();
            
            // Buttons
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.lblNom);
            this.pnlContent.Controls.Add(this.txtNom);
            this.pnlContent.Controls.Add(this.lblPrenom);
            this.pnlContent.Controls.Add(this.txtPrenom);
            this.pnlContent.Controls.Add(this.lblLogin);
            this.pnlContent.Controls.Add(this.txtLogin);
            this.pnlContent.Controls.Add(this.lblPassword);
            this.pnlContent.Controls.Add(this.txtPassword);
            this.pnlContent.Controls.Add(this.lblRole);
            this.pnlContent.Controls.Add(this.cboRole);
            this.pnlContent.Controls.Add(this.lblActif);
            this.pnlContent.Controls.Add(this.chkActif);
            this.pnlContent.Controls.Add(this.btnSave);
            this.pnlContent.Controls.Add(this.btnCancel);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(400, 450);
            this.pnlContent.TabIndex = 0;

            // lblNom
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNom.Location = new System.Drawing.Point(20, 20);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(35, 15);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom:";

            // txtNom
            this.txtNom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNom.Location = new System.Drawing.Point(20, 40);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(360, 23);
            this.txtNom.TabIndex = 0;

            // lblPrenom
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrenom.Location = new System.Drawing.Point(20, 70);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(51, 15);
            this.lblPrenom.TabIndex = 2;
            this.lblPrenom.Text = "Prénom:";

            // txtPrenom
            this.txtPrenom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrenom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrenom.Location = new System.Drawing.Point(20, 90);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(360, 23);
            this.txtPrenom.TabIndex = 1;

            // lblLogin
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLogin.Location = new System.Drawing.Point(20, 120);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(40, 15);
            this.lblLogin.TabIndex = 4;
            this.lblLogin.Text = "Login:";

            // txtLogin
            this.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLogin.Location = new System.Drawing.Point(20, 140);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(360, 23);
            this.txtLogin.TabIndex = 2;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(20, 170);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(85, 15);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Mot de passe:";

            // txtPassword
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Location = new System.Drawing.Point(20, 190);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(360, 23);
            this.txtPassword.TabIndex = 3;

            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRole.Location = new System.Drawing.Point(20, 220);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(34, 15);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Rôle:";

            // cboRole
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange(new object[] { "ADMIN", "COMPTABLE", "VISITEUR" });
            this.cboRole.Location = new System.Drawing.Point(20, 240);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(360, 23);
            this.cboRole.TabIndex = 4;

            // lblActif
            this.lblActif.AutoSize = true;
            this.lblActif.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActif.Location = new System.Drawing.Point(20, 275);
            this.lblActif.Name = "lblActif";
            this.lblActif.Size = new System.Drawing.Size(37, 15);
            this.lblActif.TabIndex = 10;
            this.lblActif.Text = "Actif:";

            // chkActif
            this.chkActif.AutoSize = true;
            this.chkActif.Checked = true;
            this.chkActif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActif.Location = new System.Drawing.Point(20, 295);
            this.chkActif.Name = "chkActif";
            this.chkActif.Size = new System.Drawing.Size(118, 17);
            this.chkActif.TabIndex = 5;
            this.chkActif.Text = "Compte actif";
            this.chkActif.UseVisualStyleBackColor = true;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(140, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(250, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = false;

            // FrmEditionUtilisateur
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditionUtilisateur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edition d'un utilisateur";
            this.Load += new System.EventHandler(this.FrmEditionUtilisateur_Load);

            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblActif;
        private System.Windows.Forms.CheckBox chkActif;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
