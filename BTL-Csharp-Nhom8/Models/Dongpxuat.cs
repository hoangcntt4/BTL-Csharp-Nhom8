using System;
using System.Collections.Generic;

#nullable disable

namespace BTL_Csharp_Nhom8.Models
{
    public partial class Dongpxuat
    {
        public string Mapx { get; set; }
        public string Masp { get; set; }
        public int Soluongxuat { get; set; }
        public int Dongiaxuat { get; set; }

        public virtual Pxuat MapxNavigation { get; set; }
        public virtual Sanpham MaspNavigation { get; set; }
    }
}
