using BTL_Csharp_Nhom8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Csharp_Nhom8
{
    public partial class DoiMatKhau : Form
    {
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        public string taikhoan { get; set; }
        public string matkhau { get; set; }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MKCu.Text) || string.IsNullOrWhiteSpace(txt_MKMoi.Text) || string.IsNullOrWhiteSpace(txt_XacNhanMK.Text))
            {
                MessageBox.Show("Không được để trống dữ liệu");
            }
            else
            {
                if (matkhau == txt_MKCu.Text && txt_MKMoi.Text == txt_XacNhanMK.Text)
                {
                    MessageBox.Show("Đổi thành công");
                   // nhanVien_BLL.UpdateMK(taikhoan, txt_MKMoi.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại");
                    txt_XacNhanMK.Clear();
                    txt_MKMoi.Clear();
                    txt_MKCu.Clear();
                }
            }

        }
        public void funData(string username, string password)
        {
            taikhoan = username;
            matkhau = password;
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
