using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    internal class KhachHangDTO
    {
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public KhachHangDTO(string maKhachHang, string tenKhachHang, string diaChi, string soDienThoai)
        {
            MaKhachHang = maKhachHang;
            TenKhachHang = tenKhachHang;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }
    }
}

