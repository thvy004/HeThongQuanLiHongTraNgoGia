using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HeThongQuanLiHongTraNgoGia
{
    public partial class LapHoaDonForm : UserControl
    {
        public LapHoaDonForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(LapHoaDonForm_Load); // Đăng ký sự kiện Load
        }

        private void LapHoaDonForm_Load(object sender, EventArgs e)
        {
            MenuSanPham();
            LoadChiTietDonHang();
        }

        private void MenuSanPham()
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
    }
}

