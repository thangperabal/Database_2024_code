namespace SNACK_MAN
{
    partial class ManageCustomer
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
            this.gbManageCustomer = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblEmployeeList = new System.Windows.Forms.Label();
            this.dtgCustomer = new System.Windows.Forms.DataGridView();
            this.gbCustomerInformation = new System.Windows.Forms.GroupBox();
            this.lblCustomerAddress = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.txtPhonenumber = new System.Windows.Forms.TextBox();
            this.lblPhonenumber = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.gbManageCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCustomer)).BeginInit();
            this.gbCustomerInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbManageCustomer
            // 
            this.gbManageCustomer.Controls.Add(this.label3);
            this.gbManageCustomer.Controls.Add(this.txtSearch);
            this.gbManageCustomer.Controls.Add(this.lblEmployeeList);
            this.gbManageCustomer.Controls.Add(this.dtgCustomer);
            this.gbManageCustomer.Controls.Add(this.gbCustomerInformation);
            this.gbManageCustomer.Location = new System.Drawing.Point(41, 44);
            this.gbManageCustomer.Name = "gbManageCustomer";
            this.gbManageCustomer.Size = new System.Drawing.Size(718, 362);
            this.gbManageCustomer.TabIndex = 3;
            this.gbManageCustomer.TabStop = false;
            this.gbManageCustomer.Text = "CustomerManager ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(569, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // lblEmployeeList
            // 
            this.lblEmployeeList.AutoSize = true;
            this.lblEmployeeList.Location = new System.Drawing.Point(406, 26);
            this.lblEmployeeList.Name = "lblEmployeeList";
            this.lblEmployeeList.Size = new System.Drawing.Size(66, 13);
            this.lblEmployeeList.TabIndex = 15;
            this.lblEmployeeList.Text = "Customer list";
            // 
            // dtgCustomer
            // 
            this.dtgCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCustomer.Location = new System.Drawing.Point(395, 45);
            this.dtgCustomer.Name = "dtgCustomer";
            this.dtgCustomer.Size = new System.Drawing.Size(276, 298);
            this.dtgCustomer.TabIndex = 1;
            this.dtgCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCustomer_CellClick);
            this.dtgCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCustomer_CellDoubleClick);
            // 
            // gbCustomerInformation
            // 
            this.gbCustomerInformation.Controls.Add(this.lblCustomerAddress);
            this.gbCustomerInformation.Controls.Add(this.txtCustomerAddress);
            this.gbCustomerInformation.Controls.Add(this.txtPhonenumber);
            this.gbCustomerInformation.Controls.Add(this.lblPhonenumber);
            this.gbCustomerInformation.Controls.Add(this.btnClear);
            this.gbCustomerInformation.Controls.Add(this.btnDelete);
            this.gbCustomerInformation.Controls.Add(this.btnUpdate);
            this.gbCustomerInformation.Controls.Add(this.btnAdd);
            this.gbCustomerInformation.Controls.Add(this.txtCustomerName);
            this.gbCustomerInformation.Controls.Add(this.txtCustomerCode);
            this.gbCustomerInformation.Controls.Add(this.lblCustomerName);
            this.gbCustomerInformation.Controls.Add(this.lblCustomerCode);
            this.gbCustomerInformation.Location = new System.Drawing.Point(6, 38);
            this.gbCustomerInformation.Name = "gbCustomerInformation";
            this.gbCustomerInformation.Size = new System.Drawing.Size(332, 287);
            this.gbCustomerInformation.TabIndex = 0;
            this.gbCustomerInformation.TabStop = false;
            this.gbCustomerInformation.Text = "Customer Information";
            // 
            // lblCustomerAddress
            // 
            this.lblCustomerAddress.AutoSize = true;
            this.lblCustomerAddress.Location = new System.Drawing.Point(32, 136);
            this.lblCustomerAddress.Name = "lblCustomerAddress";
            this.lblCustomerAddress.Size = new System.Drawing.Size(42, 13);
            this.lblCustomerAddress.TabIndex = 18;
            this.lblCustomerAddress.Text = "Addess";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Location = new System.Drawing.Point(113, 136);
            this.txtCustomerAddress.Multiline = true;
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(178, 79);
            this.txtCustomerAddress.TabIndex = 17;
            // 
            // txtPhonenumber
            // 
            this.txtPhonenumber.Location = new System.Drawing.Point(111, 91);
            this.txtPhonenumber.Name = "txtPhonenumber";
            this.txtPhonenumber.Size = new System.Drawing.Size(178, 20);
            this.txtPhonenumber.TabIndex = 16;
            // 
            // lblPhonenumber
            // 
            this.lblPhonenumber.AutoSize = true;
            this.lblPhonenumber.Location = new System.Drawing.Point(32, 91);
            this.lblPhonenumber.Name = "lblPhonenumber";
            this.lblPhonenumber.Size = new System.Drawing.Size(73, 13);
            this.lblPhonenumber.TabIndex = 15;
            this.lblPhonenumber.Text = "Phonenumber";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(251, 221);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(170, 221);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(91, 221);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 221);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(113, 61);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(178, 20);
            this.txtCustomerName.TabIndex = 7;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(113, 33);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(178, 20);
            this.txtCustomerCode.TabIndex = 6;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(32, 61);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(82, 13);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Location = new System.Drawing.Point(32, 33);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(79, 13);
            this.lblCustomerCode.TabIndex = 0;
            this.lblCustomerCode.Text = "Customer Code";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(23, 412);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ManageCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gbManageCustomer);
            this.Name = "ManageCustomer";
            this.Text = "ManageCustomer";
            this.Load += new System.EventHandler(this.ManageCustomer_Load);
            this.gbManageCustomer.ResumeLayout(false);
            this.gbManageCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCustomer)).EndInit();
            this.gbCustomerInformation.ResumeLayout(false);
            this.gbCustomerInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbManageCustomer;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblEmployeeList;
        private System.Windows.Forms.DataGridView dtgCustomer;
        private System.Windows.Forms.GroupBox gbCustomerInformation;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.Label lblCustomerAddress;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.TextBox txtPhonenumber;
        private System.Windows.Forms.Label lblPhonenumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
    }
}