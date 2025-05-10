using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TransferObject;
using System.Configuration;

public class SanPhamDL
{
    private string connString = ConfigurationManager.ConnectionStrings["HongTraNgoGia"].ConnectionString;

    // Lấy danh sách sản phẩm
    public List<SanPhamDTO> GetSanPhamList()
    {
        List<SanPhamDTO> sanPhamList = new List<SanPhamDTO>();
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = @"
            SELECT sp.maSanPham, sp.tenSanPham, sp.maLoai, gsp.donGia
            FROM SanPham sp
            JOIN GiaSanPham gsp ON sp.maSanPham = gsp.maSanPham";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SanPhamDTO sanPham = new SanPhamDTO(
                    Convert.ToInt32(reader["maSanPham"]),
                    reader["tenSanPham"].ToString(),
                    reader["maLoai"].ToString(),
                    Convert.ToDecimal(reader["donGia"])  // Lấy giá từ bảng GiaSanPham
                );
                sanPhamList.Add(sanPham);
            }
        }
        return sanPhamList;
    }

    // Thêm một sản phẩm mới
    public void AddSanPham(SanPhamDTO sanPham)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "INSERT INTO dbo.SanPham (tensp, maloai) VALUES (@prodName, @prodType)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@prodName", sanPham.tenSanPham);  // Tham số từ DTO
            cmd.Parameters.AddWithValue("@prodType", sanPham.maLoai);  // Tham số từ DTO

            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // Cập nhật thông tin sản phẩm
    public void UpdateSanPham(SanPhamDTO sanPham)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "UPDATE dbo.SanPham SET tenSanPham = @prodName, maLoai = @prodType WHERE maSanPham = @prodID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@prodID", sanPham.maSanPham);      // Tham số từ DTO
            cmd.Parameters.AddWithValue("@prodName", sanPham.tenSanPham);  // Tham số từ DTO
            cmd.Parameters.AddWithValue("@prodType", sanPham.maLoai);  // Tham số từ DTO

            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // Xóa sản phẩm
    public void DeleteSanPham(int productID)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "DELETE FROM dbo.SanPham WHERE maSanPham = @prodID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@prodID", productID);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
    public List<string> GetDanhSachLoai()
    {
        List<string> danhSach = new List<string>();
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "SELECT DISTINCT maLoai FROM SanPham";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(reader["maLoai"].ToString());
            }
        }
        return danhSach;
    }

    public List<string> GetDanhSachMaSP()
    {
        List<string> danhSach = new List<string>();
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "SELECT maSanPham FROM SanPham";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhSach.Add(reader["maSanPham"].ToString());
            }
        }
        return danhSach;
    }
    public SanPhamDTO GetSanPhamTheoMa(int maSP)
    {
        SanPhamDTO sanPham = null;
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = @"
            SELECT sp.maSanPham, sp.tenSanPham, sp.maLoai, gsp.donGia
            FROM SanPham sp
            JOIN GiaSanPham gsp ON sp.maSanPham = gsp.maSanPham
            WHERE sp.maSanPham = @maSP";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@maSP", maSP);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sanPham = new SanPhamDTO(
                    Convert.ToInt32(reader["maSanPham"]),
                    reader["tenSanPham"].ToString(),
                    reader["maLoai"].ToString(),
                    Convert.ToDecimal(reader["donGia"])
                );
            }
        }
        return sanPham;
    }




}