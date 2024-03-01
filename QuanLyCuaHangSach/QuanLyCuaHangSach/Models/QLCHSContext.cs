using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuanLyCuaHangSach.Models
{
    public partial class QLCHSContext : DbContext
    {
        public QLCHSContext()
        {
        }

        public QLCHSContext(DbContextOptions<QLCHSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietnhap> Chitietnhaps { get; set; }
        public virtual DbSet<Chitietxuat> Chitietxuats { get; set; }
        public virtual DbSet<Donvivanchuyen> Donvivanchuyens { get; set; }
        public virtual DbSet<Httt> Httts { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Loaisach> Loaisaches { get; set; }
        public virtual DbSet<Nganhang> Nganhangs { get; set; }
        public virtual DbSet<Ngonngu> Ngonngus { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Nhaxuatban> Nhaxuatbans { get; set; }
        public virtual DbSet<Noidungthanhtoan> Noidungthanhtoans { get; set; }
        public virtual DbSet<Noidungthutien> Noidungthutiens { get; set; }
        public virtual DbSet<Phieudathangban> Phieudathangbans { get; set; }
        public virtual DbSet<Phieudathangmua> Phieudathangmuas { get; set; }
        public virtual DbSet<Phieuthanhtoantienmua> Phieuthanhtoantienmuas { get; set; }
        public virtual DbSet<Phieuthutienban> Phieuthutienbans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Tacgia> Tacgias { get; set; }
        public virtual DbSet<Trangthai> Trangthais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=GODOFGA\\SQLEXPRESS;Initial Catalog=QLCHS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Chitietnhap>(entity =>
            {
                entity.HasKey(e => e.Idctn)
                    .HasName("PK__CHITIETN__91A8964E485AA43C");

                entity.ToTable("CHITIETNHAP");

                entity.Property(e => e.Idctn).HasColumnName("IDCTN");

                entity.Property(e => e.Dongianhap).HasColumnName("DONGIANHAP");

                entity.Property(e => e.Dvt)
                    .HasMaxLength(255)
                    .HasColumnName("DVT");

                entity.Property(e => e.Phieudathangmuaidpdhm).HasColumnName("PHIEUDATHANGMUAIDPDHM");

                entity.Property(e => e.Sachidsach).HasColumnName("SACHIDSACH");

                entity.Property(e => e.Sldat).HasColumnName("SLDAT");

                entity.Property(e => e.Slgiao).HasColumnName("SLGIAO");

                entity.Property(e => e.Xacnhan).HasColumnName("XACNHAN");

                entity.HasOne(d => d.PhieudathangmuaidpdhmNavigation)
                    .WithMany(p => p.Chitietnhaps)
                    .HasForeignKey(d => d.Phieudathangmuaidpdhm)
                    .HasConstraintName("FKCHITIETNHA597063");

                entity.HasOne(d => d.SachidsachNavigation)
                    .WithMany(p => p.Chitietnhaps)
                    .HasForeignKey(d => d.Sachidsach)
                    .HasConstraintName("FKCHITIETNHA209084");
            });

            modelBuilder.Entity<Chitietxuat>(entity =>
            {
                entity.HasKey(e => e.Idctx)
                    .HasName("PK__CHITIETX__91A897B077062A08");

                entity.ToTable("CHITIETXUAT");

                entity.Property(e => e.Idctx).HasColumnName("IDCTX");

                entity.Property(e => e.Dongiaban).HasColumnName("DONGIABAN");

                entity.Property(e => e.Dvt)
                    .HasMaxLength(255)
                    .HasColumnName("DVT");

                entity.Property(e => e.Phieudathangbanidpdhb).HasColumnName("PHIEUDATHANGBANIDPDHB");

                entity.Property(e => e.Sachidsach).HasColumnName("SACHIDSACH");

                entity.Property(e => e.Sldat).HasColumnName("SLDAT");

                entity.Property(e => e.Slgiao).HasColumnName("SLGIAO");

                entity.Property(e => e.Xacnhan).HasColumnName("XACNHAN");

                entity.HasOne(d => d.PhieudathangbanidpdhbNavigation)
                    .WithMany(p => p.Chitietxuats)
                    .HasForeignKey(d => d.Phieudathangbanidpdhb)
                    .HasConstraintName("FKCHITIETXUA989455");

                entity.HasOne(d => d.SachidsachNavigation)
                    .WithMany(p => p.Chitietxuats)
                    .HasForeignKey(d => d.Sachidsach)
                    .HasConstraintName("FKCHITIETXUA898676");
            });

            modelBuilder.Entity<Donvivanchuyen>(entity =>
            {
                entity.HasKey(e => e.Iddvvc)
                    .HasName("PK__DONVIVAN__303C0973B65D02FC");

                entity.ToTable("DONVIVANCHUYEN");

                entity.Property(e => e.Iddvvc).HasColumnName("IDDVVC");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Diachi)
                    .HasColumnType("ntext")
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Ghichu)
                    .HasColumnType("ntext")
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Madvvc)
                    .HasMaxLength(255)
                    .HasColumnName("MADVVC");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("SDT");

                entity.Property(e => e.Tendvvc)
                    .HasMaxLength(255)
                    .HasColumnName("TENDVVC");
            });

            modelBuilder.Entity<Httt>(entity =>
            {
                entity.HasKey(e => e.Idhttt)
                    .HasName("PK__HTTT__9DCEA6E366B6E543");

                entity.ToTable("HTTT");

                entity.Property(e => e.Idhttt).HasColumnName("IDHTTT");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Ghichu)
                    .HasColumnType("ntext")
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Mahttt)
                    .HasMaxLength(255)
                    .HasColumnName("MAHTTT");

                entity.Property(e => e.Nganhangidnganhang).HasColumnName("NGANHANGIDNGANHANG");

                entity.Property(e => e.Tenhttt)
                    .HasMaxLength(255)
                    .HasColumnName("TENHTTT");

                entity.HasOne(d => d.NganhangidnganhangNavigation)
                    .WithMany(p => p.Httts)
                    .HasForeignKey(d => d.Nganhangidnganhang)
                    .HasConstraintName("FKHTTT886305");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Idkhachhang)
                    .HasName("PK__KHACHHAN__629294BE3ECB49F8");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Idkhachhang).HasColumnName("IDKHACHHANG");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Diachi)
                    .HasColumnType("ntext")
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Image).HasColumnName("IMAGE");

                entity.Property(e => e.Makhachhang)
                    .HasMaxLength(255)
                    .HasColumnName("MAKHACHHANG");

                entity.Property(e => e.Nganhangidnganhang).HasColumnName("NGANHANGIDNGANHANG");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("SDT");

                entity.Property(e => e.Stk)
                    .HasMaxLength(255)
                    .HasColumnName("STK");

                entity.Property(e => e.Tenkhachhang)
                    .HasMaxLength(255)
                    .HasColumnName("TENKHACHHANG");

                entity.HasOne(d => d.NganhangidnganhangNavigation)
                    .WithMany(p => p.Khachhangs)
                    .HasForeignKey(d => d.Nganhangidnganhang)
                    .HasConstraintName("FKKHACHHANG96359");
            });

            modelBuilder.Entity<Loaisach>(entity =>
            {
                entity.HasKey(e => e.Idloai)
                    .HasName("PK__LOAISACH__0CDEF51920006DAA");

                entity.ToTable("LOAISACH");

                entity.Property(e => e.Idloai).HasColumnName("IDLOAI");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(255)
                    .HasColumnName("MALOAI");

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(255)
                    .HasColumnName("TENLOAI");
            });

            modelBuilder.Entity<Nganhang>(entity =>
            {
                entity.HasKey(e => e.Idnganhang)
                    .HasName("PK__NGANHANG__4C4BF656F11415DB");

                entity.ToTable("NGANHANG");

                entity.Property(e => e.Idnganhang).HasColumnName("IDNGANHANG");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Ghichu)
                    .HasColumnType("ntext")
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Manganhang)
                    .HasMaxLength(255)
                    .HasColumnName("MANGANHANG");

                entity.Property(e => e.Tennganhang)
                    .HasMaxLength(255)
                    .HasColumnName("TENNGANHANG");
            });

            modelBuilder.Entity<Ngonngu>(entity =>
            {
                entity.HasKey(e => e.Idngonngu)
                    .HasName("PK__NGONNGU__F2344A3F6F02F454");

                entity.ToTable("NGONNGU");

                entity.Property(e => e.Idngonngu).HasColumnName("IDNGONNGU");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Tenngongu)
                    .HasMaxLength(255)
                    .HasColumnName("TENNGONGU");
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.HasKey(e => e.Idncc)
                    .HasName("PK__NHACUNGC__945E4705B47300B6");

                entity.ToTable("NHACUNGCAP");

                entity.Property(e => e.Idncc).HasColumnName("IDNCC");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Diachi)
                    .HasColumnType("ntext")
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Ghichu)
                    .HasColumnType("ntext")
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Mancc)
                    .HasMaxLength(255)
                    .HasColumnName("MANCC");

                entity.Property(e => e.Masothue)
                    .HasMaxLength(255)
                    .HasColumnName("MASOTHUE");

                entity.Property(e => e.Nganhangidnganhang).HasColumnName("NGANHANGIDNGANHANG");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("SDT");

                entity.Property(e => e.Stk)
                    .HasMaxLength(255)
                    .HasColumnName("STK");

                entity.Property(e => e.Tenncc)
                    .HasMaxLength(255)
                    .HasColumnName("TENNCC");

                entity.HasOne(d => d.NganhangidnganhangNavigation)
                    .WithMany(p => p.Nhacungcaps)
                    .HasForeignKey(d => d.Nganhangidnganhang)
                    .HasConstraintName("FKNHACUNGCAP775616");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Idnhanvien)
                    .HasName("PK__NHANVIEN__CEEFA9833F1023A1");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Idnhanvien).HasColumnName("IDNHANVIEN");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Manhanvien)
                    .HasMaxLength(255)
                    .HasColumnName("MANHANVIEN");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("SDT");

                entity.Property(e => e.Tennhanvien)
                    .HasMaxLength(255)
                    .HasColumnName("TENNHANVIEN");
            });

            modelBuilder.Entity<Nhaxuatban>(entity =>
            {
                entity.HasKey(e => e.Idnxb)
                    .HasName("PK__NHAXUATB__945B98FB7353941D");

                entity.ToTable("NHAXUATBAN");

                entity.Property(e => e.Idnxb).HasColumnName("IDNXB");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Manxb)
                    .HasMaxLength(255)
                    .HasColumnName("MANXB");

                entity.Property(e => e.Tennxb)
                    .HasMaxLength(255)
                    .HasColumnName("TENNXB");
            });

            modelBuilder.Entity<Noidungthanhtoan>(entity =>
            {
                entity.HasKey(e => e.Idndtt)
                    .HasName("PK__NOIDUNGT__383E185187B9A3BC");

                entity.ToTable("NOIDUNGTHANHTOAN");

                entity.Property(e => e.Idndtt).HasColumnName("IDNDTT");

                entity.Property(e => e.Phieudathangmuaidpdhm).HasColumnName("PHIEUDATHANGMUAIDPDHM");

                entity.Property(e => e.Phieuthanhtoantienmuaidptttm).HasColumnName("PHIEUTHANHTOANTIENMUAIDPTTTM");

                entity.Property(e => e.Sotienthanhtoan).HasColumnName("SOTIENTHANHTOAN");

                entity.HasOne(d => d.PhieudathangmuaidpdhmNavigation)
                    .WithMany(p => p.Noidungthanhtoans)
                    .HasForeignKey(d => d.Phieudathangmuaidpdhm)
                    .HasConstraintName("FKNOIDUNGTHA22473");

                entity.HasOne(d => d.PhieuthanhtoantienmuaidptttmNavigation)
                    .WithMany(p => p.Noidungthanhtoans)
                    .HasForeignKey(d => d.Phieuthanhtoantienmuaidptttm)
                    .HasConstraintName("FKNOIDUNGTHA787343");
            });

            modelBuilder.Entity<Noidungthutien>(entity =>
            {
                entity.HasKey(e => e.Idndthu)
                    .HasName("PK__NOIDUNGT__3EAAF7A5D490F293");

                entity.ToTable("NOIDUNGTHUTIEN");

                entity.Property(e => e.Idndthu).HasColumnName("IDNDTHU");

                entity.Property(e => e.Phieudathangbanidpdhb).HasColumnName("PHIEUDATHANGBANIDPDHB");

                entity.Property(e => e.Phieuthutienbanidpttb).HasColumnName("PHIEUTHUTIENBANIDPTTB");

                entity.Property(e => e.Sotienthu).HasColumnName("SOTIENTHU");

                entity.HasOne(d => d.PhieudathangbanidpdhbNavigation)
                    .WithMany(p => p.Noidungthutiens)
                    .HasForeignKey(d => d.Phieudathangbanidpdhb)
                    .HasConstraintName("FKNOIDUNGTHU806863");

                entity.HasOne(d => d.PhieuthutienbanidpttbNavigation)
                    .WithMany(p => p.Noidungthutiens)
                    .HasForeignKey(d => d.Phieuthutienbanidpttb)
                    .HasConstraintName("FKNOIDUNGTHU127596");
            });

            modelBuilder.Entity<Phieudathangban>(entity =>
            {
                entity.HasKey(e => e.Idpdhb)
                    .HasName("PK__PHIEUDAT__A2D2C985025BBECC");

                entity.ToTable("PHIEUDATHANGBAN");

                entity.Property(e => e.Idpdhb).HasColumnName("IDPDHB");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Donvivanchuyeniddvvc).HasColumnName("DONVIVANCHUYENIDDVVC");

                entity.Property(e => e.Ghichu)
                    .HasColumnType("ntext")
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Khachhangidkhachhang).HasColumnName("KHACHHANGIDKHACHHANG");

                entity.Property(e => e.Ngaydat)
                    .HasColumnType("date")
                    .HasColumnName("NGAYDAT");

                entity.Property(e => e.Ngaygiaohang)
                    .HasColumnType("date")
                    .HasColumnName("NGAYGIAOHANG");

                entity.Property(e => e.Ngaytiepnhan)
                    .HasColumnType("date")
                    .HasColumnName("NGAYTIEPNHAN");

                entity.Property(e => e.Nhanvienidnhanvien).HasColumnName("NHANVIENIDNHANVIEN");

                entity.Property(e => e.Sopdhb)
                    .HasMaxLength(255)
                    .HasColumnName("SOPDHB");

                entity.Property(e => e.Trangthaiidtt).HasColumnName("TRANGTHAIIDTT");

                entity.HasOne(d => d.DonvivanchuyeniddvvcNavigation)
                    .WithMany(p => p.Phieudathangbans)
                    .HasForeignKey(d => d.Donvivanchuyeniddvvc)
                    .HasConstraintName("FKPHIEUDATHA350616");

                entity.HasOne(d => d.KhachhangidkhachhangNavigation)
                    .WithMany(p => p.Phieudathangbans)
                    .HasForeignKey(d => d.Khachhangidkhachhang)
                    .HasConstraintName("FKPHIEUDATHA440685");

                entity.HasOne(d => d.NhanvienidnhanvienNavigation)
                    .WithMany(p => p.Phieudathangbans)
                    .HasForeignKey(d => d.Nhanvienidnhanvien)
                    .HasConstraintName("FKPHIEUDATHA497914");

                entity.HasOne(d => d.TrangthaiidttNavigation)
                    .WithMany(p => p.Phieudathangbans)
                    .HasForeignKey(d => d.Trangthaiidtt)
                    .HasConstraintName("FKPHIEUDATHA366751");
            });

            modelBuilder.Entity<Phieudathangmua>(entity =>
            {
                entity.HasKey(e => e.Idpdhm)
                    .HasName("PK__PHIEUDAT__A2D2C988BD813EC2");

                entity.ToTable("PHIEUDATHANGMUA");

                entity.Property(e => e.Idpdhm).HasColumnName("IDPDHM");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Donvivanchuyeniddvvc).HasColumnName("DONVIVANCHUYENIDDVVC");

                entity.Property(e => e.Ghichu)
                    .HasColumnType("ntext")
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Ngaydat)
                    .HasColumnType("date")
                    .HasColumnName("NGAYDAT");

                entity.Property(e => e.Ngaygiaohang)
                    .HasColumnType("date")
                    .HasColumnName("NGAYGIAOHANG");

                entity.Property(e => e.Ngaytiepnhan)
                    .HasColumnType("date")
                    .HasColumnName("NGAYTIEPNHAN");

                entity.Property(e => e.Nhacungcapidncc).HasColumnName("NHACUNGCAPIDNCC");

                entity.Property(e => e.Nhanvienidnhanvien).HasColumnName("NHANVIENIDNHANVIEN");

                entity.Property(e => e.Sopdhm)
                    .HasMaxLength(255)
                    .HasColumnName("SOPDHM");

                entity.Property(e => e.Trangthaiidtt).HasColumnName("TRANGTHAIIDTT");

                entity.HasOne(d => d.DonvivanchuyeniddvvcNavigation)
                    .WithMany(p => p.Phieudathangmuas)
                    .HasForeignKey(d => d.Donvivanchuyeniddvvc)
                    .HasConstraintName("FKPHIEUDATHA339438");

                entity.HasOne(d => d.NhacungcapidnccNavigation)
                    .WithMany(p => p.Phieudathangmuas)
                    .HasForeignKey(d => d.Nhacungcapidncc)
                    .HasConstraintName("FKPHIEUDATHA67436");

                entity.HasOne(d => d.NhanvienidnhanvienNavigation)
                    .WithMany(p => p.Phieudathangmuas)
                    .HasForeignKey(d => d.Nhanvienidnhanvien)
                    .HasConstraintName("FKPHIEUDATHA486736");

                entity.HasOne(d => d.TrangthaiidttNavigation)
                    .WithMany(p => p.Phieudathangmuas)
                    .HasForeignKey(d => d.Trangthaiidtt)
                    .HasConstraintName("FKPHIEUDATHA377929");
            });

            modelBuilder.Entity<Phieuthanhtoantienmua>(entity =>
            {
                entity.HasKey(e => e.Idptttm)
                    .HasName("PK__PHIEUTHA__0228700E6276F61A");

                entity.ToTable("PHIEUTHANHTOANTIENMUA");

                entity.Property(e => e.Idptttm).HasColumnName("IDPTTTM");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Htttidhttt).HasColumnName("HTTTIDHTTT");

                entity.Property(e => e.Ngaythanhtoan)
                    .HasColumnType("date")
                    .HasColumnName("NGAYTHANHTOAN");

                entity.Property(e => e.Nhanvienidnhanvien).HasColumnName("NHANVIENIDNHANVIEN");

                entity.Property(e => e.Soptttm)
                    .HasMaxLength(255)
                    .HasColumnName("SOPTTTM");

                entity.HasOne(d => d.HtttidhtttNavigation)
                    .WithMany(p => p.Phieuthanhtoantienmuas)
                    .HasForeignKey(d => d.Htttidhttt)
                    .HasConstraintName("FKPHIEUTHANH436959");

                entity.HasOne(d => d.NhanvienidnhanvienNavigation)
                    .WithMany(p => p.Phieuthanhtoantienmuas)
                    .HasForeignKey(d => d.Nhanvienidnhanvien)
                    .HasConstraintName("FKPHIEUTHANH219561");
            });

            modelBuilder.Entity<Phieuthutienban>(entity =>
            {
                entity.HasKey(e => e.Idpttb)
                    .HasName("PK__PHIEUTHU__8F8EFC5B7435F6F1");

                entity.ToTable("PHIEUTHUTIENBAN");

                entity.Property(e => e.Idpttb).HasColumnName("IDPTTB");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Htttidhttt).HasColumnName("HTTTIDHTTT");

                entity.Property(e => e.Ngaythutien).HasColumnName("NGAYTHUTIEN");

                entity.Property(e => e.Nhanvienidnhanvien).HasColumnName("NHANVIENIDNHANVIEN");

                entity.Property(e => e.Sopttb)
                    .HasMaxLength(255)
                    .HasColumnName("SOPTTB");

                entity.HasOne(d => d.HtttidhtttNavigation)
                    .WithMany(p => p.Phieuthutienbans)
                    .HasForeignKey(d => d.Htttidhttt)
                    .HasConstraintName("FKPHIEUTHUTI514256");

                entity.HasOne(d => d.NhanvienidnhanvienNavigation)
                    .WithMany(p => p.Phieuthutienbans)
                    .HasForeignKey(d => d.Nhanvienidnhanvien)
                    .HasConstraintName("FKPHIEUTHUTI142264");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Idsach)
                    .HasName("PK__SACH__8FB3F1150C47B9C7");

                entity.ToTable("SACH");

                entity.Property(e => e.Idsach).HasColumnName("IDSACH");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Ghichu)
                    .HasColumnType("ntext")
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Image).HasColumnName("IMAGE");

                entity.Property(e => e.Lanxb)
                    .HasMaxLength(255)
                    .HasColumnName("LANXB");

                entity.Property(e => e.Loaisachidloai).HasColumnName("LOAISACHIDLOAI");

                entity.Property(e => e.Masach)
                    .HasMaxLength(255)
                    .HasColumnName("MASACH");

                entity.Property(e => e.Ngayxb)
                    .HasColumnType("date")
                    .HasColumnName("NGAYXB");

                entity.Property(e => e.Ngonnguidngonngu).HasColumnName("NGONNGUIDNGONNGU");

                entity.Property(e => e.Nhaxuatbanidnxb).HasColumnName("NHAXUATBANIDNXB");

                entity.Property(e => e.Tacgiaidtacgia).HasColumnName("TACGIAIDTACGIA");

                entity.Property(e => e.Tensach)
                    .HasMaxLength(255)
                    .HasColumnName("TENSACH");

                entity.HasOne(d => d.LoaisachidloaiNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Loaisachidloai)
                    .HasConstraintName("FKSACH513020");

                entity.HasOne(d => d.NgonnguidngonnguNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Ngonnguidngonngu)
                    .HasConstraintName("FKSACH970053");

                entity.HasOne(d => d.NhaxuatbanidnxbNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Nhaxuatbanidnxb)
                    .HasConstraintName("FKSACH492486");

                entity.HasOne(d => d.TacgiaidtacgiaNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Tacgiaidtacgia)
                    .HasConstraintName("FKSACH553672");
            });

            modelBuilder.Entity<Tacgia>(entity =>
            {
                entity.HasKey(e => e.Idtacgia)
                    .HasName("PK__TACGIA__9D7CC9B0637EF363");

                entity.ToTable("TACGIA");

                entity.Property(e => e.Idtacgia).HasColumnName("IDTACGIA");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Ghichu)
                    .HasColumnType("ntext")
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Matacgia)
                    .HasMaxLength(255)
                    .HasColumnName("MATACGIA");

                entity.Property(e => e.Tentacgia)
                    .HasMaxLength(255)
                    .HasColumnName("TENTACGIA");
            });

            modelBuilder.Entity<Trangthai>(entity =>
            {
                entity.HasKey(e => e.Idtt)
                    .HasName("PK__TRANGTHA__B87C3AF87454C78A");

                entity.ToTable("TRANGTHAI");

                entity.Property(e => e.Idtt).HasColumnName("IDTT");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Tentt)
                    .HasMaxLength(255)
                    .HasColumnName("TENTT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
