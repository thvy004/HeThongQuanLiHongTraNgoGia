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
        private readonly LoginBL loginBL;

        public DangNhap()
        {
            InitializeComponent();
            loginBL = new LoginBL();

            // Đăng ký sự kiện KeyDown cho các TextBox
            txtTaiKhoan.KeyDown += new KeyEventHandler(txtTaiKhoan_KeyDown);
            txtMatKhau.KeyDown += new KeyEventHandler(txtMatKhau_KeyDown);
        }

        private void label2_Click(object sender, EventArgs e) { }

        bool UserLogin(Account account)
        {
            try
            {
                return loginBL.Login(account);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; //Đăng nhập thất bại
            }
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void DN_btnDK_Click(object sender, EventArgs e)
        {
            Dangki regform = new Dangki();
            regform.Show();
            this.Hide();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            // Kiểm tra nếu tên tài khoản hoặc mật khẩu bị bỏ trống
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu có trường hợp thiếu
            }

            Account account = new Account(username, password);
            LoginBL bl = new LoginBL();

            bool result = bl.Login(account);

            if (UserLogin(account) == true)
            {
                MainForm formDashboard = new MainForm();
                txtTaiKhoan.Clear();
                txtMatKhau.Clear();
                formDashboard.Show();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtTaiKhoan.Clear();
                txtTaiKhoan.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void chbhMK_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chbhMK.Checked;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        // Xử lý khi nhấn Enter trong TextBox Tài Khoản
        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDN.PerformClick(); // Gọi sự kiện click của nút đăng nhập
            }
        }

        // Xử lý khi nhấn Enter trong TextBox Mật Khẩu
        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDN.PerformClick(); // Gọi sự kiện click của nút đăng nhập
            }
        }

        private void Label2_Click(object sender, EventArgs e) { }
    }
}
