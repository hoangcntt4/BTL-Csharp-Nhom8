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
    public partial class DangNhap : Form
    {
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        public static string MaNVDangNhap = "";
        public DangNhap()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

        }

        private bool ValiData()
        {
            if (txt_userName.Text == "")
            {
                errorProvider1.SetError(txt_userName, "Tên đăng nhập không được để trống!");
                txt_userName.Focus();
                return false;
            }
            if (txt_passWord.Text == "")
            {
                errorProvider1.SetError(txt_passWord, "Mật khẩu không được để trống!");
                txt_passWord.Focus();
                return false;
            }
            return true;
        }


        private void btn_login_Click(object sender, EventArgs e)
        {
            if (ValiData())
            {
                var user = db.Nhanviens.Find(txt_userName.Text);
                if (user != null)
                {
                    if (user.Password == txt_passWord.Text)
                    {
                        if (user.Status.Equals("ADMIN") || user.Status.Equals("admin") || user.Status.Equals("Admin"))
                        {
                            MaNVDangNhap = user.Manv.ToString();
                            CuaSoChinh cuaSoChinh = new CuaSoChinh();
                            this.Hide();
                            MessageBox.Show("Bạn đã đăng nhập với tư cách ADMIN");
                           
                            cuaSoChinh.ShowDialog();

                            this.Show();
                           
                          
                        }
                        else
                        {
                            MaNVDangNhap = user.Manv.ToString();
                            CuaSoChinhNhanVien cuaSoChinhNhanVien = new CuaSoChinhNhanVien();

                            this.Hide();
                            cuaSoChinhNhanVien.TKMK(txt_userName.Text, txt_passWord.Text);
                            MessageBox.Show("Bạn đã đăng nhập với tư cách nhân viên");
                           
                            cuaSoChinhNhanVien.ShowDialog();

                            this.Show();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu của bạn chưa đúng!");
                        txt_passWord.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên tài khoản của bạn chưa đúng!");
                    txt_userName.Focus();
                }
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_passWord.PasswordChar = '\0';
            }
            else
                txt_passWord.PasswordChar = '*';
        }

        private void txt_userName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_userName, "");
        }

        private void txt_passWord_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_passWord, "");
        }
    }
}
