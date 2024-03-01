using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Phieudathangban
    {
        public Phieudathangban()
        {
            Chitietxuats = new HashSet<Chitietxuat>();
            Noidungthutiens = new HashSet<Noidungthutien>();
        }

        public int Idpdhb { get; set; }
        public string Sopdhb { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngaydat { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngaytiepnhan { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngaygiaohang { get; set; }
        public string Ghichu { get; set; }
        public bool? Active { get; set; }
        public int? Khachhangidkhachhang { get; set; }
        public int? Nhanvienidnhanvien { get; set; }
        public int? Trangthaiidtt { get; set; }
        public int? Donvivanchuyeniddvvc { get; set; }

        public virtual Donvivanchuyen DonvivanchuyeniddvvcNavigation { get; set; }
        public virtual Khachhang KhachhangidkhachhangNavigation { get; set; }
        public virtual Nhanvien NhanvienidnhanvienNavigation { get; set; }
        public virtual Trangthai TrangthaiidttNavigation { get; set; }
        public virtual ICollection<Chitietxuat> Chitietxuats { get; set; }
        public virtual ICollection<Noidungthutien> Noidungthutiens { get; set; }
    }
}
