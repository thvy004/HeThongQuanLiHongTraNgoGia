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

        private void adminAddUsers_addBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost;Database=HongTraNgoGia;Trusted_Connection=True;"))
            {
                string query = "INSERT INTO SanPham (maSanPham, tenSanPham, maLoai, soLuongTon, trangThai) VALUES (@maSP, @tenSP, @loai, @ton, @trangThai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maSP", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@tenSP", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@loai", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@ton", int.TryParse(textBox4.Text, out int ton) ? ton : 10);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm sản phẩm thành công!");
                LoadDanhSachSanPham();
                ClearForm();
            }
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = 0;
        }
    }
}

