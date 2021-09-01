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
    public partial class QuanLyDanhMuc : Form
    {
        int indexOfDGV;
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        public QuanLyDanhMuc()
        {
            InitializeComponent();
        }
        //tạo mã  danh mục tăng tự động
        private String AutoIDDanhMuc()
        {
            var dmID = db.DanhmucSps.ToList();
            if (dmID.Count == 0)
                return "DM001";
            String lastID = (from c in db.DanhmucSps
                             orderby c.Madm descending
                             select c.Madm).First();
            int indexID = int.Parse(lastID.Remove(0, 2));
            indexID++;
            for (int i = 1; i < (lastID.Length - 2); i++)
            {
                if (indexID < 10)
                {
                    return "DM00" + indexID.ToString();
                }
                else if (indexID < 100)
                    return "DM0" + indexID.ToString();
            }
            return "DM" + indexID;


            //
            //int dem = 0;
            //dem = dgv_DanhMuc.Rows.Count;
            //string chuoi = "";
            //int chuoi2 = 0;
            //chuoi = Convert.ToString(dgv_DanhMuc.Rows[dem - 2].Cells[0].Value);
            //chuoi2 = Convert.ToInt32((chuoi.Remove(0, 2)));
            //if (chuoi2+1<10)
            //{
            //    return "DM00" + (chuoi2 + 1).ToString();
            //}
            //else if (chuoi2+1<100)
            //{
            //    return "DM0" + (chuoi2 + 1).ToString();
            //}


        }
        private void QuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            //hiển thị danh mục
            dgv_DanhMuc.DataSource = db.DanhmucSps.Select(x => new {
                x.Madm,
                x.Tendm
            }).ToList();
            //
            dgv_DanhMuc.Columns[0].HeaderText = "Mã danh mục";
            dgv_DanhMuc.Columns[1].HeaderText = "Tên danh mục";
            dgv_DanhMuc.Columns[0].Width = 160;
            dgv_DanhMuc.Columns[1].Width = 780;
            txt_MaDM.Text = AutoIDDanhMuc();
            txt_TenDM.Text = "";
            txt_MaDM.Enabled = false;

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rep = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rep == DialogResult.Yes)
                {
                    DanhmucSp dmXoa = (from s in db.DanhmucSps
                                       where s.Madm == txt_MaDM.Text
                                       select s).SingleOrDefault();
                    List<Sanpham> spXoa = db.Sanphams.Where(x => x.Madm == txt_MaDM.Text).ToList();

                    if (spXoa != null)
                    {
                        foreach (Sanpham i in spXoa)
                        {
                            db.Sanphams.Remove(i);
                        }
                    }
                    db.Remove<DanhmucSp>(dmXoa);
                    db.SaveChanges();

                }
                QuanLyDanhMuc_Load(sender, e);
                MessageBox.Show("Xóa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Lỗi: " + exp.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_TenDM.Focus();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            DanhmucSp dmSua = db.DanhmucSps.SingleOrDefault(sp => sp.Madm == txt_MaDM.Text);
            try
            {
                DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn lưu nội dung vừa sửa?", "Thông báo", MessageBoxButtons.YesNo);
                if (dlr == DialogResult.Yes)
                {
                    dmSua.Tendm = txt_TenDM.Text;

                    db.SaveChanges();
                    QuanLyDanhMuc_Load(sender, e);
                    MessageBox.Show("Thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    QuanLyDanhMuc_Load(sender, e);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("Thất bại!\nError: " + exp.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_TenDM.Focus();
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TenDM.Text))
            {
                MessageBox.Show("Không được để trống!!!");
                txt_TenDM.Focus();
            }
            else
            {
                try
                {
                    DanhmucSp dmthem = new DanhmucSp();
                    dmthem.Madm = AutoIDDanhMuc();
                    dmthem.Tendm = txt_TenDM.Text;

                    //kiểm tra tồn tại sp
                    if (!db.DanhmucSps.Contains(dmthem))
                    {
                        db.DanhmucSps.Add(dmthem);
                        db.SaveChanges();
                        QuanLyDanhMuc_Load(sender, e);
                        MessageBox.Show("Thêm thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Trùng sản phẩm " + txt_TenDM.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_TenDM.Focus();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Thất bại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void dgv_DanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexOfDGV = e.RowIndex;
            txt_MaDM.Text = dgv_DanhMuc.Rows[indexOfDGV].Cells[0].Value.ToString();
            txt_TenDM.Text = dgv_DanhMuc.Rows[indexOfDGV].Cells[1].Value.ToString();
        }
    }
}
