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
    public partial class QuanLyKhachHang : Form
    {
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
       Khachhang khachHang_BLL = new Khachhang();
        Dongpxuat phieuXuat_BLL = new Dongpxuat();
        int indexOfDGV;
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            cbb_kieuTK.SelectedIndex = 0;
            ckb_nam.Visible = false;
            lbl_tuKhoaTK.Visible = false;
            txt_tuKhoaTK.Visible = false;
           // dgv_khachHang.DataSource = khachHang_BLL.ChonKhachHang();
        }

        private void cbb_kieuTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_kieuTK.SelectedItem.ToString().Equals("Tất cả"))
            {
                ckb_nam.Visible = false;
                txt_tuKhoaTK.Visible = false;
                lbl_tuKhoaTK.Visible = false;
            }
            else if (cbb_kieuTK.SelectedItem.ToString().Equals("SĐT khách hàng") || cbb_kieuTK.SelectedItem.ToString().Equals("Tên khách hàng"))
            {
                ckb_nam.Visible = false;
                txt_tuKhoaTK.Visible = true;
                lbl_tuKhoaTK.Visible = true;
            }
            else
            {
                ckb_nam.Visible = true;
                txt_tuKhoaTK.Visible = false;
                lbl_tuKhoaTK.Visible = false;
            }
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            //if (cbb_kieuTK.SelectedItem.ToString().Equals("Tất cả"))
            //{
            //    dgv_khachHang.DataSource = khachHang_BLL.ChonKhachHang();
            //}
            //else if (cbb_kieuTK.SelectedItem.ToString().Equals("Giới tính"))
            //{
            //    if (ckb_nam.Checked == true)
            //    {
            //        dgv_khachHang.DataSource = khachHang_BLL.TimKhachHang("GIOITNH", "1");
            //    }
            //    else
            //    {
            //        dgv_khachHang.DataSource = khachHang_BLL.TimKhachHang("GIOITNH", "0");
            //    }
            //}
            //else
            //{
            //    if (string.IsNullOrWhiteSpace(txt_tuKhoaTK.Text))
            //    {
            //        MessageBox.Show("Nhập thông tin tìm kiếm!");
            //    }
            //    else
            //    {
            //        if (cbb_kieuTK.SelectedItem.ToString().Equals("SĐT khách hàng"))
            //        {
            //            dgv_khachHang.DataSource = khachHang_BLL.TimKhachHang("SDT", txt_tuKhoaTK.Text);
            //        }
            //        else if (cbb_kieuTK.SelectedItem.ToString().Equals("Tên khách hàng"))
            //        {
            //            dgv_khachHang.DataSource = khachHang_BLL.TimKhachHang("TENKH", txt_tuKhoaTK.Text);
            //        }
            //    }
            //}
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string maKH = dgv_khachHang.Rows[indexOfDGV].Cells[0].Value.ToString();
            string tenKH = dgv_khachHang.Rows[indexOfDGV].Cells[1].Value.ToString();
            string gioiTinh;
            if (dgv_khachHang.Rows[indexOfDGV].Cells[2].Value.ToString().Equals("True"))
            {
                gioiTinh = "1";
            }
            else
            {
                gioiTinh = "0";
            }
            string sdt = dgv_khachHang.Rows[indexOfDGV].Cells[3].Value.ToString();
            DialogResult kq = MessageBox.Show("Bạn có muốn sửa thông tin khách hàng này không?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (kq == DialogResult.Yes)
            //{
            //    if (string.IsNullOrWhiteSpace(tenKH))
            //    {
            //        MessageBox.Show("Không để trống tên!");
            //    }
            //    else
            //    {
            //        try
            //        {
            //            KHACHHANG temp = new KHACHHANG(maKH, tenKH, gioiTinh, sdt);
            //            khachHang_BLL.SuaKhachHang(temp);
            //            MessageBox.Show("Thành công!");
            //            QuanLyKhachHang_Load(sender, e);
            //        }
            //        catch (Exception ex)
            //        {

            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //}
        }

        private void dgv_khachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    indexOfDGV = e.RowIndex;
            //    string maKH_current = dgv_khachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    dgv_phieuXuat.DataSource = phieuXuat_BLL.TimTheoKieu("MAKH", maKH_current);
            //}
            //catch (Exception ex)
            //{


            //}
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang_Load(sender, e);
        }
    }
}
