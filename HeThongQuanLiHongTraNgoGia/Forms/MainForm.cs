using HeThongQuanLiHongTraNgoGia.Forms;
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
    public partial class MainForm : Form
    {
        private readonly BangTongQuanForm bangTongQuanForm;
        private readonly QuanLySanPham quanLySanPham;
        private readonly LapHoaDonForm lapHoaDonForm;
        private readonly QuanLyKhachHang quanLyKhachHang;
        public MainForm()
        {
            InitializeComponent();

            // Khởi tạo các UserControl
            bangTongQuanForm = new BangTongQuanForm();
            quanLySanPham = new QuanLySanPham();
            lapHoaDonForm = new LapHoaDonForm();
            quanLyKhachHang = new QuanLyKhachHang();

            // Thiết lập Dock = Fill để các UserControl chiếm toàn bộ panel3
            bangTongQuanForm.Dock = DockStyle.Fill;
            quanLySanPham.Dock = DockStyle.Fill;
            lapHoaDonForm.Dock = DockStyle.Fill;
            quanLyKhachHang.Dock = DockStyle.Fill;

            // Thêm các UserControl vào panel3
            panel3.Controls.Add(bangTongQuanForm);
            panel3.Controls.Add(quanLySanPham);
            panel3.Controls.Add(lapHoaDonForm);
            panel3.Controls.Add(quanLyKhachHang);

            // Hiện form tổng quan đầu tiên
            ShowForm(bangTongQuanForm);

            // Đặt toàn màn hình
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ShowForm(UserControl formToShow)
        {
            try
            {
                // Kiểm tra nếu formToShow là null
                if (formToShow == null)
                {
                    MessageBox.Show("Form không hợp lệ!");
                    return;
                }

                // Ẩn tất cả các UserControl trong panel3
                foreach (Control control in panel3.Controls)
                {
                    control.Visible = false;
                }

                // Hiện form được chọn và đưa nó lên trên cùng
                formToShow.Visible = true;
                formToShow.BringToFront();
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có vấn đề khi xử lý
                MessageBox.Show("Lỗi khi chuyển đổi form: " + ex.Message);
            }
        }


        private void thoat_Click(object sender, EventArgs e)
        {

        }

        private void dangxuatBtn_Click(object sender, EventArgs e)
        {
        }

        private void cashierOrderForm1_Load(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }




        private void button1_Click(object sender, EventArgs e)
        {
            ShowForm(bangTongQuanForm); // Khi bấm vào nút này, sẽ hiển thị form Tổng Quan
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowForm(quanLySanPham); // Khi bấm vào nút này, sẽ hiển thị form Quản Lý Sản Phẩm
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowForm(lapHoaDonForm); // Khi bấm vào nút này, sẽ hiển thị form Lập Hóa Đơn
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowForm(quanLyKhachHang); // Khi bấm vào nút này, sẽ hiển thị form Quản Lý Khách Hàng
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void DangxuatBtn_Click(object sender, EventArgs e)
        {


        }

        private void CashierOrderForm1_Load(object sender, EventArgs e)
        {
        }

        private void Label4_Click(object sender, EventArgs e)
        {
        }

        private void cashierOrderForm1_Load_1(object sender, EventArgs e)
        {

        }

        private void cashierOrderForm1_Load_2(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dangxuatBtn_Click_1(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                this.Hide(); // Ẩn form hiện tại (form chính)

                DangNhap dangNhap = new DangNhap();
                dangNhap.FormClosed += (s, args) => this.Close(); // Khi form DangNhap đóng thì form chính cũng đóng luôn

                dangNhap.Show(); // Mở lại form đăng nhập
            }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ShowForm(quanLySanPham); // Khi bấm vào nút này, sẽ hiển thị form Quản Lý Sản Phẩm
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ShowForm(lapHoaDonForm); // Khi bấm vào nút này, sẽ hiển thị form Lập Hóa Đơn
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ShowForm(quanLyKhachHang); // Khi bấm vào nút này, sẽ hiển thị form Quản Lý Khách Hàng
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowForm(bangTongQuanForm); // Khi bấm vào nút này, sẽ hiển thị form Tổng Quan
        }
    }
}