using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Ngonngu
    {
        public Ngonngu()
        {
            Saches = new HashSet<Sach>();
        }

        public int Idngonngu { get; set; }
        public string Tenngongu { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
