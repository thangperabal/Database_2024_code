using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNACK_MAN
{
    public partial class ManageProduct : Form
    {        
        // variable to store the selected product
        private int productId;

        // variable to store the authority level of user, so that we are able to navigate back
        private string authorityLevel;

        // variable to store logged in userId
        private int userId;
        private object employeeId;

        public ManageProduct(string authorityLevel, int userId)
        {
            this.authorityLevel = authorityLevel;
            this.userId = userId;
            productId = 0;
            InitializeComponent();
        }

        public ManageProduct(string authorityLevel, object employeeId)
        {
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
        }

        private void LoadCategoryCombobox()
        {

            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {

                connection.Open();
                string query = "SELECT CategoryID, CategoryName FROM Category";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cbCategory.DataSource = dataTable;
                cbCategory.DisplayMember = "CategoryName";
                cbCategory.ValueMember = "CategoryID";
            }
        }

        private bool ValidateData(String productCode,
            String productName,
            String productPrice,
            String productQuantity)
        {
            double temp;
            int temp2;
            if (String.IsNullOrEmpty(productName)) { return false; }
            if (String.IsNullOrEmpty(productPrice)) { return false; }
            if (!double.TryParse(productPrice, out temp)) { return false; }
            if (String.IsNullOrEmpty(productQuantity)) { return false; }
            return int.TryParse(productQuantity, out temp2);
        }

        private void UploadFile(String filter, String path)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Optional: Set file filters (e.g., only allow certain file types)
            openFileDialog.Filter = filter;

            openFileDialog.Title = "Select a file to upload";

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of the selected file
                string sourceFilePath = openFileDialog.FileName;

                // Specify the target path relative to the project directory
                string targetDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploads");//sửa

                // Combine the target directory with the file name to get the destination path
                string targetFilePath = System.IO.Path.Combine(targetDirectory, Path.GetFileName(sourceFilePath));//sửa

                try
                {
                    // Ensure the target directory exists
                    if (!System.IO.Directory.Exists(targetDirectory))
                    {
                        System.IO.Directory.CreateDirectory(targetDirectory);
                    }
                    // Copy the file to the target directory
                    File.Copy(sourceFilePath, targetFilePath, overwrite: true);

                    txtProductImg.Text = targetFilePath;
                    // Inform the user
                    MessageBox.Show("File uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the file upload
                    MessageBox.Show("Error uploading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadFile("Image Files ( *. jpg ;*. jpeg ;*. png)| *. jpg ;*. jpeg ;*. png");
        }

        private void UploadFile(string v)
        {
            throw new NotImplementedException();
        }


        private void LoadProductData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Snacks_BaTuyetID, Snacks_BaTuyetCode, Snacks_BaTuyetName, Price, InventoryQuantity, Snacks_BaTuyetImage, CategoryName " +
                                   "FROM Snacks_BaTuyet " +
                                   "INNER JOIN Category ON Snacks_BaTuyet.CategoryID = Category.CategoryID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dtgProduct.DataSource = dataTable; // dtgProduct là tên DataGridView của bạn
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void ClearData()
        {
            FlushProductId();
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductImg.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            txtProductQuantity.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }
        private void ChangeButtonStatus(bool buttonStatus)
        {

            btnUpdate.Enabled = buttonStatus;
            btnDelete.Enabled = buttonStatus;
            btnClear.Enabled = buttonStatus;
            btnAdd.Enabled = !buttonStatus;
        }

        private void FlushProductId()
        {
            this.productId = 0;
            ChangeButtonStatus(false);
        }
        private void AddProduct()
        {

            SqlConnection connection = DatabaseConnection.GetConnection();
            // Check connection
            if (connection != null)
            {
                // Open the connection
                connection.Open();
                // Get data from input
                string productCode = txtProductCode.Text;
                string productName = txtProductName.Text;
                string productImg = txtProductImg.Text;
                string price = txtProductPrice.Text;
                string quantity = txtProductQuantity.Text;
                int categoryId = Convert.ToInt32(cbCategory.SelectedValue);
                // Validate data
                if (ValidateData(productCode, productName, price, quantity))
                {
                    // declare query
                    string sql = "INSERT INTO Product VALUES (" +
                    "@productCode, @productName, @productPrice, @productQuantity, @productImg, @categoryId)";
                    // declare sqlcommand variable to manipulate query
                    SqlCommand command = new SqlCommand(sql, connection);
                    // add params
                    command.Parameters.AddWithValue("productCode", productCode);
                    command.Parameters.AddWithValue("productName", productName);
                    command.Parameters.AddWithValue("productPrice", Convert.ToDouble(price));
                    command.Parameters.AddWithValue("productQuantity", Convert.ToInt32(quantity));
                    command.Parameters.AddWithValue("productImg", productImg);
                    command.Parameters.AddWithValue("categoryId", categoryId);
                    // execute query and get the result
                    int result = command.ExecuteNonQuery();
                    // check the result
                    if (result > 0)
                    {
                        MessageBox.Show("Successfully add new product", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearData();
                        LoadProductData();
                    }
                    else
                    {
                        MessageBox.Show("Cannot add new product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // close the connection
                connection.Close();
            }
        }


        private void UpdateProduct()
        {

            SqlConnection connection = DatabaseConnection.GetConnection();
            // Check connection
            if (connection != null)
            {
                // Open the connection
                connection.Open();
                // get input data
                string productCode = txtProductCode.Text;
                string productName = txtProductName.Text;
                string productImg = txtProductImg.Text;
                string price = txtProductPrice.Text;
                string quantity = txtProductQuantity.Text;
                int categoryId = Convert.ToInt32(cbCategory.SelectedValue);
                // validate data
                if (ValidateData(productCode, productName, price, quantity))
                {
                    // declare query
                    string sql = "UPDATE Product SET ProductCode = @productCode, " +
                        "ProductName = @productName," +
                        "Price = @productPrice," +
                        "InventoryQuantity = @productQuantity," +
                        "ProductImage = @productImg," +
                        "CategoryID = @categoryId " +
                        "WHERE ProductID = @productId";
                    // declare sqlcommand variable to manipulate query
                    SqlCommand command = new SqlCommand(sql, connection);
                    // add params
                    command.Parameters.AddWithValue("productCode", productCode);
                    command.Parameters.AddWithValue("productName", productName);
                    command.Parameters.AddWithValue("productPrice", Convert.ToDouble(price));
                    command.Parameters.AddWithValue("productQuantity", Convert.ToInt32(quantity));
                    command.Parameters.AddWithValue("productImg", productImg);
                    command.Parameters.AddWithValue("categoryId", categoryId);
                    command.Parameters.AddWithValue("productId", this.productId);
                    // execute query and get the result
                    int result = command.ExecuteNonQuery();
                    // check result
                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Successfully update product",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        ClearData();
                        LoadProductData();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Cannot update product",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    // close the connection
                    connection.Close();
                }
            }
        }
        private void DeleteProduct()
        {
            // Ask for confirmation
            DialogResult dialogResult = MessageBox.Show("Do you want to delete the product",
            "Warning",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (!IsProductInOrder(this.productId))
                {
                    // Open connection by call the GetConnection function in DatabaseConnection
                    // class
                    SqlConnection connection = DatabaseConnection.GetConnection();
                    // Check connection
                    if (connection != null)
                    {
                        // Open the connection
                        connection.Open();
                        // declare query
                        string sql = "DELETE Product WHERE ProductID = @productId";
                        // declare sqlcommand variable to manipulate query
                        SqlCommand command = new SqlCommand(sql, connection);
                        // add params
                        command.Parameters.AddWithValue("productId", this.productId);
                        // execute query and get the result
                        int result = command.ExecuteNonQuery();
                        // check result
                        if (result > 0)
                        {
                            MessageBox.Show(
                            "Successfully delete product",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            ClearData();
                            LoadProductData();
                        }
                        else
                        {
                            MessageBox.Show(
                            "Cannot delete product",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                        // close the connection
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show(
                    "Product is in another order\nCannot delete",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }


        private bool IsProductInOrder(int productId)
        {

            SqlConnection connection = DatabaseConnection.GetConnection();
            // Check connection
            if (connection != null)
            {
                // Open the connection
                connection.Open();
                // declare query to get number of record have productId equal productId
                string sql = "SELECT COUNT(*) FROM OrderDetail WHERE ProductID = @productId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("productId", productId);
                int result = (int)command.ExecuteScalar();
                connection.Close();
                return result > 0;
            }
            return false;
        }


        private void SearchProduct(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadProductData();
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
                    string sql = "SELECT p.ProductID, p.ProductCode, p.ProductName, p.Price, " +
                    "p. InventoryQuantity, p.ProductImage, c.CategoryName " +
                    "FROM Product p " +
                    "INNER JOIN Category c " +
                    "ON p.CategoryID = c.CategoryID " +
                    "WHERE p.ProductCode LIKE @search " +
                    "OR p.ProductName LIKE @search " +
                    "OR c.CategoryName LIKE @search";
                    // Initialize SqlDataAdapter to translate query result to a data table
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Add params to query
                    adapter.SelectCommand.Parameters.AddWithValue("search", "%" + search + "%");
                    // Initialize data table
                    DataTable data = new DataTable();
                    // Fill datatable with data queried from database
                    adapter.Fill(data);
                    // Set the data source for data table
                    dtgProduct.DataSource = data;
                    // Close the connection
                    connection.Close();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            // binding data to the data gridview
            LoadProductData();
            // binding data to combobox
            LoadCategoryCombobox();
            // set status for button to ensure the UX of user
            ChangeButtonStatus(false);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (authorityLevel)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(this.authorityLevel, this.userId);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse Manager":
                    {
                        WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(this.authorityLevel, this.userId);
                        this.Hide();
                        warehouseManagerForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        OrderHistory saleForm = new OrderHistory(this.authorityLevel, this.userId);
                        this.Hide();
                        saleForm.Show();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }


        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            ManageCategory manageCategory = new ManageCategory(this.authorityLevel, this.employeeId);
            this.Hide();
            manageCategory.Show();
        }
        private void dtgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get row index based on current cell (cell clicked)
            int index = dtgProduct.CurrentCell.RowIndex;
            // Check index
            if (index != -1 && !dtgProduct.Rows[index].IsNewRow)
            {

                productId = Convert.ToInt32(dtgProduct.Rows[index].Cells[0].Value);

                ChangeButtonStatus(true);
                // Get the ProductCode (index is 1)
                txtProductCode.Text = dtgProduct.Rows[index].Cells[1].Value.ToString();
                // Get the ProductName (index is 2)
                txtProductName.Text = dtgProduct.Rows[index].Cells[2].Value.ToString();
                // Get the ProductPrice (index is 3)
                txtProductPrice.Text = dtgProduct.Rows[index].Cells[3].Value.ToString();
                // Get the ProductQuantity (index is 4)
                txtProductQuantity.Text = dtgProduct.Rows[index].Cells[4].Value.ToString();
                // Get the Img URL (index is 5)
                txtProductImg.Text = dtgProduct.Rows[index].Cells[5].Value.ToString();
                // Get the CategoryName (index is 6) and check in combobox to select the equal value
                string categoryName = dtgProduct.Rows[index].Cells[6].Value.ToString();
                for (int i = 0; i < cbCategory.Items.Count; i++)
                {
                    if (cbCategory.SelectedText == categoryName)
                    {
                        cbCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text;
            SearchProduct(search);
        }
        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            ManageProduct manageProduct = new ManageProduct(this.authorityLevel, this.employeeId);
            this.Hide();
            manageProduct.Show();
        }



    }
}

