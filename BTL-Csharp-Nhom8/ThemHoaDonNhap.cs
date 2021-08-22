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
    public partial class ThemHoaDonNhap : Form
    {
        //NHANVIEN_BLL nhanVien_BLL = new NHANVIEN_BLL();
        //PHIEUNHAP_BLL phieuNhap_BLL = new PHIEUNHAP_BLL();
        //NHACC_BLL nhaCC_BLL = new NHACC_BLL();
        //SANPHAM_BLL sanPham_BLL = new SANPHAM_BLL();
        //DONGPNHAP_BLL dongPNhap_BLL = new DONGPNHAP_BLL();
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        string maNV_current;
        int indexOfDGV;

        public ThemHoaDonNhap()
        {
            InitializeComponent();
        }

        public void funData(string maNV)
        {
            maNV_current = maNV;
        }

        private void ThemHoaDonNhap_Load(object sender, EventArgs e)
        {
            //txt_nhanVien.Text = nhanVien_BLL.TimNhanVien("MANV", maNV_current).Rows[0][1].ToString();
            //txt_maPN.Text = "PN" + phieuNhap_BLL.ToanBoPhieuNhap().Rows.Count.ToString();
            //cbb_NCC.DataSource = nhaCC_BLL.ChonNhaCC();
            //cbb_NCC.DisplayMember = "TENNCC";
            //cbb_NCC.ValueMember = "MANCC";
            //cbbSanPham.DataSource = sanPham_BLL.ChonSanPham();
            //cbbSanPham.DisplayMember = "TENSP";
            //cbbSanPham.ValueMember = "MASP";
            //txt_sdtNCC.MaxLength = 10;
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtThanhTien.Text = Convert.ToInt32(txtSoLuong.Text) * Convert.ToInt32(txtDonGia.Text) + "";
            }
            catch (Exception)
            {

                txtThanhTien.Text = null;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtThanhTien.Text = Convert.ToInt32(txtSoLuong.Text) * Convert.ToInt32(txtDonGia.Text) + "";
            }
            catch (Exception)
            {

                txtThanhTien.Text = null;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn hủy không", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq.Equals(DialogResult.Yes))
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                cbbSanPham.Text = "";
                cbb_NCC.Text = "";
                txtDonGia.Text = "";
                txtSoLuong.Text = "";
                lblTongTien.Text = "0";

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(cbbSanPham.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
            }
            else
            {
                int kiemtratrunghang = 0;
                string sanpham = cbbSanPham.Text;
                if (dataGridView1.Rows.Count >= 1)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (sanpham.Equals(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                        {
                            kiemtratrunghang = 1;
                            break;
                        }

                    }
                }

                if (kiemtratrunghang == 1)
                {
                    MessageBox.Show("Đã có mặt hàng này !!!");
                }
                else
                {
                    this.dataGridView1.Rows.Add(cbbSanPham.Text, txtDonGia.Text, txtSoLuong.Text, txtThanhTien.Text);
                    kiemtratrunghang = 0;
                }
                int tongtien = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    tongtien = tongtien + Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                lblTongTien.Text = tongtien + "";
                ;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string tensp = cbbSanPham.Text;
                DataGridViewRow dgvRow = dataGridView1.Rows[indexOfDGV];
                dataGridView1.Rows.Remove(dgvRow);
                int tongtien = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    tongtien = tongtien + Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                lblTongTien.Text = tongtien + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexOfDGV = e.RowIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int thanhcong = 0;
            //if (dataGridView1.Rows.Count == 0)
            //{
            //    MessageBox.Show("Chưa có sản phẩm nào!!!");
            //}
            //else if (string.IsNullOrWhiteSpace(cbb_NCC.Text))
            //{
            //    MessageBox.Show("Không được để trống nhà cung cấp!!!");
            //}
            //else
            //{
            //    nhaCC_BLL.KTNhaCC(cbb_NCC.Text);
            //    if (nhaCC_BLL.tonTaiNCC == 0)
            //    { // TỒN TẠI NHÀ CUNG CẤP
            //        //CHÈN VÀO PHIẾU
            //        PHIEUNHAP temp = new PHIEUNHAP(txt_maPN.Text, cbb_NCC.SelectedValue.ToString(), maNV_current, dtpDateTime.Value);
            //        phieuNhap_BLL.ThemPhieuNhap(temp);
            //        for (int i = 0; i < dataGridView1.RowCount; i++)
            //        {
            //            string tensp = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //            sanPham_BLL.KTSanPham(tensp);
            //            if (sanPham_BLL.tonTaiSP == 0)
            //            {
            //                // CHƯA TỒN TẠI SẢN PHẨM
            //                string maSP = "SP" + sanPham_BLL.ChonSanPham().Rows.Count.ToString();
            //                SANPHAM temp_SP = new SANPHAM(maSP, tensp, "", "", 0);
            //                sanPham_BLL.ThemSanPham(temp_SP);
            //                DONGPN temp_dongpNhap = new DONGPN(txt_maPN.Text, maSP, dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString());
            //                dongPNhap_BLL.ThemDongPNhap(temp_dongpNhap);

            //            }
            //            else
            //            {
            //                //TỒN TẠI SẢN PHẨM
            //                string maSP = sanPham_BLL.LayMASP(tensp).Rows[0][0].ToString();
            //                DONGPN temp_dongpNhap = new DONGPN(txt_maPN.Text, maSP, dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString());
            //                dongPNhap_BLL.ThemDongPNhap(temp_dongpNhap);

            //            }
            //        }
            //        thanhcong = 1;
            //        if (thanhcong == 1)
            //        {
            //            MessageBox.Show("Thanh toán thành công");
            //            dataGridView1.Rows.Clear();
            //            dataGridView1.Refresh();
            //            cbbSanPham.Text = "";
            //            cbb_NCC.Text = "";
            //            txtDonGia.Text = "";
            //            txtSoLuong.Text = "";
            //            lblTongTien.Text = "0";
            //            txt_maPN.Text = "PN" + phieuNhap_BLL.ToanBoPhieuNhap().Rows.Count.ToString();
            //            ThemHoaDonNhap_Load(sender, e);
            //        }

            //    }
            //    if (nhaCC_BLL.tonTaiNCC == 1)
            //    {// CHƯA TỒN TẠI NHÀ CUNG CẤP
            //        NHACC temp_nhaCC = new NHACC(txt_sdtNCC.Text, cbb_NCC.Text, txt_sdtNCC.Text, "");
            //        nhaCC_BLL.ThemNCC(temp_nhaCC);
            //        //THEm PHIEU NHAP
            //        PHIEUNHAP temp = new PHIEUNHAP(txt_maPN.Text, txt_sdtNCC.Text, maNV_current, dtpDateTime.Value);
            //        phieuNhap_BLL.ThemPhieuNhap(temp);
            //        for (int i = 0; i < dataGridView1.RowCount; i++)
            //        {
            //            string tensp = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //            sanPham_BLL.KTSanPham(tensp);
            //            if (sanPham_BLL.tonTaiSP == 0)
            //            {
            //                // CHƯA TỒN TẠI SẢN PHẨM
            //                string maSP = "SP" + sanPham_BLL.ChonSanPham().Rows.Count.ToString();
            //                SANPHAM temp_SP = new SANPHAM(maSP, tensp, "", "", 0);
            //                sanPham_BLL.ThemSanPham(temp_SP);
            //                DONGPN temp_dongpNhap = new DONGPN(txt_maPN.Text, maSP, dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString());
            //                dongPNhap_BLL.ThemDongPNhap(temp_dongpNhap);

            //            }
            //            else
            //            {
            //                //TỒN TẠI SẢN PHẨM
            //                string maSP = sanPham_BLL.LayMASP(tensp).Rows[0][0].ToString();
            //                DONGPN temp_dongpNhap = new DONGPN(txt_maPN.Text, maSP, dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString());
            //                dongPNhap_BLL.ThemDongPNhap(temp_dongpNhap);

            //            }
            //        }
            //        thanhcong = 1;
            //        if (thanhcong == 1)
            //        {
            //            MessageBox.Show("Thanh toán thành công");
            //            dataGridView1.Rows.Clear();
            //            dataGridView1.Refresh();
            //            cbbSanPham.Text = "";
            //            cbb_NCC.Text = "";
            //            txtDonGia.Text = "";
            //            txtSoLuong.Text = "";
            //            lblTongTien.Text = "0";
            //            txt_maPN.Text = "PN" + phieuNhap_BLL.ToanBoPhieuNhap().Rows.Count.ToString();
            //            ThemHoaDonNhap_Load(sender, e);
            //        }
            //    }
            //}
        }

        private void btn_timNCC_Click(object sender, EventArgs e)
        {
            //if (nhaCC_BLL.KTTTNhaCC(cbb_NCC.Text) == true)
            //{
            //    txt_sdtNCC.Enabled = false;
            //    txt_sdtNCC.Text = nhaCC_BLL.LaySDTNCC(cbb_NCC.Text).Rows[0][0].ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Không tồn tại nhà cung cấp này! Vui lòng nhập số điện thoại nhà cung cấp!");
            //    txt_sdtNCC.Enabled = true;
            //    txt_sdtNCC.Text = "";
            //}
        }

        private void txt_sdtNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
