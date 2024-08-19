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
    public partial class Khoa : Form
    {
        public Khoa()
        {
            InitializeComponent();
            Loadtb1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string makhoa = mk.Text.Trim();
                    string tenkhoa=tk.Text.Trim();
                    string sql = "insert into khoa values(@Ma,@Ten)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    
                    cmd.Parameters.AddWithValue("@Ma", makhoa);
                    cmd.Parameters.AddWithValue("@Ten", tenkhoa);
                    cmd.ExecuteNonQuery();
                    Loadtb1();
                    mk.ResetText();
                    tk.ResetText();

                } catch (Exception ex) {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính");
                }
        }
        private void Loadtb1()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))

                try
                {
                conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from khoa",conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    tb1.DataSource = dt;
                    tb1.Columns[1].HeaderText="MÃ KHOA";
                    tb1.Columns[2].HeaderText="TÊN KHOA";

                    tb1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells;
                    tb1.Columns[0].Width=130;
                    tb1.Columns[1].Width=170;
                    tb1.Columns[2].Width=250;

                }
                catch (Exception ex)
                {

                }



    }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string makhoa = mk.Text.Trim();
                    string tenkhoa = tk.Text.Trim();
                    string sql = "update khoa set tenkhoa=@Ten where makhoa=@Ma";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", makhoa);
                    cmd.Parameters.AddWithValue("@Ten", tenkhoa);
                    cmd.ExecuteNonQuery();
                    Loadtb1();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính");
                }
        }

        private void tb1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index=tb1.SelectedCells[0].RowIndex;
            DataGridViewRow row=tb1.Rows[index];
            mk.Text=row.Cells[0].Value.ToString().Trim();
            tk.Text=row.Cells[1].Value.ToString().Trim();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string makhoa = mk.Text.Trim();
                    
                    string sql = "delete from khoa where makhoa=@Ma";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", makhoa);
                 
                    cmd.ExecuteNonQuery();
                    Loadtb1();
                    mk.ResetText();
                    tk.ResetText();
                }
                catch (Exception ex)
                {

                }
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void quảnLíLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyLop f = new QuanLyLop();
            this.Hide();
            f.Show();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khoa f = new Khoa();
            this.Hide();
            f.Show();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLíSiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sinhvien f = new sinhvien();
            this.Hide();
            f.Show();
        }

        private void quảnLýCóVấnHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyCoVanHocTap f = new QuanLyCoVanHocTap();
            this.Hide();
            f.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan f = new QuanLyTaiKhoan();
            this.Hide();
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc f = new QuanLyMonHoc();
            this.Hide();
            f.Show();
        }

        private void quảnLíSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sinhvien f = new sinhvien();
            this.Hide();
            f.Show();
        }

        private void quảnLíLớpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            QuanLyLop f = new QuanLyLop();
            this.Hide();
            f.Show();
        }

        private void quảnLíKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khoa f = new Khoa();
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
    }
}
