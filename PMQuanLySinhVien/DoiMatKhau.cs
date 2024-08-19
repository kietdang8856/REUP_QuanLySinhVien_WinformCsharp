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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=KIETDANG\KIET;Initial Catalog=QLSV2;Integrated Security=True;"))
                try
                {
                    string tendn = tdn.Text.Trim();
                    string matkm = mkm.Text.Trim();

                   
                    string sql = "update taikhoan set matkhau=@Matkhau where tendangnhap=@Tendn";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@Tendn", tendn);
                    cmd.Parameters.AddWithValue("@Matkhau", matkm);
               

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đổi Mật Khẩu Thành Công");
                    Form1 a=new Form1();
                    this.Hide();
                    a.Show();

                



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm Tra Lại Kết Lỗi Hoặc Nhập Dữ Liệu Trùng Khóa Chính");
                }
        }

        private void tdn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
