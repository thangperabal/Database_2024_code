//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Microsoft.Data.SqlClient;
//using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
//using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;

//namespace SNACK_MAN
//{
//    public partial class ChangePassword : Form
//    {
//        // role variable is used to redirect page after password changed
//        string role;
//        // employeeId variable is used to passed to other forms which need EmployeeID to
//        // manipulate data in tables (Like Order need EmployeeID when inserted)
//        int employeeId;
//        public ChangePassword(int employeeId, string role)
//        {
//            // Assign data to the above variable when form is initialized
//            this.employeeId = employeeId;
//            this.role = role;
//            InitializeComponent();
//        }

//        private void btnClear_Click(object sender, EventArgs e)
//        {
//            ClearData();
//        }
//        private void ClearData()
//        {
//            txtNewPassword.Text = string.Empty;
//            txtConfirmPassword.Text = string.Empty;
//            txtNewPassword.Focus();
//        }
//        private void RedirectPage(int employeeId, string authorityLevel)
//        {
//            if (authorityLevel == "Admin")
//            {
//                AdminForm adminForm = new AdminForm(authorityLevel, employeeId);
//                this.Hide();
//                adminForm.Show();
//            }
//            else if (authorityLevel == "Warehouse Manager")
//            {
//                WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(authorityLevel, employeeId);
//                this.Hide();
//                warehouseManagerForm.Show();
//            }
//            else if (authorityLevel == "Sale")
//            {
//                OrderHistory saleForm = new OrderHistory(authorityLevel, employeeId);
//                this.Hide();
//                saleForm.Show();
//            }
//        }
//        private void UpdateEmployee(int employeeId, string newPassword)
//        {
//            SqlConnection connection = DatabaseConnection.GetConnection();
//            if (connection != null)
//            {
//                connection.Open();
//                string sql = "UPDATE Employee SET Password = @newPassword, " +
//                        "PasswordChanged = 1 " +
//                        "WHERE EmployeeID = @employeeId";
//                SqlCommand command = new SqlCommand(sql, connection);
//                command.Parameters.AddWithValue("newPassword", newPassword);
//                command.Parameters.AddWithValue("employeeId", employeeId);
//                int isChanged = command.ExecuteNonQuery();
//                if (isChanged > 0)
//                {
//                    MessageBox.Show(
//                            "Successfully change password",
//                            "Information",
//                            MessageBoxButtons.OK,
//                            MessageBoxIcon.Information);
//                    RedirectPage(employeeId, role);
//                }
//                else
//                {
//                    MessageBox.Show(
//                            "An error occur while change password",
//                            "Error",
//                            MessageBoxButtons.OK,
//                            MessageBoxIcon.Error);
//                    ClearData();
//                }
//                connection.Close();
//            }
//        }
//        private bool ValidateData(string newPassword, string confirmPassword)
//        {
//            bool isValid = true;
//            if (string.IsNullOrEmpty(newPassword))
//            {
//                MessageBox.Show(
//                        "New password cannot be blank",
//                        "Error",
//                        MessageBoxButtons.OK,
//                        MessageBoxIcon.Error);
//                txtNewPassword.Focus();
//                isValid = false;
//            }
//            else if (string.IsNullOrEmpty(confirmPassword))
//            {
//                MessageBox.Show(
//                "Confirm password cannot be blank",
//                "Error",
//                MessageBoxButtons.OK,
//                MessageBoxIcon.Error);
//                txtConfirmPassword.Focus();
//                isValid = false;
//            }
//            else if (newPassword != confirmPassword)
//            {

//                MessageBox.Show(
//                "New & confirm passwords are not similar",
//                "Error",
//                MessageBoxButtons.OK,
//                MessageBoxIcon.Error);
//                ClearData();
//                isValid = false;
//            }
//            return isValid;            
//        }

//        private void btnChange_Click(object sender, EventArgs e)
//        {
//            string newPassword = txtNewPassword.Text;
//            string confirmPassword = txtConfirmPassword.Text;
//            bool isValid = ValidateData(newPassword, confirmPassword);
//            if (isValid)
//            {
//                UpdateEmployee(employeeId, newPassword);
//            }
//        }
//    }
//}


using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SNACK_MAN
{
    public partial class ChangePassword : Form
    {
        string role;
        int employeeId;

        public ChangePassword(int employeeId, string role)
        {
            this.employeeId = employeeId;
            this.role = role;
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            txtNewPassword.Focus();
        }

        private void RedirectPage(int employeeId, string authorityLevel)
        {
            if (authorityLevel == "Admin")
            {
                AdminForm adminForm = new AdminForm(authorityLevel, employeeId);
                this.Hide();
                adminForm.Show();
            }
            else if (authorityLevel == "Warehouse Manager")
            {
                WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(authorityLevel, employeeId);
                this.Hide();
                warehouseManagerForm.Show();
            }
            else if (authorityLevel == "Sale")
            {
                OrderHistory saleForm = new OrderHistory(authorityLevel, employeeId);
                this.Hide();
                saleForm.Show();
            }
            else
            {
                MessageBox.Show("Unknown role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateEmployee(int employeeId, string newPassword)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE Employee SET Password = @newPassword, " +
                             "PasswordChanged = 1 " +
                             "WHERE EmployeeID = @employeeId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@newPassword", newPassword);
                command.Parameters.AddWithValue("@employeeId", employeeId);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RedirectPage(employeeId, role);
                }
                else
                {
                    MessageBox.Show("Error occurred while changing password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearData();
                }
                connection.Close();
            }
        }

        private bool ValidateData(string newPassword, string confirmPassword)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("New password cannot be blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPassword.Focus();
                isValid = false;
            }
            else if (string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Confirm password cannot be blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Focus();
                isValid = false;
            }
            else if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearData();
                isValid = false;
            }

            return isValid;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            bool isValid = ValidateData(newPassword, confirmPassword);
            if (isValid)
            {
                UpdateEmployee(employeeId, newPassword);
            }
        }
    }
}
