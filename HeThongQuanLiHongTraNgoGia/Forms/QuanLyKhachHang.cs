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

namespace HeThongQuanLiHongTraNgoGia.Forms
{
    public partial class QuanLyKhachHang : UserControl
    {
        string connectionString = "Server=localhost;Database=HongTraNgoGia;Trusted_Connection=True;";
        public QuanLyKhachHang()
        {
            InitializeComponent();
            this.Load += new EventHandler(QuanLyKhachHang_Load);

        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void LoadKhachHang()
        {
            string connectionString = "Server=localhost;Database=HongTraNgoGia;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                
                
                    string query = "SELECT * FROM QuanLyKhachHang"; // View đã tạo trong SQL
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // Tự động điều chỉnh kích thước cột
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
               
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure valid cell indices
            {
                MessageBox.Show($"Cell clicked at Row {e.RowIndex}, Column {e.ColumnIndex}");
            }
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (e != null && e.Graphics != null) // Ensure valid PaintEventArgs
            {
                e.Graphics.Clear(Color.White);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (e != null && e.Graphics != null) // Ensure valid PaintEventArgs
            {
                e.Graphics.Clear(Color.White);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (sender != null) // Ensure sender is valid
            {
                MessageBox.Show("Label clicked!");
            }
        }

        private void Cus_themBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO KhachHang (tenKhachHang, diaChi, soDienThoai) VALUES (@ten, @diaChi, @sdt)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ten", textBox2.Text);
                cmd.Parameters.AddWithValue("@diaChi", textBox4.Text);
                cmd.Parameters.AddWithValue("@sdt", maskedTextBox1.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm khách hàng thành công!");
                LoadKhachHang();
                ClearForm();
            }
        }


        private void Cus_Suabtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE KhachHang SET tenKhachHang = @ten, diaChi = @diaChi, soDienThoai = @sdt WHERE idKhachHang = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ten", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@diaChi", textBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@sdt", maskedTextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!");
                    LoadKhachHang();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để cập nhật.");
                }
            
        }

        }


        private void Cus_xoabtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM KhachHang WHERE idKhachHang = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

                conn.Open();
                int rowsDeleted = cmd.ExecuteNonQuery();

                if (rowsDeleted > 0)
                {
                    MessageBox.Show("Xóa khách hàng thành công!");
                    LoadKhachHang();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để xóa.");
                }
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["idKhachHang"].Value.ToString();
                textBox2.Text = row.Cells["tenKhachHang"].Value.ToString();
                textBox4.Text = row.Cells["diaChi"].Value.ToString();
                maskedTextBox1.Text = row.Cells["soDienThoai"].Value.ToString();
            }
        }
        private void ClearForm()
        {
            textBox1.Clear(); // ID khách hàng (ẩn)
            textBox2.Clear(); // Tên khách hàng
            textBox4.Clear(); // Địa chỉ
            maskedTextBox1.Clear(); // Số điện thoại
            textBox2.Focus();
        }
    }
}
