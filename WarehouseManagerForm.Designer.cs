namespace SNACK_MAN
{
    partial class WarehouseManagerForm
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
            this.gbWarehouseManagerFeature = new System.Windows.Forms.GroupBox();
            this.btnManageProduct = new System.Windows.Forms.Button();
            this.gbWarehouseManagerFeature.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbWarehouseManagerFeature
            // 
            this.gbWarehouseManagerFeature.Controls.Add(this.btnManageProduct);
            this.gbWarehouseManagerFeature.Location = new System.Drawing.Point(46, 46);
            this.gbWarehouseManagerFeature.Name = "gbWarehouseManagerFeature";
            this.gbWarehouseManagerFeature.Size = new System.Drawing.Size(488, 313);
            this.gbWarehouseManagerFeature.TabIndex = 0;
            this.gbWarehouseManagerFeature.TabStop = false;
            this.gbWarehouseManagerFeature.Text = "Warehouse manager feature";
            // 
            // btnManageProduct
            // 
            this.btnManageProduct.Location = new System.Drawing.Point(45, 48);
            this.btnManageProduct.Name = "btnManageProduct";
            this.btnManageProduct.Size = new System.Drawing.Size(157, 23);
            this.btnManageProduct.TabIndex = 0;
            this.btnManageProduct.Text = "Manage Product";
            this.btnManageProduct.UseVisualStyleBackColor = true;
            this.btnManageProduct.Click += new System.EventHandler(this.btnManageProduct_Click);
            // 
            // WarehouseManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbWarehouseManagerFeature);
            this.Name = "WarehouseManagerForm";
            this.Text = "WarehouseManagerForm";
            this.gbWarehouseManagerFeature.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbWarehouseManagerFeature;
        private System.Windows.Forms.Button btnManageProduct;
    }
}