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
    public partial class QuanLyNhanSu : Form
    {
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        int indexOfDGV;
        string selectedID;

        public QuanLyNhanSu()
        {
            InitializeComponent();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            if (cbb_timTheo.SelectedItem.ToString().Equals("Mã nhân viên"))
            {
                var data = db.Nhanviens.Where(s => s.Manv.Equals(txt_maNV.Text)).Select(s => new { s.Manv, s.Tennv, s.Gioitnh, s.Sodt, s.Diachi, s.Password, s.Status }).ToList();
                dgv_nhanVien.DataSource = data;
            }
            if (cbb_timTheo.SelectedItem.ToString().Equals("Tên nhân viên"))
            {
                var data = db.Nhanviens.Where(s => s.Tennv.Equals(TENNV)).Select(s => new { s.Manv, s.Tennv, s.Gioitnh, s.Sodt, s.Diachi, s.Password, s.Status }).ToList();
                dgv_nhanVien.DataSource = data;
            }
            if (cbb_timTheo.SelectedItem.ToString().Equals("Giới tính"))
            {

                int gioiTinh = 0;
                if (txt_thongTin.Text.Equals("Nam") || txt_thongTin.Text.Equals("nam"))
                {
                    gioiTinh = 1;
                }
                if (txt_thongTin.Text.Equals("Nu") || txt_thongTin.Text.Equals("nu") || txt_thongTin.Text.Equals("Nữ") || txt_thongTin.Text.Equals("nữ"))
                {
                    gioiTinh = 0;
                }
                var data = db.Nhanviens.Where(s => s.Gioitnh.Equals(false)).Select(s => new { s.Manv, s.Tennv, s.Gioitnh, s.Sodt, s.Diachi, s.Password, s.Status }).ToList();
                if (gioiTinh == 1)
                {
                    data = db.Nhanviens.Where(s => s.Gioitnh.Equals(true)).Select(s => new { s.Manv, s.Tennv, s.Gioitnh, s.Sodt, s.Diachi, s.Password, s.Status }).ToList();
                }
                dgv_nhanVien.DataSource = data;
            }
            if (cbb_timTheo.SelectedItem.ToString().Equals("Số điện thoại"))
            {
                var data = db.Nhanviens.Where(s => s.Sodt.Equals(txt_soDT.Text)).Select(s => new { s.Manv, s.Tennv, s.Gioitnh, s.Sodt, s.Diachi, s.Password, s.Status }).ToList();
                dgv_nhanVien.DataSource = data;
            }
            if (cbb_timTheo.SelectedItem.ToString().Equals("Địa chỉ"))
            {
                var data = db.Nhanviens.Where(s => s.Diachi.Equals(txt_diaChi.Text)).Select(s => new { s.Manv, s.Tennv, s.Gioitnh, s.Sodt, s.Diachi, s.Password, s.Status }).ToList();

                dgv_nhanVien.DataSource = data;
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (ValiData())
            {
                DialogResult kq = MessageBox.Show("Bạn chắc chắn muốn lưu nội dung vừa sửa?", "Thông báo", MessageBoxButtons.YesNo);
                if (kq == DialogResult.Yes)
                {
                    Nhanvien newnv = db.Nhanviens.Find(txt_maNV.Text);
                    newnv.Tennv = txt_hoTen.Text;
                    if (rdb_nam.Checked == true)
                    {
                        newnv.Gioitnh = true;
                    }
                    else
                    {
                        newnv.Gioitnh = false;
                    }

                    newnv.Sodt = txt_soDT.Text;
                    newnv.Diachi = txt_diaChi.Text;
                    newnv.Password = txt_matKhau.Text;
                    newnv.Status = cbbTinhTrang.Text;
                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công!");
                    QuanLyNhanSu_Load(sender, e);
                }
            }

        }
        private void LoadData()
        {
            var data = db.Nhanviens.Select(s => new { s.Manv, s.Tennv, s.Gioitnh, s.Sodt, s.Diachi, s.Password, s.Status });
            dgv_nhanVien.DataSource = data.ToList();
        }

        private void QuanLyNhanSu_Load(object sender, EventArgs e)
        {
            LoadData();
            txt_maNV.Text = "NV00" + (db.Nhanviens.Select(s => s).Count() + 1).ToString();
            txt_maNV.ReadOnly = true;
            txt_hoTen.Text = "";
            txt_diaChi.Text = "";
            txt_matKhau.Text = "";
            txt_soDT.Text = "";
            rdb_nam.Checked = true;
            rdb_nu.Checked = false;
            butRefresh.Visible = false;
        }

        private void dgv_nhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexOfDGV = e.RowIndex;
                txt_maNV.Text = dgv_nhanVien.Rows[indexOfDGV].Cells[0].Value.ToString();
                txt_hoTen.Text = dgv_nhanVien.Rows[indexOfDGV].Cells[1].Value.ToString();

                if (dgv_nhanVien.Rows[indexOfDGV].Cells[2].Value.Equals(true))
                {
                    rdb_nam.Checked = true;
                }
                else
                {
                    rdb_nu.Checked = true;
                }
                txt_soDT.Text = dgv_nhanVien.Rows[indexOfDGV].Cells[3].Value.ToString().Trim();
                txt_diaChi.Text = dgv_nhanVien.Rows[indexOfDGV].Cells[4].Value.ToString();
                txt_matKhau.Text = dgv_nhanVien.Rows[indexOfDGV].Cells[5].Value.ToString();
                cbbTinhTrang.Text = dgv_nhanVien.Rows[indexOfDGV].Cells[6].Value.ToString();
                selectedID = dgv_nhanVien.Rows[indexOfDGV].Cells[0].Value.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool ValiData()
        {
        
            
            if (txt_hoTen.Text == "")
            {
                errorProvider1.SetError(txt_hoTen, "Họ tên không được để trống!");
                txt_hoTen.Focus();
                return false;
            }
            if (rdb_nam.Checked == false && rdb_nu.Checked == false)
            {
                errorProvider1.SetError(rdb_nam, "Bạn phải chọn giới tính!");
                return false;
            }
            if (txt_soDT.Text == "")
            {
                errorProvider1.SetError(txt_soDT, "Số điện thoại không được để trống!");
                txt_soDT.Focus();
                return false;
            }
            else if (txt_soDT.Text.Length < 10 || txt_soDT.Text.Length > 10)
            {
                errorProvider1.SetError(txt_soDT, "Số điện thoại chỉ được có 10 chu số!");
                txt_soDT.Focus();
                return false;
            }
            else if (true)
            {
                var sdt = txt_soDT.Text.ToString().Trim();
                for (int i = 0; i < sdt.Length; i++)
                {
                    try
                    {
                        var c = int.Parse(sdt[i].ToString());
                    }
                    catch
                    {
                        errorProvider1.SetError(txt_soDT, "Số điện thoại chỉ được là các chữ số!");
                        txt_soDT.Focus();
                        return false;
                    }
                }
            }

            if (txt_diaChi.Text == "")
            {
                errorProvider1.SetError(txt_diaChi, "Địa chỉ không được để trống!");
                txt_diaChi.Focus();
                return false;
            }

            if (txt_matKhau.Text == "")
            {
                errorProvider1.SetError(txt_matKhau, "Mật khẩu không được để trống!");
                txt_matKhau.Focus();
                return false;
            }
            else if (txt_matKhau.Text.Length > 15)
            {
                errorProvider1.SetError(txt_matKhau, "Mật khẩu không được quá 15 kí tự!");
                txt_matKhau.Focus();
                return false;
            }
            if (cbbTinhTrang.Text == "")
            {
                errorProvider1.SetError(cbbTinhTrang, "Tình trạng không được để trống!");
                cbbTinhTrang.Focus();
                return false;
            }
            else if (cbbTinhTrang.Text != "ADMIN" && cbbTinhTrang.Text != "NV")
            {
                errorProvider1.SetError(cbbTinhTrang, "Tình trạng chỉ chọn 'ADMIN' hoặc 'NV'!");
                cbbTinhTrang.Focus();
                return false;
            }

            return true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            var ma = db.Nhanviens.Find(txt_maNV.Text);
            if (ma != null)
            {
                errorProvider1.SetError(txt_maNV, "Mã nhân viên trùng, nhấn 'Refresh' !");
                butRefresh.Visible = true;
               
            }
            else
            if (ValiData())
            {
                DialogResult kq = MessageBox.Show("Bạn chắc chắn muốn thêm nhân viên này?", "Thông báo", MessageBoxButtons.YesNo);
                if (kq == DialogResult.Yes)
                {
                    try
                    {

                        string gioiTinh = "1";
                        if (rdb_nu.Checked)
                        {
                            gioiTinh = "0";
                        }
                        Nhanvien newnv = new Nhanvien();
                        newnv.Manv = txt_maNV.Text;
                        newnv.Tennv = txt_hoTen.Text;
                        if (rdb_nam.Checked == true)
                        {
                            newnv.Gioitnh = true;
                        }
                        else
                        {
                            newnv.Gioitnh = false;
                        }

                        newnv.Sodt = txt_soDT.Text;
                        newnv.Diachi = txt_diaChi.Text;
                        newnv.Password = txt_matKhau.Text;
                        newnv.Status = cbbTinhTrang.Text;
                        db.Nhanviens.Add(newnv);
                        db.SaveChanges();
                        MessageBox.Show("Thêm thành công!");
                        QuanLyNhanSu_Load(sender, e);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void txt_soDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_hoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void grb_them_Enter(object sender, EventArgs e)
        {
            cbbTinhTrang.SelectedIndex = 0;
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            txt_maNV.Text = "NV00" + (db.Nhanviens.Select(s => s).Count() + 1).ToString(); ;
            butRefresh.Visible = false;
            txt_maNV_Validated(sender, e);
        }

        private void txt_hoTen_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_hoTen, "");
        }

        private void rdb_nam_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(rdb_nam, "");
        }

        private void txt_soDT_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_soDT, "");
        }

        private void txt_diaChi_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_diaChi, "");
        }

        private void txt_matKhau_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_matKhau, "");
        }

        private void cbbTinhTrang_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbbTinhTrang, "");
        }

        private void txt_maNV_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_maNV, "");
        }
    }
}
