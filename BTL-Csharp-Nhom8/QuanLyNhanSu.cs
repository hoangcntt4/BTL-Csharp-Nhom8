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
        //NHANVIEN_BLL nhanVien_BLL = new NHANVIEN_BLL();
        public QuanLyNhanSu()
        {
            InitializeComponent();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            //if (cbb_timTheo.SelectedItem.ToString().Equals("Mã nhân viên"))
            //{
            //    dgv_nhanVien.DataSource = nhanVien_BLL.TimNhanVien("MANV", txt_thongTin.Text);
            //}
            //if (cbb_timTheo.SelectedItem.ToString().Equals("Tên nhân viên"))
            //{
            //    dgv_nhanVien.DataSource = nhanVien_BLL.TimNhanVien("TENNV", txt_thongTin.Text);
            //}
            //if (cbb_timTheo.SelectedItem.ToString().Equals("Giới tính"))
            //{
            //    string gioiTinh = "";
            //    if (txt_thongTin.Text.Equals("Nam") || txt_thongTin.Text.Equals("nam"))
            //    {
            //        gioiTinh = "1";
            //    }
            //    if (txt_thongTin.Text.Equals("Nu") || txt_thongTin.Text.Equals("nu"))
            //    {
            //        gioiTinh = "0";
            //    }
            //    dgv_nhanVien.DataSource = nhanVien_BLL.TimNhanVien("GIOITNH", gioiTinh);
            //}
            //if (cbb_timTheo.SelectedItem.ToString().Equals("Số điện thoại"))
            //{
            //    dgv_nhanVien.DataSource = nhanVien_BLL.TimNhanVien("SODT", txt_thongTin.Text);
            //}
            //if (cbb_timTheo.SelectedItem.ToString().Equals("Địa chỉ"))
            //{
            //    dgv_nhanVien.DataSource = nhanVien_BLL.TimNhanVien("DIACHI", txt_thongTin.Text);
            //}
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn lưu nội dung vừa sửa?", "Thông báo", MessageBoxButtons.YesNo);
            string hoTen = dgv_nhanVien.Rows[indexOfDGV].Cells[1].Value.ToString();
            string gioiTinh = "0";
            //if (dlr == DialogResult.Yes)
            //{
            //    if (string.IsNullOrWhiteSpace(dgv_nhanVien.Rows[indexOfDGV].Cells[1].Value.ToString()) || string.IsNullOrWhiteSpace(dgv_nhanVien.Rows[indexOfDGV].Cells[3].Value.ToString()) || string.IsNullOrWhiteSpace(dgv_nhanVien.Rows[indexOfDGV].Cells[4].Value.ToString()))
            //    {
            //        MessageBox.Show("Không được để trắng");
            //        //QuanLyNhanSu_Load(sender, e);
            //    }
            //    else
            //    {
            //        if (dgv_nhanVien.Rows[indexOfDGV].Cells[6].Value.ToString().Equals("ADMIN") || dgv_nhanVien.Rows[indexOfDGV].Cells[6].Value.ToString().Equals("VHH") || dgv_nhanVien.Rows[indexOfDGV].Cells[6].Value.ToString().Equals("NV"))
            //        {
            //            if (dgv_nhanVien.Rows[indexOfDGV].Cells[2].Value.ToString().Equals("True"))
            //            {
            //                gioiTinh = "1";
            //            }
            //            string soDT = dgv_nhanVien.Rows[indexOfDGV].Cells[3].Value.ToString();
            //            string diaChi = dgv_nhanVien.Rows[indexOfDGV].Cells[4].Value.ToString();
            //            string matKhau = dgv_nhanVien.Rows[indexOfDGV].Cells[5].Value.ToString();
            //            string tinhtrang = dgv_nhanVien.Rows[indexOfDGV].Cells[6].Value.ToString();
            //            NHANVIEN temp = new NHANVIEN(selectedID, hoTen, gioiTinh, soDT, diaChi, matKhau, tinhtrang);
            //            nhanVien_BLL.SuaNhanVien(temp);
            //            QuanLyNhanSu_Load(sender, e);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Tình trạng chưa hợp lệ");
            //        }

            //    }
            //}

        }

        private void QuanLyNhanSu_Load(object sender, EventArgs e)
        {
            //dgv_nhanVien.DataSource = nhanVien_BLL.ChonNhanVien();
            //txt_maNV.Text = "NV00" + nhanVien_BLL.ChonNhanVien().Rows.Count;
            //txt_hoTen.Text = "";
            //txt_diaChi.Text = "";
            //txt_matKhau.Text = "";
            //txt_soDT.Text = "";
            //rdb_nam.Checked = false;
            //rdb_nu.Checked = false;
        }

        private void dgv_nhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexOfDGV = e.RowIndex;
                selectedID = dgv_nhanVien.Rows[indexOfDGV].Cells[0].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_diaChi.Text) || string.IsNullOrWhiteSpace(txt_hoTen.Text) || string.IsNullOrWhiteSpace(txt_maNV.Text) || string.IsNullOrWhiteSpace(txt_matKhau.Text) || string.IsNullOrWhiteSpace(txt_soDT.Text))
            //{
            //    MessageBox.Show("Không được trắng giá trị");
            //}
            //else if (txt_soDT.Text.Length != 10)
            //{
            //    MessageBox.Show("Số điện thoại phải có 10 số");
            //}
            //else if (!rdb_nam.Checked && !rdb_nu.Checked)
            //{
            //    MessageBox.Show("Vui lòng chọn giới tính");
            //}
            //else
            //{
            //    try
            //    {
            //        string gioiTinh = "1";
            //        if (rdb_nu.Checked)
            //        {
            //            gioiTinh = "0";
            //        }
            //        NHANVIEN temp = new NHANVIEN(txt_maNV.Text, txt_hoTen.Text, gioiTinh, txt_soDT.Text, txt_diaChi.Text, txt_matKhau.Text, cbbTinhTrang.Text);
            //        nhanVien_BLL.ThemNhanVien(temp);
            //        MessageBox.Show("Thêm thành công!");
            //        QuanLyNhanSu_Load(sender, e);
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message);
            //    }
            //}
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
    }
}
