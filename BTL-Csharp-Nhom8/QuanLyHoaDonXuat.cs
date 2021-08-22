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
    
    public partial class QuanLyHoaDonXuat : Form
    {
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        //PHIEUXUAT_BLL phieuXuat_BLL = new PHIEUXUAT_BLL();
        //DONGPXUAT_BLL dongPXuat_BLL = new DONGPXUAT_BLL();
        int indexOfDGVPXuat;
        public QuanLyHoaDonXuat()
        {
            InitializeComponent();
        }

        private void dgv_phieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    indexOfDGVPXuat = e.RowIndex;
            //    string maPX_current = dgv_phieuXuat.Rows[indexOfDGVPXuat].Cells[0].Value.ToString();
            //    txt_maPhieuXuat.Text = maPX_current;
            //    dtp_ngayXuatCT.Value = DateTime.Parse(dongPXuat_BLL.TimTheoKieu("NGAYXUAT", maPX_current).Rows[0]["NGAYXUAT"].ToString());
            //    txt_maKH.Text = dongPXuat_BLL.TimTheoKieu("KHACHHANG.MAKH", maPX_current).Rows[0]["MAKH"].ToString();
            //    txt_tenKH.Text = dongPXuat_BLL.TimTheoKieu("KHACHHANG.TENKH", maPX_current).Rows[0]["TENKH"].ToString();
            //    txt_maNV.Text = dongPXuat_BLL.TimTheoKieu("NHANVIEN.MANV", maPX_current).Rows[0]["MANV"].ToString();
            //    txt_tenNV.Text = dongPXuat_BLL.TimTheoKieu("NHANVIEN.TENNV", maPX_current).Rows[0]["TENNV"].ToString();
            //    dgv_chiTietPX.DataSource = dongPXuat_BLL.ToanBoSanPham(maPX_current);
            //    int tongtien = 0;
            //    for (int i = 0; i < dgv_chiTietPX.Rows.Count; i++)
            //    {
            //        tongtien += Convert.ToInt32(dgv_chiTietPX.Rows[i].Cells[4].Value.ToString());
            //    }
            //    lbl_tongTien.Text = tongtien + "VND";
            //}
            //catch (Exception ex)
            //{


            //}
        }

        private void QuanLyHoaDonXuat_Load(object sender, EventArgs e)
        {
            //dgv_phieuXuat.DataSource = phieuXuat_BLL.ToanBoPhieuXuat();
            //cbb_kieuTK.SelectedIndex = 0;
            //lbl_chonNgay.Visible = false;
            //dtp_ngayNhap.Visible = false;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            QuanLyHoaDonXuat_Load(sender, e);
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            //if (cbb_kieuTK.SelectedItem.ToString().Equals("Ngày xuất"))
            //{
            //    dgv_phieuXuat.DataSource = phieuXuat_BLL.TimTheoKieu("NGAYXUAT", dtp_ngayNhap.Text);
            //}
            //else
            //{
            //    if (cbb_kieuTK.SelectedItem.ToString().Equals("Tất cả"))
            //    {
            //        try
            //        {
            //            dgv_phieuXuat.DataSource = phieuXuat_BLL.ToanBoPhieuXuat();
            //        }
            //        catch (Exception ex)
            //        {

            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //    else
            //    {
            //        if (string.IsNullOrWhiteSpace(txt_tuKhoaTK.Text))
            //        {
            //            MessageBox.Show("Nhập từ khóa tìm kiếm!");
            //        }
            //        else
            //        {
            //            try
            //            {
            //                if (cbb_kieuTK.SelectedItem.ToString().Equals("Mã nhân viên"))
            //                    dgv_phieuXuat.DataSource = phieuXuat_BLL.TimTheoKieu("MANV", txt_tuKhoaTK.Text);
            //                else if (cbb_kieuTK.SelectedItem.ToString().Equals("Mã phiếu xuất"))
            //                    dgv_phieuXuat.DataSource = phieuXuat_BLL.TimTheoKieu("MAPN", txt_tuKhoaTK.Text);
            //                else if (cbb_kieuTK.SelectedItem.ToString().Equals("Mã khách hàng"))
            //                    dgv_phieuXuat.DataSource = phieuXuat_BLL.TimTheoKieu("MAKH", txt_tuKhoaTK.Text);
            //            }
            //            catch (Exception)
            //            {
            //                MessageBox.Show("Không tìm được!");
            //            }
            //        }
            //    }

            //}
        }

        private void cbb_kieuTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_kieuTK.SelectedItem.ToString().Equals("Tất cả"))
            {
                dtp_ngayNhap.Visible = false;
                txt_tuKhoaTK.Visible = false;
                lbl_chonNgay.Visible = false;
                lbl_thongTinTK.Visible = false;
            }
            else
            {
                if (cbb_kieuTK.SelectedItem.ToString().Equals("Ngày xuất"))
                {
                    dtp_ngayNhap.Visible = true;
                    txt_tuKhoaTK.Visible = false;
                    lbl_chonNgay.Visible = true;
                    lbl_thongTinTK.Visible = false;
                }
                else
                {
                    dtp_ngayNhap.Visible = false;
                    txt_tuKhoaTK.Visible = true;
                    lbl_chonNgay.Visible = false;
                    lbl_thongTinTK.Visible = true;
                }
            }
        }
    }
}
