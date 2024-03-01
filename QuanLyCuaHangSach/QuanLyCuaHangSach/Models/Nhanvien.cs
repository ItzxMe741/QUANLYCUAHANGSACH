using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Phieudathangbans = new HashSet<Phieudathangban>();
            Phieudathangmuas = new HashSet<Phieudathangmua>();
            Phieuthanhtoantienmuas = new HashSet<Phieuthanhtoantienmua>();
            Phieuthutienbans = new HashSet<Phieuthutienban>();
        }

        public int Idnhanvien { get; set; }
        public string Manhanvien { get; set; }
        public string Tennhanvien { get; set; }
        public string Sdt { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile FrontImage { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngaysinh { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Phieudathangban> Phieudathangbans { get; set; }
        public virtual ICollection<Phieudathangmua> Phieudathangmuas { get; set; }
        public virtual ICollection<Phieuthanhtoantienmua> Phieuthanhtoantienmuas { get; set; }
        public virtual ICollection<Phieuthutienban> Phieuthutienbans { get; set; }
    }
}
