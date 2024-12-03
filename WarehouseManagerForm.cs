using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNACK_MAN
{


public partial class WarehouseManagerForm : Form
    {
        int employeeId;
        string authorityLevel;
        public WarehouseManagerForm(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            // Khởi tạo form ManageProduct với authorityLevel và userId
            ManageProduct manageProduct = new ManageProduct(this.authorityLevel, this.employeeId);

            // Khi form ManageProduct đóng, hiển thị lại AdminForm
            manageProduct.FormClosed += (s, args) =>
            {
                this.Show(); // Hiển thị lại AdminForm
            };

            // Ẩn form AdminForm khi mở ManageProduct
            this.Hide();

            // Hiển thị form ManageProduct
            manageProduct.Show();
        }
    }
}