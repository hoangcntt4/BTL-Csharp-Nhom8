using System;
using System.Collections.Generic;

#nullable disable

namespace BTL_Csharp_Nhom8.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Pnhaps = new HashSet<Pnhap>();
            Pxuats = new HashSet<Pxuat>();
        }

        public string Manv { get; set; }
        public string Tennv { get; set; }
        public bool? Gioitnh { get; set; }
        public string Sodt { get; set; }
        public string Diachi { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Pnhap> Pnhaps { get; set; }
        public virtual ICollection<Pxuat> Pxuats { get; set; }
    }
}
