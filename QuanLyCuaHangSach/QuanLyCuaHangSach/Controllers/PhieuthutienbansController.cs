using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangSach.Models;

namespace QuanLyCuaHangSach.Controllers
{
    public class PhieuthutienbansController : Controller
    {
        private readonly QLCHSContext _context;

        public PhieuthutienbansController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Phieuthutienbans
        public async Task<IActionResult> Index(DateTime fromDate, DateTime toDate, string searchString, int page = 1)
        {
            var qLCHSContext = await _context.Phieuthutienbans.Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.HtttidhtttNavigation).Where(x => x.Active == true).ToListAsync();

            var fdate = fromDate.ToString("ddMMyyyy");
            var tdate = toDate.ToString("ddMMyyyy");

            if (fdate != "01010001" && tdate != "01010001" && Int32.Parse(fdate) < Int32.Parse(tdate))
            {
                qLCHSContext = _context.Phieuthutienbans.Where(x => (x.Ngaythutien >= fromDate) && (x.Ngaythutien <= toDate) && (x.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieuthutienbans.Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.HtttidhtttNavigation).Where(x => x.Active == true).ToListAsync();
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
                qLCHSContext = _context.Phieuthutienbans.Where(x => (x.Sopttb.Contains(searchString)) && (x.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieuthutienbans.Include(p => p.NhanvienidnhanvienNavigation).Include(p => p.HtttidhtttNavigation).Where(x => x.Active == true).ToListAsync();
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
            return View( qLCHSContext);
        }

        // GET: Phieuthutienbans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthutienban = await _context.Phieuthutienbans
                .Include(p => p.NhanvienidnhanvienNavigation)
                .FirstOrDefaultAsync(m => m.Idpttb == id);
            if (phieuthutienban == null)
            {
                return NotFound();
            }

            return View(phieuthutienban);
        }

        // GET: Phieuthutienbans/Create
        public IActionResult Create()
        {
            ViewData["Htttidhttt"] = new SelectList(_context.Httts.Where(x => x.Active == true), "Idhttt", "Tenhttt");
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien");
            var lastedphieu = _context.Phieuthutienbans.OrderByDescending(x => x.Idpttb).First();
            int lastedID = lastedphieu.Idpttb;
            string currentDate = DateTime.Now.ToString("ddMMyyyy");
            string id = currentDate + (lastedID + 1).ToString("D3");
            ViewData["id"] = id;
            return View();
        }

        // POST: Phieuthutienbans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpttb,Sopttb,Ngaythutien,Nhanvienidnhanvien,Htttidhttt")] Phieuthutienban phieuthutienban)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Phieuthutienbans.FirstOrDefault(s => s.Sopttb == phieuthutienban.Sopttb);
                if (check == null)
                {
                    phieuthutienban.Active = true;
                    _context.Add(phieuthutienban);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + phieuthutienban.Sopttb + " already exists.";
                    ViewData["Htttidhttt"] = new SelectList(_context.Httts.Where(x => x.Active == true), "Idhttt", "Tenhttt");
                    ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien");
                    return View(phieuthutienban);
                }

            }
            ViewData["Htttidhttt"] = new SelectList(_context.Httts, "Idhttt", "Idhttt", phieuthutienban.Htttidhttt);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens, "Idnhanvien", "Idnhanvien", phieuthutienban.Nhanvienidnhanvien);
            return View(phieuthutienban);
        }

        // GET: Phieuthutienbans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthutienban = await _context.Phieuthutienbans.FindAsync(id);
            if (phieuthutienban == null)
            {
                return NotFound();
            }
            ViewData["Htttidhttt"] = new SelectList(_context.Httts.Where(x => x.Active == true), "Idhttt", "Tenhttt", phieuthutienban.Htttidhttt);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien", phieuthutienban.Nhanvienidnhanvien);
            return View(phieuthutienban);
        }

        // POST: Phieuthutienbans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpttb,Sopttb,Ngaythutien,Nhanvienidnhanvien,Htttidhttt")] Phieuthutienban phieuthutienban)
        {
            if (id != phieuthutienban.Idpttb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    phieuthutienban.Active = true;
                    _context.Update(phieuthutienban);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuthutienbanExists(phieuthutienban.Idpttb))
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
            ViewData["Htttidhttt"] = new SelectList(_context.Httts, "Idhttt", "Idhttt", phieuthutienban.Htttidhttt);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens, "Idnhanvien", "Idnhanvien", phieuthutienban.Nhanvienidnhanvien);
            return View(phieuthutienban);
        }

        // GET: Phieuthutienbans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthutienban = await _context.Phieuthutienbans
                .Include(p => p.NhanvienidnhanvienNavigation)
                .FirstOrDefaultAsync(m => m.Idpttb == id);
            if (phieuthutienban == null)
            {
                return NotFound();
            }

            return View(phieuthutienban);
        }

        // POST: Phieuthutienbans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieuthutienban = await _context.Phieuthutienbans.FindAsync(id);
            _context.Phieuthutienbans.Remove(phieuthutienban);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pttb = await _context.Phieuthutienbans
                .FirstOrDefaultAsync(m => m.Idpttb == id);
            if (pttb == null)
            {
                return NotFound();
            }


            pttb.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuthutienbanExists(int id)
        {
            return _context.Phieuthutienbans.Any(e => e.Idpttb == id);
        }
    }
}
