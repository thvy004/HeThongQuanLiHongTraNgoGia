using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TransferObject
{
    public class GiaSanPhamDTO
    {
        public int MaSP { get; set; }
        public int MaSize { get; set; }
        public decimal GiaBan { get; set; }

        public GiaSanPhamDTO() { }

        public GiaSanPhamDTO(int maSP, int maSize, decimal giaBan)
        {
            MaSP = maSP;
            MaSize = maSize;
            GiaBan = giaBan;
        }
    }
}
