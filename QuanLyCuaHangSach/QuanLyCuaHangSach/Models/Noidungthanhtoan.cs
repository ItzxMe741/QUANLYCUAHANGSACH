using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Noidungthanhtoan
    {
        public int Idndtt { get; set; }
        public double? Sotienthanhtoan { get; set; }
        public int? Phieuthanhtoantienmuaidptttm { get; set; }
        public int? Phieudathangmuaidpdhm { get; set; }

        public virtual Phieudathangmua PhieudathangmuaidpdhmNavigation { get; set; }
        public virtual Phieuthanhtoantienmua PhieuthanhtoantienmuaidptttmNavigation { get; set; }
    }
}
