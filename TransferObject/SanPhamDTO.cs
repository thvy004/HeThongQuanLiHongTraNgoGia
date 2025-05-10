using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class SanPhamDTO
    {
        public int maSanPham { get; set; }
        public string tenSanPham { get; set; }
        public string maLoai { get; set; }


        public SanPhamDTO(int id, string name, string type)
        {
            maSanPham = id;
            tenSanPham = name;
            maLoai = type;

        }

        public SanPhamDTO(int id, string name, string type, int v1, int v2) : this(id, name, type)
        {
        }
    }
}