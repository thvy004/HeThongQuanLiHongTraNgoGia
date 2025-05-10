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
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
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
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            Account account = new Account(username, password);


            LoginBL bl = new LoginBL();
            bool result = bl.Login(account);

            if (txtTaiKhoan.Text.Trim() == string.Empty || txtMatKhau.Text.Trim() == string.Empty)
                MessageBox.Show("Please enter all field!", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (UserLogin(account) == true)
                {
                    MainForm formDashboard = new MainForm();
                    txtTaiKhoan.Clear();
                    txtMatKhau.Clear();
                    formDashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Username or Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtTaiKhoan.Clear();
                    txtTaiKhoan.Focus();
                }
            }
        }
       
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void chbhMK_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chbhMK.Checked;
           
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }
        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
