using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuanLyCuaHangSach.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QuanLyCuaHangSach.Controllers
{
    public class PhieudathangbansController : Controller
    {
        private readonly QLCHSContext _context;
        private readonly IConfiguration _configuration;

        public PhieudathangbansController(QLCHSContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: Phieudathangbans
        public async Task<IActionResult> Index(DateTime fromDate, DateTime toDate, string searchString,int page = 1)
        {
            var qLCHSContext = await _context.Phieudathangbans.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.KhachhangidkhachhangNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation)
                                                              .Where(x => x.Active == true).ToListAsync();

            var fdate = fromDate.ToString("ddMMyyyy");
            var tdate = toDate.ToString("ddMMyyyy");

            if (fdate != "01010001" && tdate != "01010001" && Int32.Parse(fdate) < Int32.Parse(tdate))
            {
                qLCHSContext = _context.Phieudathangbans.Where(x => (x.Ngaydat >= fromDate) && (x.Ngaydat <= toDate) && (x.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangbans.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.KhachhangidkhachhangNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation).Where(x => x.Active == true).ToListAsync();
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
                qLCHSContext = _context.Phieudathangbans.Where(x => (x.Sopdhb.Contains(searchString)) && (x.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangbans.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.KhachhangidkhachhangNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation).Where(x => x.Active == true).ToListAsync();
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

        public async Task<IActionResult> Capnhattrangthaidvvc(int Iddvvc, DateTime fromDate, DateTime toDate,string searchString, int page = 1)
        {
            var qLCHSContext = await _context.Phieudathangbans.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.KhachhangidkhachhangNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation).Where(x => (x.Active == true) && (x.Donvivanchuyeniddvvc == Iddvvc) && (x.Trangthaiidtt >= 6) && (x.Trangthaiidtt < 10)).ToListAsync();

            var fdate = fromDate.ToString("ddMMyyyy");
            var tdate = toDate.ToString("ddMMyyyy");

            if (fdate != "01010001" && tdate != "01010001" && Int32.Parse(fdate) < Int32.Parse(tdate))
            {
                qLCHSContext = _context.Phieudathangbans.Where(x => (x.Ngaydat >= fromDate) && (x.Ngaydat <= toDate) && (x.Active == true) && (x.Donvivanchuyeniddvvc == Iddvvc) && (x.Trangthaiidtt >= 6) && (x.Trangthaiidtt < 10)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangbans.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.KhachhangidkhachhangNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation).Where(x => (x.Active == true) && (x.Donvivanchuyeniddvvc == Iddvvc) && (x.Trangthaiidtt >= 6) && (x.Trangthaiidtt < 10)).ToListAsync();
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
                qLCHSContext = _context.Phieudathangbans.Where(x => (x.Sopdhb.Contains(searchString)) && (x.Active == true) && (x.Trangthaiidtt >= 7) && (x.Trangthaiidtt < 10)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieudathangbans.Include(p => p.DonvivanchuyeniddvvcNavigation).Include(p => p.KhachhangidkhachhangNavigation).Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.TrangthaiidttNavigation).Where(x => (x.Active == true) && (x.Donvivanchuyeniddvvc == Iddvvc) && (x.Trangthaiidtt >= 6) && (x.Trangthaiidtt < 10)).ToListAsync();
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

        // GET: Phieudathangbans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudathangban = await _context.Phieudathangbans
                .Include(p => p.DonvivanchuyeniddvvcNavigation)
                .Include(p => p.KhachhangidkhachhangNavigation)
                .Include(p => p.NhanvienidnhanvienNavigation)
                .Include(p => p.TrangthaiidttNavigation)
                .FirstOrDefaultAsync(m => m.Idpdhb == id);
            if (phieudathangban == null)
            {
                return NotFound();
            }

            return View(phieudathangban);
        }



        // GET: Phieudathangbans/Create
        public IActionResult Create()
        {
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens.Where(x => x.Active == true), "Iddvvc", "Tendvvc");
            ViewData["Khachhangidkhachhang"] = new SelectList(_context.Khachhangs.Where(x => x.Active == true), "Idkhachhang", "Tenkhachhang");
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien");
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais.Where(x => x.Active == true), "Idtt", "Tentt");
            var lastedphieu = _context.Phieudathangbans.OrderByDescending(x => x.Idpdhb).First();
            int lastedID = lastedphieu.Idpdhb;
            string currentDate = DateTime.Now.ToString("ddMMyyyy");
            string id = currentDate + (lastedID + 1).ToString("D3");
            ViewData["id"] = id;
            return View();
        }

        // POST: Phieudathangbans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpdhb,Sopdhb,Ngaydat,Ngaytiepnhan,Ngaygiaohang,Ghichu,Khachhangidkhachhang,Nhanvienidnhanvien,Trangthaiidtt,Donvivanchuyeniddvvc")] Phieudathangban phieudathangban)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Phieudathangbans.FirstOrDefault(s => s.Sopdhb == phieudathangban.Sopdhb);
                if (check == null)
                {
                    phieudathangban.Active = true;
                    _context.Add(phieudathangban);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + phieudathangban.Sopdhb + " already exists.";
                    ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens.Where(x => x.Active == true), "Iddvvc", "Tendvvc");
                    ViewData["Khachhangidkhachhang"] = new SelectList(_context.Khachhangs.Where(x => x.Active == true), "Idkhachhang", "Tenkhachhang");
                    ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien");
                    ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais.Where(x => x.Active == true), "Idtt", "Tentt");
                    return View(phieudathangban);
                }
            }
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens, "Iddvvc", "Iddvvc", phieudathangban.Donvivanchuyeniddvvc);
            ViewData["Khachhangidkhachhang"] = new SelectList(_context.Khachhangs, "Idkhachhang", "Idkhachhang", phieudathangban.Khachhangidkhachhang);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens, "Idnhanvien", "Idnhanvien", phieudathangban.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais, "Idtt", "Idtt", phieudathangban.Trangthaiidtt);
            return View(phieudathangban);
        }

        // GET: Phieudathangbans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudathangban = await _context.Phieudathangbans.FindAsync(id);
            if (phieudathangban == null)
            {
                return NotFound();
            }
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens.Where(x => x.Active == true), "Iddvvc", "Tendvvc", phieudathangban.Donvivanchuyeniddvvc);
            ViewData["Khachhangidkhachhang"] = new SelectList(_context.Khachhangs.Where(x => x.Active == true), "Idkhachhang", "Tenkhachhang", phieudathangban.Khachhangidkhachhang);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien", phieudathangban.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais.Where(x => x.Active == true), "Idtt", "Tentt", phieudathangban.Trangthaiidtt);
            return View(phieudathangban);
        }

        // POST: Phieudathangbans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpdhb,Sopdhb,Ngaydat,Ngaytiepnhan,Ngaygiaohang,Ghichu,Khachhangidkhachhang,Nhanvienidnhanvien,Trangthaiidtt,Donvivanchuyeniddvvc")] Phieudathangban phieudathangban)
        {
            if (id != phieudathangban.Idpdhb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    phieudathangban.Active = true;
                    _context.Update(phieudathangban);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieudathangbanExists(phieudathangban.Idpdhb))
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
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens, "Iddvvc", "Iddvvc", phieudathangban.Donvivanchuyeniddvvc);
            ViewData["Khachhangidkhachhang"] = new SelectList(_context.Khachhangs, "Idkhachhang", "Idkhachhang", phieudathangban.Khachhangidkhachhang);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens, "Idnhanvien", "Idnhanvien", phieudathangban.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais, "Idtt", "Idtt", phieudathangban.Trangthaiidtt);
            return View(phieudathangban);
        }

        public async Task<IActionResult> Editttdvvc(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudathangban = await _context.Phieudathangbans.FindAsync(id);
            if (phieudathangban == null)
            {
                return NotFound();
            }
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens.Where(x => x.Active == true), "Iddvvc", "Tendvvc", phieudathangban.Donvivanchuyeniddvvc);
            ViewData["Khachhangidkhachhang"] = new SelectList(_context.Khachhangs.Where(x => x.Active == true), "Idkhachhang", "Tenkhachhang", phieudathangban.Khachhangidkhachhang);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien", phieudathangban.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais.Where(x => (x.Active == true) && (x.Idtt >= 7) && (x.Idtt < 10)), "Idtt", "Tentt", phieudathangban.Trangthaiidtt);
            return View(phieudathangban);
        }

        // POST: Phieudathangbans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editttdvvc(int id, [Bind("Idpdhb,Sopdhb,Ngaydat,Ngaytiepnhan,Ngaygiaohang,Ghichu,Khachhangidkhachhang,Nhanvienidnhanvien,Trangthaiidtt,Donvivanchuyeniddvvc")] Phieudathangban phieudathangban)
        {
            if (id != phieudathangban.Idpdhb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    phieudathangban.Active = true;
                    _context.Update(phieudathangban);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieudathangbanExists(phieudathangban.Idpdhb))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Capnhattrangthaidvvc", "Phieudathangbans", new { Iddvvc = phieudathangban.Donvivanchuyeniddvvc });
            }
            ViewData["Donvivanchuyeniddvvc"] = new SelectList(_context.Donvivanchuyens, "Iddvvc", "Iddvvc", phieudathangban.Donvivanchuyeniddvvc);
            ViewData["Khachhangidkhachhang"] = new SelectList(_context.Khachhangs, "Idkhachhang", "Idkhachhang", phieudathangban.Khachhangidkhachhang);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens, "Idnhanvien", "Idnhanvien", phieudathangban.Nhanvienidnhanvien);
            ViewData["Trangthaiidtt"] = new SelectList(_context.Trangthais, "Idtt", "Idtt", phieudathangban.Trangthaiidtt);
            return View(phieudathangban);
        }

        // GET: Phieudathangbans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieudathangban = await _context.Phieudathangbans
                .Include(p => p.DonvivanchuyeniddvvcNavigation)
                .Include(p => p.KhachhangidkhachhangNavigation)
                .Include(p => p.NhanvienidnhanvienNavigation)
                .Include(p => p.TrangthaiidttNavigation)
                .FirstOrDefaultAsync(m => m.Idpdhb == id);
            if (phieudathangban == null)
            {
                return NotFound();
            }

            return View(phieudathangban);
        }

        // POST: Phieudathangbans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieudathangban = await _context.Phieudathangbans.FindAsync(id);
            _context.Phieudathangbans.Remove(phieudathangban);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdhb = await _context.Phieudathangbans
                .FirstOrDefaultAsync(m => m.Idpdhb == id);
            if (pdhb == null)
            {
                return NotFound();
            }


            pdhb.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Capnhatcbxong(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdhb = await _context.Phieudathangbans
                .FirstOrDefaultAsync(m => m.Idpdhb == id);
            if (pdhb == null)
            {
                return NotFound();
            }


            pdhb.Trangthaiidtt = 6;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool PhieudathangbanExists(int id)
        {
            return _context.Phieudathangbans.Any(e => e.Idpdhb == id);
        }
    }
}
