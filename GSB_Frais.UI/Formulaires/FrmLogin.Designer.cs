namespace GSB_Frais.UI.Formulaires
{
    partial class FrmLogin
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlForm = new System.Windows.Forms.Panel();
            
            // Title
            this.lblTitle = new System.Windows.Forms.Label();
            
            // Login Section
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            
            // Password Section
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            
            // Remember Me
            this.chkRememberMe = new System.Windows.Forms.CheckBox();
            
            // Buttons
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            
            // Status Label
            this.lblStatus = new System.Windows.Forms.Label();
            
            this.pnlMain.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.pnlMain.Controls.Add(this.pnlForm);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(400, 500);
            this.pnlMain.TabIndex = 0;

            // pnlForm
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Controls.Add(this.lblLogin);
            this.pnlForm.Controls.Add(this.txtLogin);
            this.pnlForm.Controls.Add(this.lblPassword);
            this.pnlForm.Controls.Add(this.txtPassword);
            this.pnlForm.Controls.Add(this.chkRememberMe);
            this.pnlForm.Controls.Add(this.btnLogin);
            this.pnlForm.Controls.Add(this.btnExit);
            this.pnlForm.Controls.Add(this.lblStatus);
            this.pnlForm.Location = new System.Drawing.Point(30, 60);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(340, 380);
            this.pnlForm.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "GSB Frais";

            // lblLogin
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblLogin.Location = new System.Drawing.Point(30, 80);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(45, 19);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login:";

            // txtLogin
            this.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLogin.Location = new System.Drawing.Point(30, 105);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(280, 25);
            this.txtLogin.TabIndex = 0;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblPassword.Location = new System.Drawing.Point(30, 145);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(94, 19);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Mot de passe:";

            // txtPassword
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(30, 170);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(280, 25);
            this.txtPassword.TabIndex = 1;

            // chkRememberMe
            this.chkRememberMe.AutoSize = true;
            this.chkRememberMe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRememberMe.Location = new System.Drawing.Point(30, 210);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Size = new System.Drawing.Size(145, 19);
            this.chkRememberMe.TabIndex = 2;
            this.chkRememberMe.Text = "Se souvenir de moi";
            this.chkRememberMe.UseVisualStyleBackColor = true;

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(30, 260);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(130, 40);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Connexion";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);

            // btnExit
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(180, 260);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Quitter";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblStatus.Location = new System.Drawing.Point(30, 330);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 5;

            // FrmLogin
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GSB Frais - Connexion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);

            this.pnlMain.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblStatus;
    }
}
