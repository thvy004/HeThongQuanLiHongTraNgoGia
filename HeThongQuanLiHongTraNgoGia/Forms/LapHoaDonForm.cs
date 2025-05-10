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
        private List<SanPhamDTO> danhSachSanPham = new List<SanPhamDTO>();

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
                cbLoai.SelectedIndex = -1;  // Đảm bảo không chọn mặc định

                // Lấy danh sách mã sản phẩm
                List<string> danhSachMaSP = sanPhamBL.GetDanhSachMaSP();
                cbMaSanPham.DataSource = danhSachMaSP;
                cbMaSanPham.SelectedIndex = -1;  // Đảm bảo không chọn mặc định
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
            try
            {
                // Kiểm tra nếu SelectedItem có giá trị
                if (cbMaSanPham.SelectedItem != null)
                {
                    // Lấy giá trị mã sản phẩm từ SelectedItem
                    string maSanPhamString = cbMaSanPham.SelectedItem.ToString();

                    // Kiểm tra nếu giá trị có thể chuyển đổi thành int
                    if (int.TryParse(maSanPhamString, out int maSanPham))
                    {
                        // Lấy sản phẩm theo mã
                        SanPhamBL sanPhamBL = new SanPhamBL();
                        SanPhamDTO sanPham = sanPhamBL.GetSanPhamTheoMa(maSanPham);

                        if (sanPham != null)
                        {
                            // Hiển thị thông tin sản phẩm
                            lblTenSanPham.Text = sanPham.tenSanPham; // Ví dụ, gán tên sản phẩm vào label
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã sản phẩm không hợp lệ.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (danhSachSanPham.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong đơn hàng.");
                return;
            }

            decimal tongTien = TinhTongTien();
            MessageBox.Show($"Tổng tiền: {tongTien:C}", "Xác nhận thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // TODO: Thêm code lưu đơn hàng vào CSDL nếu cần

            // Reset sau khi thanh toán
            danhSachSanPham.Clear();
            cashierOrderForm_orderTable.Rows.Clear(); // nếu bạn có DataGridView
        }

        // Phương thức tính tổng tiền
        private decimal TinhTongTien()
        {
            decimal tong = 0;
            foreach (SanPhamDTO sp in danhSachSanPham)
            {
                tong += sp.soLuong * sp.donGia;
            }
            return tong;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
    }


