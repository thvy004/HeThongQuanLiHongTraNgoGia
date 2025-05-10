using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TransferObject;
using BusinessLayer;

namespace HeThongQuanLiHongTraNgoGia
{
    public partial class LapHoaDonForm : UserControl
    {
        public LapHoaDonForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(LapHoaDonForm_Load);
        }
        private void LapHoaDonForm_Load(object sender, EventArgs e)
        {
            LoadData(); // Gọi LoadData sau khi form đã được khởi tạo
            LoadMenuSanPham();
            LoadChiTietDonHang();
        }
        // Phương thức load dữ liệu cho combo box
        private void LoadData()
        {
            try
            {
                SanPhamBL sanPhamBL = new SanPhamBL();

                // Lấy danh sách loại sản phẩm
                List<string> danhSachLoai = sanPhamBL.GetDanhSachLoai();
                cbLoai.DataSource = danhSachLoai;

                // Lấy danh sách mã sản phẩm
                List<string> danhSachMaSP = sanPhamBL.GetDanhSachMaSP();
                cbMaSanPham.DataSource = danhSachMaSP;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }


        

        private void LoadMenuSanPham()
        {
            string connectionString = "Server=localhost;Database=HongTraNgoGia;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM MenuSanPham"; // Thay bằng bảng MenuSanPham trong cơ sở dữ liệu của bạn
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Đảm bảo DataGridView có tên là cashierOrderForm_menuTable
                    cashierOrderForm_menuTable.DataSource = dt;

                    // Điều chỉnh cột để vừa với nội dung
                    foreach (DataGridViewColumn column in cashierOrderForm_menuTable.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi nếu có vấn đề với kết nối hoặc truy vấn
                    MessageBox.Show("Lỗi khi tải dữ liệu từ MenuSanPham: " + ex.Message);
                }
            }
        }

        // Sự kiện xử lý khi click vào một ô trong DataGridView (nếu cần thêm logic)
        private void cashierOrderForm_menuTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click vào ô bất kỳ (nếu cần)
            if (e.RowIndex >= 0)
            {
                // Có thể xử lý thêm thông tin khi người dùng click vào một sản phẩm
                DataGridViewRow row = cashierOrderForm_menuTable.Rows[e.RowIndex];
                MessageBox.Show("Sản phẩm: " + row.Cells["tenSanPham"].Value.ToString());
            }
        }

        private void LoadChiTietDonHang()
        {
            string connectionString = "Server=localhost;Database=HongTraNgoGia;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM ChiTietDonHang_View";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Đảm bảo DataGridView có tên là cashierOrderForm_orderTable
                    cashierOrderForm_orderTable.DataSource = dt;

                    // Căn chỉnh tự động độ rộng cột
                    foreach (DataGridViewColumn column in cashierOrderForm_orderTable.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ChiTietDonHang_View: " + ex.Message);
                }
            }
        }


        private void cashierOrderForm_orderTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbMaSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaSanPham.SelectedItem is SanPhamDTO sanPham)
            {
                lblTenSanPham.Text = sanPham.tenSanPham; // Gán tên sản phẩm vào label
            }
        }
    }
}

