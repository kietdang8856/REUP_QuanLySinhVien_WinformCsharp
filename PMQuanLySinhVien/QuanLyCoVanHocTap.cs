using System;
using System.Collections;
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
    public partial class QuanLyCoVanHocTap : Form
    {
        public QuanLyCoVanHocTap()
        {
            InitializeComponent();
            DataTable a = Loadcombokhoa();
            mk.DataSource=a;
            mk.DisplayMember="tenkhoa";
           mk.ValueMember = "makhoa";

        
            Loaddulieu();

        }

        private DataTable Loadcombokhoa()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
            {
                string query = "select makhoa,tenkhoa from khoa ";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(reader);
                conn.Close();
                return dt;
            }

        }

        private void mk_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
            {

                string sql = @"select khoa.tenkhoa,lop.malop from khoa 
             inner join lop on lop.makhoa=khoa.makhoa
                where (khoa.tenkhoa=N'"+mk.Text+@"')";

                // Thực thi truy vấn và lấy tập kết quả dưới dạng SqlDataReader
                SqlCommand cmd = new SqlCommand(sql, conn);
               conn.Open();


                SqlDataReader reader = cmd.ExecuteReader();
                ml.ResetText();//reset lại combobox trắng
                ml.Items.Clear(); // Xóa các mục cũ trước khi thêm mới

                while (reader.Read())
                {
                   //truy cập cột 2 bằng chỉ số
                    ml.Items.Add(reader[1].ToString());


                } 
          conn.Close();
            }
        }
        private void Loaddulieu()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT covanhoctap.macvht, covanhoctap.tencvht, covanhoctap.ngaysinh, covanhoctap.gioitinh, khoa.tenkhoa, lop.malop, lop.tenlop " +
                                                    "FROM covanhoctap " +
                                                    "INNER JOIN khoa ON covanhoctap.makhoa = khoa.makhoa " +
                                                    "INNER JOIN lop ON covanhoctap.malop = lop.malop", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    tb2.DataSource = dt;

                    // Set column headers according to the SQL query result order
                    tb2.Columns[0].HeaderText = "MÃ CỐ VẤN";    // Column 0: macvht
                    tb2.Columns[1].HeaderText = "TÊN CỐ VẤN";   // Column 1: tencvht
                    tb2.Columns[2].HeaderText = "NGÀY SINH";    // Column 2: ngaysinh
                    tb2.Columns[3].HeaderText = "GIỚI TÍNH";    // Column 3: gioitinh
                    tb2.Columns[4].HeaderText = "TÊN KHOA";     // Column 4: tenkhoa
                    tb2.Columns[5].HeaderText = "MÃ LỚP";       // Column 5: malop
                    tb2.Columns[6].HeaderText = "TÊN LỚP";      // Column 6: tenlop

                    tb2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // Format the date column, assuming it is in index 2 (NGÀY SINH)
                    tb2.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Load Dữ Liệu: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string macvht = mcv.Text.Trim();
                    string tencvht = tcv.Text.Trim();
                    DateTime ngaysinh = ns.Value.Date;
                    string gt = (nam.Checked) ? "Nam" : "Nữ";

                    string makhoa = mk.SelectedValue.ToString();
                    string tenlop=ml.Text.Trim();
                   
                    string sql = "insert into covanhoctap values(@Ma,@Ten,@Ngaysinh,@GioiTinh,@Makhoa,@Malop)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", macvht);
                    cmd.Parameters.AddWithValue("@Ten", tencvht);
                    // Sử dụng giá trị từ DatePicker
                    cmd.Parameters.AddWithValue("@Ngaysinh", ngaysinh.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@GioiTinh", gt);

                    cmd.Parameters.AddWithValue("@Makhoa", makhoa);
                    cmd.Parameters.AddWithValue("@Malop", tenlop);
                    cmd.ExecuteNonQuery();
   MessageBox.Show("Thêm dữ liệu thành công!");
                        Loaddulieu();
                        ml.ResetText();
                        mcv.ResetText();
                        tcv.ResetText();
                     
                    
                    
               

                   

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
            mcv.Text=row.Cells[0].Value.ToString().Trim();
            tcv.Text=row.Cells[1].Value.ToString().Trim();
            ns.Text=row.Cells[2].Value.ToString().Trim();
            string gt;
            gt=row.Cells[3].Value.ToString().Trim();
            if (gt.Equals("Nam"))
            {
                nam.Checked=true;
            }
            else
                nu.Checked=true;
            mk.Text=row.Cells[4].Value.ToString().Trim();
            ml.Text=row.Cells[5].Value.ToString().Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string macvht = mcv.Text.Trim();
                    string tencvht = tcv.Text.Trim();
                    DateTime ngaysinh = ns.Value.Date;
                    string gt = (nam.Checked) ? "Nam" : "Nữ";

                    string makhoa = mk.SelectedValue.ToString();
                    string tenlop = ml.Text.Trim();

                    string sql = "update covanhoctap set tencvht=@Ten,ngaysinh=@Ngaysinh,gioitinh=@GioiTinh,makhoa=@Makhoa,malop=@Malop where macvht=@Ma ";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", macvht);
                    cmd.Parameters.AddWithValue("@Ten", tencvht);
                    // Sử dụng giá trị từ DatePicker
                    cmd.Parameters.AddWithValue("@Ngaysinh", ngaysinh.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@GioiTinh", gt);

                    cmd.Parameters.AddWithValue("@Makhoa", makhoa);
                    cmd.Parameters.AddWithValue("@Malop", tenlop);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        ml.ResetText();
                        mcv.ResetText();
                        tcv.ResetText();
                        MessageBox.Show("Sửa dữ liệu thành công!");
                        Loaddulieu();
                    }
                    else
                    {
                        MessageBox.Show("Sửa dữ liệu thất bại.");
                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc  Dữ Liệu Trùng Lăp"+ex);
                }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string macvht = mcv.Text.Trim();
                    string tencvht = tcv.Text.Trim();
                    DateTime ngaysinh = ns.Value.Date;
                    string gt = (nam.Checked) ? "Nam" : "Nữ";

                    string makhoa = mk.SelectedValue.ToString();
                    string tenlop = ml.Text.Trim();

                    string sql = "delete from covanhoctap where macvht=@Ma ";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", macvht);
                 
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        ml.ResetText();
                        mcv.ResetText();
                        tcv.ResetText();
                        MessageBox.Show("Xóa dữ liệu thành công!");
                        Loaddulieu();
                    }
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu thất bại.");
                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính"+ex);
                }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
