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

    // Lấy danh sách loại sản phẩm
    public List<string> GetDanhSachLoai()
    {
        return sanPhamDL.GetDanhSachLoai();
    }

    // Lấy danh sách mã sản phẩm
    public List<string> GetDanhSachMaSP()
    {
        return sanPhamDL.GetDanhSachMaSP();
    }

    // Lấy thông tin sản phẩm theo mã sản phẩm
    public SanPhamDTO GetSanPhamTheoMa(int maSanPham)
    {
        return sanPhamDL.GetSanPhamTheoMa(maSanPham); // Gọi phương thức DAL để lấy thông tin sản phẩm
    }
}