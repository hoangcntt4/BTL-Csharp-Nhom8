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
    public partial class QuanLyHoaDonNhap : Form
    {
        //PHIEUNHAP_BLL phieuNhap_BLL = new PHIEUNHAP_BLL();
        //DONGPNHAP_BLL dongPNhap_BLL = new DONGPNHAP_BLL();
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        int indexOfDGVPNhap;

        public QuanLyHoaDonNhap()
        {
            InitializeComponent();
        }

        private void QuanLyHoaDonNhap_Load(object sender, EventArgs e)
        {
            //dgv_phieuNhap.DataSource = phieuNhap_BLL.ToanBoPhieuNhap();
            //cbb_kieuTK.SelectedIndex = 0;
            //lbl_chonNgay.Visible = false;
            //dtp_ngayNhap.Visible = false;
        }

        private void dgv_phieuNhap_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    indexOfDGVPNhap = e.RowIndex;
            //    string maPN_current = dgv_phieuNhap.Rows[indexOfDGVPNhap].Cells[0].Value.ToString();
            //    txt_maPhieuNhap.Text = maPN_current;
            //    dtp_ngayNhapCT.Text = (DateTime.Parse(dongPNhap_BLL.TimTheoKieu("NGAYNHAP", maPN_current).Rows[0]["NGAYNHAP"].ToString())).ToString();
            //    txt_maNCC.Text = dongPNhap_BLL.TimTheoKieu("NHACC.MANCC", maPN_current).Rows[0]["MANCC"].ToString();
            //    txt_tenNCC.Text = dongPNhap_BLL.TimTheoKieu("NHACC.TENNCC", maPN_current).Rows[0]["TENNCC"].ToString();
            //    txt_maNV.Text = dongPNhap_BLL.TimTheoKieu("NHANVIEN.MANV", maPN_current).Rows[0]["MANV"].ToString();
            //    txt_tenNV.Text = dongPNhap_BLL.TimTheoKieu("NHANVIEN.TENNV", maPN_current).Rows[0]["TENNV"].ToString();
            //    dgv_chiTietPN.DataSource = dongPNhap_BLL.ToanBoSanPham(maPN_current);
            //    int tongtien = 0;
            //    for (int i = 0; i < dgv_chiTietPN.Rows.Count; i++)
            //    {
            //        tongtien += Convert.ToInt32(dgv_chiTietPN.Rows[i].Cells[4].Value.ToString());
            //    }
            //    lbl_tongTien.Text = tongtien + "VND";
            //}
            //catch (Exception ex)
            //{


            //}

        }

        private void btn_refresh_Click_1(object sender, EventArgs e)
        {
            QuanLyHoaDonNhap_Load(sender, e);
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {

            //if (cbb_kieuTK.SelectedItem.ToString().Equals("Ngày nhập"))
            //{
            //    dgv_phieuNhap.DataSource = phieuNhap_BLL.TimTheoKieu("NGAYNHAP", dtp_ngayNhap.Text);
            //}
            //else
            //{
            //    if (cbb_kieuTK.SelectedItem.ToString().Equals("Tất cả"))
            //    {
            //        try
            //        {
            //            dgv_phieuNhap.DataSource = phieuNhap_BLL.ToanBoPhieuNhap();
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
            //                    dgv_phieuNhap.DataSource = phieuNhap_BLL.TimTheoKieu("MANV", txt_tuKhoaTK.Text);
            //                else if (cbb_kieuTK.SelectedItem.ToString().Equals("Mã phiếu nhập"))
            //                    dgv_phieuNhap.DataSource = phieuNhap_BLL.TimTheoKieu("MAPN", txt_tuKhoaTK.Text);
            //                else if (cbb_kieuTK.SelectedItem.ToString().Equals("Mã nhà cung cấp"))
            //                    dgv_phieuNhap.DataSource = phieuNhap_BLL.TimTheoKieu("MANCC", txt_tuKhoaTK.Text);
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
                if (cbb_kieuTK.SelectedItem.ToString().Equals("Ngày nhập"))
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
