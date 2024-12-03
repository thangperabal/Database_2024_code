using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNACK_MAN
{
    public class DatabaseConnection
    {
        private static string _connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=Snack;Integrated Security=True;Trust Server Certificate=True";

        public static Microsoft.Data.SqlClient.SqlConnection GetConnection()
        {
            Microsoft.Data.SqlClient.SqlConnection connection = null;
            try
            {
                connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    $"Error while connecting to the database: {ex.Message}",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return connection;
        }
    }
}
