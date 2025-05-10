using System;
using System.Collections.Generic;
using TransferObject;

public class SanPhamBL
{
    private SanPhamDL sanPhamDL = new SanPhamDL();

    // Lấy danh sách sản phẩm
    public List<SanPhamDTO> GetSanPhamList()
    {
        return sanPhamDL.GetSanPhamList();
    }

    // Thêm sản phẩm mới
    public void AddSanPham(SanPhamDTO sanPham)
    {
        sanPhamDL.AddSanPham(sanPham);
    }

    // Cập nhật thông tin sản phẩm
    public void UpdateSanPham(SanPhamDTO sanPham)
    {
        sanPhamDL.UpdateSanPham(sanPham);
    }

    // Xóa sản phẩm
    public void DeleteSanPham(int productID)
    {
        sanPhamDL.DeleteSanPham(productID);
    }
    public List<string> GetDanhSachLoai()
    {
        return sanPhamDL.GetDanhSachLoai();
    }

    public List<string> GetDanhSachMaSP()
    {
        return sanPhamDL.GetDanhSachMaSP();
    }

}