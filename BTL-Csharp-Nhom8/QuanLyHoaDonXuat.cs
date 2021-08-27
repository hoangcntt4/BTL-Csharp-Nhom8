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
            try
            {
                indexOfDGVPXuat = e.RowIndex;
                string maPX_current = dgv_phieuXuat.Rows[indexOfDGVPXuat].Cells[0].Value.ToString();
                txt_maPhieuXuat.Text = maPX_current;

         
                var query = db.Dongpxuats.Where(p => p.Mapx == maPX_current).ToList();

                var query1 = db.Pxuats.Where(p => p.Mapx == maPX_current).SingleOrDefault();
                string makh = query1.Makh;

                var query2 = db.Khachhangs.Where(p => p.Makh == makh).SingleOrDefault();
                string tenkh = query2.Tenkh;
                txt_maKH.Text = makh;
           
                txt_tenKH.Text = tenkh;
                dtp_ngayXuatCT.Value = query1.Ngayxuat;

                txt_maNV.Text = query1.Manv;
                var query3 = db.Nhanviens.Where(p => p.Manv == txt_maNV.Text).SingleOrDefault();
                txt_tenNV.Text = query3.Tennv;


                List<XemChiTietHoaDon> list = new List<XemChiTietHoaDon>();
                foreach (var item in query)
                {
                    var sanpham = db.Sanphams.Where(p => p.Masp == item.Masp).SingleOrDefault();
                    XemChiTietHoaDon hoadon = new XemChiTietHoaDon();
                    hoadon.dvt = sanpham.DVT;
                    hoadon.tensp = sanpham.Tensp;
                    hoadon.soluong = item.Soluongxuat;
                    hoadon.dongia = item.Dongiaxuat;
                    hoadon.thanhtien = item.Dongiaxuat * item.Soluongxuat;
                    list.Add(hoadon);

                }
                dgv_chiTietPX.DataSource = list;
                dgv_chiTietPX.Columns[0].HeaderText = "Tên sản phẩm";
                dgv_chiTietPX.Columns[2].HeaderText = "ĐVT";
                dgv_chiTietPX.Columns[1].HeaderText = "Số lượng ";
                dgv_chiTietPX.Columns[3].HeaderText = "Đơn giá (VNĐ)";
                dgv_chiTietPX.Columns[4].HeaderText = "Thành tiền(VNĐ)";

                int tongtien = 0;
                for (int i = 0; i < dgv_chiTietPX.Rows.Count; i++)
                {
                    tongtien = tongtien + Convert.ToInt32(dgv_chiTietPX.Rows[i].Cells[3].Value.ToString());
                }
                lbl_tongTien.Text = tongtien.ToString();
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
            }
            catch (Exception ex)
            {


            }
        }

        private void QuanLyHoaDonXuat_Load(object sender, EventArgs e)
        {
            
            cbb_kieuTK.SelectedIndex = 0;
            lbl_chonNgay.Visible = false;
            dtp_ngayNhap.Visible = false;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            QuanLyHoaDonXuat_Load(sender, e);
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            if (cbb_kieuTK.Text.Equals("Tất cả"))
            {

                var s = from u in db.Pxuats
                        orderby u.Ngayxuat
                        select new
                        {
                            mahd = u.Mapx,
                            makh = u.Makh,
                            manv = u.Manv,
                            ngayxuat = u.Ngayxuat
                        };
                dgv_phieuXuat.DataSource = s.ToList();
                dgv_phieuXuat.Columns[0].HeaderText = "Mã hóa đơn";
                dgv_phieuXuat.Columns[1].HeaderText = "Mã khách hàng";
                dgv_phieuXuat.Columns[2].HeaderText = "Mã nhân viên";
                dgv_phieuXuat.Columns[3].HeaderText = "Ngày xuất";
            }
            else if (cbb_kieuTK.Text.Equals("Mã khách hàng"))
            {


                var s = from u in db.Pxuats
                        orderby u.Manv
                        where u.Makh == txt_tuKhoaTK.Text
                        select new
                        {
                            mahd = u.Mapx,
                            makh = u.Makh,
                            manv = u.Manv,
                            ngayxuat = u.Ngayxuat
                        };
                dgv_phieuXuat.DataSource = s.ToList();
                dgv_phieuXuat.Columns[0].HeaderText = "Mã hóa đơn";
                dgv_phieuXuat.Columns[1].HeaderText = "Mã khách hàng";
                dgv_phieuXuat.Columns[2].HeaderText = "Mã nhân viên";
                dgv_phieuXuat.Columns[3].HeaderText = "Ngày xuất";

            }
            else if (cbb_kieuTK.Text.Equals("Mã phiếu xuất"))
            {


                var s = from u in db.Pxuats
                        orderby u.Manv
                        where u.Mapx == txt_tuKhoaTK.Text
                        select new
                        {
                            mahd = u.Mapx,
                            makh = u.Makh,
                            manv = u.Manv,
                            ngayxuat = u.Ngayxuat
                        };
                dgv_phieuXuat.DataSource = s.ToList();
                dgv_phieuXuat.Columns[0].HeaderText = "Mã hóa đơn";
                dgv_phieuXuat.Columns[1].HeaderText = "Mã khách hàng";
                dgv_phieuXuat.Columns[2].HeaderText = "Mã nhân viên";
                dgv_phieuXuat.Columns[3].HeaderText = "Ngày xuất";

            }
            else if (cbb_kieuTK.Text.Equals("Mã nhân viên"))
            {


                var s = from u in db.Pxuats
                        orderby u.Manv
                        where u.Manv == txt_tuKhoaTK.Text
                        select new
                        {
                            mahd = u.Mapx,
                            makh = u.Makh,
                            manv = u.Manv,
                            ngayxuat = u.Ngayxuat
                        };
                dgv_phieuXuat.DataSource = s.ToList();
                dgv_phieuXuat.Columns[0].HeaderText = "Mã hóa đơn";
                dgv_phieuXuat.Columns[1].HeaderText = "Mã khách hàng";
                dgv_phieuXuat.Columns[2].HeaderText = "Mã nhân viên";
                dgv_phieuXuat.Columns[3].HeaderText = "Ngày xuất";

            }
            else if (cbb_kieuTK.Text.Equals("Ngày xuất"))
            {


                var s = from u in db.Pxuats
                        orderby u.Manv
                        where u.Ngayxuat == dtp_ngayNhap.Value
                        select new
                        {
                            mahd = u.Mapx,
                            makh = u.Makh,
                            manv = u.Manv,
                            ngayxuat = u.Ngayxuat
                        };
                dgv_phieuXuat.DataSource = s.ToList();
                dgv_phieuXuat.Columns[0].HeaderText = "Mã hóa đơn";
                dgv_phieuXuat.Columns[1].HeaderText = "Mã khách hàng";
                dgv_phieuXuat.Columns[2].HeaderText = "Mã nhân viên";
                dgv_phieuXuat.Columns[3].HeaderText = "Ngày xuất";

            }
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

        private void txt_maPhieuXuat_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txt_maPhieuXuat.Text))
            {
                MessageBox.Show("Vui lòng chọn một bản ghi");
            }    
            else
            {
                InHoaDon f = new InHoaDon();
                f.mahd = txt_maPhieuXuat.Text;
                f.Show();
            }    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
