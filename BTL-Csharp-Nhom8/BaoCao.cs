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
    public partial class BaoCao : Form
    {
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        public BaoCao()
        {
            InitializeComponent();
        }

        //Thống kê
        private void button1_Click(object sender, EventArgs e)
        {
            if (dtp1.Value > dtp2.Value)
            {
                MessageBox.Show("Ngày sau phải lớn hơn hoặc bằng ngày trước!!!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //xuất

                var q0 = db.Pxuats.Where(x => x.Ngayxuat >= dtp1.Value && x.Ngayxuat <= dtp2.Value).Join(db.Dongpxuats, x => x.Mapx, y => y.Mapx, (x, y) => new { y.Masp, y.Soluongxuat, y.Dongiaxuat });
                var q = q0.GroupBy(x => x.Masp).Select(x => new
                {
                    Masp = x.Key,
                    SLXUAT = x.Sum(x => x.Soluongxuat),
                    DGXUATTB = x.Average(x => x.Dongiaxuat),
                    THANHTIEN = x.Sum(x => x.Soluongxuat) * x.Average(x => x.Dongiaxuat),
                });
                var q1 = db.Sanphams.Join(q, x => x.Masp, y => y.Masp, (x, y) => new { y.Masp, x.Tensp, y.SLXUAT, y.DGXUATTB, y.THANHTIEN });
                dgvxuat.DataSource = q1.ToList();

                //Nhập
                var nhap0 = db.Pnhaps.Where(a => a.Ngaynhap >= dtp1.Value && a.Ngaynhap <= dtp2.Value).Join(db.Dongpnhaps, a => a.Mapn, b => b.Mapn, (a, b) => new { b.Masp, b.Soluongnhap, b.Dongianhap });
                var nhap = nhap0.GroupBy(a => a.Masp).Select(a => new
                {
                    MaSp = a.Key,
                    SLNHAP = a.Sum(x => x.Soluongnhap),
                    DGNHAPTB = a.Average(x => x.Dongianhap),
                    THANHTIEN = a.Sum(x => x.Soluongnhap) * a.Average(t => t.Dongianhap)
                });
                var nhap1 = db.Sanphams.Join(nhap, a => a.Masp, b => b.MaSp, (a, b) => new { b.MaSp, a.Tensp, b.SLNHAP, b.DGNHAPTB, b.THANHTIEN });
                dgvnhap.DataSource = nhap1.ToList();
            }
            //số hóa đơn xuất trong kỳ
            var sohdXuat = db.Pxuats.Where(y => y.Ngayxuat >= dtp1.Value && y.Ngayxuat <= dtp2.Value).Count();
            lbl_tongHDX.Text = sohdXuat.ToString();
            //số hóa đơn nhập trong kỳ
            var sohdNhap = db.Pnhaps.Count(a => a.Ngaynhap >= dtp1.Value && a.Ngaynhap <= dtp2.Value);
            lbl_tongHDNhap.Text = sohdNhap.ToString();
            if (dgvxuat.RowCount != 0)
            {
                int tongGTXuat = 0;
                int tongSLHang = 0;
                for (int i = 0; i < dgvxuat.RowCount; i++)
                {
                    tongGTXuat += Convert.ToInt32(dgvxuat.Rows[i].Cells[4].Value.ToString());
                    tongSLHang += Convert.ToInt32(dgvxuat.Rows[i].Cells[2].Value.ToString());
                }
                lbl_tongGTXuat.Text = tongGTXuat.ToString() + " VND";
                //lbl_tongHDX.Text = dgvxuat.RowCount.ToString();
                lbl_giaTriTB.Text = (tongGTXuat / Convert.ToInt32(lbl_tongHDX.Text)).ToString() + " VND";
                lbl_slHangTB.Text = (tongSLHang / Convert.ToInt32(lbl_tongHDX.Text)).ToString();
            }
            if (dgvnhap.RowCount != 0)
            {
                int tongGTNhap = 0;
                int tongSLHangNhap = 0;
                for (int i = 0; i < dgvnhap.RowCount; i++)
                {
                    tongGTNhap += Convert.ToInt32(dgvnhap.Rows[i].Cells[4].Value.ToString());
                    tongSLHangNhap += Convert.ToInt32(dgvnhap.Rows[i].Cells[2].Value.ToString());
                }
                lbl_tongGTNhap.Text = tongGTNhap.ToString() + " VND";
                //lbl_tongHDNhap.Text = dgvnhap.RowCount.ToString();
                lbl_gtTBHDNhap.Text = (tongGTNhap / Convert.ToInt32(lbl_tongHDNhap.Text)).ToString() + " VND";
                lbl_slHangTBNhap.Text = (tongSLHangNhap / Convert.ToInt32(lbl_tongHDNhap.Text)).ToString();
            }
        }
    }
}
