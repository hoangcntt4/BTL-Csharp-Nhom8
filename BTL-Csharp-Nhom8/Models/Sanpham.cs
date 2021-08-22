using System;
using System.Collections.Generic;

#nullable disable

namespace BTL_Csharp_Nhom8.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Dongpnhaps = new HashSet<Dongpnhap>();
            Dongpxuats = new HashSet<Dongpxuat>();
        }

        public string Masp { get; set; }
        public string Tensp { get; set; }
        public string Madm { get; set; }
        public DateTime Hansd { get; set; }
        public string Mota { get; set; }
        public int Sl { get; set; }

        public virtual DanhmucSp MadmNavigation { get; set; }
        public virtual ICollection<Dongpnhap> Dongpnhaps { get; set; }
        public virtual ICollection<Dongpxuat> Dongpxuats { get; set; }
    }
}
