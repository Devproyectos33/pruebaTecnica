namespace pruebatecnica
{
	partial class frmLogin
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::pruebatecnica.SplashScreen1), true, true, true);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
			this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.txtUserName = new DevExpress.XtraEditors.TextEdit();
			this.txtPassword = new DevExpress.XtraEditors.TextEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.bttnOK = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.txtPasswordConfirmar = new DevExpress.XtraEditors.TextEdit();
			this.simpleButtonRegistrame = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordConfirmar.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// splashScreenManager1
			// 
			splashScreenManager1.ClosingDelay = 1000;
			// 
			// pictureEdit1
			// 
			this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
			this.pictureEdit1.Location = new System.Drawing.Point(23, 82);
			this.pictureEdit1.Name = "pictureEdit1";
			this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.pictureEdit1.Size = new System.Drawing.Size(197, 97);
			this.pictureEdit1.TabIndex = 0;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.BackColor = System.Drawing.Color.Silver;
			this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
			this.labelControl1.Appearance.Options.UseBackColor = true;
			this.labelControl1.Appearance.Options.UseFont = true;
			this.labelControl1.Appearance.Options.UseTextOptions = true;
			this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.labelControl1.Location = new System.Drawing.Point(0, 338);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(500, 13);
			this.labelControl1.TabIndex = 9;
			this.labelControl1.Text = "Bienvendios";
			this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl2.Appearance.Options.UseFont = true;
			this.labelControl2.Location = new System.Drawing.Point(270, 41);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(38, 13);
			this.labelControl2.TabIndex = 1;
			this.labelControl2.Text = "Correo:";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(270, 60);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(174, 20);
			this.txtUserName.TabIndex = 2;
			this.txtUserName.EditValueChanged += new System.EventHandler(this.txtUserName_EditValueChanged);
			// 
			// txtPassword
			// 
			this.txtPassword.EditValue = "";
			this.txtPassword.Location = new System.Drawing.Point(270, 105);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Properties.PasswordChar = '*';
			this.txtPassword.Properties.UseSystemPasswordChar = true;
			this.txtPassword.Size = new System.Drawing.Size(174, 20);
			this.txtPassword.TabIndex = 4;
			this.txtPassword.EditValueChanged += new System.EventHandler(this.textEdit2_EditValueChanged);
			// 
			// labelControl3
			// 
			this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl3.Appearance.Options.UseFont = true;
			this.labelControl3.Location = new System.Drawing.Point(270, 86);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(60, 13);
			this.labelControl3.TabIndex = 3;
			this.labelControl3.Text = "Contraseña:";
			this.labelControl3.Click += new System.EventHandler(this.labelControl3_Click);
			// 
			// bttnOK
			// 
			this.bttnOK.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bttnOK.Appearance.Options.UseFont = true;
			this.bttnOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bttnOK.ImageOptions.Image")));
			this.bttnOK.Location = new System.Drawing.Point(309, 190);
			this.bttnOK.Name = "bttnOK";
			this.bttnOK.Size = new System.Drawing.Size(88, 32);
			this.bttnOK.TabIndex = 7;
			this.bttnOK.Text = "Ingresar";
			this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
			// 
			// labelControl4
			// 
			this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl4.Appearance.Options.UseFont = true;
			this.labelControl4.Location = new System.Drawing.Point(270, 131);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(114, 13);
			this.labelControl4.TabIndex = 5;
			this.labelControl4.Text = "Confirmar Contraseña:";
			this.labelControl4.Click += new System.EventHandler(this.labelControl4_Click);
			// 
			// txtPasswordConfirmar
			// 
			this.txtPasswordConfirmar.EditValue = "";
			this.txtPasswordConfirmar.Location = new System.Drawing.Point(270, 150);
			this.txtPasswordConfirmar.Name = "txtPasswordConfirmar";
			this.txtPasswordConfirmar.Properties.PasswordChar = '*';
			this.txtPasswordConfirmar.Properties.UseSystemPasswordChar = true;
			this.txtPasswordConfirmar.Size = new System.Drawing.Size(174, 20);
			this.txtPasswordConfirmar.TabIndex = 6;
			// 
			// simpleButtonRegistrame
			// 
			this.simpleButtonRegistrame.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.simpleButtonRegistrame.Appearance.Options.UseFont = true;
			this.simpleButtonRegistrame.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonRegistrame.ImageOptions.Image")));
			this.simpleButtonRegistrame.Location = new System.Drawing.Point(53, 264);
			this.simpleButtonRegistrame.Name = "simpleButtonRegistrame";
			this.simpleButtonRegistrame.Size = new System.Drawing.Size(105, 32);
			this.simpleButtonRegistrame.TabIndex = 10;
			this.simpleButtonRegistrame.Text = "Registrarme";
			this.simpleButtonRegistrame.Click += new System.EventHandler(this.simpleButtonRegistrame_Click);
			// 
			// frmLogin
			// 
			this.AcceptButton = this.bttnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 351);
			this.Controls.Add(this.simpleButtonRegistrame);
			this.Controls.Add(this.txtPasswordConfirmar);
			this.Controls.Add(this.labelControl4);
			this.Controls.Add(this.bttnOK);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.pictureEdit1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmLogin.IconOptions.Image")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Stone ERP";
			this.Load += new System.EventHandler(this.frmLogin_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPasswordConfirmar.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.PictureEdit pictureEdit1;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.TextEdit txtUserName;
		private DevExpress.XtraEditors.TextEdit txtPassword;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.SimpleButton bttnOK;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.TextEdit txtPasswordConfirmar;
		private DevExpress.XtraEditors.SimpleButton simpleButtonRegistrame;
	}
}