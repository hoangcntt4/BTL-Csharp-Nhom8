using System;
using System.Collections.Generic;

#nullable disable

namespace BTL_Csharp_Nhom8.Models
{
    public partial class Pnhap
    {
        public Pnhap()
        {
            Dongpnhaps = new HashSet<Dongpnhap>();
        }

        public string Mapn { get; set; }
        public string Mancc { get; set; }
        public string Manv { get; set; }
        public DateTime Ngaynhap { get; set; }

        public virtual Nhacc ManccNavigation { get; set; }
        public virtual Nhanvien ManvNavigation { get; set; }
        public virtual ICollection<Dongpnhap> Dongpnhaps { get; set; }
    }
}
