using System;
using System.Collections.Generic;
using TransferObject;

public class LoaiSanPhamBL
{
    private LoaiSanPhamDL loaiSanPhamDL = new LoaiSanPhamDL();

    // Lấy danh sách loại sản phẩm
    public List<LoaiSanPhamDTO> GetLoaiSanPhamList()
    {
        return loaiSanPhamDL.GetLoaiSanPhamList();
    }

    // Thêm loại sản phẩm
    public void AddLoaiSanPham(LoaiSanPhamDTO loai)
    {
        loaiSanPhamDL.AddLoaiSanPham(loai);
    }

    // Cập nhật loại sản phẩm
    public void UpdateLoaiSanPham(LoaiSanPhamDTO loai)
    {
        loaiSanPhamDL.UpdateLoaiSanPham(loai);
    }

    // Xóa loại sản phẩm
    public void DeleteLoaiSanPham(string maLoai)
    {
        loaiSanPhamDL.DeleteLoaiSanPham(maLoai);
    }
}
