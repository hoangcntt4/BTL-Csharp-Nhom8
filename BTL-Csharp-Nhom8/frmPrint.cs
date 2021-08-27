using BTL_Csharp_Nhom8.Models;
using GSF.Adapters;
using Microsoft.Reporting.WinForms;
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
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
        }
        QLCuaHangTapHoaContext db = new QLCuaHangTapHoaContext();
        private void frmPrint_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            
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
            dgv_SPChay.DataSource = listProductMost.ToList();

            this.reportToolBar1.LocalReport.ReportEmbeddedResource = "BTL.ReportSP.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetSP";
            rds.Value = ds.Tables["SanPhamBanChayNhat"];
            this.reportToolBar1.LocalReport.DataSource.Add(rds);


            this.reportToolBar1.RefreshReport();
        }
    }
}
