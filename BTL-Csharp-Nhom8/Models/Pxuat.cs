using System;
using System.Collections.Generic;

#nullable disable

namespace BTL_Csharp_Nhom8.Models
{
    public partial class Pxuat
    {
        public Pxuat()
        {
            Dongpxuats = new HashSet<Dongpxuat>();
        }

        public string Mapx { get; set; }
        public string Makh { get; set; }
        public string Manv { get; set; }
        public DateTime Ngayxuat { get; set; }

        public virtual Khachhang MakhNavigation { get; set; }
        public virtual Nhanvien ManvNavigation { get; set; }
        public virtual ICollection<Dongpxuat> Dongpxuats { get; set; }
    }
}
