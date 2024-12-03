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
    public partial class SaleForm : Form
    {
        private int employeeId;
        private string authorityLevel;

        // Constructor nhận tham số authorityLevel và employeeId
        public SaleForm(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {
            // Khởi tạo form OrderHistory và truyền giá trị authorityLevel, employeeId
            OrderHistory orderHistory = new OrderHistory(this.authorityLevel, this.employeeId);

            // Ẩn form hiện tại và hiển thị form OrderHistory
            this.Hide();
            orderHistory.Show();
        }

        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            ManageCustomer manageCustomer = new ManageCustomer(authorityLevel, employeeId);
            this.Hide();
            manageCustomer.Show();
        }
    }
}
