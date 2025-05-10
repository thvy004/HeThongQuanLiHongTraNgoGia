using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class BangTongQuanBL
    {
        public static int LayTongTaiKhoan()
        {
            return BangTongQuanDL.DemTaiKhoan();
        }

        public static int LayTongKhachHang()
        {
            return BangTongQuanDL.DemKhachHang();
        }
    }
}
