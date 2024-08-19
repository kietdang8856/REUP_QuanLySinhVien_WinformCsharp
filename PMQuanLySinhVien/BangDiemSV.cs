using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQuanLySinhVien
{
    public partial class BangDiemSV : Form
    {
        public BangDiemSV()
        {
            InitializeComponent();
            DataTable a = Loadcombomonhoc();
            mmh.DataSource=a;
            mmh.DisplayMember="tenmonhoc";
            mmh.ValueMember = "mamonhoc";
            Loaddulieu();
        }
        private DataTable Loadcombomonhoc()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
            {
                string query = "select mamonhoc,tenmonhoc from monhoc ";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(reader);
                conn.Close();
                return dt;
            }

        }
        private void Loaddulieu()
        {

            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                SELECT 
                sinhvien.masv, 
                sinhvien.tensv,
                monhoc.mamonhoc,
                monhoc.tenmonhoc,
                diem.phantramtrenlop,
                diem.phantramthi,
                diem.diemtrenlop,
                diem.diemthi,
                       ROUND(AVG(diem.diemtrenlop * diem.phantramtrenlop / 100 + diem.diemthi * diem.phantramthi / 100), 2) AS diemtbthi,
                    CASE
                        WHEN AVG(diem.diemtrenlop * diem.phantramtrenlop / 100 + diem.diemthi * diem.phantramthi / 100) <= 5 THEN N'Kém'
                        WHEN AVG(diem.diemtrenlop * diem.phantramtrenlop / 100 + diem.diemthi * diem.phantramthi / 100) BETWEEN 5 AND 6.5 THEN N'Trung bình'
                        WHEN AVG(diem.diemtrenlop * diem.phantramtrenlop / 100 + diem.diemthi * diem.phantramthi / 100) BETWEEN 6.6 AND 7.9 THEN N'Khá'
                        WHEN AVG(diem.diemtrenlop * diem.phantramtrenlop / 100 + diem.diemthi * diem.phantramthi / 100) BETWEEN 8 AND 9 THEN N'Giỏi'
                        WHEN AVG(diem.diemtrenlop * diem.phantramtrenlop / 100 + diem.diemthi * diem.phantramthi / 100) >=9 THEN N'Xuất sắc'
                    END AS loai
                FROM
                    diem
                    INNER JOIN sinhvien ON sinhvien.masv = diem.masv
                    INNER JOIN monhoc ON monhoc.mamonhoc = diem.mamonhoc
                GROUP BY
                sinhvien.masv, 
                sinhvien.tensv,
                monhoc.mamonhoc,
                monhoc.tenmonhoc,
                diem.phantramtrenlop,
                diem.phantramthi,
                diem.diemtrenlop,
                diem.diemthi";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    tb2.DataSource = dt;
                    tb2.Columns[0].HeaderText = "MÃ SV";
                    tb2.Columns[1].HeaderText = "TÊN SV";
                    tb2.Columns[2].HeaderText = "MÃ MH";
                    tb2.Columns[3].HeaderText = "TÊN MH";
                    tb2.Columns[4].HeaderText = "PHẦN TRĂM TRÊN LỚP";
                    tb2.Columns[5].HeaderText = "PHẦN TRĂM THI";
                    tb2.Columns[6].HeaderText = "ĐIỂM TRÊN LỚP";
                    tb2.Columns[7].HeaderText = "ĐIỂM THI";
                    tb2.Columns[8].HeaderText = "ĐIỂM TRUNG BÌNH";
                    tb2.Columns[9].HeaderText = "XẾP LOẠI";
                    tb2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string masv = msv.Text.Trim();
                    string mamh = mmh.SelectedValue.ToString();
                    int ptramtl = (int)ptl.Value;
                    int ptramthi= (int)ptt.Value;
                    decimal diemtl = decimal.Parse(dl.Text.Trim());
                     decimal diemthi = decimal.Parse(dt.Text.Trim());
                   
                    string sql = "insert into diem values(@Masv,@Mamh,@PhanTramLop,@PhanTramThi,@DiemLop,@DiemThi)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Masv", masv);
                    cmd.Parameters.AddWithValue("@Mamh", mamh);
                    cmd.Parameters.AddWithValue("@PhanTramLop", ptramtl);
                    cmd.Parameters.AddWithValue("@PhanTramThi", ptramthi);
                    cmd.Parameters.AddWithValue("@DiemLop",diemtl);
                    cmd.Parameters.AddWithValue("@DiemThi",diemthi);
       
                    cmd.ExecuteNonQuery();
                    Loaddulieu();

                    msv.ResetText();
                   
                    ptl.ResetText();
                    ptt.ResetText();
                   dl.ResetText();
                    dt.ResetText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính"+ex);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string masv = msv.Text.Trim();
                    string mamh = mmh.SelectedValue.ToString();
                    int ptramtl = (int)ptl.Value;
                    int ptramthi = (int)ptt.Value;
                    float diemtl = float.Parse(dl.Text.Trim());
                    float diemthi = float.Parse(dt.Text.Trim());

                    string sql = "update diem set mamonhoc=@Mamh ,phantramtrenlop=@PhanTramLop,phantramthi=@PhanTramThi,diemtrenlop=@DiemLop,diemthi=@DiemThi where masv=@Masv ";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Masv", masv);
                    cmd.Parameters.AddWithValue("@Mamh", mamh);
                    cmd.Parameters.AddWithValue("@PhanTramLop", ptramtl);
                    cmd.Parameters.AddWithValue("@PhanTramThi", ptramthi);
                    cmd.Parameters.AddWithValue("@DiemLop", diemtl);
                    cmd.Parameters.AddWithValue("@DiemThi", diemthi);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa Dữ Liệu Thành Công");
                    Loaddulieu();

                    msv.ResetText();

                    ptl.ResetText();
                    ptt.ResetText();
                    dl.ResetText();
                    dt.ResetText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính"+ex);
                }
        }

        private void tb2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the click is within the data area (not headers or outside bounds)
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Access the row based on the clicked cell
                    DataGridViewRow row = tb2.Rows[e.RowIndex];

                    // Safely extract cell values and handle null cases
                    msv.Text = row.Cells[0]?.Value?.ToString().Trim() ?? string.Empty; // MÃ SV
                    mmh.Text = row.Cells[2]?.Value?.ToString().Trim() ?? string.Empty; // MÃ MH
                    ptl.Text = row.Cells[4]?.Value?.ToString().Trim() ?? string.Empty; // PHẦN TRĂM TRÊN LỚP

                    ptt.Text = row.Cells[5]?.Value?.ToString().Trim() ?? string.Empty; // PHẦN TRĂM THI
                    dl.Text = row.Cells[6]?.Value?.ToString().Trim() ?? string.Empty; // ĐIỂM TRÊN LỚP
                    dt.Text = row.Cells[7]?.Value?.ToString().Trim() ?? string.Empty; // ĐIỂM THI
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn ô: " + ex.Message);
            }

        }

        private void quảnLíKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khoa f = new Khoa();
            this.Hide();
            f.Show();
        }

        private void quảnLíSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sinhvien f = new sinhvien();
            this.Hide();
            f.Show();
        }

        private void quảnLíLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           QuanLyLop f = new  QuanLyLop();
            this.Hide();
            f.Show();
        }

        private void quảnLýCóVấnHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyCoVanHocTap f = new  QuanLyCoVanHocTap();
            this.Hide();
            f.Show();
        }

        private void quảnLíĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BangDiemSV f = new BangDiemSV();
            this.Hide();
            f.Show();
        }

        private void quảnLíTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
           QuanLyTaiKhoan f = new QuanLyTaiKhoan();
            this.Hide();
            f.Show();
        }

        private void BangDiemSV_Load(object sender, EventArgs e)
        {
            // Kiểm tra quyền của người dùng
            bool isAdmin = true; // Ở đây bạn sẽ kiểm tra quyền người dùng từ dữ liệu đăng nhập

            // Hiện/ẩn menu "Quản lý tài khoản" dựa trên quyền
            menu1.Visible = isAdmin;
        }

        private void quảnLíMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc f = new QuanLyMonHoc();
            this.Hide();
            f.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc f = new QuanLyMonHoc();
            this.Hide();
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Show();
        }
    }
        
    
        } 
