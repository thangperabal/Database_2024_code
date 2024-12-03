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
    public partial class OrderHistory : Form
    {
        private string authorityLevel;
        private int employeeId;

        public OrderHistory(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
        }

        // Phương thức để load lịch sử đơn hàng từ cơ sở dữ liệu
        private void LoadOrderHistory()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string query = "SELECT o.OrderDate, " +
                               "e.EmployeeName, " +
                               "c.CustomerName " +
                               "FROM Orders o " +
                               "INNER JOIN Employee e ON o.EmployeeID = e.EmployeeID " +
                               "INNER JOIN Customer c ON o.CustomerID = c.CustomerID " +
                               "WHERE o.EmployeeID = @employeeId " +
                               "GROUP BY o.OrderDate, e.EmployeeName, c.CustomerName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@employeeId", employeeId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dtgOrderHistory.DataSource = dataTable;  // Đổ dữ liệu vào DataGridView
            }
        }


        // Phương thức chuyển hướng tới các form khác dựa trên quyền hạn của người dùng
        private void RedirectPage()
        {
            // Dựa trên quyền hạn (authorityLevel), chuyển hướng đến các form tương ứng
            switch (this.authorityLevel)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(authorityLevel, employeeId);
                        this.Hide();  // Ẩn form hiện tại
                        adminForm.Show();  // Hiển thị form Admin
                        break;
                    }
                case "Warehouse Manager":
                    {
                        WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(authorityLevel, employeeId);
                        this.Hide();  // Ẩn form hiện tại
                        warehouseManagerForm.Show();  // Hiển thị form Warehouse Manager
                        break;
                    }
                case "Sale":
                    {
                        ManageCustomer saleForm = new ManageCustomer(authorityLevel, employeeId);
                        this.Hide();  // Ẩn form hiện tại
                        saleForm.Show();  // Hiển thị form Sale
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        // Gọi phương thức load dữ liệu khi form được tải
        private void OrderHistory_Load(object sender, EventArgs e)
        {
            LoadOrderHistory();  // Gọi hàm LoadOrderHistory khi form tải
        }

        // Sự kiện khi nhấn nút Back
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Quay lại form trước đó dựa trên quyền hạn của người dùng
            RedirectPage();
        }
    }
}
