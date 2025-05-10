using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;


namespace HeThongQuanLiHongTraNgoGia
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void DN_btnDK_Click(object sender, EventArgs e)
        {
            Dangki regform = new Dangki();
            regform.Show();

            this.Hide();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            Account acc = new Account
            {
                Username = txtTaiKhoan.Text,
                Password = txtMatKhau.Text
            };

            LoginBL bl = new LoginBL();
            bool result = bl.Login(acc);

            if (result)
            {
                MessageBox.Show("Đăng nhập thành công!");
                // mở form chính ở đây
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
            }
        }
    }
}
