using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Trangthai
    {
        public Trangthai()
        {
            Phieudathangbans = new HashSet<Phieudathangban>();
            Phieudathangmuas = new HashSet<Phieudathangmua>();
        }

        public int Idtt { get; set; }
        public string Tentt { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Phieudathangban> Phieudathangbans { get; set; }
        public virtual ICollection<Phieudathangmua> Phieudathangmuas { get; set; }
    }
}
