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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
namespace BTL_Csharp_Nhom8
{
    public partial class InHoaDon : Form
    {
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();

        public String mahd { get; set; }
        public InHoaDon()
        {
            this.mahd = mahd;
            InitializeComponent();
        }

        private void InHoaDon_Load(object sender, EventArgs e)
        {
            txtmahd.Text = mahd;
            var query = db.Dongpxuats.Where(p => p.Mapx == mahd).ToList();




            var query1 = db.Pxuats.Where(p => p.Mapx == mahd).SingleOrDefault();
            string makh = query1.Makh;

            var query2 = db.Khachhangs.Where(p => p.Makh == makh).SingleOrDefault();
            string tenkh = query2.Tenkh;
            txtMaKH.Text = makh;
            txtSDT.Text = query2.Sdt;
            txtTenKH.Text = tenkh;
            dtpNgayLap.Value = query1.Ngayxuat;

            string manv = query1.Manv;

            var query4 = db.Nhanviens.Where(p => p.Manv == manv).SingleOrDefault();// LẤY RA RATHOONG TIN NHÂN VIÊN

            txtTenNV.Text = query4.Tennv;
            txtSDT_NV.Text = query4.Sodt;

            List<XemChiTietHoaDon> list = new List<XemChiTietHoaDon>();
            foreach (var item in query)
            {
                var sanpham = db.Sanphams.Where(p => p.Masp == item.Masp).SingleOrDefault();
                XemChiTietHoaDon hoadon = new XemChiTietHoaDon();
                hoadon.dvt = sanpham.DVT;
                hoadon.tensp = sanpham.Tensp;
                hoadon.soluong = item.Soluongxuat;
                hoadon.dongia = item.Dongiaxuat;
                hoadon.thanhtien = item.Dongiaxuat * item.Soluongxuat;
                list.Add(hoadon);

            }
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns[2].HeaderText = "Đơn vị tính";
            dataGridView1.Columns[1].HeaderText = "Số lượng ";
            dataGridView1.Columns[3].HeaderText = "Đơn giá (VNĐ)";
            dataGridView1.Columns[4].HeaderText = "Thành tiền(VNĐ)";

            int tongtien = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                tongtien = tongtien + Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            txtTongTien.Text = tongtien.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String filename = txtmahd.Text;
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

                Phrase phrase92 = new Phrase("PHIẾU GIAO NHẬN HÀNG HÓA", font);
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


                Phrase phrase6 = new Phrase("Mã HĐ:" + txtmahd.Text, fontHearder);
                PdfPCell pdfPCell6 = new PdfPCell(phrase6);
                pdfPCell6.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell6.Colspan = 3;
                pdfPCell6.PaddingLeft = 400;
                pdfPCell6.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell6);

                Phrase phrase5 = new Phrase("   ", font);
                PdfPCell pdfPCell5 = new PdfPCell(phrase5);
                pdfPCell5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell5.Colspan = 3;
                pdfPCell5.PaddingTop = 20;
                pdfPCell5.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell5);
                Phrase phrase8 = new Phrase("Tên KH:" + txtTenKH.Text + "                                                                                                                         Tên nhân viên:" + txtTenNV.Text, font);
                PdfPCell pdfPCell8 = new PdfPCell(phrase8);
                pdfPCell8.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell8.Colspan = 3;
                pdfPCell8.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell8);



                Phrase phrase7 = new Phrase("SĐT :" + txtSDT.Text + "                                                                                                                                SĐT nhân viên: "+txtSDT_NV.Text, font);
                PdfPCell pdfPCell7 = new PdfPCell(phrase7);
                pdfPCell7.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell7.Colspan = 3;
                pdfPCell5.PaddingTop = 20;
                pdfPCell7.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(pdfPCell7);

               

                Phrase phrase81 = new Phrase("          ",font);
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

                Phrase phrase9 = new Phrase("Tổng tiền:" + txtTongTien.Text, font);
                PdfPCell pdfPCell9 = new PdfPCell(phrase9);
                pdfPCell9.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell9.Colspan = 3;
                pdfPCell9.PaddingTop = 20;
                pdfPCell9.PaddingLeft = 400;
                pdfPCell9.HorizontalAlignment = Element.ALIGN_LEFT;
                table2.AddCell(pdfPCell9);

                Phrase phrase10 = new Phrase("Ngày lập: " + dtpNgayLap.Value, font);
                PdfPCell pdfPCell10 = new PdfPCell(phrase10);
                pdfPCell10.Border = iTextSharp.text.Rectangle.NO_BORDER;
                pdfPCell10.Colspan = 3;
                pdfPCell10.PaddingTop = 20;
                pdfPCell10.PaddingLeft = 360;
                pdfPCell10.HorizontalAlignment = Element.ALIGN_LEFT;
                table2.AddCell(pdfPCell10);

                Phrase phrase11 = new Phrase("Chữ ký bên nhận           Chữ ký bên giao ",font);
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
    }
}
