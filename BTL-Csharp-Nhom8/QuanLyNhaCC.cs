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
    public partial class QuanLyNhaCC : Form
    {
        //NHACC_BLL nhaCC_BLL = new NHACC_BLL();
        //PHIEUNHAP_BLL phieuNhap_BLL = new PHIEUNHAP_BLL();
        int indexOfDGV;
        QLCuaHangTapHoaContext db =new QLCuaHangTapHoaContext();
        public QuanLyNhaCC()
        {
            InitializeComponent();
        }

        private void QuanLyNhaCC_Load(object sender, EventArgs e)
        {
            //dgv_nhaCC.DataSource = nhaCC_BLL.ChonNhaCC();
            //cbb_kieuTK.SelectedIndex = 0;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            QuanLyNhaCC_Load(sender, e);
        }

        private void dgv_nhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    indexOfDGV = e.RowIndex;
            //    string maNCC_current = dgv_nhaCC.Rows[indexOfDGV].Cells[0].Value.ToString();
            //    dgv_phieuNhap.DataSource = phieuNhap_BLL.TimTheoKieu("PNHAP.MANCC", maNCC_current);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string maNCC = dgv_nhaCC.Rows[indexOfDGV].Cells[0].Value.ToString();
            string tenNCC = dgv_nhaCC.Rows[indexOfDGV].Cells[1].Value.ToString();
            string diaChi = dgv_nhaCC.Rows[indexOfDGV].Cells[2].Value.ToString();
            string sdt = dgv_nhaCC.Rows[indexOfDGV].Cells[3].Value.ToString();
            DialogResult kq = MessageBox.Show("Bạn có muốn sửa thông tin nhà cung cấp này không?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (kq == DialogResult.Yes)
            //{
            //    if (string.IsNullOrWhiteSpace(tenNCC) || string.IsNullOrWhiteSpace(diaChi))
            //    {
            //        MessageBox.Show("Không để trống tên và địa chỉ!");
            //    }
            //    else
            //    {
            //        try
            //        {
            //            NHACC temp = new NHACC(maNCC, tenNCC, sdt, diaChi);
            //            nhaCC_BLL.SuaNCC(temp);
            //            MessageBox.Show("Thành công");
            //            QuanLyNhaCC_Load(sender, e);
            //        }
            //        catch (Exception ex)
            //        {

            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //}

        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            //if (cbb_kieuTK.SelectedItem.ToString().Equals("Tất cả"))
            //{
            //    dgv_nhaCC.DataSource = nhaCC_BLL.ChonNhaCC();
            //}
            //else
            //{
            //    if (string.IsNullOrWhiteSpace(txt_tuKhoaTK.Text))
            //    {
            //        MessageBox.Show("Nhập thông tin tìm kiếm!");
            //    }
            //    else
            //    {
            //        if (cbb_kieuTK.SelectedItem.ToString().Equals("SĐT nhà cung cấp"))
            //        {
            //            dgv_nhaCC.DataSource = nhaCC_BLL.TimKiemNCC("MANCC", txt_tuKhoaTK.Text);
            //        }
            //        else if (cbb_kieuTK.SelectedItem.ToString().Equals("Tên nhà cung cấp"))
            //        {
            //            dgv_nhaCC.DataSource = nhaCC_BLL.TimKiemNCC("TENNCC", txt_tuKhoaTK.Text);
            //        }
            //        else if (cbb_kieuTK.SelectedItem.ToString().Equals("Địa chỉ"))
            //        {
            //            dgv_nhaCC.DataSource = nhaCC_BLL.TimKiemNCC("DIACHI", txt_tuKhoaTK.Text);
            //        }
            //    }
            //}
        }

        private void cbb_kieuTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_kieuTK.Text.Equals("Tất cả"))
            {
                lbl_tuKhoaTK.Visible = false;
                txt_tuKhoaTK.Visible = false;
            }
            else
            {
                lbl_tuKhoaTK.Visible = true;
                txt_tuKhoaTK.Visible = true;
            }
        }
    }
}
