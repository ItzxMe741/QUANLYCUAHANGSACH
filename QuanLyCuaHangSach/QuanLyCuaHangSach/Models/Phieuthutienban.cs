using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Phieuthutienban
    {
        public Phieuthutienban()
        {
            Noidungthutiens = new HashSet<Noidungthutien>();
        }

        public int Idpttb { get; set; }
        public string Sopttb { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngaythutien { get; set; }
        public bool? Active { get; set; }
        public int? Nhanvienidnhanvien { get; set; }
        public int? Htttidhttt { get; set; }

        public virtual Httt HtttidhtttNavigation { get; set; }
        public virtual Nhanvien NhanvienidnhanvienNavigation { get; set; }
        public virtual ICollection<Noidungthutien> Noidungthutiens { get; set; }
    }
}
