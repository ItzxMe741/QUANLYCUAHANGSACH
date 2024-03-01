using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Phieuthanhtoantienmua
    {
        public Phieuthanhtoantienmua()
        {
            Noidungthanhtoans = new HashSet<Noidungthanhtoan>();
        }

        public int Idptttm { get; set; }
        public string Soptttm { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngaythanhtoan { get; set; }
        public bool? Active { get; set; }
        public int? Htttidhttt { get; set; }
        public int? Nhanvienidnhanvien { get; set; }

        public virtual Httt HtttidhtttNavigation { get; set; }
        public virtual Nhanvien NhanvienidnhanvienNavigation { get; set; }
        public virtual ICollection<Noidungthanhtoan> Noidungthanhtoans { get; set; }
    }
}
