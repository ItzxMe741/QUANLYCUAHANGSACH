using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Chitietxuat
    {
        public int Idctx { get; set; }
        public int? Sldat { get; set; }
        public int? Slgiao { get; set; }
        public string Dvt { get; set; }
        public double? Dongiaban { get; set; }
        public bool? Xacnhan { get; set; }
        public int? Sachidsach { get; set; }
        public int? Phieudathangbanidpdhb { get; set; }

        public virtual Phieudathangban PhieudathangbanidpdhbNavigation { get; set; }
        public virtual Sach SachidsachNavigation { get; set; }
    }
}
