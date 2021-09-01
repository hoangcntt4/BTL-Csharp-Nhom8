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
        string manv_current = DangNhap.MaNVDangNhap;
        int indexOfDGV;
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        public QuanLyNhaCC()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var data = db.Nhaccs.Select(s => new { s.Mancc, s.Tenncc, s.Diachi, s.Sodt });
            dgv_nhaCC.DataSource = data.ToList();

        }

        private void QuanLyNhaCC_Load(object sender, EventArgs e)
        {

            LoadData();
            cbb_kieuTK.SelectedIndex = 0;
            txtTenNCC.Text = "";
            txtSoDT.Text = "";
            txtDiaChi.Text = "";
            var nv = db.Nhanviens.Find(manv_current);
            if (!nv.Status.Equals("ADMIN") && !nv.Status.Equals("admin") && !nv.Status.Equals("Admin"))
            {
                butThemNCC.Visible = false;
                butXoaNCC.Visible = false;
                btn_sua.Visible = false;
                txtTenNCC.ReadOnly =true;
                txtSoDT.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
            }

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            QuanLyNhaCC_Load(sender, e);
        }

        private void dgv_nhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexOfDGV = e.RowIndex;
                string maNCC_current = dgv_nhaCC.Rows[indexOfDGV].Cells[0].Value.ToString();
                var data = db.Pnhaps.Where(s => s.Mancc.Equals(maNCC_current)).Select(s => new { s.Mapn, s.ManccNavigation.Tenncc, s.ManvNavigation.Tennv, s.Ngaynhap });

                dgv_phieuNhap.DataSource = data.ToList();
                txtTenNCC.Text = dgv_nhaCC.Rows[indexOfDGV].Cells[1].Value.ToString();
                txtDiaChi.Text = dgv_nhaCC.Rows[indexOfDGV].Cells[2].Value.ToString();
                txtSoDT.Text = dgv_nhaCC.Rows[indexOfDGV].Cells[3].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (ValiNCC())
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn sửa thông tin nhà cung cấp này không?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (kq == DialogResult.Yes)
                {
                    try
                    {

                        var ma = dgv_nhaCC.Rows[indexOfDGV].Cells[0].Value.ToString();
                        var newncc = db.Nhaccs.Find(ma);
                        newncc.Tenncc = txtTenNCC.Text;
                        newncc.Diachi = txtDiaChi.Text;
                        newncc.Sodt = txtSoDT.Text;
                        db.SaveChanges();

                        MessageBox.Show("Thành công");
                        QuanLyNhaCC_Load(sender, e);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            if (cbb_kieuTK.SelectedItem.ToString().Equals("tất cả"))
            {
                QuanLyNhaCC_Load(sender, e);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txt_tuKhoaTK.Text))
                {
                    MessageBox.Show("nhập thông tin tìm kiếm!");
                }
                else
                {
                    if (cbb_kieuTK.SelectedItem.ToString().Equals("SĐT nhà cung cấp"))
                    {
                        dgv_nhaCC.DataSource = db.Nhaccs.Where(s => s.Sodt.Equals(txt_tuKhoaTK.Text)).Select(s => new { s.Mancc, s.Tenncc, s.Diachi, s.Sodt }).ToList();
                    }
                    else if (cbb_kieuTK.SelectedItem.ToString().Equals("Tên nhà cung cấp"))
                    {
                        dgv_nhaCC.DataSource = db.Nhaccs.Where(s => s.Tenncc.Equals(txt_tuKhoaTK.Text)).Select(s => new { s.Mancc, s.Tenncc, s.Diachi, s.Sodt }).ToList();
                    }
                    else if (cbb_kieuTK.SelectedItem.ToString().Equals("Địa chỉ"))
                    {
                        dgv_nhaCC.DataSource = db.Nhaccs.Where(s => s.Tenncc.Equals(txt_tuKhoaTK.Text)).Select(s => new { s.Mancc, s.Tenncc, s.Diachi, s.Sodt }).ToList();
                    }
                }
            }
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
        private bool ValiNCC()
        {
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                errorProvider1.SetError(txtTenNCC, "Nhập tên NCC!");
                txtTenNCC.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoDT.Text))
            {
                errorProvider1.SetError(txtSoDT, "Nhập SDT!");
                txtSoDT.Focus();
                return false;
            }
            else if (txtSoDT.Text.Length < 10 || txtSoDT.Text.Length > 10)
            {
                errorProvider1.SetError(txtSoDT, "Số điện thoại chỉ được có 10 chu số!");
                txtSoDT.Focus();
                return false;
            }
            else if (true)
            {
                var sdt = txtSoDT.Text.ToString();
                for (int i = 0; i < sdt.Length; i++)
                {
                    try
                    {
                        var c = int.Parse(sdt[i].ToString());
                    }
                    catch
                    {
                        errorProvider1.SetError(txtSoDT, "Số điện thoại chỉ được là các chữ số!");
                        txtSoDT.Focus();
                        return false;
                    }
                }
            }


            else if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                errorProvider1.SetError(txtDiaChi, "Nhập địa chỉ!");
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }

        private void butThemNCC_Click(object sender, EventArgs e)
        {
            if (ValiNCC())
            {
                DialogResult kq = MessageBox.Show("Bạn có chắc muốn thêm nhà cung cấp này không?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (kq == DialogResult.Yes)
                {

                    try
                    {
                        Nhacc newncc = new Nhacc();
                        newncc.Mancc = AutoIDNCC();
                        newncc.Tenncc = txtTenNCC.Text;
                        newncc.Diachi = txtDiaChi.Text;
                        newncc.Sodt = txtSoDT.Text;
                        db.Nhaccs.Add(newncc);
                        db.SaveChanges();
                        MessageBox.Show("Thành công");
                        QuanLyNhaCC_Load(sender, e);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public string AutoIDNCC()
        {
            var ncc = db.Nhaccs.ToList();
            if (ncc.Count == 0)
                return "NCC001";
            String lastID = (from c in db.Nhaccs
                             orderby c.Mancc descending
                             select c.Mancc).First();
            int indexID = int.Parse(lastID.Substring(3));
            indexID++;
            String mid = "";
            for (int i = 1; i < (lastID.Length - 3); i++)
            {
                if (indexID < 10)
                {
                    return "NCC00" + indexID.ToString();
                }
                else if (indexID < 100)
                    return "NCC0" + indexID.ToString();
            }
            return "NCC" + indexID.ToString();

        }

        private void butXoaNCC_Click(object sender, EventArgs e)
        {
            var ma = dgv_nhaCC.Rows[indexOfDGV].Cells[0].Value.ToString();
            var ncc = db.Nhaccs.Find(ma);
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp " + ncc.Tenncc, "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                try
                {
                    db.Nhaccs.Remove(ncc);
                    db.SaveChanges();
                    MessageBox.Show("Thành công");
                    QuanLyNhaCC_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtTenNCC_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTenNCC, "");
        }

        private void txtSoDT_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSoDT, "");
        }

        private void txtDiaChi_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDiaChi, "");
        }
    }
}
