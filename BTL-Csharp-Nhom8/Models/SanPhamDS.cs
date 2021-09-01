using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_Csharp_Nhom8.Models
{
    public class SanPhamDS
    {
        public string MASP { get; set; }
        public string TENSP { get; set; }
        public int DonGia { get; set; }
        public string TENDM { get; set; }
        public string MOTA { get; set; }
        public int SL { get; set; }
        public string DVT { get; set; }
        public DateTime Tungay { get; set; }
        public DateTime Denngay { get; set; }
        public int Thang { get; set; }
    }
}
