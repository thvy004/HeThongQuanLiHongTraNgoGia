using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataLayer
{
    public class BangTongQuanDL
    {
        private static string connectionString = @"Data Source=.;Initial Catalog=HongTraNgoGia;Integrated Security=True";

        public static int DemTaiKhoan()
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM TaiKhoan";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }

        public static int DemKhachHang()
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM KhachHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }
    }
}
