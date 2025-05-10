using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    internal class KhachHangDL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataTable LayDanhSachKhachHang()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM KhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void ThemKhachHang(string tenKhachHang, string diaChi, string soDienThoai)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO KhachHang (tenKhachHang, diaChi, soDienThoai) VALUES (@ten, @diaChi, @sdt)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ten", tenKhachHang);
                cmd.Parameters.AddWithValue("@diaChi", diaChi);
                cmd.Parameters.AddWithValue("@sdt", soDienThoai);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SuaKhachHang(int idKhachHang, string tenKhachHang, string diaChi, string soDienThoai)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE KhachHang SET tenKhachHang = @ten, diaChi = @diaChi, soDienThoai = @sdt WHERE idKhachHang = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ten", tenKhachHang);
                cmd.Parameters.AddWithValue("@diaChi", diaChi);
                cmd.Parameters.AddWithValue("@sdt", soDienThoai);
                cmd.Parameters.AddWithValue("@id", idKhachHang);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void XoaKhachHang(int idKhachHang)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM KhachHang WHERE idKhachHang = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idKhachHang);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
