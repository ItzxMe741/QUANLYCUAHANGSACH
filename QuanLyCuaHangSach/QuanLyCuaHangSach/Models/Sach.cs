using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Sach
    {
        public Sach()
        {
            Chitietnhaps = new HashSet<Chitietnhap>();
            Chitietxuats = new HashSet<Chitietxuat>();
        }

        public int Idsach { get; set; }
        public string Masach { get; set; }
        public string Tensach { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngayxb { get; set; }
        public string Lanxb { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile FrontImage { get; set; }
        public string Ghichu { get; set; }
        public bool? Active { get; set; }
        public int? Loaisachidloai { get; set; }
        public int? Nhaxuatbanidnxb { get; set; }
        public int? Tacgiaidtacgia { get; set; }
        public int? Ngonnguidngonngu { get; set; }

        public virtual Loaisach LoaisachidloaiNavigation { get; set; }
        public virtual Ngonngu NgonnguidngonnguNavigation { get; set; }
        public virtual Nhaxuatban NhaxuatbanidnxbNavigation { get; set; }
        public virtual Tacgia TacgiaidtacgiaNavigation { get; set; }
        public virtual ICollection<Chitietnhap> Chitietnhaps { get; set; }
        public virtual ICollection<Chitietxuat> Chitietxuats { get; set; }
    }
}
