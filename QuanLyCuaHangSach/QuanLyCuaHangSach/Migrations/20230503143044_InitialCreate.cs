using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyCuaHangSach.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DONVIVANCHUYEN",
                columns: table => new
                {
                    IDDVVC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MADVVC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TENDVVC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DIACHI = table.Column<string>(type: "ntext", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GHICHU = table.Column<string>(type: "ntext", nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DONVIVAN__303C0973B65D02FC", x => x.IDDVVC);
                });

            migrationBuilder.CreateTable(
                name: "LOAISACH",
                columns: table => new
                {
                    IDLOAI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MALOAI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TENLOAI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOAISACH__0CDEF51920006DAA", x => x.IDLOAI);
                });

            migrationBuilder.CreateTable(
                name: "NGANHANG",
                columns: table => new
                {
                    IDNGANHANG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MANGANHANG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TENNGANHANG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GHICHU = table.Column<string>(type: "ntext", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NGANHANG__4C4BF656F11415DB", x => x.IDNGANHANG);
                });

            migrationBuilder.CreateTable(
                name: "NGONNGU",
                columns: table => new
                {
                    IDNGONNGU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENNGONGU = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NGONNGU__F2344A3F6F02F454", x => x.IDNGONNGU);
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    IDNHANVIEN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MANHANVIEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TENNHANVIEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IMAGE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAYSINH = table.Column<DateTime>(type: "date", nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ROLE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NHANVIEN__CEEFA9833F1023A1", x => x.IDNHANVIEN);
                });

            migrationBuilder.CreateTable(
                name: "NHAXUATBAN",
                columns: table => new
                {
                    IDNXB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MANXB = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TENNXB = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NHAXUATB__945B98FB7353941D", x => x.IDNXB);
                });

            migrationBuilder.CreateTable(
                name: "TACGIA",
                columns: table => new
                {
                    IDTACGIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MATACGIA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TENTACGIA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GHICHU = table.Column<string>(type: "ntext", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TACGIA__9D7CC9B0637EF363", x => x.IDTACGIA);
                });

            migrationBuilder.CreateTable(
                name: "TRANGTHAI",
                columns: table => new
                {
                    IDTT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENTT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TRANGTHA__B87C3AF87454C78A", x => x.IDTT);
                });

            migrationBuilder.CreateTable(
                name: "HTTT",
                columns: table => new
                {
                    IDHTTT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAHTTT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TENHTTT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GHICHU = table.Column<string>(type: "ntext", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    NGANHANGIDNGANHANG = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HTTT__9DCEA6E366B6E543", x => x.IDHTTT);
                    table.ForeignKey(
                        name: "FKHTTT886305",
                        column: x => x.NGANHANGIDNGANHANG,
                        principalTable: "NGANHANG",
                        principalColumn: "IDNGANHANG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                columns: table => new
                {
                    IDKHACHHANG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAKHACHHANG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TENKHACHHANG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DIACHI = table.Column<string>(type: "ntext", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IMAGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STK = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ROLE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    NGANHANGIDNGANHANG = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KHACHHAN__629294BE3ECB49F8", x => x.IDKHACHHANG);
                    table.ForeignKey(
                        name: "FKKHACHHANG96359",
                        column: x => x.NGANHANGIDNGANHANG,
                        principalTable: "NGANHANG",
                        principalColumn: "IDNGANHANG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NHACUNGCAP",
                columns: table => new
                {
                    IDNCC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MANCC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TENNCC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DIACHI = table.Column<string>(type: "ntext", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MASOTHUE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    STK = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GHICHU = table.Column<string>(type: "ntext", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    NGANHANGIDNGANHANG = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NHACUNGC__945E4705B47300B6", x => x.IDNCC);
                    table.ForeignKey(
                        name: "FKNHACUNGCAP775616",
                        column: x => x.NGANHANGIDNGANHANG,
                        principalTable: "NGANHANG",
                        principalColumn: "IDNGANHANG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SACH",
                columns: table => new
                {
                    IDSACH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MASACH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TENSACH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAYXB = table.Column<DateTime>(type: "date", nullable: true),
                    LANXB = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IMAGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GHICHU = table.Column<string>(type: "ntext", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    LOAISACHIDLOAI = table.Column<int>(type: "int", nullable: true),
                    NHAXUATBANIDNXB = table.Column<int>(type: "int", nullable: true),
                    TACGIAIDTACGIA = table.Column<int>(type: "int", nullable: true),
                    NGONNGUIDNGONNGU = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SACH__8FB3F1150C47B9C7", x => x.IDSACH);
                    table.ForeignKey(
                        name: "FKSACH492486",
                        column: x => x.NHAXUATBANIDNXB,
                        principalTable: "NHAXUATBAN",
                        principalColumn: "IDNXB",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKSACH513020",
                        column: x => x.LOAISACHIDLOAI,
                        principalTable: "LOAISACH",
                        principalColumn: "IDLOAI",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKSACH553672",
                        column: x => x.TACGIAIDTACGIA,
                        principalTable: "TACGIA",
                        principalColumn: "IDTACGIA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKSACH970053",
                        column: x => x.NGONNGUIDNGONNGU,
                        principalTable: "NGONNGU",
                        principalColumn: "IDNGONNGU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUTHANHTOANTIENMUA",
                columns: table => new
                {
                    IDPTTTM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SOPTTTM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAYTHANHTOAN = table.Column<DateTime>(type: "date", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    HTTTIDHTTT = table.Column<int>(type: "int", nullable: true),
                    NHANVIENIDNHANVIEN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PHIEUTHA__0228700E6276F61A", x => x.IDPTTTM);
                    table.ForeignKey(
                        name: "FKPHIEUTHANH219561",
                        column: x => x.NHANVIENIDNHANVIEN,
                        principalTable: "NHANVIEN",
                        principalColumn: "IDNHANVIEN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKPHIEUTHANH436959",
                        column: x => x.HTTTIDHTTT,
                        principalTable: "HTTT",
                        principalColumn: "IDHTTT",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUTHUTIENBAN",
                columns: table => new
                {
                    IDPTTB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SOPTTB = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAYTHUTIEN = table.Column<int>(type: "int", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    NHANVIENIDNHANVIEN = table.Column<int>(type: "int", nullable: true),
                    HTTTIDHTTT = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PHIEUTHU__8F8EFC5B7435F6F1", x => x.IDPTTB);
                    table.ForeignKey(
                        name: "FKPHIEUTHUTI142264",
                        column: x => x.NHANVIENIDNHANVIEN,
                        principalTable: "NHANVIEN",
                        principalColumn: "IDNHANVIEN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKPHIEUTHUTI514256",
                        column: x => x.HTTTIDHTTT,
                        principalTable: "HTTT",
                        principalColumn: "IDHTTT",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUDATHANGBAN",
                columns: table => new
                {
                    IDPDHB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SOPDHB = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAYDAT = table.Column<DateTime>(type: "date", nullable: true),
                    NGAYTIEPNHAN = table.Column<DateTime>(type: "date", nullable: true),
                    NGAYGIAOHANG = table.Column<DateTime>(type: "date", nullable: true),
                    GHICHU = table.Column<string>(type: "ntext", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    KHACHHANGIDKHACHHANG = table.Column<int>(type: "int", nullable: true),
                    NHANVIENIDNHANVIEN = table.Column<int>(type: "int", nullable: true),
                    TRANGTHAIIDTT = table.Column<int>(type: "int", nullable: true),
                    DONVIVANCHUYENIDDVVC = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PHIEUDAT__A2D2C985025BBECC", x => x.IDPDHB);
                    table.ForeignKey(
                        name: "FKPHIEUDATHA350616",
                        column: x => x.DONVIVANCHUYENIDDVVC,
                        principalTable: "DONVIVANCHUYEN",
                        principalColumn: "IDDVVC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKPHIEUDATHA366751",
                        column: x => x.TRANGTHAIIDTT,
                        principalTable: "TRANGTHAI",
                        principalColumn: "IDTT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKPHIEUDATHA440685",
                        column: x => x.KHACHHANGIDKHACHHANG,
                        principalTable: "KHACHHANG",
                        principalColumn: "IDKHACHHANG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKPHIEUDATHA497914",
                        column: x => x.NHANVIENIDNHANVIEN,
                        principalTable: "NHANVIEN",
                        principalColumn: "IDNHANVIEN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUDATHANGMUA",
                columns: table => new
                {
                    IDPDHM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SOPDHM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAYDAT = table.Column<DateTime>(type: "date", nullable: true),
                    NGAYTIEPNHAN = table.Column<DateTime>(type: "date", nullable: true),
                    NGAYGIAOHANG = table.Column<DateTime>(type: "date", nullable: true),
                    GHICHU = table.Column<string>(type: "ntext", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    NHACUNGCAPIDNCC = table.Column<int>(type: "int", nullable: true),
                    NHANVIENIDNHANVIEN = table.Column<int>(type: "int", nullable: true),
                    TRANGTHAIIDTT = table.Column<int>(type: "int", nullable: true),
                    DONVIVANCHUYENIDDVVC = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PHIEUDAT__A2D2C988BD813EC2", x => x.IDPDHM);
                    table.ForeignKey(
                        name: "FKPHIEUDATHA339438",
                        column: x => x.DONVIVANCHUYENIDDVVC,
                        principalTable: "DONVIVANCHUYEN",
                        principalColumn: "IDDVVC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKPHIEUDATHA377929",
                        column: x => x.TRANGTHAIIDTT,
                        principalTable: "TRANGTHAI",
                        principalColumn: "IDTT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKPHIEUDATHA486736",
                        column: x => x.NHANVIENIDNHANVIEN,
                        principalTable: "NHANVIEN",
                        principalColumn: "IDNHANVIEN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKPHIEUDATHA67436",
                        column: x => x.NHACUNGCAPIDNCC,
                        principalTable: "NHACUNGCAP",
                        principalColumn: "IDNCC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETXUAT",
                columns: table => new
                {
                    IDCTX = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLDAT = table.Column<int>(type: "int", nullable: true),
                    SLGIAO = table.Column<int>(type: "int", nullable: true),
                    DVT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DONGIABAN = table.Column<float>(type: "real", nullable: true),
                    XACNHAN = table.Column<bool>(type: "bit", nullable: true),
                    SACHIDSACH = table.Column<int>(type: "int", nullable: true),
                    PHIEUDATHANGBANIDPDHB = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHITIETX__91A897B077062A08", x => x.IDCTX);
                    table.ForeignKey(
                        name: "FKCHITIETXUA898676",
                        column: x => x.SACHIDSACH,
                        principalTable: "SACH",
                        principalColumn: "IDSACH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKCHITIETXUA989455",
                        column: x => x.PHIEUDATHANGBANIDPDHB,
                        principalTable: "PHIEUDATHANGBAN",
                        principalColumn: "IDPDHB",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOIDUNGTHUTIEN",
                columns: table => new
                {
                    IDNDTHU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PHIEUDATHANGBANIDPDHB = table.Column<int>(type: "int", nullable: true),
                    PHIEUTHUTIENBANIDPTTB = table.Column<int>(type: "int", nullable: true),
                    SOTIENTHU = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NOIDUNGT__3EAAF7A5D490F293", x => x.IDNDTHU);
                    table.ForeignKey(
                        name: "FKNOIDUNGTHU127596",
                        column: x => x.PHIEUTHUTIENBANIDPTTB,
                        principalTable: "PHIEUTHUTIENBAN",
                        principalColumn: "IDPTTB",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKNOIDUNGTHU806863",
                        column: x => x.PHIEUDATHANGBANIDPDHB,
                        principalTable: "PHIEUDATHANGBAN",
                        principalColumn: "IDPDHB",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETNHAP",
                columns: table => new
                {
                    IDCTN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLDAT = table.Column<int>(type: "int", nullable: true),
                    SLGIAO = table.Column<int>(type: "int", nullable: true),
                    DVT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DONGIANHAP = table.Column<float>(type: "real", nullable: true),
                    XACNHAN = table.Column<bool>(type: "bit", nullable: true),
                    SACHIDSACH = table.Column<int>(type: "int", nullable: true),
                    PHIEUDATHANGMUAIDPDHM = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHITIETN__91A8964E485AA43C", x => x.IDCTN);
                    table.ForeignKey(
                        name: "FKCHITIETNHA209084",
                        column: x => x.SACHIDSACH,
                        principalTable: "SACH",
                        principalColumn: "IDSACH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKCHITIETNHA597063",
                        column: x => x.PHIEUDATHANGMUAIDPDHM,
                        principalTable: "PHIEUDATHANGMUA",
                        principalColumn: "IDPDHM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOIDUNGTHANHTOAN",
                columns: table => new
                {
                    IDNDTT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SOTIENTHANHTOAN = table.Column<double>(type: "float", nullable: true),
                    PHIEUTHANHTOANTIENMUAIDPTTTM = table.Column<int>(type: "int", nullable: true),
                    PHIEUDATHANGMUAIDPDHM = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NOIDUNGT__383E185187B9A3BC", x => x.IDNDTT);
                    table.ForeignKey(
                        name: "FKNOIDUNGTHA22473",
                        column: x => x.PHIEUDATHANGMUAIDPDHM,
                        principalTable: "PHIEUDATHANGMUA",
                        principalColumn: "IDPDHM",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKNOIDUNGTHA787343",
                        column: x => x.PHIEUTHANHTOANTIENMUAIDPTTTM,
                        principalTable: "PHIEUTHANHTOANTIENMUA",
                        principalColumn: "IDPTTTM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETNHAP_PHIEUDATHANGMUAIDPDHM",
                table: "CHITIETNHAP",
                column: "PHIEUDATHANGMUAIDPDHM");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETNHAP_SACHIDSACH",
                table: "CHITIETNHAP",
                column: "SACHIDSACH");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETXUAT_PhieudathangbanIdpdhb",
                table: "CHITIETXUAT",
                column: "PhieudathangbanIdpdhb");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETXUAT_PHIEUDATHANGBANIDPDHB",
                table: "CHITIETXUAT",
                column: "PHIEUDATHANGBANIDPDHB");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETXUAT_SACHIDSACH",
                table: "CHITIETXUAT",
                column: "SACHIDSACH");

            migrationBuilder.CreateIndex(
                name: "IX_HTTT_NGANHANGIDNGANHANG",
                table: "HTTT",
                column: "NGANHANGIDNGANHANG");

            migrationBuilder.CreateIndex(
                name: "IX_KHACHHANG_NGANHANGIDNGANHANG",
                table: "KHACHHANG",
                column: "NGANHANGIDNGANHANG");

            migrationBuilder.CreateIndex(
                name: "IX_NHACUNGCAP_NGANHANGIDNGANHANG",
                table: "NHACUNGCAP",
                column: "NGANHANGIDNGANHANG");

            migrationBuilder.CreateIndex(
                name: "IX_NOIDUNGTHANHTOAN_PHIEUDATHANGMUAIDPDHM",
                table: "NOIDUNGTHANHTOAN",
                column: "PHIEUDATHANGMUAIDPDHM");

            migrationBuilder.CreateIndex(
                name: "IX_NOIDUNGTHANHTOAN_PHIEUTHANHTOANTIENMUAIDPTTTM",
                table: "NOIDUNGTHANHTOAN",
                column: "PHIEUTHANHTOANTIENMUAIDPTTTM");

            migrationBuilder.CreateIndex(
                name: "IX_NOIDUNGTHUTIEN_PHIEUDATHANGBANIDPDHB",
                table: "NOIDUNGTHUTIEN",
                column: "PHIEUDATHANGBANIDPDHB");

            migrationBuilder.CreateIndex(
                name: "IX_NOIDUNGTHUTIEN_PHIEUTHUTIENBANIDPTTB",
                table: "NOIDUNGTHUTIEN",
                column: "PHIEUTHUTIENBANIDPTTB");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDATHANGBAN_DONVIVANCHUYENIDDVVC",
                table: "PHIEUDATHANGBAN",
                column: "DONVIVANCHUYENIDDVVC");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDATHANGBAN_KHACHHANGIDKHACHHANG",
                table: "PHIEUDATHANGBAN",
                column: "KHACHHANGIDKHACHHANG");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDATHANGBAN_NHANVIENIDNHANVIEN",
                table: "PHIEUDATHANGBAN",
                column: "NHANVIENIDNHANVIEN");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDATHANGBAN_TRANGTHAIIDTT",
                table: "PHIEUDATHANGBAN",
                column: "TRANGTHAIIDTT");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDATHANGMUA_DONVIVANCHUYENIDDVVC",
                table: "PHIEUDATHANGMUA",
                column: "DONVIVANCHUYENIDDVVC");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDATHANGMUA_NHACUNGCAPIDNCC",
                table: "PHIEUDATHANGMUA",
                column: "NHACUNGCAPIDNCC");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDATHANGMUA_NHANVIENIDNHANVIEN",
                table: "PHIEUDATHANGMUA",
                column: "NHANVIENIDNHANVIEN");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUDATHANGMUA_TRANGTHAIIDTT",
                table: "PHIEUDATHANGMUA",
                column: "TRANGTHAIIDTT");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUTHANHTOANTIENMUA_HTTTIDHTTT",
                table: "PHIEUTHANHTOANTIENMUA",
                column: "HTTTIDHTTT");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUTHANHTOANTIENMUA_NHANVIENIDNHANVIEN",
                table: "PHIEUTHANHTOANTIENMUA",
                column: "NHANVIENIDNHANVIEN");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUTHUTIENBAN_HTTTIDHTTT",
                table: "PHIEUTHUTIENBAN",
                column: "HTTTIDHTTT");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUTHUTIENBAN_NHANVIENIDNHANVIEN",
                table: "PHIEUTHUTIENBAN",
                column: "NHANVIENIDNHANVIEN");

            migrationBuilder.CreateIndex(
                name: "IX_SACH_LOAISACHIDLOAI",
                table: "SACH",
                column: "LOAISACHIDLOAI");

            migrationBuilder.CreateIndex(
                name: "IX_SACH_NGONNGUIDNGONNGU",
                table: "SACH",
                column: "NGONNGUIDNGONNGU");

            migrationBuilder.CreateIndex(
                name: "IX_SACH_NHAXUATBANIDNXB",
                table: "SACH",
                column: "NHAXUATBANIDNXB");

            migrationBuilder.CreateIndex(
                name: "IX_SACH_TACGIAIDTACGIA",
                table: "SACH",
                column: "TACGIAIDTACGIA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHITIETNHAP");

            migrationBuilder.DropTable(
                name: "CHITIETXUAT");

            migrationBuilder.DropTable(
                name: "NOIDUNGTHANHTOAN");

            migrationBuilder.DropTable(
                name: "NOIDUNGTHUTIEN");

            migrationBuilder.DropTable(
                name: "SACH");

            migrationBuilder.DropTable(
                name: "PHIEUDATHANGMUA");

            migrationBuilder.DropTable(
                name: "PHIEUTHANHTOANTIENMUA");

            migrationBuilder.DropTable(
                name: "PHIEUTHUTIENBAN");

            migrationBuilder.DropTable(
                name: "PHIEUDATHANGBAN");

            migrationBuilder.DropTable(
                name: "NHAXUATBAN");

            migrationBuilder.DropTable(
                name: "LOAISACH");

            migrationBuilder.DropTable(
                name: "TACGIA");

            migrationBuilder.DropTable(
                name: "NGONNGU");

            migrationBuilder.DropTable(
                name: "NHACUNGCAP");

            migrationBuilder.DropTable(
                name: "HTTT");

            migrationBuilder.DropTable(
                name: "DONVIVANCHUYEN");

            migrationBuilder.DropTable(
                name: "TRANGTHAI");

            migrationBuilder.DropTable(
                name: "KHACHHANG");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "NGANHANG");
        }
    }
}
