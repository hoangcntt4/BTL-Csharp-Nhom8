using System;
using System.Collections.Generic;

#nullable disable

namespace BTL_Csharp_Nhom8.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Pxuats = new HashSet<Pxuat>();
        }

        public string Makh { get; set; }
        public string Tenkh { get; set; }
        public bool? Gioitnh { get; set; }
        public string Sdt { get; set; }

        public virtual ICollection<Pxuat> Pxuats { get; set; }
    }
}
