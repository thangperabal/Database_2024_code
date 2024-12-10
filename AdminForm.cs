using SNACK_MAN;
using System;
using System.Collections.Generic;
using System. ComponentModel;
using System.Data;
using System.Drawing;
using System. Linq;
using System. Text;
using System. Threading. Tasks;
using System.Windows.Forms;

namespace SNACK_MAN
{
    public partial class AdminForm : Form
    {
        string employeePosition;
        private readonly string authorityLevel;
        int employeeId;
        private object manageProduct;
        private int userId;

        public AdminForm(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
            this.employeePosition = authorityLevel; // Gán đúng giá trị
            this.FormClosing += AdminForm_FormClosing;
        }

        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            ManageEmployee manageEmployee = new ManageEmployee(employeePosition);

            manageEmployee.FormClosed += (s, args) =>
            {
                this.Show();
            };

            this.Hide();
            manageEmployee.Show();
        }
        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            ManageProduct manageProduct = new ManageProduct(this.authorityLevel, this.userId);

            manageProduct.FormClosed += (s, args) =>
            {
                this.Show(); 
            };
            this.Hide();
            manageProduct.Show();
        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {
            ManageCustomer manageCustomer = new ManageCustomer(authorityLevel, employeeId);
            manageCustomer.FormClosed += (s, args) =>
            {
                this.Show();
            };
            this.Hide();

            manageCustomer.Show();
        }
    }
}

