using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Nganhang
    {
        public Nganhang()
        {
            Httts = new HashSet<Httt>();
            Khachhangs = new HashSet<Khachhang>();
            Nhacungcaps = new HashSet<Nhacungcap>();
        }

        public int Idnganhang { get; set; }
        public string Manganhang { get; set; }
        public string Tennganhang { get; set; }
        public string Ghichu { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Httt> Httts { get; set; }
        public virtual ICollection<Khachhang> Khachhangs { get; set; }
        public virtual ICollection<Nhacungcap> Nhacungcaps { get; set; }
    }
}
