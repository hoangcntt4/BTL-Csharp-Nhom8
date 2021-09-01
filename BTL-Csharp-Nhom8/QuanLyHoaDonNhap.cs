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

        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        int indexOfDGVPNhap;

        public QuanLyHoaDonNhap()
        {
            InitializeComponent();

        }


        private void QuanLyHoaDonNhap_Load(object sender, EventArgs e)
        {
            var data = db.Pnhaps.Select(s => new { s.Mapn, s.ManccNavigation.Tenncc, s.ManvNavigation.Tennv, s.Ngaynhap });
            dgv_phieuNhap.DataSource = data.ToList();
            cbb_kieuTK.SelectedIndex = 0;
            lbl_chonNgay.Visible = false;
            dtp_ngayNhap.Visible = false;
        }

        private void dgv_phieuNhap_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexOfDGVPNhap = e.RowIndex;
                string maPN_current = dgv_phieuNhap.Rows[indexOfDGVPNhap].Cells[0].Value.ToString();
                var phieunhap = db.Pnhaps.Find(maPN_current);

                txt_maPhieuNhap.Text = maPN_current;
                dtp_ngayNhapCT.Value = phieunhap.Ngaynhap;
                txt_maNCC.Text = phieunhap.Mancc.ToString();
                txt_tenNCC.Text = db.Nhaccs.Where(s => s.Mancc.Equals(phieunhap.Mancc)).Select(s => s.Tenncc).FirstOrDefault().ToString();
                txt_maNV.Text = phieunhap.Manv.ToString();
                txt_tenNV.Text = db.Nhanviens.Where(s => s.Manv.Equals(phieunhap.Manv)).Select(s => s.Tennv).FirstOrDefault().ToString();
                dgv_chiTietPN.DataSource = db.Dongpnhaps.Where(s => s.Mapn.Equals(maPN_current)).Select(s => new { s.Masp, s.MaspNavigation.Tensp, s.Soluongnhap, s.Dongianhap, Tổng = (s.Soluongnhap) * (s.Dongianhap) }).ToList();
                int tongtien = 0;
                for (int i = 0; i < dgv_chiTietPN.Rows.Count; i++)
                {
                    tongtien += Convert.ToInt32(dgv_chiTietPN.Rows[i].Cells[4].Value.ToString());
                }
                lbl_tongTien.Text = tongtien + "VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btn_refresh_Click_1(object sender, EventArgs e)
        {
            QuanLyHoaDonNhap_Load(sender, e);
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {

            if (cbb_kieuTK.SelectedItem.ToString().Equals("Ngày nhập"))
            {
                dgv_phieuNhap.DataSource = db.Pnhaps.Where(s => s.Ngaynhap.Equals(dtp_ngayNhap.Value)).Select(s => new { s.Mapn, s.ManccNavigation.Tenncc, s.ManvNavigation.Tennv, s.Ngaynhap }).ToList();
            }
            else
            {
                if (cbb_kieuTK.SelectedItem.ToString().Equals("Tất cả"))
                {
                    try
                    {
                        dgv_phieuNhap.DataSource = db.Pnhaps.Select(s => s).ToList();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txt_tuKhoaTK.Text))
                    {
                        MessageBox.Show("Nhập từ khóa tìm kiếm!");
                    }
                    else
                    {
                        try
                        {
                            if (cbb_kieuTK.SelectedItem.ToString().Equals("Tên nhân viên"))
                            {
                                var data = db.Pnhaps.Where(s => s.ManvNavigation.Tennv.Equals(txt_tuKhoaTK.Text)).Select(s => new { s.Mapn, s.ManccNavigation.Tenncc, s.ManvNavigation.Tennv, s.Ngaynhap }).ToList();
                                dgv_phieuNhap.DataSource = data;
                            }
                            else if (cbb_kieuTK.SelectedItem.ToString().Equals("Mã phiếu nhập"))
                            {
                                var data = db.Pnhaps.Where(s => s.Mapn.Equals(txt_tuKhoaTK.Text)).Select(s => new { s.Mapn, s.ManccNavigation.Tenncc, s.ManvNavigation.Tennv, s.Ngaynhap }).ToList();
                                dgv_phieuNhap.DataSource = data;
                            }
                            else if (cbb_kieuTK.SelectedItem.ToString().Equals("Tên nhà cung cấp"))
                            {
                                var data = db.Pnhaps.Where(s => s.ManccNavigation.Tenncc.Equals(txt_tuKhoaTK.Text)).Select(s => new { s.Mapn, s.ManccNavigation.Tenncc, s.ManvNavigation.Tennv, s.Ngaynhap }).ToList();
                                dgv_phieuNhap.DataSource = data;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Không tìm được!");
                        }
                    }
                }

            }
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

        private void butXoaPhieu_Click(object sender, EventArgs e)
        {
            string maPN_current = dgv_phieuNhap.Rows[indexOfDGVPNhap].Cells[0].Value.ToString();
            Pnhap newpn = db.Pnhaps.Find(maPN_current);
            DialogResult kq = MessageBox.Show("Bạn có muốn Xóa phiếu nhập này không?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                try
                {

                    var dongphieu = db.Dongpnhaps.Where(s => s.Mapn.Equals(newpn.Mapn)).ToList();
                    foreach (var item in dongphieu)
                    {
                        Sanpham sp = db.Sanphams.Find(item.Masp);
                        sp.Sl = sp.Sl - item.Soluongnhap;
                        db.Dongpnhaps.Remove(item);
                        db.SaveChanges();
                    }
                    db.Pnhaps.Remove(newpn);
                    db.SaveChanges();
                    MessageBox.Show("Thành công");
                    QuanLyHoaDonNhap_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
