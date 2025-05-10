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
            Application.Exit();
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


        private void btnDangKy_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            string username = DK.Text;
            string password = MK_DK.Text;

            Account account = new Account(username, password);
            bool success = loginBL.Register(account);

            if (success)
            {
                MessageBox.Show("Đăng ký thành công! Bạn có thể đăng nhập.");
                this.Close(); // hoặc chuyển sang form đăng nhập
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại.");
                MessageBox.Show("Register called");
            }
        }
    }
    
}

    

 