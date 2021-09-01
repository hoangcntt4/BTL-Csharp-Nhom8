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
        string manv_current = DangNhap.MaNVDangNhap;
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private bool ValiData()
        {
            if (txt_MKCu.Text == "")
            {
                errorProvider1.SetError(txt_MKCu, "Mật khẩu cũ không được để trống!");
                txt_MKCu.Focus();
                return false;
            }
            if (txt_MKMoi.Text == "")
            {
                errorProvider1.SetError(txt_MKMoi, "Mật khẩu mới không được để trống!");
                txt_MKMoi.Focus();
                return false;
            }
            if (txt_XacNhanMK.Text == "")
            {
                errorProvider1.SetError(txt_XacNhanMK, "Mật khẩu xác nhận không được để trống!");
                txt_XacNhanMK.Focus();
                return false;
            }
            return true;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (ValiData())
            {
                var nv = db.Nhanviens.Find(manv_current);
                if (nv.Password == txt_MKCu.Text)
                {
                    if (txt_MKMoi.Text == txt_XacNhanMK.Text)
                    {
                        nv.Password = txt_MKMoi.Text;
                        db.SaveChanges();
                        MessageBox.Show("Đổi thành công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới và xác nhận chưa giống nhau, nhập lại!");
                        txt_MKMoi.Clear();
                        txt_XacNhanMK.Clear();
                        txt_MKMoi.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai mật khẩu cũ, Nhập lại");
                    txt_MKCu.Clear();
                    txt_MKCu.Focus();
                }
            }

        }


        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void txt_MKCu_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_MKCu, "");
        }

        private void txt_MKMoi_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_MKMoi, "");
        }

        private void txt_XacNhanMK_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_XacNhanMK, "");
        }
    }
}
