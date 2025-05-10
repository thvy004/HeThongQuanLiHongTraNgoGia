using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLiHongTraNgoGia
{
    public partial class Dangki : Form
    {
        public Dangki()
        {
            InitializeComponent();
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
    }
}
 