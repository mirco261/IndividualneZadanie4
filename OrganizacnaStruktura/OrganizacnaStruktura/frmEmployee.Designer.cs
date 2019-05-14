namespace OrganizacnaStruktura
{
    partial class frmEmployee
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
            this.lblNameOfFrm = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txbTitle = new System.Windows.Forms.TextBox();
            this.txbFirstName = new System.Windows.Forms.TextBox();
            this.txbLastName = new System.Windows.Forms.TextBox();
            this.txbTelephone = new System.Windows.Forms.TextBox();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.btnSaveExist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNameOfFrm
            // 
            this.lblNameOfFrm.AutoSize = true;
            this.lblNameOfFrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNameOfFrm.Location = new System.Drawing.Point(12, 9);
            this.lblNameOfFrm.Name = "lblNameOfFrm";
            this.lblNameOfFrm.Size = new System.Drawing.Size(123, 20);
            this.lblNameOfFrm.TabIndex = 1;
            this.lblNameOfFrm.Text = "lblNameOfFrm";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(13, 48);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Titul";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(13, 74);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(66, 13);
            this.lblFirstName.TabIndex = 4;
            this.lblFirstName.Text = "Krstné meno";
            // 
            // txbTitle
            // 
            this.txbTitle.Location = new System.Drawing.Point(138, 45);
            this.txbTitle.MaxLength = 10;
            this.txbTitle.Name = "txbTitle";
            this.txbTitle.Size = new System.Drawing.Size(149, 20);
            this.txbTitle.TabIndex = 6;
            // 
            // txbFirstName
            // 
            this.txbFirstName.Location = new System.Drawing.Point(138, 71);
            this.txbFirstName.MaxLength = 50;
            this.txbFirstName.Name = "txbFirstName";
            this.txbFirstName.Size = new System.Drawing.Size(149, 20);
            this.txbFirstName.TabIndex = 7;
            // 
            // txbLastName
            // 
            this.txbLastName.Location = new System.Drawing.Point(138, 97);
            this.txbLastName.MaxLength = 50;
            this.txbLastName.Name = "txbLastName";
            this.txbLastName.Size = new System.Drawing.Size(149, 20);
            this.txbLastName.TabIndex = 8;
            // 
            // txbTelephone
            // 
            this.txbTelephone.Location = new System.Drawing.Point(138, 123);
            this.txbTelephone.MaxLength = 50;
            this.txbTelephone.Name = "txbTelephone";
            this.txbTelephone.Size = new System.Drawing.Size(149, 20);
            this.txbTelephone.TabIndex = 9;
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(138, 149);
            this.txbEmail.MaxLength = 255;
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(149, 20);
            this.txbEmail.TabIndex = 10;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(138, 175);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(149, 21);
            this.cmbDepartment.TabIndex = 14;
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Location = new System.Drawing.Point(12, 202);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(275, 26);
            this.btnSaveNew.TabIndex = 15;
            this.btnSaveNew.Text = "Uložiť nového zamestnanca";
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(13, 100);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(55, 13);
            this.lblSurname.TabIndex = 16;
            this.lblSurname.Text = "Priezvisko";
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(13, 126);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(81, 13);
            this.lblTelephone.TabIndex = 17;
            this.lblTelephone.Text = "Klapka/Telefón";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(13, 152);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(13, 178);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(55, 13);
            this.lblDepartment.TabIndex = 19;
            this.lblDepartment.Text = "Oddelenie";
            // 
            // btnSaveExist
            // 
            this.btnSaveExist.Location = new System.Drawing.Point(12, 202);
            this.btnSaveExist.Name = "btnSaveExist";
            this.btnSaveExist.Size = new System.Drawing.Size(275, 26);
            this.btnSaveExist.TabIndex = 20;
            this.btnSaveExist.Text = "Uložiť nové údaje zamestnanca";
            this.btnSaveExist.UseVisualStyleBackColor = true;
            this.btnSaveExist.Click += new System.EventHandler(this.btnSaveExist_Click);
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 233);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTelephone);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.txbEmail);
            this.Controls.Add(this.txbTelephone);
            this.Controls.Add(this.txbLastName);
            this.Controls.Add(this.txbFirstName);
            this.Controls.Add(this.txbTitle);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNameOfFrm);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.btnSaveExist);
            this.MaximumSize = new System.Drawing.Size(323, 272);
            this.MinimumSize = new System.Drawing.Size(323, 272);
            this.Name = "frmEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmEmployee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNameOfFrm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txbTitle;
        private System.Windows.Forms.TextBox txbFirstName;
        private System.Windows.Forms.TextBox txbLastName;
        private System.Windows.Forms.TextBox txbTelephone;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Button btnSaveExist;
    }
}