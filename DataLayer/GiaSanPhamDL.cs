using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TransferObject;
using System.Configuration;

public class GiaSanPhamDL
{
    private string connString = ConfigurationManager.ConnectionStrings["HongTraNgoGia"].ConnectionString;

    public List<GiaSanPhamDTO> GetGiaSanPhamList()
    {
        List<GiaSanPhamDTO> list = new List<GiaSanPhamDTO>();
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "SELECT * FROM GiaSanPham";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                GiaSanPhamDTO gia = new GiaSanPhamDTO
                {
                    MaSP = Convert.ToInt32(reader["maSanPham"]),
                    MaSize = Convert.ToInt32(reader["maSize"]), // Fixed conversion to int
                    GiaBan = Convert.ToDecimal(reader["giaBan"])
                };
                list.Add(gia);
            }
        }
        return list;
    }

    public void AddGiaSanPham(GiaSanPhamDTO gia)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "INSERT INTO GiaSanPham (maSanPham, maSize, giaBan) VALUES (@maSP, @maSize, @gia)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@maSP", gia.MaSP); 
            cmd.Parameters.AddWithValue("@maSize", gia.MaSize); 
            cmd.Parameters.AddWithValue("@gia", gia.GiaBan); 
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateGiaSanPham(GiaSanPhamDTO gia)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "UPDATE GiaSanPham SET giaBan = @gia WHERE maSanPham = @maSP AND maSize = @maSize";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@maSP", gia.MaSP);
            cmd.Parameters.AddWithValue("@maSize", gia.MaSize); 
            cmd.Parameters.AddWithValue("@gia", gia.GiaBan);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteGiaSanPham(int maSP, string maSize)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            string query = "DELETE FROM GiaSanPham WHERE maSanPham = @maSP AND maSize = @maSize";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@maSP", maSP);
            cmd.Parameters.AddWithValue("@maSize", maSize);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
    public List<GiaSanPhamDTO> LayDanhSachGiaSanPham()
    {
        return GetGiaSanPhamList();
    }
}
