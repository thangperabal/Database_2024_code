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
                // Declare SqlCommand variable to add parameters to query and execute it
                SqlCommand command = new SqlCommand(checkCustomerQuery, connection);
                // Add parameters
                command.Parameters.AddWithValue("employeeId", employeeId);
                // Declare SqlDataReader variable to read retrieved data
                SqlDataReader reader = command.ExecuteReader();
                // Check if reader has row (query success and return one row show user information)
                isExist = reader.HasRows;
                // close the connection
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
            // Ask for confirmation
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
            // Kiểm tra employeePosition
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

            // Kiểm tra nếu form đã mở
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

            // Nếu form chưa mở, tạo form mới và mở nó
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

            // Đóng form hiện tại và hiển thị form mục tiêu
            this.Close(); // Đóng form hiện tại

            // Đảm bảo thoát hoàn toàn ứng dụng khi đóng form cuối cùng
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }

            nextForm.Show(); // Hiển thị form mới hoặc đã mở
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
                // Open connection by call the GetConnection function in DatabaseConnection
                // class
                SqlConnection connection = DatabaseConnection.GetConnection();
                // Check connection
                if (connection != null)
                {
                    // Open the connection
                    connection.Open();
                    // Declare query to the database
                    string query = "SELECT * FROM Employee WHERE EmployeeCode LIKE @search " +
                        "OR EmployeeName LIKE @search " +
                        "OR Position LIKE @search " +
                        "OR AuthorityLevel LIKE @search " +
                        "OR Username LIKE @search " +
                        "OR Password LIKE @search";
                    // Initialize SqlDataAdapter to translate query result to a data table
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("search", "%" + search + "%");
                    // Initialize data table
                    DataTable table = new DataTable();
                    // Fill the data set by data querried from the database
                    adapter.Fill(table);
                    // Set the datasource of data gridview by the dataset
                    dtgEmployee.DataSource = table;
                    // close the connection
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
            // Get row index based on current cell (cell clicked)
            int index = dtgEmployee.CurrentCell.RowIndex;
            // Check index
            if (index != -1)
            {
                // get value of each cell based on row index
                // you have to check the sql query which is used to load data from database (LoadEmployeeData function)
                // use this query and execute it in SSMS to imagine the datagridview
                // the order of the column header is follow: ID | Code | Name | Position | AuthorityLevel | Username | Password | PasswordChanged
                // and the index is from 0 to 7
                // Get the employeeID (index is 0)
                employeeId = Convert.ToInt32(dtgEmployee.Rows[index].Cells[0].Value);
                // Change the button status by true (update, delete, clear is enable when employeeId is assigned with value > 0)
                ChangeButtonStatus(true);
                // Get the employeeCode (index is 1)
                txtEmployeeCode.Text = dtgEmployee.Rows[index].Cells[1].Value.ToString();
                // Get the employeeName (index is 2)
                txtEmployeeName.Text = dtgEmployee.Rows[index].Cells[2].Value.ToString();
                // Get the employeePosition (index is 3)
                txtEmployeePosition.Text = dtgEmployee.Rows[index].Cells[3].Value.ToString();
                // Get the authorityLevel (index is 4)
                string authorityLevel = dtgEmployee.Rows[index].Cells[4].Value.ToString();
                // Change the combobox selected index base ont the value of authority level
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
                // Get the Username (index is 5)
                txtUsername.Text = dtgEmployee.Rows[index].Cells[5].Value.ToString();
                // Get the Password (index is 6)
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
            // When employee is selected, button add will be disabled
            // button Update, Delete & Clear will be enabled and vice versa
            btnUpdate.Enabled = buttonStatus;
            btnDelete.Enabled = buttonStatus;
            btnClear.Enabled = buttonStatus;
            btnAdd.Enabled = !buttonStatus;
        }
        private void FlushEmployeeId()
        {
            // Flush employeeId value to check button and setup status for buttons
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
            // Setup for combobox
            cbAuthorityLevel.Items.Add("Admin");
            cbAuthorityLevel.Items.Add("Warehouse Manager");
            cbAuthorityLevel.Items.Add("Sale");
            // Set the selected index to the first item of the array (Admin)
            cbAuthorityLevel.SelectedIndex = 0;
        }
    }
}
