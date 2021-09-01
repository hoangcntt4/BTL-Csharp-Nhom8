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
using System.Globalization;

namespace BTL_Csharp_Nhom8
{
    public partial class QuanLyKhoHang : Form
    {

        int indexOfDGV;
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        public QuanLyKhoHang()
        {
            InitializeComponent();
        }
        //tạo mã sản phẩm tăng tự động
        private String AutoIDCus()
        {
            var _maSp = db.Sanphams.ToList();
            if (_maSp.Count == 0)
                return "SP1";
            String lastID = (from c in db.Sanphams
                             orderby c.Masp descending
                             select c.Masp).First();
            int indexID = int.Parse(lastID.Substring(2));
            indexID++;
            return "SP" + indexID;

        }
        private void SetDataToCollection()
        {
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            txt_tuKhoaTK.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_tuKhoaTK.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var item in db.Sanphams.Select(x => x).ToList())
            {
                auto1.Add(item.Tensp);

            }
           txt_tuKhoaTK.AutoCompleteCustomSource = auto1;
        }
        private void QuanLyKhoHang_Load(object sender, EventArgs e)
        {
            //hiển thị danh sách các sản phẩm hiện đang có
            var product = from prod in db.Sanphams
                          select new
                          {
                              prod.Masp,
                              prod.Tensp,
                              dongia = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", prod.DonGia) + " vnđ",
                              loaihang = prod.MadmNavigation.Tendm,
                              prod.Mota,
                              prod.Sl,
                              prod.DVT
                          };
            dgv_sanPham.DataSource = product.ToList();
            //
            dgv_sanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dgv_sanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_sanPham.Columns[2].HeaderText = "Đơn giá";
            dgv_sanPham.Columns[3].HeaderText = "Loại hàng";
            dgv_sanPham.Columns[4].HeaderText = "Mô tả";
            dgv_sanPham.Columns[5].HeaderText = "Số lượng";
            dgv_sanPham.Columns[6].HeaderText = "Đơn vị tính";
            //
            dgv_sanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_sanPham.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_sanPham.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Danh sách sản phẩm bán chạy
            var listProductMost = db.Dongpxuats.Join(db.Sanphams, px => px.Masp, sp => sp.Masp,
                (px, sp) => new
                {
                    masp = sp.Masp,
                    tensp = sp.Tensp,
                    sl = px.Soluongxuat
                }).GroupBy(x => new
                {
                    masp = x.masp,
                    tensp = x.tensp,
                }).Select(a => new
                {
                    a.Key.masp,
                    a.Key.tensp,
                    slbanra = a.Sum(t => t.sl)
                }).OrderByDescending(px => px.slbanra);
            dgv_sanPhamBC.DataSource = listProductMost.ToList();
            //
            dgv_sanPhamBC.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_sanPhamBC.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //danh sách sản phẩm còn nhiều
            var spcon = db.Sanphams.Where(sp => sp.Sl > 50).Select(sp => new
            {
                sp.Masp,
                sp.Tensp,
                sl = sp.Sl
            }).OrderByDescending(sp => sp.sl);
            dgv_sanPhamTN.DataSource = spcon.ToList();
            dgv_sanPhamTN.Columns[0].HeaderText = "Mã sản phẩm";
            dgv_sanPhamTN.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_sanPhamTN.Columns[2].HeaderText = "Số lượng";

            //
            dgv_sanPhamTN.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_sanPhamTN.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //hiển thị comboBox loại hàng
            cbo_LoaiHang.DataSource = (db.DanhmucSps.Select(x => x)).ToList();
            cbo_LoaiHang.DisplayMember = "TENDM";
            cbo_LoaiHang.ValueMember = "MADM";

            //danh sách sản phầm còn lại trong kho
            lbl_thongTinTK.Visible = false;
            txt_tuKhoaTK.Visible = false;
            cbb_kieuTK.Text = "Tất cả";
            txt_tuKhoaTK.Clear();
            txt_moTa.Text = "";
            txt_tenSP.Text = "";
            txt_maSP.Text = AutoIDCus();
            txt_maSP.Enabled = false;
            txt_DonGia.Text = "";
            txt_SL.Text = "";
            txt_DVT.Text = "";

            SetDataToCollection();
        }


