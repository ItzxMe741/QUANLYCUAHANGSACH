using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Donvivanchuyen
    {
        public Donvivanchuyen()
        {
            Phieudathangbans = new HashSet<Phieudathangban>();
            Phieudathangmuas = new HashSet<Phieudathangmua>();
        }

        public int Iddvvc { get; set; }
        public string Madvvc { get; set; }
        public string Tendvvc { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Ghichu { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Phieudathangban> Phieudathangbans { get; set; }
        public virtual ICollection<Phieudathangmua> Phieudathangmuas { get; set; }
    }
}
