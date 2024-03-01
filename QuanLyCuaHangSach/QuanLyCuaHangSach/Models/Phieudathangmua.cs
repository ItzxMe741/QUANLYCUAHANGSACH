using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Phieudathangmua
    {
        public Phieudathangmua()
        {
            Chitietnhaps = new HashSet<Chitietnhap>();
            Noidungthanhtoans = new HashSet<Noidungthanhtoan>();
        }

        public int Idpdhm { get; set; }
        public string Sopdhm { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngaydat { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngaytiepnhan { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngaygiaohang { get; set; }
        public string Ghichu { get; set; }
        public bool? Active { get; set; }
        public int? Nhacungcapidncc { get; set; }
        public int? Nhanvienidnhanvien { get; set; }
        public int? Trangthaiidtt { get; set; }
        public int? Donvivanchuyeniddvvc { get; set; }

        public virtual Donvivanchuyen DonvivanchuyeniddvvcNavigation { get; set; }
        public virtual Nhacungcap NhacungcapidnccNavigation { get; set; }
        public virtual Nhanvien NhanvienidnhanvienNavigation { get; set; }
        public virtual Trangthai TrangthaiidttNavigation { get; set; }
        public virtual ICollection<Chitietnhap> Chitietnhaps { get; set; }
        public virtual ICollection<Noidungthanhtoan> Noidungthanhtoans { get; set; }
    }
}
