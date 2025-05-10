using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // Để sử dụng SqlConnection


namespace DataLayer
{
    public class DataProvider
    {
        private static SqlConnection connection;

        public static SqlConnection Connect()
        {
            if (connection == null)
            {
                // Thay đổi chuỗi kết nối với thông tin của bạn (Server, Database)
                connection = new SqlConnection("Data Source=.;Initial Catalog=HongTraNgoGia;Integrated Security=True");
            }
            return connection;
        }

        public static void Disconnect()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}