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
    public partial class CuaSoChinhNhanVien : Form
    {
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        POSBH frm_POS = new POSBH();
        ThemHoaDonNhap themHoaDonNhap = new ThemHoaDonNhap();
        QuanLyHoaDonNhap quanLyHoaDonNhap = new QuanLyHoaDonNhap();
        QuanLyKhoHang quanLyKhoHang = new QuanLyKhoHang();
        QuanLyHoaDonXuat quanLyHoaDonXuat = new QuanLyHoaDonXuat();
        DoiMatKhau doiMatKhau = new DoiMatKhau();
        QuanLyNhaCC quanLyNhaCC = new QuanLyNhaCC();
        QuanLyDanhMuc quanLyDanhMuc = new QuanLyDanhMuc();
        BaoCao baoCaoTheoNgay = new BaoCao();
        string maNV_current, matkhau;

        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void tạoMớiĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Bạn phải là ADMIN mới được truy cập mục này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //this.pnl_Container.Controls.Clear();
            //themHoaDonNhap.FormBorderStyle = FormBorderStyle.None;
            //themHoaDonNhap.TopLevel = false;
            //themHoaDonNhap.TopMost = true;
            ////frm_POS.AutoScroll = true;
            //themHoaDonNhap.Dock = DockStyle.Fill;
            //this.pnl_Container.Controls.Add(themHoaDonNhap);
            //themHoaDonNhap.Show();
        }

        private void quảnLýĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void xuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
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
            //doiMatKhau.funData(maNV_current, matkhau);
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

        private void CuaSoChinhNhanVien_Load(object sender, EventArgs e)
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

        public void TKMK(string username, string password)
        {
            this.maNV_current = username;
            this.matkhau = password;
        }

        private void khachHangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.pnl_Container.Controls.Clear();
            quanLyDanhMuc.FormBorderStyle = FormBorderStyle.None;
            quanLyDanhMuc.TopLevel = false;
            quanLyDanhMuc.TopMost = true;
            //frm_POS.AutoScroll = true;
            quanLyDanhMuc.Dock = DockStyle.Fill;
            this.pnl_Container.Controls.Add(quanLyDanhMuc);
            quanLyDanhMuc.Show();
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

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
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

        public CuaSoChinhNhanVien()
        {
            InitializeComponent();
        }
    }
}
