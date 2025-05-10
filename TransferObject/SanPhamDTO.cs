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
        public decimal donGia { get; set; }  // Thêm dòng này cho đơn giá
        public int soLuongTon { get; set; }  // Thêm dòng này nếu cần

        public SanPhamDTO(int id, string name, string type, decimal price)
        {
            maSanPham = id;
            tenSanPham = name;
            maLoai = type;
            donGia = price;
        }

        public SanPhamDTO(int id, string name, string type, decimal price, int ton)
            : this(id, name, type, price)
        {
            soLuongTon = ton;
        }
    }

}