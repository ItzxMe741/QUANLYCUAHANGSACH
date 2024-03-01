using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Tacgia
    {
        public Tacgia()
        {
            Saches = new HashSet<Sach>();
        }

        public int Idtacgia { get; set; }
        public string Matacgia { get; set; }
        public string Tentacgia { get; set; }
        public string Ghichu { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
