using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Loaisach
    {
        public Loaisach()
        {
            Saches = new HashSet<Sach>();
        }

        public int Idloai { get; set; }
        public string Maloai { get; set; }
        public string Tenloai { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
