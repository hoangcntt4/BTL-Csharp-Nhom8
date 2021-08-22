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
    public partial class CuaSoChinh : Form
    {
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        POSBH frm_POS = new POSBH();
        ThemHoaDonNhap themHoaDonNhap = new ThemHoaDonNhap();
        QuanLyHoaDonNhap quanLyHoaDonNhap = new QuanLyHoaDonNhap();
        QuanLyKhoHang quanLyKhoHang = new QuanLyKhoHang();
        QuanLyHoaDonXuat quanLyHoaDonXuat = new QuanLyHoaDonXuat();
        DoiMatKhau doiMatKhau = new DoiMatKhau();
        QuanLyNhanSu quanLyNhanSu = new QuanLyNhanSu();
        QuanLyNhaCC quanLyNhaCC = new QuanLyNhaCC();
        QuanLyKhachHang quanLyKhachHang = new QuanLyKhachHang();
        BaoCao baoCaoTheoNgay = new BaoCao();
        string maNV_current, matkhau;

        public CuaSoChinh()
        {
            InitializeComponent();
        }

        private void pOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frm_POS.funData(maNV_current);
            this.pnl_Container.Controls.Clear();
            frm_POS.FormBorderStyle = FormBorderStyle.None;
            frm_POS.TopLevel = false;
            frm_POS.TopMost = true;
            //frm_POS.AutoScroll = true;
            frm_POS.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(frm_POS);
            frm_POS.Show();
        }

        private void tạoMớiHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //themHoaDonNhap.funData(maNV_current);
            this.pnl_Container.Controls.Clear();
            themHoaDonNhap.FormBorderStyle = FormBorderStyle.None;
            themHoaDonNhap.TopLevel = false;
            themHoaDonNhap.TopMost = true;
            //frm_POS.AutoScroll = true;
            themHoaDonNhap.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(themHoaDonNhap);
            themHoaDonNhap.Show();
        }

        private void quảnLýHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnl_Container.Controls.Clear();
            quanLyHoaDonNhap.FormBorderStyle = FormBorderStyle.None;
            quanLyHoaDonNhap.TopLevel = false;
            quanLyHoaDonNhap.TopMost = true;
            //frm_POS.AutoScroll = true;
            quanLyHoaDonNhap.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(quanLyHoaDonNhap);
            quanLyHoaDonNhap.Show();
        }

        private void khoHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.pnl_Container.Controls.Clear();
            quanLyKhoHang.FormBorderStyle = FormBorderStyle.None;
            quanLyKhoHang.TopLevel = false;
            quanLyKhoHang.TopMost = true;
            //frm_POS.AutoScroll = true;
            quanLyKhoHang.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(quanLyKhoHang);
            quanLyKhoHang.Show();
        }

        private void xuấtHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.pnl_Container.Controls.Clear();
            quanLyHoaDonXuat.FormBorderStyle = FormBorderStyle.None;
            quanLyHoaDonXuat.TopLevel = false;
            quanLyHoaDonXuat.TopMost = true;
            //frm_POS.AutoScroll = true;
            quanLyHoaDonXuat.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(quanLyHoaDonXuat);
            quanLyHoaDonXuat.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // doiMatKhau.funData(maNV_current, matkhau);
            this.pnl_Container.Controls.Clear();
            doiMatKhau.FormBorderStyle = FormBorderStyle.None;
            doiMatKhau.TopLevel = false;
            doiMatKhau.TopMost = true;
            //frm_POS.AutoScroll = true;
            doiMatKhau.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(doiMatKhau);
            doiMatKhau.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CuaSoChinh_Load(object sender, EventArgs e)
        {
           // frm_POS.funData(maNV_current);
            this.pnl_Container.Controls.Clear();
            frm_POS.FormBorderStyle = FormBorderStyle.None;
            frm_POS.TopLevel = false;
            frm_POS.TopMost = true;
            //frm_POS.AutoScroll = true;
            frm_POS.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(frm_POS);
            frm_POS.Show();
        }

        private void nhânSựToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.pnl_Container.Controls.Clear();
            quanLyNhanSu.FormBorderStyle = FormBorderStyle.None;
            quanLyNhanSu.TopLevel = false;
            quanLyNhanSu.TopMost = true;
            //frm_POS.AutoScroll = true;
            quanLyNhanSu.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(quanLyNhanSu);
            quanLyNhanSu.Show();
        }

        private void nCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnl_Container.Controls.Clear();
            quanLyNhaCC.FormBorderStyle = FormBorderStyle.None;
            quanLyNhaCC.TopLevel = false;
            quanLyNhaCC.TopMost = true;
            //frm_POS.AutoScroll = true;
            quanLyNhaCC.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(quanLyNhaCC);
            quanLyNhaCC.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnl_Container.Controls.Clear();
            quanLyKhachHang.FormBorderStyle = FormBorderStyle.None;
            quanLyKhachHang.TopLevel = false;
            quanLyKhachHang.TopMost = true;
            //frm_POS.AutoScroll = true;
            quanLyKhachHang.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(quanLyKhachHang);
            quanLyKhachHang.Show();
        }

        private void báoCáoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.pnl_Container.Controls.Clear();
            baoCaoTheoNgay.FormBorderStyle = FormBorderStyle.None;
            baoCaoTheoNgay.TopLevel = false;
            baoCaoTheoNgay.TopMost = true;
            //frm_POS.AutoScroll = true;
            baoCaoTheoNgay.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(baoCaoTheoNgay);
            baoCaoTheoNgay.Show();
        }

        public void TKMK(string username, string password)
        {
            this.maNV_current = username;
            this.matkhau = password;
        }
    }
}
