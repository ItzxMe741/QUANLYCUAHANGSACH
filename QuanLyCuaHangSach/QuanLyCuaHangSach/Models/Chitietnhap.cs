using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Chitietnhap
    {
        public int Idctn { get; set; }
        public int? Sldat { get; set; }
        public int? Slgiao { get; set; }
        public string Dvt { get; set; }
        public double? Dongianhap { get; set; }
        public bool? Xacnhan { get; set; }
        public int? Sachidsach { get; set; }
        public int? Phieudathangmuaidpdhm { get; set; }

        public virtual Phieudathangmua PhieudathangmuaidpdhmNavigation { get; set; }
        public virtual Sach SachidsachNavigation { get; set; }
    }
}