        private void btn_tim_Click(object sender, EventArgs e)
        {
            if (cbb_kieuTK.SelectedItem.ToString().Equals("Mã sản phẩm") || cbb_kieuTK.SelectedItem.ToString().Equals("Tên sản phẩm"))
            {
                if (string.IsNullOrWhiteSpace(txt_tuKhoaTK.Text))
                {
                    MessageBox.Show("Không được để trắng !!!");
                    txt_tuKhoaTK.Focus();
                }
                else
                {
                    try
                    {
                        if (cbb_kieuTK.SelectedItem.ToString().Equals("Mã sản phẩm"))
                        {
                            var result = from c in db.Sanphams
                                         where c.Masp == txt_tuKhoaTK.Text
                                         select new
                                         {
                                             c.Masp,
                                             c.Tensp,
                                             c.DonGia,
                                             loaihang = c.MadmNavigation.Tendm,
                                             c.Mota,
                                             c.Sl,
                                             c.DVT
                                         };
                            dgv_sanPham.DataSource = result.ToList();
                        }
                        else if (cbb_kieuTK.SelectedItem.ToString().Equals("Tên sản phẩm"))
                        {
                            var result = from c in db.Sanphams
                                         where c.Tensp == txt_tuKhoaTK.Text
                                         select new
                                         {
                                             c.Masp,
                                             c.Tensp,
                                             c.DonGia,
                                             loaihang = c.MadmNavigation.Tendm,
                                             c.Mota,
                                             c.Sl,
                                             c.DVT
                                         };
                            dgv_sanPham.DataSource = result.ToList();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    if (cbb_kieuTK.SelectedItem.ToString().Equals("Hết hàng"))
                    {
                        var result = from c in db.Sanphams
                                     where c.Sl == 0
                                     select new
                                     {
                                         c.Masp,
                                         c.Tensp,
                                         c.DonGia,
                                         loaihang = c.MadmNavigation.Tendm,
                                         c.Mota,
                                         c.Sl,
                                         c.DVT
                                     };
                        dgv_sanPham.DataSource = result.ToList();
                    }
                    else if (cbb_kieuTK.SelectedItem.ToString().Equals("Còn hàng"))
                    {
                        var result = from c in db.Sanphams
                                     where c.Sl > 0
                                     select new
                                     {
                                         c.Masp,
                                         c.Tensp,
                                         c.DonGia,
                                         loaihang = c.MadmNavigation.Tendm,
                                         c.Mota,
                                         c.Sl,
                                         c.DVT
                                     };
                        dgv_sanPham.DataSource = result.ToList();
                    }
                    else if (cbb_kieuTK.SelectedItem.ToString().Equals("Tất cả"))
                    {
                        QuanLyKhoHang_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            Sanpham spSua = db.Sanphams.SingleOrDefault(sp => sp.Masp == txt_maSP.Text);
            try
            {
                DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn lưu nội dung vừa sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlr == DialogResult.Yes)
                {
                    spSua.Tensp = txt_tenSP.Text;
                    spSua.DonGia = Convert.ToInt32(txt_DonGia.Text);
                    spSua.Madm = cbo_LoaiHang.SelectedValue.ToString();
                    spSua.Mota = txt_moTa.Text;
                    spSua.Sl = Convert.ToInt32(txt_SL.Text);
                    spSua.DVT = txt_DVT.Text;
                    db.SaveChanges();
                    QuanLyKhoHang_Load(sender, e);
                    MessageBox.Show("Thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    QuanLyKhoHang_Load(sender, e);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("Thất bại!\nError: " + exp.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_sanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexOfDGV = e.RowIndex;
            txt_maSP.Text = dgv_sanPham.Rows[indexOfDGV].Cells[0].Value.ToString();
            txt_tenSP.Text = dgv_sanPham.Rows[indexOfDGV].Cells[1].Value.ToString();
            txt_DonGia.Text = dgv_sanPham.Rows[indexOfDGV].Cells[2].Value.ToString();
            cbo_LoaiHang.Text = dgv_sanPham.Rows[indexOfDGV].Cells[3].Value.ToString();
            txt_moTa.Text = dgv_sanPham.Rows[indexOfDGV].Cells[4].Value.ToString();
            txt_SL.Text = dgv_sanPham.Rows[indexOfDGV].Cells[5].Value.ToString();
            txt_DVT.Text = dgv_sanPham.Rows[indexOfDGV].Cells[6].Value.ToString();
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

        private void button2_Click(object sender, EventArgs e)//thêm sản phẩm
        {
            if (string.IsNullOrWhiteSpace(txt_tenSP.Text) || string.IsNullOrWhiteSpace(txt_moTa.Text))
            {
                MessageBox.Show("Không được để trống!!!");
            }
            else
            {
                try
                {
                    Sanpham spthem = new Sanpham();
                    spthem.Masp = AutoIDCus();
                    spthem.Tensp = txt_tenSP.Text;
                    spthem.DonGia = Convert.ToInt32(txt_DonGia.Text);
                    spthem.Madm = cbo_LoaiHang.SelectedValue.ToString();
                    spthem.Mota = txt_moTa.Text;
                    spthem.Sl = Convert.ToInt32(txt_SL.Text);
                    spthem.DVT = txt_DVT.Text;
                    //kiểm tra tồn tại sp
                    if (!db.Sanphams.Contains(spthem))
                    {
                        db.Sanphams.Add(spthem);
                        db.SaveChanges();
                        QuanLyKhoHang_Load(sender, e);
                        MessageBox.Show("Thêm thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Trùng sản phẩm " + txt_tenSP.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_tenSP.Focus();
                        txt_tenSP.SelectAll();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Thất bại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            QuanLyKhoHang_Load(sender, e);
        }
    }
}
