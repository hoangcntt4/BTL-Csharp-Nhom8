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
        private void button1_Click(object sender, EventArgs e) 
        {
        }
    }
}
