using System;
using System.Collections.Generic;

#nullable disable

namespace BTL_Csharp_Nhom8.Models
{
    public partial class DanhmucSp
    {
        public DanhmucSp()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public string Madm { get; set; }
        public string Tendm { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
