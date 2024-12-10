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

    public partial class ManageEmployee : Form
    {
        int employeeId;
        string employeePosition;
        public ManageEmployee(string employeePosition)
        {
            employeeId = 0;
            InitializeComponent();
            this.employeePosition = employeePosition;
        }
        private bool ValidateData(string employeeCode,
                    string employeeName,
                    string employeePosition,
                    string authorityLevel,
                    string username,
                    string password)
        {
            bool isValid = true;
            if (employeeCode == null || employeeCode == string.Empty)
            {
                MessageBox.Show(
                        "Employee Code cannot be blank",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                txtEmployeeCode.Focus();
                isValid = false;
            }
            else if (employeeName == null || employeeName == string.Empty)
            {
                MessageBox.Show(
                        "Employee Name cannot be blank",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                txtEmployeeName.Focus();
                isValid = false;
            }
            else if (employeePosition == null || employeePosition == string.Empty)
            {
                MessageBox.Show(
                        "Employee Position cannot be blank",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                txtEmployeePosition.Focus();
                isValid = false;
            }
            else if (authorityLevel == null || authorityLevel == string.Empty)
            {
                MessageBox.Show(
                        "Employee Code cannot be blank",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                cbAuthorityLevel.Focus();
                isValid = false;

            }

            else if (username == null || username == string.Empty)
            {
                MessageBox.Show(
                        "Username cannot be blank",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                txtUsername.Focus();
                isValid = false;
            }


            else if (password == null || password == string.Empty)
            {

                MessageBox.Show(
                        "Password cannot be blank",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                txtPassword.Focus();
                isValid = false;
            }
            return isValid;
        }
        private void cbAuthorityLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAuthorityLevel.Items.AddRange(new object[] { "Admin", "User", "Manager" });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get user input data
            string employeeCode = txtEmployeeCode.Text;
            string employeeName = txtEmployeeName.Text;
            string employeePosition = txtEmployeePosition.Text;
            string authorityLevel = cbAuthorityLevel.SelectedItem.ToString();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            // Validate data
            bool isValid = ValidateData(employeeCode,
            employeeName,
            employeePosition,
            authorityLevel,
            username,
            password);

            if (isValid)
            {
                AddUser(employeeCode, employeeName, employeePosition, authorityLevel, username, password);
            }
        }
        private bool CheckUserExistence(int employeeId)
        {
            bool isExist = false;
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string checkCustomerQuery = "SELECT * FROM Employee WHERE EmployeeID = @employeeId";
                SqlCommand command = new SqlCommand(checkCustomerQuery, connection);
                command.Parameters.AddWithValue("employeeId", employeeId);
                SqlDataReader reader = command.ExecuteReader();
                isExist = reader.HasRows;
                connection.Close();
            }
            return isExist;
        }
        private void UpdateUser(int employeeId,
                        string employeeCode,
                        string employeeName,
                        string employeePosition,
                        string authorityLevel,
                        string username,
                        string password)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE Employee SET EmployeeCode = @employeeCode, " +
                             "EmployeeName = @employeeName, " +
                             "Position = @employeePosition, " +
                             "AuthorityLevel = @authorityLevel, " +
                             "Username = @username, " +
                             "Password = @password " +
                             "WHERE EmployeeID = @employeeId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("employeeCode", employeeCode);
                command.Parameters.AddWithValue("employeeName", employeeName);
                command.Parameters.AddWithValue("employeePosition", employeePosition);
                command.Parameters.AddWithValue("authorityLevel", authorityLevel);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);
                command.Parameters.AddWithValue("employeeId", employeeId);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {

                    MessageBox.Show(
                        "Successfully update user",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearData();
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show(
                    "Cannot update user",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get user input data
            string employeeCode = txtEmployeeCode.Text;
            string employeeName = txtEmployeeName.Text;
            string employeePosition = txtEmployeePosition.Text;
            string authorityLevel = cbAuthorityLevel.SelectedItem.ToString();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            // Validate data
            bool isValid = ValidateData(employeeCode,
            employeeName,
            employeePosition,
            authorityLevel,
            username,
            password);

            if (isValid)
            {
                UpdateUser(employeeId, employeeCode, employeeName, employeePosition, authorityLevel, username, password);
            }
        }
        private void DeleteUser(int employeeId)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "DELETE Employee WHERE EmployeeID = @employeeId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("employeeId", employeeId);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully delete user",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearData();
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot delete user",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Do you want to delete this user",
            "Warning",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DeleteUser(employeeId);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(employeePosition))
            {
                MessageBox.Show(
                    "Cannot determine user role. Please check the data.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Form nextForm = null;

            foreach (Form form in Application.OpenForms)
            {
                if (form is AdminForm && employeePosition == "Admin")
                {
                    nextForm = form;
                    break;
                }
                else if (form is WarehouseManagerForm && employeePosition == "Warehouse Manager")
                {
                    nextForm = form;
                    break;
                }
                else if (form is OrderHistory && employeePosition == "Sale")
                {
                    nextForm = form;
                    break;
                }
            }

            if (nextForm == null)
            {
                switch (employeePosition)
                {
                    case "Admin":
                        nextForm = new AdminForm(employeePosition, employeeId);
                        break;
                    case "Warehouse Manager":
                        nextForm = new WarehouseManagerForm(employeePosition, employeeId);
                        break;
                    case "Sale":
                        nextForm = new OrderHistory(employeePosition, employeeId);
                        break;
                    default:
                        MessageBox.Show(
                            "Invalid role detected. Cannot navigate.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                }
            }

            this.Close();

            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }

            nextForm.Show();
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        private void gbManageEmployee_Enter(object sender, EventArgs e)
        {

        }

        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
            ChangeButtonStatus(false);
            InitializeCombobox();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void SearchUser(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadEmployeeData();
            }
            else
            {
                SqlConnection connection = DatabaseConnection.GetConnection();
                if (connection != null)
                {
                    connection.Open();
                    string query = "SELECT * FROM Employee WHERE EmployeeCode LIKE @search " +
                        "OR EmployeeName LIKE @search " +
                        "OR Position LIKE @search " +
                        "OR AuthorityLevel LIKE @search " +
                        "OR Username LIKE @search " +
                        "OR Password LIKE @search";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("search", "%" + search + "%");
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dtgEmployee.DataSource = table;
                    connection.Close();
                }
            }
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text;
            SearchUser(search);
        }
        private void dtgEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgEmployee.CurrentCell.RowIndex;
            // Check index
            if (index != -1)
            {
                employeeId = Convert.ToInt32(dtgEmployee.Rows[index].Cells[0].Value);
                ChangeButtonStatus(true);
                txtEmployeeCode.Text = dtgEmployee.Rows[index].Cells[1].Value.ToString();
                txtEmployeeName.Text = dtgEmployee.Rows[index].Cells[2].Value.ToString();
                txtEmployeePosition.Text = dtgEmployee.Rows[index].Cells[3].Value.ToString();
                string authorityLevel = dtgEmployee.Rows[index].Cells[4].Value.ToString();
                if (authorityLevel == "Admin")
                {
                    cbAuthorityLevel.SelectedIndex = 0;
                }
                else if (authorityLevel == "Warehouse Manager")
                {
                    cbAuthorityLevel.SelectedIndex = 1;
                }
                else if (authorityLevel == "Sale")
                {
                    cbAuthorityLevel.SelectedIndex = 2;
                }
                txtUsername.Text = dtgEmployee.Rows[index].Cells[5].Value.ToString();
                txtPassword.Text = dtgEmployee.Rows[index].Cells[6].Value.ToString();
            }
        }
        private void AddUser(string employeeCode,
                    string employeeName,
                    string employeePosition,
                    string authorityLevel,
                    string username,
                    string password)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "INSERT INTO Employee (EmployeeCode, EmployeeName, Position, AuthorityLevel, Username, Password, PasswordChanged) " +
                             "VALUES (@employeeCode, @employeeName, @employeePosition, @authorityLevel, @username, @password, 0)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("employeeCode", employeeCode);
                command.Parameters.AddWithValue("employeeName", employeeName);
                command.Parameters.AddWithValue("employeePosition", employeePosition);
                command.Parameters.AddWithValue("authorityLevel", authorityLevel);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully add new user",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearData();
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show(
                            "Cannot add new user",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }
        private void ChangeButtonStatus(bool buttonStatus)
        {
            btnUpdate.Enabled = buttonStatus;
            btnDelete.Enabled = buttonStatus;
            btnClear.Enabled = buttonStatus;
            btnAdd.Enabled = !buttonStatus;
        }
        private void FlushEmployeeId()
        {
            this.employeeId = 0;
            ChangeButtonStatus(false);
        }
        private void LoadEmployeeData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Employee";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dtgEmployee.DataSource = table;
                connection.Close();
            }
        }
        private void ClearData()
        {
            FlushEmployeeId();
            txtEmployeeCode.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtEmployeePosition.Text = string.Empty;
            cbAuthorityLevel.SelectedIndex = 0;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmployeeCode.Focus();
        }
        public void InitializeCombobox()
        {
            cbAuthorityLevel.Items.Add("Admin");
            cbAuthorityLevel.Items.Add("Warehouse Manager");
            cbAuthorityLevel.Items.Add("Sale");
            cbAuthorityLevel.SelectedIndex = 0;
        }
    }
}
