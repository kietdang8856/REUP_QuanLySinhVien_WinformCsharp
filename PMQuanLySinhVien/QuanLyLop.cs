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
    public partial class QuanLyLop : Form
    {
        public QuanLyLop()
        {

            InitializeComponent();


            DataTable a = Loadcombo();
            cbmk.DataSource=a;
            cbmk.DisplayMember="tenkhoa";
            cbmk.ValueMember = "makhoa";
            Loaddulieu();




        }
        private void Loaddulieu()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT lop.*, khoa.tenkhoa FROM lop INNER JOIN khoa ON khoa.makhoa = lop.makhoa", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    tb2.DataSource = dt;

                    tb2.Columns[0].HeaderText = "MÃ LỚP";   // Column for 'lop' table's first column
                    tb2.Columns[1].HeaderText = "TÊN LỚP";  // Column for 'lop' table's second column
                    tb2.Columns[2].HeaderText = "SỐ LƯỢNG"; // Column for 'lop' table's third column
                    tb2.Columns[3].HeaderText = "MÃ KHOA";  // Column for 'lop' table's fourth column
                    tb2.Columns[4].HeaderText = "TÊN KHOA"; // Column for 'khoa.tenkhoa'

                    // Adjust column widths
                    tb2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    tb2.Columns[0].Width = 130; // Width for MÃ LỚP
                    tb2.Columns[1].Width = 170; // Width for TÊN LỚP
                    tb2.Columns[2].Width = 250; // Width for SỐ LƯỢNG
                    tb2.Columns[3].Width = 130; // Width for MÃ KHOA
                    tb2.Columns[4].Width = 170; // Width for TÊN KHOA


                }
                catch (Exception ex) {

            }
        }
        private DataTable Loadcombo()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
            {
                string query = "select makhoa,tenkhoa from khoa";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
              
                dt.Load(reader);
                conn.Close();
                return dt;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string malop = ml.Text.Trim();
                    string tenlop = tl.Text.Trim();
                    int soluong = (int)sl.Value;
                    string makhoa = cbmk.SelectedValue.ToString();
                    string sql = "insert into lop values(@Ma,@Ten,@Soluong,@Makhoa)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", malop);
                    cmd.Parameters.AddWithValue("@Ten", tenlop);
                    cmd.Parameters.AddWithValue("@Soluong", soluong);
                    cmd.Parameters.AddWithValue("@Makhoa", makhoa);
                    cmd.ExecuteNonQuery();
                    Loaddulieu();
                    
                    ml.ResetText();
                    tl.ResetText();
                    sl.ResetText();
                   

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


                    string malop = ml.Text.Trim();
                    string tenlop = tl.Text.Trim();
                    int soluong1 = (int)sl.Value;
                    string makhoa = cbmk.SelectedValue.ToString();
                    string sql = "update lop set tenlop=@Ten,soluong=@SL,makhoa=@Tenkhoa where malop=@Ma";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", malop);
                    cmd.Parameters.AddWithValue("@Ten", tenlop);
                    cmd.Parameters.AddWithValue("@SL", soluong1);
                    cmd.Parameters.AddWithValue("@Tenkhoa", makhoa);
                    cmd.ExecuteNonQuery();
                    Loaddulieu();
                    ml.ResetText();
                    tl.ResetText();
                    sl.ResetText();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính"+ex);
                }
        }

        private void tb2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = tb2.SelectedCells[0].RowIndex;
            DataGridViewRow row = tb2.Rows[index];
            ml.Text = row.Cells[0].Value.ToString().Trim();
            tl.Text = row.Cells[1].Value.ToString().Trim();
            sl.Text = row.Cells[2].Value.ToString().Trim();
            cbmk.Text = row.Cells[4].Value.ToString().Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string malop = ml.Text.Trim();
                    string tenlop = tl.Text.Trim();
                    int soluong = (int)sl.Value;
                    string makhoa = cbmk.SelectedValue.ToString();
                    string sql = "delete from lop  where malop=@Ma";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", malop);
                   
                    cmd.ExecuteNonQuery();
                    Loaddulieu();

                    ml.ResetText();
                    tl.ResetText();
                    sl.ResetText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính");
                }
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void quảnLíSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sinhvien f = new sinhvien();
            this.Hide();
            f.Show();
        }

        private void quảnLíCốVấnHọcTâpToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
