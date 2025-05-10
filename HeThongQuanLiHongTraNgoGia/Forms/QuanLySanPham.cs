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

namespace HeThongQuanLiHongTraNgoGia
{
    public partial class QuanLySanPham : UserControl
    {
        public QuanLySanPham()
        {
            InitializeComponent();
            this.Load += new EventHandler(QuanLySanPham_Load);
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
            LoadLoaiSanPham();
            LoadSizeSanPham();
        }

        private void LoadDanhSachSanPham()
        {
            string connectionString = "Server=localhost;Database=HongTraNgoGia;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM QuanLySanPham";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // Tự động điều chỉnh độ rộng cột
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message);
                }
            }
        }

        private void LoadLoaiSanPham()
        {
            string connectionString = "Server=localhost;Database=HongTraNgoGia;Trusted_Connection=True;";
            string query = "SELECT maLoai, tenLoai FROM LoaiSanPham";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "tenLoai";
                    comboBox1.ValueMember = "maLoai";
                    comboBox1.SelectedIndex = 0; // chọn mục đầu tiên
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải loại sản phẩm: " + ex.Message);
            }
        }

        // ===================== Tải size sản phẩm =====================
        private void LoadSizeSanPham()
        {
            string connectionString = "Server=localhost;Database=HongTraNgoGia;Trusted_Connection=True;";
            string query = "SELECT maSize, tenSize FROM SizeSanPham";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "tenSize";
                    comboBox2.ValueMember = "maSize";
                    comboBox2.SelectedIndex = 0; // chọn mục đầu tiên
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải size sản phẩm: " + ex.Message);
            }
        }

        private void adminAddUsers_addBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=HongTraNgoGia;Trusted_Connection=True;";

            // Lấy thông tin từ các trường nhập liệu
            string maSP = textBox1.Text.Trim();
            string tenSP = textBox2.Text.Trim();
            int maLoai = Convert.ToInt32(comboBox1.SelectedValue);
            int ton = int.TryParse(textBox4.Text, out int t) ? t : 10;
            int maSize = Convert.ToInt32(comboBox2.SelectedValue);
            double giaBan = double.TryParse(textBox3.Text, out double g) ? g : 0;

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrWhiteSpace(maSP) || string.IsNullOrWhiteSpace(tenSP) || giaBan <= 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm hợp lệ.");
                return;
            }

            // Kết nối tới SQL Server
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); // Đảm bảo các thao tác SQL được thực hiện trong một giao dịch

                try
                {
                    // 1. Thêm sản phẩm vào bảng SanPham
                    string insertSanPham = @"INSERT INTO SanPham (maSanPham, tenSanPham, maLoai, soLuongTon, trangThai)
                                             VALUES (@maSP, @tenSP, @maLoai, @ton, 1)";
                    SqlCommand cmdSP = new SqlCommand(insertSanPham, conn, transaction);
                    cmdSP.Parameters.AddWithValue("@maSP", maSP);
                    cmdSP.Parameters.AddWithValue("@tenSP", tenSP);
                    cmdSP.Parameters.AddWithValue("@maLoai", maLoai);
                    cmdSP.Parameters.AddWithValue("@ton", ton);
                    cmdSP.ExecuteNonQuery();

                    // 2. Thêm giá sản phẩm theo size vào bảng GiaSanPham
                    string insertGia = @"INSERT INTO GiaSanPham (maSanPham, maSize, giaBan)
                                         VALUES (@maSP, @maSize, @giaBan)";
                    SqlCommand cmdGia = new SqlCommand(insertGia, conn, transaction);
                    cmdGia.Parameters.AddWithValue("@maSP", maSP);
                    cmdGia.Parameters.AddWithValue("@maSize", maSize);
                    cmdGia.Parameters.AddWithValue("@giaBan", giaBan);
                    cmdGia.ExecuteNonQuery();

                    // Commit transaction nếu không có lỗi
                    transaction.Commit();
                    MessageBox.Show("Thêm sản phẩm và giá theo size thành công!");

                    // Cập nhật lại danh sách sản phẩm
                    LoadDanhSachSanPham();
                    ClearForm(); // Xóa các trường nhập liệu
                }
                catch (Exception ex)
                {
                    // Rollback transaction nếu có lỗi
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["maSanPham"].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["maSanPham"].Value.ToString();
                textBox2.Text = row.Cells["tenSanPham"].Value.ToString();
                textBox4.Text = row.Cells["soLuongTon"].Value.ToString();
                comboBox1.SelectedValue = row.Cells["maLoai"].Value;
            }
        }

        private void adminAddUsers_updateBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=HongTraNgoGia;Trusted_Connection=True;";
            string maSP = textBox1.Text.Trim();
            string tenSP = textBox2.Text.Trim();
            int maLoai = Convert.ToInt32(comboBox1.SelectedValue);
            int ton = int.TryParse(textBox4.Text, out int t) ? t : 10;
            int maSize = Convert.ToInt32(comboBox2.SelectedValue);
            double giaBan = double.TryParse(textBox3.Text, out double g) ? g : 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Cập nhật sản phẩm
                    string updateSP = @"UPDATE SanPham 
                                SET tenSanPham = @tenSP, maLoai = @maLoai, soLuongTon = @ton
                                WHERE maSanPham = @maSP";
                    SqlCommand cmd1 = new SqlCommand(updateSP, conn, transaction);
                    cmd1.Parameters.AddWithValue("@maSP", maSP);
                    cmd1.Parameters.AddWithValue("@tenSP", tenSP);
                    cmd1.Parameters.AddWithValue("@maLoai", maLoai);
                    cmd1.Parameters.AddWithValue("@ton", ton);
                    cmd1.ExecuteNonQuery();

                    // Cập nhật giá theo size
                    string updateGia = @"UPDATE GiaSanPham 
                                 SET giaBan = @giaBan, maSize = @maSize
                                 WHERE maSanPham = @maSP";
                    SqlCommand cmd2 = new SqlCommand(updateGia, conn, transaction);
                    cmd2.Parameters.AddWithValue("@maSP", maSP);
                    cmd2.Parameters.AddWithValue("@maSize", maSize);
                    cmd2.Parameters.AddWithValue("@giaBan", giaBan);
                    cmd2.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                    LoadDanhSachSanPham();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
        }

        private void adminAddUsers_deleteBtn_Click(object sender, EventArgs e)
        {
            string maSP = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            string connectionString = "Server=localhost;Database=HongTraNgoGia;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Xóa giá trước vì phụ thuộc vào mã sản phẩm
                    string deleteGia = "DELETE FROM GiaSanPham WHERE maSanPham = @maSP";
                    SqlCommand cmd1 = new SqlCommand(deleteGia, conn, transaction);
                    cmd1.Parameters.AddWithValue("@maSP", maSP);
                    cmd1.ExecuteNonQuery();

                    // Xóa sản phẩm
                    string deleteSP = "DELETE FROM SanPham WHERE maSanPham = @maSP";
                    SqlCommand cmd2 = new SqlCommand(deleteSP, conn, transaction);
                    cmd2.Parameters.AddWithValue("@maSP", maSP);
                    cmd2.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    LoadDanhSachSanPham();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }
    }
}

