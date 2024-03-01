using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Nhaxuatban
    {
        public Nhaxuatban()
        {
            Saches = new HashSet<Sach>();
        }

        public int Idnxb { get; set; }
        public string Manxb { get; set; }
        public string Tennxb { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
