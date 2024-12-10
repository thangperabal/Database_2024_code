using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Data.SqlClient;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;

namespace SNACK_MAN
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            InitializeCombobox();
        }

        public void InitializeCombobox()
        {
            // Setup for combobox
            cbRole.Items.Add("Admin");
            cbRole.Items.Add("Warehouse Manager");
            cbRole.Items.Add("Sale");
            cbRole.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cbRole.SelectedItem.ToString();

            if (ValidateData(username, password, role))  
            {
                SqlConnection connection = DatabaseConnection.GetConnection();
                if (connection != null)
                {
                    string query = "SELECT EmployeeId, PasswordChanged FROM Employee " +
                                   "WHERE Username = @username AND Password = @password " +
                                   "AND AuthorityLevel COLLATE Latin1_General_CI_AS = @role";
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@role", role);

                    SqlDataReader reader = command.ExecuteReader();
                    int employeeId = 0;
                    bool passwordChanged = false;

                    while (reader.Read())
                    {
                        employeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                        passwordChanged = reader.GetBoolean(reader.GetOrdinal("PasswordChanged"));
                    }

                    connection.Close();

                    if (employeeId > 0)
                    {
                        MessageBox.Show("Login success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RedirectPage(role, employeeId, passwordChanged);
                    }
                    else
                    {
                        MessageBox.Show("Invalid login credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearData();
                    }
                }
            }
        }

        private bool ValidateData(string username, string password, string role)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show(
                    "Username cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtUsername.Focus();
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Password cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtPassword.Focus();
            }
            else if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show(
                    "No role selected",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                cbRole.Focus();
            }
            return isValid;
        }

        private void ClearData()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cbRole.SelectedIndex = -1;
            txtUsername.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            cbRole.SelectedIndex = 0;
            txtUsername.Focus();
        }

        private void RedirectPage(string selectedRole, int employeeId, bool isChangePassword)
        {
            if (!isChangePassword)
            {
                ChangePassword changePassword = new ChangePassword(employeeId, selectedRole);
                changePassword.Show();
                this.Hide(); 
            }
            else
            {
                Form newForm = null;

                if (selectedRole == "Admin")
                    newForm = new AdminForm(selectedRole, employeeId);
                else if (selectedRole == "Warehouse Manager")
                    newForm = new WarehouseManagerForm(selectedRole, employeeId);
                else if (selectedRole == "Sale")
                    newForm = new OrderHistory(selectedRole, employeeId);

                if (newForm != null)
                {
                    newForm.Show();
                    this.Hide(); 
                }
            }
        }
    }

}



