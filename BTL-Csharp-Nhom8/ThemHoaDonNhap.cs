using BTL_Csharp_Nhom8.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Csharp_Nhom8
{
    public partial class ThemHoaDonNhap : Form
    {

        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        string manv_current = DangNhap.MaNVDangNhap;
        int indexOfDGV;

        public ThemHoaDonNhap()
        {
            InitializeComponent();
        }

        private void SetDataToCollection()
        {
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            txtSanPham.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSanPham.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (var item in db.Sanphams.Select(x => x).ToList())
            {
                auto1.Add(item.Tensp);

            }
            txtSanPham.AutoCompleteCustomSource = auto1;
        }
        private String AutoIDNhao()
        {
            var _maPN = db.Pnhaps.ToList();
            if (_maPN.Count == 0)
                return "pn1";
            String lastID = (from c in db.Pnhaps
                             orderby c.Mapn descending
                             select c.Mapn).First();
            int indexID = int.Parse(lastID.Substring(2));
            indexID++;
            return "pn" + indexID;

        }
        private void ThemHoaDonNhap_Load(object sender, EventArgs e)
        {

            txt_nhanVien.Text = db.Nhanviens.Find(manv_current).Tennv;
            txt_maPN.Text = AutoIDNhao();
            cbb_NCC.DataSource = db.Nhaccs.Select(s => s).ToList();
            cbb_NCC.DisplayMember = "Tenncc";
            cbb_NCC.ValueMember = "Mancc";
            cbbDanhMuc.DataSource = db.DanhmucSps.Select(s => s).ToList();
            cbbDanhMuc.DisplayMember = "TENDM";
            cbbDanhMuc.ValueMember = "MADM";
            dtpDateTime.Value = DateTime.Now;
            SetDataToCollection();
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtThanhTien.Text = Convert.ToInt32(txtSoLuong.Text) * Convert.ToInt32(txtDonGia.Text) + "";
            }
            catch (Exception)
            {

                txtThanhTien.Text = null;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtThanhTien.Text = Convert.ToInt32(txtSoLuong.Text) * Convert.ToInt32(txtDonGia.Text) + "";
            }
            catch (Exception)
            {

                txtThanhTien.Text = null;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn hủy không", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq.Equals(DialogResult.Yes))
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
           
                cbb_NCC.Text = "";
                txtSanPham.Text = "";
                txtSoLuong.Text = "";
                lblTongTien.Text = "0";

            }
        }

        private bool ValiSanPham()
        {

            if (txtSanPham.Text == "")
            {
                errorProvider1.SetError(txtSanPham, "Tên sản phẩm không được để trống!");
                txtSanPham.Focus();
                return false;

            }
            
            if (txtDonViTinh.Text == "")
            {
                errorProvider1.SetError(txtDonViTinh, "Đơn vị tính không được để trống");
                txtDonViTinh.Focus();
                return false;
            }
            if (txtSoLuong.Text == "")
            {
                errorProvider1.SetError(txtSoLuong, "Số lượng không được để trống");
                txtSoLuong.Focus();
                return false;
            }
            else
            {
                try
                {
                    int.Parse(txtSoLuong.Text);
                    if (int.Parse(txtSoLuong.Text) <= 0)
                    {
                        errorProvider1.SetError(txtSoLuong, "Số lượng phải lớn hơn 0");
                        txtSoLuong.Focus();
                        return false;
                    }

                }
                catch
                {
                    errorProvider1.SetError(txtSoLuong, "Số lượng nhập phải là số nguyên!");
                    txtSoLuong.Focus();
                    return false;
                }
            }
            var giaban = db.Sanphams.Where(s => s.Tensp.Equals(txtSanPham.Text)).SingleOrDefault();
            if (txtDonGia.Text == "")
            {
                errorProvider1.SetError(txtDonGia, "Đơn giá không được để trống!");
                txtDonGia.Focus();
                return false;
            }
            else if (giaban!=null)
            {
                if(int.Parse(txtDonGia.Text) >= giaban.DonGia)
                {
                    errorProvider1.SetError(txtDonGia, "Đơn giá nhập không được lớn hơn giá bán, sẽ lỗ, nhập lại!");
                    txtDonGia.Focus();
                    return false;
                }
               
            }
            else
            {
                try
                {
                    int.Parse(txtDonGia.Text);
                    if (int.Parse(txtDonGia.Text) <= 0)
                    {
                        errorProvider1.SetError(txtDonGia, "Đơn giá phải lớn hơn 0");
                        txtDonGia.Focus();
                        return false;
                    }

                }
                catch
                {
                    errorProvider1.SetError(txtDonGia, "Số lượng nhập phải là số nguyên!");
                    txtDonGia.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValiSanPham())
            {
                
                this.dataGridView1.Rows.Add(txtSanPham.Text,cbbDanhMuc.Text,txtDonViTinh.Text, txtDonGia.Text, txtSoLuong.Text, txtThanhTien.Text);
       
                int tongtien = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    tongtien = tongtien + Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                lblTongTien.Text = tongtien + "";

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string tensp = txtSanPham.Text;
                DataGridViewRow dgvRow = dataGridView1.Rows[indexOfDGV];
                dataGridView1.Rows.Remove(dgvRow);
                int tongtien = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    tongtien = tongtien + Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                lblTongTien.Text = tongtien + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexOfDGV = e.RowIndex;
        }

        private bool ValiNCC()
        {
            if (cbb_NCC.Text == "")
            {
                errorProvider1.SetError(cbb_NCC, "Nhà cung cấp không được để trống!");
                cbb_NCC.Focus();
                return false;
            }
            else
            {
                var data = db.Nhaccs.Where(s => s.Tenncc.Equals(cbb_NCC.Text)).Select(s => s).FirstOrDefault();
                if (data == null)
                {
                    errorProvider1.SetError(cbb_NCC, "Tên nhà cung cấp chưa tồn tại trong danh sách!");
                    cbb_NCC.Focus();
                    return false;
                }

            }
            return true;
        }
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
        private void inHoaDon()
        {
            String filename = txt_maPN.Text;
            var savefile = new SaveFileDialog();
            savefile.FileName = filename;
            savefile.DefaultExt = ".pdf";
            if (savefile.ShowDialog() == DialogResult.OK)
            { // set up để thêm dữ liệu
                Document document = new Document(PageSize.A4, 10f, 20f, 20f, 20f);
                Stream stream = new FileStream(savefile.FileName, FileMode.Create);
                PdfWriter.GetInstance(document, stream);
                document.Open();

                PdfPTable table = new PdfPTable(3);
                float[] columnsWidth = { 1, 1, 1 };
                table.SetWidths(columnsWidth);
                table.DefaultCell.BorderWidth = 0;
                table.DefaultCell.Padding = 10;
                table.WidthPercentage = 100;
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                // font chữ
                string path = Path.Combine(Path.GetFullPath(@"..\..\..\"), "Resources") + @"\font.ttf";
                BaseFont baseFont = BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);


                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontHearder = new iTextSharp.text.Font(baseFont, 15, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontBold = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);

                // TẠO CHI TIẾT NHẬP HÀNG BAN ĐẦU
                Phrase phrase1 = new Phrase("CỬA HÀNG TẠP HÓA PHÚ SƠN", fontHearder);
                PdfPCell pdfPCell1 = new PdfPCell(phrase1);
                pdfPCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell1.Colspan = 3;
                pdfPCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(pdfPCell1);

                Phrase phrase2 = new Phrase("Chuyên Bán Sỉ, Lẻ Rượu Bia,Bánh Kẹo, Thuốc Lá, Sữa Các Loại...", font);
                PdfPCell pdfPCell2 = new PdfPCell(phrase2);
                pdfPCell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell2.Colspan = 3;
                pdfPCell2.HorizontalAlignment = Element.ALIGN_CENTER;

                table.AddCell(pdfPCell2);

                Phrase phrase3 = new Phrase("D/C: QL 1A - P.Kỳ Liên - T/X Kỳ Anh - Hà Tĩnh", font);
                PdfPCell pdfPCell3 = new PdfPCell(phrase3);
                pdfPCell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell3.Colspan = 3;
                pdfPCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(pdfPCell3);

                Phrase phrase4 = new Phrase("Đ/T: 0975.588.688 - 0911.412.389", font);
                PdfPCell pdfPCell4 = new PdfPCell(phrase4);
                pdfPCell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell4.Colspan = 3;
                pdfPCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(pdfPCell4);

                Phrase phrase91 = new Phrase("", font);
                PdfPCell pdfPCell91 = new PdfPCell(phrase91);
                pdfPCell91.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell91.Colspan = 3;
                pdfPCell91.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(pdfPCell91);

                Phrase phrase92 = new Phrase("PHIẾU NHÂP HÀNG", font);
                PdfPCell pdfPCell92 = new PdfPCell(phrase92);
                pdfPCell92.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell92.Colspan = 3;
                pdfPCell92.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(pdfPCell92);


                PdfPTable table1 = new PdfPTable(3);
                float[] columnsWidth1 = { 1, 1, 1 };
                table1.SetWidths(columnsWidth1);
                table1.DefaultCell.BorderWidth = 0;
                table1.DefaultCell.Padding = 10;
                table1.WidthPercentage = 100;
                table1.HorizontalAlignment = Element.ALIGN_LEFT;


                Phrase phrase6 = new Phrase("Mã HĐ:" + txt_maPN.Text, fontHearder);
                PdfPCell pdfPCell6 = new PdfPCell(phrase6);
                pdfPCell6.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell6.Colspan = 3;
                pdfPCell6.PaddingLeft = 400;
                pdfPCell6.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell6);

                var tennv = db.Nhanviens.Where(x => x.Manv.Equals(manv_current)).SingleOrDefault().Tennv;
                var sdt= db.Nhanviens.Where(x => x.Manv.Equals(manv_current)).SingleOrDefault().Sodt;
                Phrase phrase5 = new Phrase("   ", font);
                PdfPCell pdfPCell5 = new PdfPCell(phrase5);
                pdfPCell5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell5.Colspan = 3;
                pdfPCell5.PaddingTop = 20;
                pdfPCell5.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell5);

                Phrase phrase8 = new Phrase("Tên nhân viên nhâp:" + tennv , font);
                PdfPCell pdfPCell8 = new PdfPCell(phrase8);
                pdfPCell8.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell8.Colspan = 3;
                pdfPCell8.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell8);

                Phrase phrase85 = new Phrase("Số ĐT nhân viên nhâp:" + sdt, font);
                PdfPCell pdfPCell85 = new PdfPCell(phrase85);
                pdfPCell85.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell85.Colspan = 3;
                pdfPCell85.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell85);

                var nhacc = db.Nhaccs.Where(x => x.Mancc.Equals(cbb_NCC.SelectedValue)).SingleOrDefault();
                Phrase phrase82 = new Phrase("Tên nhà cung cấp:" + cbb_NCC.Text, font);
                PdfPCell pdfPCell82 = new PdfPCell(phrase82);
                pdfPCell82.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell82.Colspan = 3;
                pdfPCell82.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell82);

                Phrase phrase83 = new Phrase("Địa chỉ nhà cung cấp:" + nhacc.Diachi, font);
                PdfPCell pdfPCell83 = new PdfPCell(phrase83);
                pdfPCell83.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell83.Colspan = 3;
                pdfPCell83.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell83);

                Phrase phrase84 = new Phrase("Số điên thoại nhà cung cấp:" + nhacc.Sodt, font);
                PdfPCell pdfPCell84 = new PdfPCell(phrase84);
                pdfPCell84.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell84.Colspan = 3;
                pdfPCell84.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell84);






                Phrase phrase81 = new Phrase("          ", font);
                PdfPCell pdfPCell81 = new PdfPCell(phrase81);
                pdfPCell81.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell81.Colspan = 3;
                pdfPCell81.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell81);


              
                //table Sản phẩm
                PdfPTable tableProduct = new PdfPTable(dataGridView1.ColumnCount);
                tableProduct.DefaultCell.PaddingBottom = 10;
                tableProduct.DefaultCell.PaddingTop = 10;
                tableProduct.WidthPercentage = 90;
                tableProduct.PaddingTop = 50;
                tableProduct.HorizontalAlignment = Element.ALIGN_LEFT;
                tableProduct.DefaultCell.BorderWidth = 1;


                //add headertext
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell pdfPCell = new PdfPCell(new Phrase(column.HeaderText, fontBold));
                    pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfPCell.PaddingTop = 5;
                    pdfPCell.PaddingBottom = 5;
                    tableProduct.AddCell(pdfPCell);
                }

                //// add cell
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        PdfPCell pdfPCell = new PdfPCell(new Phrase(cell.Value.ToString(), font));
                        pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfPCell.Padding = 5;
                        tableProduct.AddCell(pdfPCell);
                    }
                }



                // TỔNG TIỀN CHỮ KÝ
                PdfPTable table2 = new PdfPTable(3);
                float[] columnsWidth2 = { 1, 1, 1 };
                table2.SetWidths(columnsWidth1);
                table2.DefaultCell.BorderWidth = 0;
                table2.DefaultCell.Padding = 10;
                table2.WidthPercentage = 100;
                table2.HorizontalAlignment = Element.ALIGN_LEFT;

                Phrase phrase9 = new Phrase("Tổng tiền:" + lblTongTien.Text, font);
                PdfPCell pdfPCell9 = new PdfPCell(phrase9);
                pdfPCell9.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell9.Colspan = 3;
                pdfPCell9.PaddingTop = 20;
                pdfPCell9.PaddingLeft = 400;
                pdfPCell9.HorizontalAlignment = Element.ALIGN_LEFT;
                table2.AddCell(pdfPCell9);

                Phrase phrase10 = new Phrase("Ngày lập: " + dtpDateTime.Value, font);
                PdfPCell pdfPCell10 = new PdfPCell(phrase10);
                pdfPCell10.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell10.Colspan = 3;
                pdfPCell10.PaddingTop = 20;
                pdfPCell10.PaddingLeft = 360;
                pdfPCell10.HorizontalAlignment = Element.ALIGN_LEFT;
                table2.AddCell(pdfPCell10);

                Phrase phrase11 = new Phrase("Chữ ký bên nhận           Chữ ký bên giao ", font);
                PdfPCell pdfPCell11 = new PdfPCell(phrase11);
                pdfPCell11.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell11.Colspan = 3;
                pdfPCell11.PaddingTop = 20;
                pdfPCell11.PaddingLeft = 340;
                pdfPCell11.HorizontalAlignment = Element.ALIGN_LEFT;
                table2.AddCell(pdfPCell11);




                document.Add(table);
                document.Add(table1);
                //document.Add(parablank);
                document.Add(tableProduct);
                document.Add(table2);
                //document.Add(parablank);
                //document.Add(para);

                document.Close();
                stream.Close();
                MessageBox.Show("In hóa đơn thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);




                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", savefile.FileName); // XML NHẬP
                }
                catch (Exception)
                {
                    System.Diagnostics.Process.Start("msedge.exe", savefile.FileName);

                }


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
       
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào!!!");
            }
            else if (ValiNCC())
            {
                Pnhap newPN = new Pnhap();
                newPN.Mapn = txt_maPN.Text;
                var ncc = db.Nhaccs.Where(s => s.Tenncc.Equals(cbb_NCC.Text)).FirstOrDefault();
                newPN.Mancc = ncc.Mancc;
                newPN.Manv = manv_current;
                newPN.Ngaynhap = dtpDateTime.Value;
                db.Pnhaps.Add(newPN);
                db.SaveChanges();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    string tensp = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    Sanpham sanpham = db.Sanphams.Where(s => s.Tensp.Equals(tensp)).FirstOrDefault();
                    var maDM = db.DanhmucSps.Where(s => s.Tendm.Equals(dataGridView1.Rows[i].Cells[1].Value.ToString().Trim())).SingleOrDefault().Madm;
                    if (sanpham == null)
                    {
                        sanpham = new Sanpham();
                        sanpham.Masp = AutoIDCus();
                        sanpham.Tensp = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        sanpham.DonGia =Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        sanpham.Madm =maDM;
                        sanpham.Sl = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value.ToString());
                        sanpham.DVT = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        db.Sanphams.Add(sanpham);
                        db.SaveChanges();
                    }    
                    Dongpnhap newDPN = new Dongpnhap();
                    newDPN.Mapn = newPN.Mapn;
                    newDPN.Masp = sanpham.Masp;
                    newDPN.Dongianhap = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    newDPN.Soluongnhap = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    db.Dongpnhaps.Add(newDPN);
                    db.SaveChanges();
                }
                DialogResult re = MessageBox.Show("Nhập hàng thành công, bạn có muôn in hóa đơn!", "Cảnh báo", MessageBoxButtons.YesNo);
                if (re == System.Windows.Forms.DialogResult.Yes)
                {
                    //in hóa đơn
                    inHoaDon();
                }
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                cbb_NCC.Text = "";
                txtSanPham.Text = "";
                txtSoLuong.Text = "";
                txtDonViTinh.Text = "";
                txtDonGia.Text = "";
                lblTongTien.Text = "0";
                txt_maPN.Text = "pn" + (db.Pnhaps.Select(s => s).Count() + 1).ToString();
                ThemHoaDonNhap_Load(sender, e);
            }

        }



        private void cbbSanPham_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbbDanhMuc, "");
        }

        private void txtSoLuong_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSoLuong, "");
        }

        private void txtDonGia_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDonGia, "");
        }

        private void cbb_NCC_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbb_NCC, "");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtSanPham_TextChanged(object sender, EventArgs e)
        {
            var sanpham = db.Sanphams.Where(x => x.Tensp.Equals(txtSanPham.Text)).SingleOrDefault();
            if (sanpham != null)
            {
                txtDonViTinh.Text = sanpham.DVT;
                txtDonGia.Text = sanpham.DonGia.ToString();
                cbbDanhMuc.SelectedValue = sanpham.Madm;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
