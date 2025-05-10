using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace HeThongQuanLiHongTraNgoGia
{
    public partial class BangTongQuanForm : UserControl
    {
        public BangTongQuanForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(BangTongQuanForm_Load);
        }
        private void BangTongQuanForm_Load(object sender, EventArgs e)
        {
            lblThuNgan.Text = BangTongQuanBL.LayTongTaiKhoan().ToString();
            lblKhachHang.Text = BangTongQuanBL.LayTongKhachHang().ToString(); // Nếu có bảng KhachHang
        }
    }
}
