using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Httt
    {
        public Httt()
        {
            Phieuthanhtoantienmuas = new HashSet<Phieuthanhtoantienmua>();
            Phieuthutienbans = new HashSet<Phieuthutienban>();
        }

        public int Idhttt { get; set; }
        public string Mahttt { get; set; }
        public string Tenhttt { get; set; }
        public string Ghichu { get; set; }
        public bool? Active { get; set; }
        public int? Nganhangidnganhang { get; set; }

        public virtual Nganhang NganhangidnganhangNavigation { get; set; }
        public virtual ICollection<Phieuthanhtoantienmua> Phieuthanhtoantienmuas { get; set; }
        public virtual ICollection<Phieuthutienban> Phieuthutienbans { get; set; }
    }
}
