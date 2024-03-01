using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Phieudathangbans = new HashSet<Phieudathangban>();
        }

        public int Idkhachhang { get; set; }
        public string Makhachhang { get; set; }
        public string Tenkhachhang { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile FrontImage { get; set; }
        public string Stk { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool? Active { get; set; }
        public int? Nganhangidnganhang { get; set; }

        public virtual Nganhang NganhangidnganhangNavigation { get; set; }
        public virtual ICollection<Phieudathangban> Phieudathangbans { get; set; }
    }
}
