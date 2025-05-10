using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class LoaiSanPhamDTO
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }

        public LoaiSanPhamDTO() { }

        public LoaiSanPhamDTO(int maLoai, string tenLoai)
        {
            MaLoai = maLoai;
            TenLoai = tenLoai;
        }
    }

}
