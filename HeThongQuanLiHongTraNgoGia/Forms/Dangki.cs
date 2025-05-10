using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;

namespace HeThongQuanLiHongTraNgoGia
{
    public partial class Dangki : Form
    {
        private LoginBL loginBL;

        public Dangki()
        {
            InitializeComponent();
            loginBL = new LoginBL();
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void DK_btnDN_Click(object sender, EventArgs e)
        {
            DangNhap logiForm = new DangNhap();
            logiForm.Show();
            this.Hide();
        }

        private void chbhMK_CheckedChanged(object sender, EventArgs e)
        {
            MK_DK.UseSystemPasswordChar = !chbhMK.Checked;
            XacnhanMKDK.UseSystemPasswordChar = !chbhMK.Checked;
        }

        private void Dangki_Load(object sender, EventArgs e)
        {
            MK_DK.UseSystemPasswordChar = true;
            XacnhanMKDK.UseSystemPasswordChar = true;
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            string username = DK.Text.Trim();
            string password = MK_DK.Text.Trim();
            string confirmPassword = XacnhanMKDK.Text.Trim();

            // Kiểm tra nếu có trường trống
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tất cả các trường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu và xác nhận mật khẩu có khớp không
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!", "Lỗi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Account account = new Account(username, password);

            bool success = loginBL.Register(account);

            if (success)
            {
                MessageBox.Show("Đăng ký thành công! Bạn có thể đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở lại form đăng nhập và đóng form đăng ký
                DangNhap loginForm = new DangNhap();
                loginForm.Show();
                this.Hide(); // Ẩn form đăng ký đi
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại. Tên tài khoản đã tồn tại hoặc có lỗi xảy ra.", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
