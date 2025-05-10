using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using TransferObject;

public class SizeSanPhamDL
{
    private string connString = ConfigurationManager.ConnectionStrings["HongTraNgoGia"].ConnectionString;

    public List<SizeSanPhamDTO> GetSizeList()
    {
        List<SizeSanPhamDTO> list = new List<SizeSanPhamDTO>();
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string query = "SELECT * FROM SizeSanPham";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new SizeSanPhamDTO(
                    Convert.ToInt32(reader["maSize"]),
                    reader["tenSize"].ToString()
                ));
            }
        }
        return list;
    }

    public void AddSize(SizeSanPhamDTO size)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string query = "INSERT INTO SizeSanPham (maSize, tenSize) VALUES (@ma, @ten)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ma", size.maSize);
            cmd.Parameters.AddWithValue("@ten", size.tenSize);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateSize(SizeSanPhamDTO size)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string query = "UPDATE SizeSanPham SET tenSize = @ten WHERE maSize = @ma";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ma", size.maSize);
            cmd.Parameters.AddWithValue("@ten", size.tenSize);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteSize(int maSize)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string query = "DELETE FROM SizeSanPham WHERE maSize = @ma";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ma", maSize);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
