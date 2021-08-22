using System;
using System.Collections.Generic;

#nullable disable

namespace BTL_Csharp_Nhom8.Models
{
    public partial class Nhacc
    {
        public Nhacc()
        {
            Pnhaps = new HashSet<Pnhap>();
        }

        public string Mancc { get; set; }
        public string Tenncc { get; set; }
        public string Diachi { get; set; }
        public string Sodt { get; set; }

        public virtual ICollection<Pnhap> Pnhaps { get; set; }
    }
}
