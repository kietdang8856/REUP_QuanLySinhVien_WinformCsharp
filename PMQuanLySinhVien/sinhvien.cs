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
    public partial class sinhvien : Form
    {
        public sinhvien()
        {
            InitializeComponent();
            DataTable a = Loadcombokhoa();
            mk.DataSource=a;
            mk.DisplayMember="tenkhoa";
            mk.ValueMember = "makhoa";

            Loaddulieu();
        }

        private void Loaddulieu()
        {
            string connectionString = @"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;";
            string query = "SELECT sinhvien.masv, sinhvien.tensv, sinhvien.ngaysinh, sinhvien.gioitinh, sinhvien.quequan, sinhvien.ngaynhaphoc, khoa.tenkhoa, lop.malop, lop.tenlop " +
                           "FROM sinhvien " +
                           "INNER JOIN khoa ON sinhvien.makhoa = khoa.makhoa " +
                           "INNER JOIN lop ON sinhvien.malop = lop.malop";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    tb2.DataSource = dt;

                    // Setting column headers and formats
                    tb2.Columns[0].HeaderText = "MÃ SV";
                    tb2.Columns[1].HeaderText = "TÊN SV";
                    tb2.Columns[2].HeaderText = "NGÀY SINH";
                    tb2.Columns[3].HeaderText = "GIỚI TÍNH";
                    tb2.Columns[4].HeaderText = "QUÊ QUÁN";
                    tb2.Columns[5].HeaderText = "NGÀY NHẬP HỌC";
                    tb2.Columns[6].HeaderText = "TÊN KHOA";
                    tb2.Columns[7].HeaderText = "MÃ LỚP";
                    tb2.Columns[8].HeaderText = "TÊN LỚP";

                    tb2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    tb2.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
                    tb2.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("SQL Error: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string masv = msv.Text.Trim();
                    string tensv = tsv.Text.Trim();
                    DateTime ngaysinh = ns.Value.Date;
                    string gt = (nam.Checked) ? "Nam" : "Nữ";
                    string quequan=qq.Text.Trim();
                    DateTime ngaynhaphoc = nnh.Value.Date;
                    string makhoa = mk.SelectedValue.ToString();
                    string tenlop = ml.Text.Trim();

                    string sql = "insert into sinhvien values(@Ma,@Ten,@Ngaysinh,@GioiTinh,@Quequan,@Ngaynhaphoc,@Malop,@Makhoa)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", masv);
                    cmd.Parameters.AddWithValue("@Ten", tensv);
                    // Sử dụng giá trị từ DatePicker
                    cmd.Parameters.AddWithValue("@Ngaysinh", ngaysinh.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@GioiTinh", gt);
                    cmd.Parameters.AddWithValue("@Quequan", quequan);
                    cmd.Parameters.AddWithValue("@Ngaynhaphoc", ngaynhaphoc.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Makhoa", makhoa);
                    cmd.Parameters.AddWithValue("@Malop", tenlop);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm dữ liệu thành công!");
                    Loaddulieu();
                    ml.ResetText();
                    msv.ResetText();
                    tsv.ResetText();
                    qq.ResetText();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính"+ex);
                }
        }

        private void quảnLíTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan f= new QuanLyTaiKhoan();
            this.Hide();
       f.Show();
        }

        private void quảnLíKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khoa f= new Khoa();
            this.Hide();
            f.Show();
        }

        private void quảnLíLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyLop f= new QuanLyLop();
            this.Hide();
            f.Show();
        }

        private void quảnLíCốVấnHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyCoVanHocTap f=new QuanLyCoVanHocTap();
            this.Hide();
            f.Show();
        }

        private void quảnLíMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc f=new QuanLyMonHoc();
            this.Hide();
            f.Show();
        }

        private void thôngTinChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau f=new DoiMatKhau();
            this.Hide();
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f=new Form1();
            this.Hide();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string masv = msv.Text.Trim();
                    string tensv = tsv.Text.Trim();
                    DateTime ngaysinh = ns.Value.Date;
                    string gt = (nam.Checked) ? "Nam" : "Nữ";
                    string quequan = qq.Text.Trim();
                    DateTime ngaynhaphoc = nnh.Value.Date;
                    string makhoa = mk.SelectedValue.ToString();
                    string tenlop = ml.Text.Trim();

                    string sql = "update sinhvien set tensv=@Ten,ngaysinh=@Ngaysinh,gioitinh=@GioiTinh,quequan=@Quequan,ngaynhaphoc=@Ngaynhaphoc,malop=@Malop,makhoa=@Makhoa where masv=@Ma";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", masv);
                    cmd.Parameters.AddWithValue("@Ten", tensv);
                    // Sử dụng giá trị từ DatePicker
                    cmd.Parameters.AddWithValue("@Ngaysinh", ngaysinh.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@GioiTinh", gt);
                    cmd.Parameters.AddWithValue("@Quequan", quequan);
                    cmd.Parameters.AddWithValue("@Ngaynhaphoc", ngaynhaphoc.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Makhoa", makhoa);
                    cmd.Parameters.AddWithValue("@Malop", tenlop);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa dữ liệu thành công!");
                    Loaddulieu();
                    ml.ResetText();
                    msv.ResetText();
                    tsv.ResetText();
                    qq.ResetText();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính"+ex);
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

        private void tb2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = tb2.SelectedCells[0].RowIndex;
            DataGridViewRow row = tb2.Rows[index];
            msv.Text=row.Cells[0].Value.ToString().Trim();
            tsv.Text=row.Cells[1].Value.ToString().Trim();
            ns.Text=row.Cells[2].Value.ToString().Trim();
            string gt;
            gt=row.Cells[3].Value.ToString().Trim();
            if (gt.Equals("Nam"))
            {
                nam.Checked=true;
            }
            else
                nu.Checked=true;
            qq.Text=row.Cells[4].Value.ToString().Trim();
            nnh.Text=row.Cells[5].Value.ToString().Trim();
            mk.Text=row.Cells[6].Value.ToString().Trim();
            ml.Text=row.Cells[7].Value.ToString().Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string masv = msv.Text.Trim();
                    string tensv = tsv.Text.Trim();
                    DateTime ngaysinh = ns.Value.Date;
                    string gt = (nam.Checked) ? "Nam" : "Nữ";
                    string quequan = qq.Text.Trim();
                    DateTime ngaynhaphoc = nnh.Value.Date;
                    string makhoa = mk.SelectedValue.ToString();
                    string tenlop = ml.Text.Trim();

                    string sql = "delete from sinhvien where masv=@Ma";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Ma", masv);
                    cmd.Parameters.AddWithValue("@Ten", tensv);
                    // Sử dụng giá trị từ DatePicker
                    cmd.Parameters.AddWithValue("@Ngaysinh", ngaysinh.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@GioiTinh", gt);
                    cmd.Parameters.AddWithValue("@Quequan", quequan);
                    cmd.Parameters.AddWithValue("@Ngaynhaphoc", ngaynhaphoc.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Makhoa", makhoa);
                    cmd.Parameters.AddWithValue("@Malop", tenlop);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa dữ liệu thành công!");
                    Loaddulieu();
                    ml.ResetText();
                    msv.ResetText();
                    tsv.ResetText();
                    qq.ResetText();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi "+ex);
                }
        }

        private void điểmSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BangDiemSV f = new BangDiemSV();
            this.Hide();
            f.Show();
        }

        private void quảnLíSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sinhvien f = new sinhvien();
            this.Hide();
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Show();
        }

        private void tb2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void msv_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void quảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLíĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ml_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void qq_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tsv_TextChanged(object sender, EventArgs e)
        {

        }

        private void nnh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void nu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void ns_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
