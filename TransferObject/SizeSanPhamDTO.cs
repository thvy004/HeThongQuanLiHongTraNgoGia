using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class SizeSanPhamDTO
    {
        public int maSize { get; set; }
        public string tenSize { get; set; }

        public SizeSanPhamDTO() { }

        public SizeSanPhamDTO(int maS, string tenS)
        {
            maSize = maS;
            tenSize = tenS;
        }
    }
}

