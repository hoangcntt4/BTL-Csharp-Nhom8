using BTL_Csharp_Nhom8.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

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
                    DGXUATTB =(int) x.Average(x => x.Dongiaxuat),
                    THANHTIEN =(int) x.Sum(x => x.Soluongxuat) * x.Average(x => x.Dongiaxuat),
                });
                var q1 = db.Sanphams.Join(q, x => x.Masp, y => y.Masp, (x, y) => new { y.Masp, x.Tensp, y.SLXUAT, y.DGXUATTB, y.THANHTIEN });
                dgvxuat.DataSource = q1.ToList();
                //dgvxuat.Columns[3].DefaultCellStyle.Format = "#,### vnđ";
                //dgvxuat.Columns[4].DefaultCellStyle.Format = "#,### vnđ";
                dgvxuat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvxuat.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvxuat.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvxuat.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                //Nhập
                var nhap0 = db.Pnhaps.Where(a => a.Ngaynhap >= dtp1.Value && a.Ngaynhap <= dtp2.Value).Join(db.Dongpnhaps, a => a.Mapn, b => b.Mapn, (a, b) => new { b.Masp, b.Soluongnhap, b.Dongianhap });
                var nhap = nhap0.GroupBy(a => a.Masp).Select(a => new
                {
                    MaSp = a.Key,
                    SLNHAP = a.Sum(x => x.Soluongnhap),
                    DGNHAPTB =(int) a.Average(x => x.Dongianhap),
                    THANHTIEN =(int) (a.Sum(x => x.Soluongnhap) * a.Average(t => t.Dongianhap))
                });
                var nhap1 = db.Sanphams.Join(nhap, a => a.Masp, b => b.MaSp, (a, b) => new { b.MaSp, a.Tensp, b.SLNHAP, b.DGNHAPTB, b.THANHTIEN });
                dgvnhap.DataSource = nhap1.ToList();
                //dgvnhap.Columns[3].DefaultCellStyle.Format = "#,### vnđ";
                //dgvnhap.Columns[4].DefaultCellStyle.Format = "#,### vnđ";
                dgvnhap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvnhap.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvnhap.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvnhap.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
                lbl_tongGTXuat.Text = tongGTXuat.ToString() + " vnđ";
                //lbl_tongHDX.Text = dgvxuat.RowCount.ToString();
                lbl_giaTriTB.Text = (tongGTXuat / Convert.ToInt32(lbl_tongHDX.Text)).ToString() + " vnđ";
                lbl_slHangTB.Text = (tongSLHang / Convert.ToInt32(lbl_tongHDX.Text)).ToString();
            }

            if (dgvnhap.RowCount != 0)
            {
                try
                {


                    int tongGTNhap = 0;
                    int tongSLHangNhap = 0;
                    for (int i = 0; i < dgvnhap.RowCount; i++)
                    {
                        tongGTNhap += Convert.ToInt32(dgvnhap.Rows[i].Cells[4].Value.ToString().Trim());
                        tongSLHangNhap += Convert.ToInt32(dgvnhap.Rows[i].Cells[2].Value.ToString());
                    }
                    lbl_tongGTNhap.Text = tongGTNhap.ToString() + " vnđ";
                    //lbl_tongHDNhap.Text = dgvnhap.RowCount.ToString();
                    lbl_gtTBHDNhap.Text = (tongGTNhap / Convert.ToInt32(lbl_tongHDNhap.Text)).ToString() + " vnđ";
                    lbl_slHangTBNhap.Text = (tongSLHangNhap / Convert.ToInt32(lbl_tongHDNhap.Text)).ToString();
            }
                catch (Exception exp)
            {
                MessageBox.Show("Lỗi: " + exp.Message);
            }
        }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            ExportToPDF();
        }
        private void ExportToPDF()
        {
            string deviceInfo = "";//for setting width, height etc.We use defaults
            string[] streamIds;
            Warning[] warnings;

            string mimeTpye = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "Report1.rdlc";//đường link tuyệt đối
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", GetSanPhamsData()));
            var bytes = viewer.LocalReport.Render("PDF", deviceInfo, out mimeTpye, out encoding, out extension,
                out streamIds, out warnings);
            string fileName = @"D:\" + DateTime.Now.ToString("dd.MM.yyyy.HH.mm.ss") + ".pdf";//đặt tên file tự động
            File.WriteAllBytes(fileName, bytes);
            MessageBox.Show("Xuất file thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private List<SanPhamDS> GetSanPhamsData()
        {

            List<SanPhamDS> dssp = new List<SanPhamDS>();
            var p = dtp1.Value.Month;
            foreach (DataGridViewRow row in dgvnhap.Rows)
            {
                if (row.Index < dgvnhap.Rows.Count)
                {
                    SanPhamDS SP = new SanPhamDS();
                    string ma = row.Cells[0].Value.ToString();
                    var chksp = db.Sanphams.Where(x => db.DanhmucSps.Any(y => y.Madm == x.Madm) && x.Masp == ma).Select(x => new
                    {
                        x.Masp,
                        x.Tensp,
                        x.MadmNavigation.Tendm,
                        x.DVT,
                        x.DonGia
                    }).FirstOrDefault();
                    if (chksp != null)
                    {
                        SP.MASP = ma;
                        SP.TENSP = chksp.Tensp;
                        SP.TENDM = chksp.Tendm;
                        SP.DVT = chksp.DVT;
                        SP.Tungay = dtp1.Value;
                        SP.Denngay = dtp2.Value;
                        SP.DonGia = chksp.DonGia;
                        SP.Thang = p;

                    }
                    int chkSL = db.Sanphams.Where(x => x.Masp == ma).Join(db.Dongpnhaps, x => x.Masp, y => y.Masp, (x, y) => new
                    {
                        x.Masp,
                        y.Mapn,
                        sl = y.Soluongnhap
                    }).Join(db.Pnhaps, x => x.Mapn, y => y.Mapn, (x, y) => new
                    {
                        x.Masp,
                        x.sl,
                        y.Ngaynhap
                    }).Where(x => x.Ngaynhap >= dtp1.Value && x.Ngaynhap <= dtp2.Value).Sum(x => x.sl);
                    SP.SL = chkSL;
                    dssp.Add(SP);
                }
            }

            return dssp;
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {

        }
    }
}
