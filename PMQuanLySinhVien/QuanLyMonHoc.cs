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
    public partial class QuanLyMonHoc : Form
    {
        public QuanLyMonHoc()
        {
            InitializeComponent();
            Loaddulieu();
        }
        private void Loaddulieu()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from monhoc", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    tb2.DataSource = dt;
                    tb2.Columns[0].HeaderText="ID";
                    tb2.Columns[1].HeaderText="MÃ MÔN HỌC";
                    tb2.Columns[2].HeaderText="TÊN MÔN HỌC";
                    tb2.Columns[3].HeaderText="SỐ TÍN CHỈ";
                    tb2.Columns[4].HeaderText="SỐ TIẾT LÍ THUYẾT";
                    tb2.Columns[5].HeaderText="SỐ TIẾT THỰC HÀNH";
                    tb2.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells;
                    tb2.Columns[0].Width=130;
                    tb2.Columns[1].Width=250;
                    tb2.Columns[2].Width=250;
                    tb2.Columns[3].Width=250;
                    tb2.Columns[4].Width=400;
                    tb2.Columns[5].Width=400;

                }
                catch (Exception ex)
                {

                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string mamh = mmh.Text.Trim();
                    string tenmh = tmh.Text.Trim();
                    int sotc = (int)stc.Value;
                    int sotlt= (int)tlt.Value;
                    int sotth = (int)tth.Value;
                  
                    string sql = "insert into monhoc values(@Ma,@Ten,@Sotc,@Sotlt,@Sotth)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", mamh);
                    cmd.Parameters.AddWithValue("@Ten", tenmh);
                    cmd.Parameters.AddWithValue("@Sotc", sotc);
                    cmd.Parameters.AddWithValue("@Sotlt", sotlt);
                    cmd.Parameters.AddWithValue("@Sotth", sotth);
                    cmd.ExecuteNonQuery();
                    Loaddulieu();
                    MessageBox.Show("Thêm Thành Công");
                    mmh.ResetText();
                    tmh.ResetText();
                    stc.ResetText();
                    tlt.ResetText();
                    tth.ResetText();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính");
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string mamh = mmh.Text.Trim();
                    string tenmh = tmh.Text.Trim();
                    int sotc = (int)stc.Value;
                    int sotlt = (int)tlt.Value;
                    int sotth = (int)tth.Value;

                    string sql = "update monhoc set tenmonhoc=@Ten,sotc=@Sotc,tietlt=@Sotlt,tietth=@Sotth where mamonhoc=@Ma";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", mamh);
                    cmd.Parameters.AddWithValue("@Ten", tenmh);
                    cmd.Parameters.AddWithValue("@Sotc", sotc);
                    cmd.Parameters.AddWithValue("@Sotlt", sotlt);
                    cmd.Parameters.AddWithValue("@Sotth", sotth);
                    cmd.ExecuteNonQuery();
                    Loaddulieu();
                    MessageBox.Show("Sửa Thành Công");
                    mmh.ResetText();
                    tmh.ResetText();
                    stc.ResetText();
                    tlt.ResetText();
                    tth.ResetText();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính");
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string mamh = mmh.Text.Trim();
                    string tenmh = tmh.Text.Trim();
                    int sotc = (int)stc.Value;
                    int sotlt = (int)tlt.Value;
                    int sotth = (int)tth.Value;

                    string sql = "delete from monhoc where mamonhoc=@Ma";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", mamh);
                
                    cmd.ExecuteNonQuery();
                    Loaddulieu();
                    MessageBox.Show("Xóa Thành Công");
                    mmh.ResetText();
                    tmh.ResetText();
                    stc.ResetText();
                    tlt.ResetText();
                    tth.ResetText();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính");
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void stc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void stlt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void stth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tb2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = tb2.SelectedCells[0].RowIndex;
            DataGridViewRow row = tb2.Rows[index];
            mmh.Text=row.Cells[1].Value.ToString().Trim();
            tmh.Text=row.Cells[2].Value.ToString().Trim();
            stc.Text=row.Cells[3].Value.ToString().Trim();
            tlt.Text=row.Cells[4].Value.ToString().Trim();
        }

        private void quảnLíKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khoa f = new Khoa();
            this.Hide();
            f.Show();
        }

        private void quảnLíLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyLop f = new QuanLyLop();
            this.Hide();
            f.Show();
        }

        private void quảnLíSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sinhvien f = new sinhvien();
            this.Hide();
            f.Show();
        }

        private void quảnLíCốVấnHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyCoVanHocTap f = new QuanLyCoVanHocTap();
            this.Hide();
            f.Show();
        }

        private void quảnLíMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc f = new QuanLyMonHoc();
            this.Hide();
            f.Show();
        }

        private void quảnLíTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
