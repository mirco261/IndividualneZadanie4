namespace OrganizacnaStruktura
{
    partial class frmDepartment
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblHierarchy = new System.Windows.Forms.Label();
            this.lblParentDepartment = new System.Windows.Forms.Label();
            this.txbDepartmentCode = new System.Windows.Forms.TextBox();
            this.txbDepartmentName = new System.Windows.Forms.TextBox();
            this.cmbHierarchy = new System.Windows.Forms.ComboBox();
            this.cmbParentDeparment = new System.Windows.Forms.ComboBox();
            this.lblheadEmployee = new System.Windows.Forms.Label();
            this.cmbHeadEmployee = new System.Windows.Forms.ComboBox();
            this.btnSaveNew = new System.Windows.Forms.Button();
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
            this.lblNameOfFrm.TabIndex = 0;
            this.lblNameOfFrm.Text = "lblNameOfFrm";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 76);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Názov oddelenia";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(13, 48);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(75, 13);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Kód oddelenia";
            // 
            // lblHierarchy
            // 
            this.lblHierarchy.AutoSize = true;
            this.lblHierarchy.Location = new System.Drawing.Point(13, 103);
            this.lblHierarchy.Name = "lblHierarchy";
            this.lblHierarchy.Size = new System.Drawing.Size(42, 13);
            this.lblHierarchy.TabIndex = 3;
            this.lblHierarchy.Text = "Úroveň";
            // 
            // lblParentDepartment
            // 
            this.lblParentDepartment.AutoSize = true;
            this.lblParentDepartment.Location = new System.Drawing.Point(13, 130);
            this.lblParentDepartment.Name = "lblParentDepartment";
            this.lblParentDepartment.Size = new System.Drawing.Size(111, 13);
            this.lblParentDepartment.TabIndex = 4;
            this.lblParentDepartment.Text = "Nadriadené oddelenie";
            // 
            // txbDepartmentCode
            // 
            this.txbDepartmentCode.Location = new System.Drawing.Point(142, 45);
            this.txbDepartmentCode.MaxLength = 10;
            this.txbDepartmentCode.Name = "txbDepartmentCode";
            this.txbDepartmentCode.Size = new System.Drawing.Size(149, 20);
            this.txbDepartmentCode.TabIndex = 5;
            // 
            // txbDepartmentName
            // 
            this.txbDepartmentName.Location = new System.Drawing.Point(142, 73);
            this.txbDepartmentName.Name = "txbDepartmentName";
            this.txbDepartmentName.Size = new System.Drawing.Size(149, 20);
            this.txbDepartmentName.TabIndex = 6;
            // 
            // cmbHierarchy
            // 
            this.cmbHierarchy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHierarchy.FormattingEnabled = true;
            this.cmbHierarchy.Location = new System.Drawing.Point(142, 100);
            this.cmbHierarchy.Name = "cmbHierarchy";
            this.cmbHierarchy.Size = new System.Drawing.Size(149, 21);
            this.cmbHierarchy.TabIndex = 7;
            this.cmbHierarchy.SelectedIndexChanged += new System.EventHandler(this.cmbHierarchy_SelectedIndexChanged);
            // 
            // cmbParentDeparment
            // 
            this.cmbParentDeparment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentDeparment.FormattingEnabled = true;
            this.cmbParentDeparment.Location = new System.Drawing.Point(142, 127);
            this.cmbParentDeparment.Name = "cmbParentDeparment";
            this.cmbParentDeparment.Size = new System.Drawing.Size(149, 21);
            this.cmbParentDeparment.TabIndex = 8;
            // 
            // lblheadEmployee
            // 
            this.lblheadEmployee.AutoSize = true;
            this.lblheadEmployee.Location = new System.Drawing.Point(13, 157);
            this.lblheadEmployee.Name = "lblheadEmployee";
            this.lblheadEmployee.Size = new System.Drawing.Size(106, 13);
            this.lblheadEmployee.TabIndex = 9;
            this.lblheadEmployee.Text = "Vedúci zamestnanec";
            // 
            // cmbHeadEmployee
            // 
            this.cmbHeadEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeadEmployee.FormattingEnabled = true;
            this.cmbHeadEmployee.Location = new System.Drawing.Point(142, 154);
            this.cmbHeadEmployee.Name = "cmbHeadEmployee";
            this.cmbHeadEmployee.Size = new System.Drawing.Size(149, 21);
            this.cmbHeadEmployee.TabIndex = 10;
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Location = new System.Drawing.Point(16, 186);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(275, 26);
            this.btnSaveNew.TabIndex = 11;
            this.btnSaveNew.Text = "Uložiť nové oddelenie";
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // btnSaveExist
            // 
            this.btnSaveExist.Location = new System.Drawing.Point(16, 186);
            this.btnSaveExist.Name = "btnSaveExist";
            this.btnSaveExist.Size = new System.Drawing.Size(275, 26);
            this.btnSaveExist.TabIndex = 12;
            this.btnSaveExist.Text = "Uložiť zmeny oddelenia";
            this.btnSaveExist.UseVisualStyleBackColor = true;
            this.btnSaveExist.Click += new System.EventHandler(this.btnSaveExist_Click);
            // 
            // frmDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 233);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.cmbHeadEmployee);
            this.Controls.Add(this.lblheadEmployee);
            this.Controls.Add(this.cmbParentDeparment);
            this.Controls.Add(this.cmbHierarchy);
            this.Controls.Add(this.txbDepartmentName);
            this.Controls.Add(this.txbDepartmentCode);
            this.Controls.Add(this.lblParentDepartment);
            this.Controls.Add(this.lblHierarchy);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNameOfFrm);
            this.Controls.Add(this.btnSaveExist);
            this.MaximumSize = new System.Drawing.Size(323, 272);
            this.MinimumSize = new System.Drawing.Size(323, 272);
            this.Name = "frmDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDepartment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNameOfFrm;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblHierarchy;
        private System.Windows.Forms.Label lblParentDepartment;
        private System.Windows.Forms.TextBox txbDepartmentCode;
        private System.Windows.Forms.TextBox txbDepartmentName;
        private System.Windows.Forms.ComboBox cmbHierarchy;
        private System.Windows.Forms.ComboBox cmbParentDeparment;
        private System.Windows.Forms.Label lblheadEmployee;
        private System.Windows.Forms.ComboBox cmbHeadEmployee;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Button btnSaveExist;
    }
}