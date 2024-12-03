namespace SNACK_MAN
{
    partial class ManageEmployee
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
            this.gbEmployeeInformation = new System.Windows.Forms.GroupBox();
            this.cbAuthorityLevel = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmployeePosition = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblAuthorityLevel = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblEmployeeCode = new System.Windows.Forms.Label();
            this.dtgEmployee = new System.Windows.Forms.DataGridView();
            this.gbManageEmployee = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblEmployeeList = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.gbEmployeeInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmployee)).BeginInit();
            this.gbManageEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEmployeeInformation
            // 
            this.gbEmployeeInformation.Controls.Add(this.cbAuthorityLevel);
            this.gbEmployeeInformation.Controls.Add(this.btnClear);
            this.gbEmployeeInformation.Controls.Add(this.btnDelete);
            this.gbEmployeeInformation.Controls.Add(this.btnUpdate);
            this.gbEmployeeInformation.Controls.Add(this.btnAdd);
            this.gbEmployeeInformation.Controls.Add(this.txtPassword);
            this.gbEmployeeInformation.Controls.Add(this.txtUsername);
            this.gbEmployeeInformation.Controls.Add(this.txtEmployeePosition);
            this.gbEmployeeInformation.Controls.Add(this.txtEmployeeName);
            this.gbEmployeeInformation.Controls.Add(this.txtEmployeeCode);
            this.gbEmployeeInformation.Controls.Add(this.lblPassword);
            this.gbEmployeeInformation.Controls.Add(this.lblUsername);
            this.gbEmployeeInformation.Controls.Add(this.lblAuthorityLevel);
            this.gbEmployeeInformation.Controls.Add(this.lblPosition);
            this.gbEmployeeInformation.Controls.Add(this.lblEmployeeName);
            this.gbEmployeeInformation.Controls.Add(this.lblEmployeeCode);
            this.gbEmployeeInformation.Location = new System.Drawing.Point(38, 38);
            this.gbEmployeeInformation.Name = "gbEmployeeInformation";
            this.gbEmployeeInformation.Size = new System.Drawing.Size(329, 287);
            this.gbEmployeeInformation.TabIndex = 0;
            this.gbEmployeeInformation.TabStop = false;
            this.gbEmployeeInformation.Text = "Employee Information";
            // 
            // cbAuthorityLevel
            // 
            this.cbAuthorityLevel.FormattingEnabled = true;
            this.cbAuthorityLevel.Location = new System.Drawing.Point(113, 125);
            this.cbAuthorityLevel.Name = "cbAuthorityLevel";
            this.cbAuthorityLevel.Size = new System.Drawing.Size(121, 21);
            this.cbAuthorityLevel.TabIndex = 15;
            this.cbAuthorityLevel.SelectedIndexChanged += new System.EventHandler(this.cbAuthorityLevel_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(147, 259);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(44, 259);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(147, 228);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(44, 228);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 188);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 11;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(113, 156);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(121, 20);
            this.txtUsername.TabIndex = 10;
            // 
            // txtEmployeePosition
            // 
            this.txtEmployeePosition.Location = new System.Drawing.Point(113, 91);
            this.txtEmployeePosition.Name = "txtEmployeePosition";
            this.txtEmployeePosition.Size = new System.Drawing.Size(121, 20);
            this.txtEmployeePosition.TabIndex = 8;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(113, 61);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(121, 20);
            this.txtEmployeeName.TabIndex = 7;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(113, 33);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(121, 20);
            this.txtEmployeeCode.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(32, 188);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(32, 156);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username";
            // 
            // lblAuthorityLevel
            // 
            this.lblAuthorityLevel.AutoSize = true;
            this.lblAuthorityLevel.Location = new System.Drawing.Point(32, 125);
            this.lblAuthorityLevel.Name = "lblAuthorityLevel";
            this.lblAuthorityLevel.Size = new System.Drawing.Size(29, 13);
            this.lblAuthorityLevel.TabIndex = 3;
            this.lblAuthorityLevel.Text = "Role";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(32, 91);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(44, 13);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "Position";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(32, 61);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(51, 13);
            this.lblEmployeeName.TabIndex = 1;
            this.lblEmployeeName.Text = "FullName";
            // 
            // lblEmployeeCode
            // 
            this.lblEmployeeCode.AutoSize = true;
            this.lblEmployeeCode.Location = new System.Drawing.Point(32, 33);
            this.lblEmployeeCode.Name = "lblEmployeeCode";
            this.lblEmployeeCode.Size = new System.Drawing.Size(32, 13);
            this.lblEmployeeCode.TabIndex = 0;
            this.lblEmployeeCode.Text = "Code";
            // 
            // dtgEmployee
            // 
            this.dtgEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEmployee.Location = new System.Drawing.Point(395, 45);
            this.dtgEmployee.Name = "dtgEmployee";
            this.dtgEmployee.Size = new System.Drawing.Size(430, 298);
            this.dtgEmployee.TabIndex = 1;
            this.dtgEmployee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEmployee_CellClick);
            // 
            // gbManageEmployee
            // 
            this.gbManageEmployee.Controls.Add(this.txtSearch);
            this.gbManageEmployee.Controls.Add(this.lblEmployeeList);
            this.gbManageEmployee.Controls.Add(this.dtgEmployee);
            this.gbManageEmployee.Controls.Add(this.gbEmployeeInformation);
            this.gbManageEmployee.Location = new System.Drawing.Point(32, 27);
            this.gbManageEmployee.Name = "gbManageEmployee";
            this.gbManageEmployee.Size = new System.Drawing.Size(847, 362);
            this.gbManageEmployee.TabIndex = 2;
            this.gbManageEmployee.TabStop = false;
            this.gbManageEmployee.Text = "Manage Employee";
            this.gbManageEmployee.Enter += new System.EventHandler(this.gbManageEmployee_Enter);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(480, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // lblEmployeeList
            // 
            this.lblEmployeeList.AutoSize = true;
            this.lblEmployeeList.Location = new System.Drawing.Point(406, 26);
            this.lblEmployeeList.Name = "lblEmployeeList";
            this.lblEmployeeList.Size = new System.Drawing.Size(68, 13);
            this.lblEmployeeList.TabIndex = 15;
            this.lblEmployeeList.Text = "Employee list";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(32, 395);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ManageEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 431);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gbManageEmployee);
            this.Name = "ManageEmployee";
            this.Text = "ManageEmployee";
            this.Load += new System.EventHandler(this.ManageEmployee_Load);
            this.gbEmployeeInformation.ResumeLayout(false);
            this.gbEmployeeInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmployee)).EndInit();
            this.gbManageEmployee.ResumeLayout(false);
            this.gbManageEmployee.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEmployeeInformation;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmployeePosition;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblAuthorityLevel;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblEmployeeCode;
        private System.Windows.Forms.DataGridView dtgEmployee;
        private System.Windows.Forms.GroupBox gbManageEmployee;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblEmployeeList;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cbAuthorityLevel;
    }
}