using System;
using System.Collections.Generic;
using TransferObject;

public class GiaSanPhamBL
{
    private GiaSanPhamDL giaSanPhamDL = new GiaSanPhamDL();

    // Lấy danh sách giá sản phẩm
    public List<GiaSanPhamDTO> GetGiaSanPhamList()
    {
        return giaSanPhamDL.GetGiaSanPhamList();
    }

    // Thêm giá sản phẩm
    public void AddGiaSanPham(GiaSanPhamDTO gia)
    {
        giaSanPhamDL.AddGiaSanPham(gia);
    }

    // Cập nhật giá sản phẩm
    public void UpdateGiaSanPham(GiaSanPhamDTO gia)
    {
        giaSanPhamDL.UpdateGiaSanPham(gia);
    }

    // Xóa giá sản phẩm
    public void DeleteGiaSanPham(int maSanPham, string maSize)
    {
        giaSanPhamDL.DeleteGiaSanPham(maSanPham, maSize);
    }
}
