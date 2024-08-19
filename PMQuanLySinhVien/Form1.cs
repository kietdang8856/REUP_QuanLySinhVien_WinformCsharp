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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tdn.Text.Trim();
            string password = mk.Text.Trim();

            // Kết nối đến cơ sở dữ liệu và kiểm tra thông tin đăng nhập
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
            {
                conn.Open();
                string query = "SELECT loaitaikhoan FROM taikhoan WHERE tendangnhap = @username AND matkhau = @password";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    string role = result.ToString();
                    if (role == "Cố vấn học tập")
                    {
                        BangDiemSV form1 = new BangDiemSV();
                        form1.Show();
                        this.Hide();
                       
                    }
                    else if (role == "Quản Trị")
                    {
                        Khoa form2 = new Khoa();
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tdn.ResetText();
            mk.ResetText();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DoiMatKhau f=new DoiMatKhau();
            this.Hide();
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
