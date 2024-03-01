using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangSach.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QuanLyCuaHangSach.Controllers
{
    public class PhieudathangmuasController : Controller
    {
        private readonly QLCHSContext _context;

        public PhieudathangmuasController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Phieudathangmuas
        public async Task<IActionResult> Index(DateTime fromDate, DateTime toDate, string searchString,int page =1)
        {
            var qLCHSContext = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation).Where(x => x.Active == true).ToListAsync();

            var fdate = fromDate.ToString("ddMMyyyy");
            var tdate = toDate.ToString("ddMMyyyy");

            if (fdate != "01010001" && tdate != "01010001" && Int32.Parse(fdate) < Int32.Parse(tdate))
            {
                qLCHSContext = _context.Phieudathangmuas.Where(x => (x.Ngaydat >= fromDate) && (x.Ngaydat <= toDate) && (x.Active == true)).OrderByDescending(x => x.Ngaydat).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                        .Where(x => x.Active == true).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    qLCHSContext1 = qLCHSContext1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(qLCHSContext1);
                }
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                qLCHSContext = _context.Phieudathangmuas.Where(x => (x.Sopdhm.Contains(searchString)) && (x.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                        .Where(x => x.Active == true).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    qLCHSContext1 = qLCHSContext1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(qLCHSContext1);
                }
            }
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(qLCHSContext);
        }

        public async Task<IActionResult> Indexxacnhan(DateTime fromDate, DateTime toDate, string searchString, int page = 1)
        {
            var qLCHSContext = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                .Where(x => (x.Active == true) && (x.Trangthaiidtt == 9)).ToListAsync();

            var fdate = fromDate.ToString("ddMMyyyy");
            var tdate = toDate.ToString("ddMMyyyy");

            if (fdate != "01010001" && tdate != "01010001" && Int32.Parse(fdate) < Int32.Parse(tdate))
            {
                qLCHSContext = _context.Phieudathangmuas.Where(x => (x.Ngaydat >= fromDate) && (x.Ngaydat <= toDate) && (x.Active == true) && (x.Trangthaiidtt == 9)).OrderByDescending(x => x.Ngaydat).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                        .Where(x => (x.Active == true) && (x.Trangthaiidtt == 9)).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    qLCHSContext1 = qLCHSContext1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(qLCHSContext1);
                }
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                qLCHSContext = _context.Phieudathangmuas.Where(x => (x.Sopdhm.Contains(searchString)) && (x.Active == true) && (x.Trangthaiidtt == 9)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                        .Where(x => (x.Active == true) && (x.Trangthaiidtt == 9)).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    qLCHSContext1 = qLCHSContext1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(qLCHSContext1);
                }
            }
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(qLCHSContext);
        }


        public async Task<IActionResult> Capnhattrangthai(DateTime fromDate, DateTime toDate, int Idncc, string searchString, int page = 1)
        {
            var qLCHSContext = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                .Where(x => (x.Active == true) && (x.Nhacungcapidncc == Idncc) && (x.Trangthaiidtt >=4) && (x.Trangthaiidtt < 7)).ToListAsync();

            var fdate = fromDate.ToString("ddMMyyyy");
            var tdate = toDate.ToString("ddMMyyyy");

            if (fdate != "01010001" && tdate != "01010001" && Int32.Parse(fdate) < Int32.Parse(tdate))
            {
                qLCHSContext = _context.Phieudathangmuas.Where(x => (x.Ngaydat >= fromDate) && (x.Ngaydat <= toDate) && (x.Active == true) && (x.Nhacungcapidncc == Idncc) && (x.Trangthaiidtt >= 4) && (x.Trangthaiidtt < 7)).OrderByDescending(x => x.Ngaydat).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                        .Where(x => (x.Active == true) && (x.Nhacungcapidncc == Idncc) && (x.Trangthaiidtt >= 4) && (x.Trangthaiidtt < 7)).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    qLCHSContext1 = qLCHSContext1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(qLCHSContext1);
                }
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                qLCHSContext = _context.Phieudathangmuas.Where(x => x.Sopdhm.Contains(searchString) && (x.Active == true) && (x.Nhacungcapidncc == Idncc) && (x.Trangthaiidtt >= 4) && (x.Trangthaiidtt < 7)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                        .Where(x => (x.Active == true) && (x.Nhacungcapidncc == Idncc) && (x.Trangthaiidtt >= 4) && (x.Trangthaiidtt < 7)).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    qLCHSContext1 = qLCHSContext1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(qLCHSContext1);
                }
            }
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(qLCHSContext);
        }



        public async Task<IActionResult> Capnhattrangthaidvvc(DateTime fromDate, DateTime toDate, int Iddvvc, string searchString, int page = 1)
        {
            var qLCHSContext = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                .Where(x => (x.Active == true) && (x.Donvivanchuyeniddvvc == Iddvvc) && (x.Trangthaiidtt >= 6) && (x.Trangthaiidtt < 10)).ToListAsync();

            var fdate = fromDate.ToString("ddMMyyyy");
            var tdate = toDate.ToString("ddMMyyyy");

            if (fdate != "01010001" && tdate != "01010001" && Int32.Parse(fdate) < Int32.Parse(tdate))
            {
                qLCHSContext = _context.Phieudathangmuas.Where(x => (x.Ngaydat >= fromDate) && (x.Ngaydat <= toDate) && (x.Active == true) && (x.Donvivanchuyeniddvvc == Iddvvc) && (x.Trangthaiidtt >= 6) && (x.Trangthaiidtt < 10)).OrderByDescending(x => x.Ngaydat).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                        .Where(x => (x.Active == true) && (x.Donvivanchuyeniddvvc == Iddvvc) && (x.Trangthaiidtt >= 6) && (x.Trangthaiidtt < 10)).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    qLCHSContext1 = qLCHSContext1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(qLCHSContext1);
                }
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                qLCHSContext = _context.Phieudathangmuas.Where(x => (x.Sopdhm.Contains(searchString)) && (x.Active == true) && (x.Donvivanchuyeniddvvc == Iddvvc) && (x.Trangthaiidtt >= 6) && (x.Trangthaiidtt < 10)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangmuas.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.NhacungcapidnccNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                        .Where(x => (x.Active == true) && (x.Donvivanchuyeniddvvc == Iddvvc) && (x.Trangthaiidtt >= 6) && (x.Trangthaiidtt < 10)).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    qLCHSContext1 = qLCHSContext1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(qLCHSContext1);
                }
            }
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(qLCHSContext);
        }

        // GET: Phieudathangmuas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudathangmua = await _context.Phieudathangmuas
                .Include(p => p.DonvivanchuyeniddvvcNavigation)
                .Include(p => p.NhacungcapidnccNavigation)
                .Include(p => p.NhanvienidnhanvienNavigation)
                .Include(p => p.TrangthaiidttNavigation)
                .FirstOrDefaultAsync(m => m.Idpdhm == id);
            if (phieudathangmua == null)
            {
                return NotFound();
            }

            return View(phieudathangmua);
        }

        // GET: Phieudathangmuas/Create
        public IActionResult Create()
        {
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens.Where(x => x.Active == true), "Iddvvc", "Tendvvc");
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhacungcaps.Where(x => x.Active == true), "Idncc", "Tenncc");
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien");
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais.Where(x => x.Active == true), "Idtt", "Tentt");
            var lastedphieu = _context.Phieudathangmuas.OrderByDescending(x => x.Idpdhm).First();
            int lastedID = lastedphieu.Idpdhm;
            string currentDate = DateTime.Now.ToString("ddMMyyyy");
            string id = currentDate + (lastedID + 1).ToString("D3");
            ViewData["id"] = id;
            return View();
        }

        // POST: Phieudathangmuas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpdhm,Sopdhm,Ngaydat,Ngaytiepnhan,Ngaygiaohang,Ghichu,Nhacungcapidncc,Nhanvienidnhanvien,Trangthaiidtt,Donvivanchuyeniddvvc")] Phieudathangmua phieudathangmua)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Phieudathangmuas.FirstOrDefault(s => s.Sopdhm == phieudathangmua.Sopdhm);
                if (check == null)
                {
                    phieudathangmua.Active = true;
                    _context.Add(phieudathangmua);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + phieudathangmua.Sopdhm + " already exists.";
                    ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens.Where(x => x.Active == true), "Iddvvc", "Tendvvc");
                    ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhacungcaps.Where(x => x.Active == true), "Idncc", "Tenncc");
                    ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien");
                    ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais.Where(x => x.Active == true), "Idtt", "Tentt");
                    return View(phieudathangmua);
                }

            }
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens, "Iddvvc", "Iddvvc", phieudathangmua.Donvivanchuyeniddvvc);
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhacungcaps, "Idncc", "Idncc", phieudathangmua.Nhacungcapidncc);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens, "Idnhanvien", "Idnhanvien", phieudathangmua.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais, "Idtt", "Idtt", phieudathangmua.Trangthaiidtt);
            return View(phieudathangmua);
        }

        // GET: Phieudathangmuas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudathangmua = await _context.Phieudathangmuas.FindAsync(id);
            if (phieudathangmua == null)
            {
                return NotFound();
            }
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens.Where(x => x.Active == true), "Iddvvc", "Tendvvc", phieudathangmua.Donvivanchuyeniddvvc);
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhacungcaps.Where(x => x.Active == true), "Idncc", "Tenncc", phieudathangmua.Nhacungcapidncc);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien", phieudathangmua.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais.Where(x => x.Active == true), "Idtt", "Tentt", phieudathangmua.Trangthaiidtt);
            return View(phieudathangmua);
        }

        // POST: Phieudathangmuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpdhm,Sopdhm,Ngaydat,Ngaytiepnhan,Ngaygiaohang,Ghichu,Nhacungcapidncc,Nhanvienidnhanvien,Trangthaiidtt,Donvivanchuyeniddvvc")] Phieudathangmua phieudathangmua)
        {
            if (id != phieudathangmua.Idpdhm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    phieudathangmua.Active = true;
                    _context.Update(phieudathangmua);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieudathangmuaExists(phieudathangmua.Idpdhm))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens, "Iddvvc", "Iddvvc", phieudathangmua.Donvivanchuyeniddvvc);
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhacungcaps, "Idncc", "Idncc", phieudathangmua.Nhacungcapidncc);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens, "Idnhanvien", "Idnhanvien", phieudathangmua.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais, "Idtt", "Idtt", phieudathangmua.Trangthaiidtt);
            return View(phieudathangmua);
        }

        public async Task<IActionResult> Edittt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudathangmua = await _context.Phieudathangmuas.FindAsync(id);
            if (phieudathangmua == null)
            {
                return NotFound();
            }
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens.Where(x => x.Active == true), "Iddvvc", "Tendvvc", phieudathangmua.Donvivanchuyeniddvvc);
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhacungcaps.Where(x => x.Active == true), "Idncc", "Tenncc", phieudathangmua.Nhacungcapidncc);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien", phieudathangmua.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais.Where(x => (x.Active == true) && (x.Idtt >= 5) && (x.Idtt < 7) ), "Idtt", "Tentt", phieudathangmua.Trangthaiidtt);
            return View(phieudathangmua);
        }

        // POST: Phieudathangmuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edittt(int id, [Bind("Idpdhm,Sopdhm,Ngaydat,Ngaytiepnhan,Ngaygiaohang,Ghichu,Nhacungcapidncc,Nhanvienidnhanvien,Trangthaiidtt,Donvivanchuyeniddvvc")] Phieudathangmua phieudathangmua)
        {
            if (id != phieudathangmua.Idpdhm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    phieudathangmua.Active = true;
                    _context.Update(phieudathangmua);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieudathangmuaExists(phieudathangmua.Idpdhm))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Capnhattrangthai", "Phieudathangmuas", new { Idncc = phieudathangmua.Nhacungcapidncc });
                //return RedirectToAction(nameof(Capnhattrangthaidvvc));
            }
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens, "Iddvvc", "Iddvvc", phieudathangmua.Donvivanchuyeniddvvc);
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhacungcaps, "Idncc", "Idncc", phieudathangmua.Nhacungcapidncc);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens, "Idnhanvien", "Idnhanvien", phieudathangmua.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais, "Idtt", "Idtt", phieudathangmua.Trangthaiidtt);
            return View(phieudathangmua);
        }

        public async Task<IActionResult> Editttdvvc(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudathangmua = await _context.Phieudathangmuas.FindAsync(id);
            if (phieudathangmua == null)
            {
                return NotFound();
            }
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens.Where(x => x.Active == true), "Iddvvc", "Tendvvc", phieudathangmua.Donvivanchuyeniddvvc);
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhacungcaps.Where(x => x.Active == true), "Idncc", "Tenncc", phieudathangmua.Nhacungcapidncc);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien", phieudathangmua.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais.Where(x => (x.Active == true) && (x.Idtt >= 7) && (x.Idtt < 10)), "Idtt", "Tentt", phieudathangmua.Trangthaiidtt);
            return View(phieudathangmua);
        }

        // POST: Phieudathangmuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editttdvvc(int id, [Bind("Idpdhm,Sopdhm,Ngaydat,Ngaytiepnhan,Ngaygiaohang,Ghichu,Nhacungcapidncc,Nhanvienidnhanvien,Trangthaiidtt,Donvivanchuyeniddvvc")] Phieudathangmua phieudathangmua)
        {
            if (id != phieudathangmua.Idpdhm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    phieudathangmua.Active = true;
                    _context.Update(phieudathangmua);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieudathangmuaExists(phieudathangmua.Idpdhm))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Capnhattrangthaidvvc", "Phieudathangmuas", new { Iddvvc = phieudathangmua.Donvivanchuyeniddvvc });
            }
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens, "Iddvvc", "Iddvvc", phieudathangmua.Donvivanchuyeniddvvc);
            ViewData["Nhacungcapidncc"] = new SelectList(_context.Nhacungcaps, "Idncc", "Idncc", phieudathangmua.Nhacungcapidncc);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens, "Idnhanvien", "Idnhanvien", phieudathangmua.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais, "Idtt", "Idtt", phieudathangmua.Trangthaiidtt);
            return View(phieudathangmua);
        }

        // GET: Phieudathangmuas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudathangmua = await _context.Phieudathangmuas
                .Include(p => p.DonvivanchuyeniddvvcNavigation)
                .Include(p => p.NhacungcapidnccNavigation)
                .Include(p => p.NhanvienidnhanvienNavigation)
                .Include(p => p.TrangthaiidttNavigation)
                .FirstOrDefaultAsync(m => m.Idpdhm == id);
            if (phieudathangmua == null)
            {
                return NotFound();
            }

            return View(phieudathangmua);
        }

        // POST: Phieudathangmuas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieudathangmua = await _context.Phieudathangmuas.FindAsync(id);
            _context.Phieudathangmuas.Remove(phieudathangmua);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdhm = await _context.Phieudathangmuas
                .FirstOrDefaultAsync(m => m.Idpdhm == id);
            if (pdhm == null)
            {
                return NotFound();
            }


            pdhm.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Capnhatdadat(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdhm = await _context.Phieudathangmuas
                .FirstOrDefaultAsync(m => m.Idpdhm == id);
            if (pdhm == null)
            {
                return NotFound();
            }


            pdhm.Trangthaiidtt = 4;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieudathangmuaExists(int id)
        {
            return _context.Phieudathangmuas.Any(e => e.Idpdhm == id);
        }
    }
}
