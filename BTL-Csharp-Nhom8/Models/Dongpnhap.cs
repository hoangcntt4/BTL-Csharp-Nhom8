using System;
using System.Collections.Generic;

#nullable disable

namespace BTL_Csharp_Nhom8.Models
{
    public partial class Dongpnhap
    {
        public string Masp { get; set; }
        public string Mapn { get; set; }
        public int Soluongnhap { get; set; }
        public int Dongianhap { get; set; }

        public virtual Pnhap MapnNavigation { get; set; }
        public virtual Sanpham MaspNavigation { get; set; }
    }
}
