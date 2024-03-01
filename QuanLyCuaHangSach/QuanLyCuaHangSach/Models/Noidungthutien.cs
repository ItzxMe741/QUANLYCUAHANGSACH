using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Noidungthutien
    {
        public int Idndthu { get; set; }
        public int? Phieudathangbanidpdhb { get; set; }
        public int? Phieuthutienbanidpttb { get; set; }
        public double? Sotienthu { get; set; }

        public virtual Phieudathangban PhieudathangbanidpdhbNavigation { get; set; }
        public virtual Phieuthutienban PhieuthutienbanidpttbNavigation { get; set; }
    }
}
