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
    public partial class CashierMainForm : Form
    {
        public CashierMainForm()
        {
            InitializeComponent();
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void dangxuatBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
