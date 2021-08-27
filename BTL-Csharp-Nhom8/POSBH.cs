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
    public partial class POSBH : Form
    {
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        int indexOfDGV;
        string ngayLap = DateTime.Now.Date.ToString("MM-dd-yyyy");
        //SANPHAM_BLL sanPham_BLL = new SANPHAM_BLL();
        //KHACHHANG_BLL khachHang_BLL = new KHACHHANG_BLL();
        //NHANVIEN_BLL nhanVien_BLL = new NHANVIEN_BLL();
        //PHIEUXUAT_BLL phieuXuat_BLL = new PHIEUXUAT_BLL();
        //DONGPXUAT_BLL dongPXuat_BLL = new DONGPXUAT_BLL();
        string maNV_current = "NV001";
        string sdtKH;
        public POSBH()
        {
            InitializeComponent();
        }

        private void POSBH_Load(object sender, EventArgs e)
        {
            SetDataToCollection();
            //lbl_maNV.Text = maNV_current;
            //lbl_hoTen.Text = nhanVien_BLL.TimNhanVien("MANV", maNV_current).Rows[0]["TENNV"].ToString();
            //cbb_hanghoa.DataSource = sanPham_BLL.ChonSanPham();
            //cbb_hanghoa.ValueMember = "MASP";
            //cbb_hanghoa.DisplayMember = "TENSP";
            //txt_tongTien.Enabled = false;
            //cbb_hanghoa.SelectedIndex=0;
            //txt_SDTKH.MaxLength = 10;
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    cbb_hanghoa.DataSource = sanPham_BLL.TimSanPham("TENSP", cbb_hanghoa.Text);
            //    cbb_hanghoa.DisplayMember = "TENSP";
            //    cbb_hanghoa.ValueMember = "MASP";
            //    cbb_hanghoa.DroppedDown = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btn_xoadonghd_Click(object sender, EventArgs e)
        {
            try
            {
                string tensp = cbb_hanghoa.Text;
                DataGridViewRow dgvRow = dgv_hoaDon.Rows[indexOfDGV];
                dgv_hoaDon.Rows.Remove(dgvRow);
                int tongtien = 0;
                for (int i = 0; i < dgv_hoaDon.Rows.Count; i++)
                {
                    tongtien = tongtien + Convert.ToInt32(dgv_hoaDon.Rows[i].Cells[4].Value.ToString());
                }
                txt_tongTien.Text = tongtien + "";
            }
            catch (Exception ex)
            {
               

            }
        }

        private void btn_themvaohoadon_Click(object sender, EventArgs e)
        {
            //if (txt_soLuong.Text.Equals("0"))
            //{
            //    MessageBox.Show("Không nhập SL bằng 0");
            //}
            //else
            //{ 
            //    if (string.IsNullOrWhiteSpace(txt_soLuong.Text) || string.IsNullOrWhiteSpace(cbb_hanghoa.Text))
            //    {
            //        MessageBox.Show("Dữ liệu không hợp lệ");
            //    }
            //    else if (Convert.ToInt32(txt_slCon.Text) < Convert.ToInt32(txt_soLuong.Text))
            //    {
            //        MessageBox.Show("Không còn đủ hàng !!!");
            //    }
            //    else
            //    {
            //        int kiemtratrunghang = 0;
            //        string sanpham = cbb_hanghoa.Text;
            //        if (dgv_hoaDon.Rows.Count >= 1)
            //        {
            //            for (int i = 0; i < dgv_hoaDon.Rows.Count; i++)
            //            {
            //                if (sanpham.Equals(dgv_hoaDon.Rows[i].Cells[0].Value.ToString()))
            //                {
            //                    kiemtratrunghang = 1;
            //                    break;
            //                }

            //            }
            //        }

            //        if (kiemtratrunghang == 1)
            //        {
            //            MessageBox.Show("Đã có mặt hàng này !!!");
            //        }
            //        else
            //        {
            //            //CHƯA CÓ MẶT HÀNG TRONG HÓA ĐƠN
            //            string tenSP = sanPham_BLL.ThemDSMua(cbb_hanghoa.SelectedValue.ToString()).Rows[0][0].ToString();
            //            string donGiaXuat = sanPham_BLL.ThemDSMua(cbb_hanghoa.SelectedValue.ToString()).Rows[0][1].ToString();
            //            int thanhTien = Convert.ToInt32(donGiaXuat) * Convert.ToInt32(txt_soLuong.Text);
            //            this.dgv_hoaDon.Rows.Add(tenSP, donGiaXuat, txt_soLuong.Text, thanhTien.ToString());
            //            kiemtratrunghang = 0;
            //        }
            //        int tongtien = 0;
            //        for (int i = 0; i < dgv_hoaDon.Rows.Count; i++)
            //        {
            //            tongtien = tongtien + Convert.ToInt32(dgv_hoaDon.Rows[i].Cells[3].Value.ToString());
            //        }
            //        txt_tongTien.Text = tongtien + " VND";
            //    }
            //}
            if (string.IsNullOrWhiteSpace(cbb_hanghoa.Text))
            {
                MessageBox.Show("Vui lòng nhập sản phẩm");
            }
            else if (txt_slCon.Text == "NULL")
            {
                MessageBox.Show("Nhập sai thông tin vật phẩm");
            }
            else if (string.IsNullOrWhiteSpace(txt_soLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng");
            }
            else if (string.IsNullOrWhiteSpace(txt_slCon.Text))
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào");
            }
            else
            if (Convert.ToInt32(txt_slCon.Text) < Convert.ToInt32(txt_soLuong.Text))
            {
                MessageBox.Show("Không còn đủ hàng trong kho");
            }
            else
            {
                int kiemtra = 0;
                string tenSP = cbb_hanghoa.Text;
                string donGiaXuat = txtDonGiaXuat.Text;
                string dvt = txtDVT.Text;
                int thanhTien = Convert.ToInt32(donGiaXuat) * Convert.ToInt32(txt_soLuong.Text);
                for (int i = 0; i < dgv_hoaDon.RowCount; i++)
                {
                    if (tenSP == dgv_hoaDon.Rows[i].Cells[0].Value.ToString()) 
                    {
                        kiemtra = 1;
                    }
                        
                }
                if(kiemtra ==1)
                {
                    MessageBox.Show("Hàng này đã tồn tại");
                }    
                else
                {
                      this.dgv_hoaDon.Rows.Add(tenSP,dvt, donGiaXuat, txt_soLuong.Text, thanhTien.ToString());
                }    
            }
            int tongtien = 0;
            for (int i = 0; i < dgv_hoaDon.Rows.Count; i++)
            {
                tongtien = tongtien + Convert.ToInt32(dgv_hoaDon.Rows[i].Cells[4].Value.ToString());
            }
            txt_tongTien.Text = tongtien + "";

        }

        private void dgv_hoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_soLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbb_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //private void cbb_sdt_TextUpdate(object sender, EventArgs e)
        //{
        //    sdtmoi = cbb_tenKH.Text;
        //}
        public void funData(string maNV)
        {
            maNV_current = maNV;
        }
        public string mahd;
        private void btn_thanhToan_Click(object sender, EventArgs e)
        {
            if(dgv_hoaDon.RowCount==0)
            {
                MessageBox.Show("Chưa có sản phẩm nào để thanh toán");
                
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txt_SDTKH.Text) || string.IsNullOrWhiteSpace(txt_tenKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu khách hàng!!!");
                    
                }
                else
                {
                    if (txt_SDTKH.TextLength != 10)
                    {
                        MessageBox.Show("Số điện thoại phải có 10 số !!!");

                          

                    }
                    else
                    {
                        if (kiem_tra_khach_hang_ton_tai == 0) // KHÁCH HÀNG CHƯA TỒN TẠI
                        {
                            var count = db.Khachhangs.Select(p => p);
                            Khachhang kh = new Khachhang();
                            kh.Makh = "KH" + count.Count() ;
                            kh.Tenkh = txt_tenKH.Text;
                            kh.Sdt = txt_SDTKH.Text;
                            kh.Gioitnh = null;
                            db.Khachhangs.Add(kh);
                            db.SaveChanges();
                        }
                        // CHÈN VÀO HÓA ĐƠN 
                        Pxuat dpx = new Pxuat();
                        var dem = db.Pxuats.Select(p => p);

                        var checkmakhachhang = db.Khachhangs.FirstOrDefault(p => p.Sdt == txt_SDTKH.Text);

                        dpx.Mapx = "PX" + dem.Count();
                        mahd = "PX" + dem.Count();
                        dpx.Makh = checkmakhachhang.Makh;
                        dpx.Ngayxuat = DateTime.Now;
                        dpx.Manv = maNV_current;
                        db.Pxuats.Add(dpx);
                        db.SaveChanges();

                        for (int i = 0; i < dgv_hoaDon.RowCount; i++)
                        {
                            string mapx = "PX" + (dem.Count()-1);
                            var checkmasapham = db.Sanphams.FirstOrDefault(p => p.Tensp == dgv_hoaDon.Rows[i].Cells[0].Value.ToString());
                            string maSP = checkmasapham.Masp;
                            int soluongxuat = Convert.ToInt32(dgv_hoaDon.Rows[i].Cells[3].Value.ToString());
                            int dongiaxuat = Convert.ToInt32(dgv_hoaDon.Rows[i].Cells[2].Value.ToString());
                            string dvt = dgv_hoaDon.Rows[i].Cells[1].Value.ToString();


                            Dongpxuat dongiapx = new Dongpxuat();
                            
                            dongiapx.Mapx = mapx;
                            dongiapx.Masp = maSP;
                            dongiapx.Soluongxuat = soluongxuat;
                            dongiapx.Dongiaxuat = dongiaxuat;
                            db.Dongpxuats.Add(dongiapx);
                            db.SaveChanges();

                        }
                        InHoaDon F = new InHoaDon();
                        F.mahd = mahd;
                        F.ShowDialog();

                    }
                }    
            }    
           
            


            //if(string.IsNullOrWhiteSpace(txt_SDTKH.Text) || string.IsNullOrWhiteSpace(txt_tenKH.Text))
            //{
            //    MessageBox.Show("Vui lòng nhập dữ liệu khách hàng!!!");
            //}    
            //else if (khachHang_BLL.KTTonTaiKH(txt_SDTKH.Text, txt_SDTKH.Text) == true)
            //{
            //    //ĐÃ TỒN TẠI KHÁCH HÀNG
            //    //TẠO HÓA ĐƠN
            //    try
            //    {
            //        DataTable temp = new DataTable();
            //        temp = phieuXuat_BLL.ToanBoPhieuXuat();
            //        string maPX = "PX0" + temp.Rows.Count.ToString();
            //        PHIEUXUAT phieuXuat = new PHIEUXUAT(maPX, txt_SDTKH.Text, maNV_current, DateTime.Parse(ngayLap));
            //        phieuXuat_BLL.ThemPhieuXuat(phieuXuat);
            //        for (int i = 0; i < dgv_hoaDon.RowCount ; i++)
            //        {
            //            string maSP = sanPham_BLL.LayMASP(dgv_hoaDon.Rows[i].Cells[0].Value.ToString()).Rows[0][0].ToString();
            //            string sl = dgv_hoaDon.Rows[i].Cells[2].Value.ToString();
            //            string dongia = dgv_hoaDon.Rows[i].Cells[1].Value.ToString();
            //            DONGPX temp_dongPX = new DONGPX(maPX, maSP, sl, dongia);
            //            dongPXuat_BLL.ThemDongPXuat(temp_dongPX);
            //        }
            //        MessageBox.Show("Thành công!");
            //        DialogResult dlr = MessageBox.Show("In hóa đơn", "Thông báo", MessageBoxButtons.YesNo);
            //        if (dlr == DialogResult.Yes)
            //        {
            //            this.InHoaDon(maPX);
            //        }
            //        refreshForm();
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Thất bại!");

            //    }
            //}
            //else
            //{
            //    //CHƯA TỒN TẠI KHÁCH HÀNG
            //    //THÊM MỚI KHÁCH HÀNG
            //    try
            //    {                    
            //        khachHang_BLL.ThemKhachHang(txt_SDTKH.Text,txt_tenKH.Text,txt_SDTKH.Text);
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message);
            //    }
            //    //TẠO HÓA ĐƠN
            //    try
            //    {
            //        DataTable temp = new DataTable();
            //        temp = phieuXuat_BLL.ToanBoPhieuXuat();
            //        string maPX = "PX0" + temp.Rows.Count.ToString();
            //        PHIEUXUAT phieuXuat = new PHIEUXUAT(maPX, txt_SDTKH.Text, maNV_current, DateTime.Parse(ngayLap));
            //        phieuXuat_BLL.ThemPhieuXuat(phieuXuat);
            //        for (int i = 0; i < dgv_hoaDon.RowCount ; i++)
            //        {
            //            string maSP = sanPham_BLL.LayMASP(dgv_hoaDon.Rows[i].Cells[0].Value.ToString()).Rows[0][0].ToString();
            //            string sl = dgv_hoaDon.Rows[i].Cells[2].Value.ToString();
            //            string dongia = dgv_hoaDon.Rows[i].Cells[1].Value.ToString();
            //            DONGPX temp_dongPX = new DONGPX(maPX, maSP, sl, dongia);
            //            dongPXuat_BLL.ThemDongPXuat(temp_dongPX);
            //        }
            //        MessageBox.Show("Thành công!");
            //        DialogResult dlr = MessageBox.Show("In hóa đơn", "Thông báo", MessageBoxButtons.YesNo);
            //        if (dlr == DialogResult.Yes)
            //        {
            //            this.InHoaDon(maPX);
            //        }
            //        refreshForm();
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Thất bại!");

            //    }
            //}

        }

        private void btn_huyPhieu_Click(object sender, EventArgs e)
        {
            refreshForm();
        }
        private void SetDataToCollection()
        {
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            cbb_hanghoa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbb_hanghoa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var item in db.Sanphams.Select(x => x).ToList())
            {
                auto1.Add(item.Tensp);

            }
            cbb_hanghoa.AutoCompleteCustomSource = auto1;
        }
        private void cbb_hanghoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(sanPham_BLL.LaySLTonKho(cbb_hanghoa.SelectedValue.ToString()).Rows.Count==0)
            //{

            //}    
            //else
            //{
            //    txt_slCon.Text = sanPham_BLL.LaySLTonKho(cbb_hanghoa.SelectedValue.ToString()).Rows[0][0].ToString();
            //}    
        }
        public int lengthsdt;
        int kiem_tra_khach_hang_ton_tai;
        private void txt_SDTKH_TextChanged(object sender, EventArgs e)
        {
            //lengthsdt = txt_SDTKH.Text.Length;
            //if(lengthsdt==0)
            //{

            //}
            //else if(khachHang_BLL.KTTonTaiKH(txt_SDTKH.Text,"") ==true)
            //{
            //    txt_tenKH.Text = khachHang_BLL.TimKhachHang("MAKH", txt_SDTKH.Text).Rows[0][1].ToString();
            //    lengthsdt = txt_SDTKH.Text.Length;
            //} 

                kiem_tra_khach_hang_ton_tai = 0;
                QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
                var check = db.Khachhangs.FirstOrDefault(p => p.Sdt == txt_SDTKH.Text);
                {
                    if(check != null)
                    {
                        txt_tenKH.Text = check.Tenkh.ToString();
                        kiem_tra_khach_hang_ton_tai = 1;
                        txt_tenKH.Enabled = false;
                    }
                if (check == null)
                {
                    
                    txt_tenKH.Enabled = true;
                }
            }
    
        }

        private void txt_SDTKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //    e.Handled = true;
        }

        private void txt_tenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void refreshForm()
        {
            txt_soLuong.Text = "";
            // cbb_hanghoa.SelectedIndex = 0;
            txt_SDTKH.Text = "";
            txt_tenKH.Text = "";
            dgv_hoaDon.Rows.Clear();
            dgv_hoaDon.Refresh();
            txt_tongTien.Text = "";
        }
        private void InHoaDon(string maPX)
        {

        }

        private void cbb_hanghoa_TextChanged(object sender, EventArgs e)
        {
            QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
            var check = db.Sanphams.FirstOrDefault(p => p.Tensp == cbb_hanghoa.Text);
            if (check != null)
            {
                txt_slCon.Text = check.Sl.ToString();
                txtDonGiaXuat.Text = check.DonGia.ToString();
                txtDVT.Text = check.DVT.ToString();
            }
            else
            {
                txtDVT.Text = "NULL";
                txtDonGiaXuat.Text = "NULL";
                txt_slCon.Text = "NULL";
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
