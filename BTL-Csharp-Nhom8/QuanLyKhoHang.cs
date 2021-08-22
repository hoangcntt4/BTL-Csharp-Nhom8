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
    public partial class QuanLyKhoHang : Form
    {
        //SANPHAM_BLL sanPham_BLL = new SANPHAM_BLL();
        int indexOfDGV;
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        public QuanLyKhoHang()
        {
            InitializeComponent();
        }

        private void QuanLyKhoHang_Load(object sender, EventArgs e)
        {
            //dgv_sanPham.DataSource = sanPham_BLL.ChonSanPham();
            //dgv_sanPhamBC.DataSource = sanPham_BLL.ThongKeSanPhamBanChay();
            //dgv_sanPhamTN.DataSource = sanPham_BLL.TKSanPhamTonNN();
            //txt_maSP.Text = "SP" + sanPham_BLL.ChonSanPham().Rows.Count.ToString();
            //lbl_thongTinTK.Visible = false;
            //txt_tuKhoaTK.Visible = false;
            //txt_loaiHang.Text = "";
            //txt_moTa.Text = "";
            //txt_tenSP.Text = "";
            //txt_maSP.Enabled = false;
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            //if (cbb_kieuTK.SelectedItem.ToString().Equals("Mã sản phẩm") || cbb_kieuTK.SelectedItem.ToString().Equals("Tên sản phẩm"))
            //{
            //    if (string.IsNullOrWhiteSpace(txt_tuKhoaTK.Text))
            //    {
            //        MessageBox.Show("Không được để trắng !!!");
            //    }
            //    else
            //    {
            //        try
            //        {
            //            if (cbb_kieuTK.SelectedItem.ToString().Equals("Mã sản phẩm"))
            //            {
            //                dgv_sanPham.DataSource = sanPham_BLL.TimSanPham("MASP", txt_tuKhoaTK.Text);
            //            }
            //            else if (cbb_kieuTK.SelectedItem.ToString().Equals("Tên sản phẩm"))
            //            {
            //                dgv_sanPham.DataSource = sanPham_BLL.TimSanPham("TENSP", txt_tuKhoaTK.Text);
            //            }
            //        }
            //        catch (Exception ex)
            //        {

            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        if (cbb_kieuTK.SelectedItem.ToString().Equals("Hết hàng"))
            //        {
            //            dgv_sanPham.DataSource = sanPham_BLL.TimSanPhamTheoSL("=");
            //        }
            //        else if (cbb_kieuTK.SelectedItem.ToString().Equals("Còn hàng"))
            //        {
            //            dgv_sanPham.DataSource = sanPham_BLL.TimSanPhamTheoSL("!=");
            //        }
            //        else if (cbb_kieuTK.SelectedItem.ToString().Equals("Tất cả"))
            //        {
            //            QuanLyKhoHang_Load(sender, e);
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn lưu nội dung vừa sửa?", "Thông báo", MessageBoxButtons.YesNo);
            //    if (dlr == DialogResult.Yes)
            //    {
            //        string maSP = dgv_sanPham.Rows[indexOfDGV].Cells[0].Value.ToString();
            //        string tenSP = dgv_sanPham.Rows[indexOfDGV].Cells[1].Value.ToString();
            //        string loaiHang = dgv_sanPham.Rows[indexOfDGV].Cells[2].Value.ToString();
            //        string moTa = dgv_sanPham.Rows[indexOfDGV].Cells[3].Value.ToString();
            //        sanPham_BLL.SuaSanPham(maSP, tenSP, loaiHang, moTa);
            //        MessageBox.Show("Thành công");
            //        QuanLyKhoHang_Load(sender, e);
            //    }
            //    else
            //    {
            //        QuanLyKhoHang_Load(sender, e);
            //    }

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Thất bại");
            //}
        }

        private void dgv_sanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexOfDGV = e.RowIndex;
        }

        private void cbb_kieuTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_kieuTK.SelectedItem.ToString().Equals("Mã sản phẩm") || cbb_kieuTK.SelectedItem.ToString().Equals("Tên sản phẩm"))
            {
                txt_tuKhoaTK.Visible = true;
                lbl_thongTinTK.Visible = true;
            }
            else if (cbb_kieuTK.SelectedItem.ToString().Equals("Còn hàng") || cbb_kieuTK.SelectedItem.ToString().Equals("Hết hàng") || cbb_kieuTK.SelectedItem.ToString().Equals("Tất cả"))
            {
                txt_tuKhoaTK.Visible = false;
                lbl_thongTinTK.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_loaiHang.Text) || string.IsNullOrWhiteSpace(txt_tenSP.Text) || string.IsNullOrWhiteSpace(txt_loaiHang.Text))
            //{
            //    MessageBox.Show("Không được để trống!!!");
            //}
            //else
            //{
            //    try
            //    {
            //        SANPHAM temp = new SANPHAM(txt_maSP.Text, txt_tenSP.Text, txt_loaiHang.Text, txt_moTa.Text, 0);
            //        sanPham_BLL.ThemSanPham(temp);
            //        if (sanPham_BLL.kiemtratrunghang == 0)
            //        {
            //            MessageBox.Show("Thêm thành công");
            //            QuanLyKhoHang_Load(sender, e);
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Thất bại");
            //    }
            //}
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            QuanLyKhoHang_Load(sender, e);
        }
    }
}
