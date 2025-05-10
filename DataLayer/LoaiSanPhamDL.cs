using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TransferObject;
using System.Configuration;

public class LoaiSanPhamDL
{
    private string connString = ConfigurationManager.ConnectionStrings["HongTraNgoGia"].ConnectionString;

    public List<LoaiSanPhamDTO> GetLoaiSanPhamList()
    {
        List<LoaiSanPhamDTO> list = new List<LoaiSanPhamDTO>();
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "SELECT * FROM LoaiSanPham";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                LoaiSanPhamDTO loai = new LoaiSanPhamDTO
                {
                    MaLoai = Convert.ToInt32(reader["maLoai"]),
                    TenLoai = reader["tenLoai"].ToString()
                };
                list.Add(loai);
            }
        }
        return list;
    }

    public void AddLoaiSanPham(LoaiSanPhamDTO loai)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "INSERT INTO LoaiSanPham (maLoai, tenLoai) VALUES (@ma, @ten)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ma", loai.MaLoai); // Fixed property name
            cmd.Parameters.AddWithValue("@ten", loai.TenLoai); // Fixed property name
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateLoaiSanPham(LoaiSanPhamDTO loai)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "UPDATE LoaiSanPham SET tenLoai = @ten WHERE maLoai = @ma";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ma", loai.MaLoai); // Fixed property name
            cmd.Parameters.AddWithValue("@ten", loai.TenLoai); // Fixed property name
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteLoaiSanPham(string maLoai)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "DELETE FROM LoaiSanPham WHERE maLoai = @ma";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ma", maLoai);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
