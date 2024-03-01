using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Phieudathangmuas = new HashSet<Phieudathangmua>();
        }

        public int Idncc { get; set; }
        public string Mancc { get; set; }
        public string Tenncc { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Masothue { get; set; }
        public string Email { get; set; }
        public string Stk { get; set; }
        public string Password { get; set; }
        public string Ghichu { get; set; }
        public bool? Active { get; set; }
        public int? Nganhangidnganhang { get; set; }

        public virtual Nganhang NganhangidnganhangNavigation { get; set; }
        public virtual ICollection<Phieudathangmua> Phieudathangmuas { get; set; }
    }
}
