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

namespace PMQuanLySinhVien
{
    public partial class QuanLyTaiKhoan : Form
    {
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
            Loaddulieu();
        }
        private void Loaddulieu()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    // Câu lệnh SQL để lấy dữ liệu từ bảng taikhoan
                    SqlCommand cmd = new SqlCommand("SELECT * FROM taikhoan", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    tb2.DataSource = dt;

                    // Đặt tiêu đề cho các cột trong DataGridView
                    tb2.Columns[0].HeaderText = "ID"; // Cột id, đây là khóa chính auto-increment
                    tb2.Columns[1].HeaderText = "TÊN TÀI KHOẢN"; // Cột tentaikhoan
                    tb2.Columns[2].HeaderText = "TÊN ĐĂNG NHẬP"; // Cột tendangnhap
                    tb2.Columns[3].HeaderText = "MẬT KHẨU"; // Cột matkhau
                    tb2.Columns[4].HeaderText = "LOẠI TÀI KHOẢN"; // Cột loaitaikhoan

                    tb2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
            {
                try
                {
                    // Lấy dữ liệu từ các điều khiển
                    string tentaikhoan = ttk.Text.Trim();
                    string tendangnhap = tdn.Text.Trim();
                    string matkhau = mk.Text.Trim();
                    string loaitaikhoan = ltk.Text.Trim();

                    // Câu lệnh SQL để chèn dữ liệu vào bảng taikhoan
                    string sql = "INSERT INTO taikhoan (tentaikhoan, tendangnhap, matkhau, loaitaikhoan) VALUES (@Tentaikhoan, @Tendangnhap, @Matkhau, @Loaitaikhoan)";

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@Tentaikhoan", tentaikhoan);
                    cmd.Parameters.AddWithValue("@Tendangnhap", tendangnhap);
                    cmd.Parameters.AddWithValue("@Matkhau", matkhau);
                    cmd.Parameters.AddWithValue("@Loaitaikhoan", loaitaikhoan);

                    // Thực thi câu lệnh SQL
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm Dữ Liệu Thành Công");

                    // Cập nhật dữ liệu trong giao diện
                    Loaddulieu();

                    // Đặt lại các điều khiển
                    ttk.ResetText();
                    tdn.ResetText();
                    mk.ResetText();
                    ltk.ResetText();
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính: " + ex.Message);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string tentk = ttk.Text.Trim();
                    string tendn = tdn.Text.Trim();
                    string matk = mk.Text.Trim();
                    string loaitk = ltk.Text.Trim();
                    string sql = "update taikhoan set matkhau=@Matkhau,loaitaikhoan=@Quyen, tentaikhoan=@Tentaikhoan where tendangnhap=@Tendn";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Tentaikhoan", tentk);
                    cmd.Parameters.AddWithValue("@Tendn", tendn);
                    cmd.Parameters.AddWithValue("@Matkhau", matk);
                    cmd.Parameters.AddWithValue("@Quyen", loaitk);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa Dữ Liệu Thành Công");
                    Loaddulieu();

                    tdn.ResetText();
                    mk.ResetText();



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính");
                }
        }

        private void tb2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = tb2.SelectedCells[0].RowIndex;
            DataGridViewRow row = tb2.Rows[index];
            ttk.Text = row.Cells[1].Value.ToString().Trim();
            tdn.Text=row.Cells[1].Value.ToString().Trim();
            mk.Text=row.Cells[2].Value.ToString().Trim();
            string loaitk = row.Cells[4].Value.ToString().Trim();
            ltk.SelectedIndex = ltk.Items.IndexOf(loaitk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string tentk = ttk.Text.Trim();
                    string tendn = tdn.Text.Trim();
                    string matk = mk.Text.Trim();
                    string loaitk = ltk.Text.Trim();
                    string sql = "delete from taikhoan where tentaikhoan=@Tentaikhoan";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Tentaikhoan", tentk);
                    cmd.Parameters.AddWithValue("@Tendn", tendn);
                    cmd.Parameters.AddWithValue("@Matkhau", matk);
                    cmd.Parameters.AddWithValue("@Quyen", loaitk);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa Dữ Liệu Thành Công");
                    Loaddulieu();

                    tdn.ResetText();
                    mk.ResetText();



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính");
                }
        }

        private void quảnLýCosVấnHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyCoVanHocTap f = new QuanLyCoVanHocTap();
            this.Hide();
            f.Show();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khoa f = new Khoa();
            this.Hide();
            f.Show();
        }

        private void quảnLýLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyLop f = new QuanLyLop();
            this.Hide();
            f.Show();
        }

        private void quảnLýSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sinhvien f = new sinhvien();
            this.Hide();
            f.Show();
        }

        private void quảnLýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc f = new QuanLyMonHoc();
            this.Hide();
            f.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan f = new QuanLyTaiKhoan();
            this.Hide();
            f.Show();
        }

        private void điểmSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BangDiemSV f = new BangDiemSV();
            this.Hide();
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Show();
        }

        private void tb2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void ttk_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
