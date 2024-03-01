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
    public class PhieuthanhtoantienmuasController : Controller
    {
        private readonly QLCHSContext _context;

        public PhieuthanhtoantienmuasController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Phieuthanhtoantienmuas
        public async Task<IActionResult> Index(DateTime fromDate, DateTime toDate, string searchString,int page = 1)
        {
            var qLCHSContext = await _context.Phieuthanhtoantienmuas.Include(p => p.HtttidhtttNavigation).Include(p => p.NhanvienidnhanvienNavigation).Where(x => x.Active == true).ToListAsync();

            var fdate = fromDate.ToString("ddMMyyyy");
            var tdate = toDate.ToString("ddMMyyyy");

            if (fdate != "01010001" && tdate != "01010001" && Int32.Parse(fdate) < Int32.Parse(tdate))
            {
                qLCHSContext = _context.Phieuthanhtoantienmuas.Where(x => (x.Ngaythanhtoan >= fromDate) && (x.Ngaythanhtoan <= toDate) && (x.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieuthanhtoantienmuas.Include(p => p.HtttidhtttNavigation).Include(p => p.NhanvienidnhanvienNavigation).Where(x => x.Active == true).ToListAsync();
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
                qLCHSContext = _context.Phieuthanhtoantienmuas.Where(x => (x.Soptttm.Contains(searchString)) && (x.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Phieuthanhtoantienmuas.Include(p => p.HtttidhtttNavigation).Include(p => p.NhanvienidnhanvienNavigation).Where(x => x.Active == true).ToListAsync();
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

        // GET: Phieuthanhtoantienmuas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthanhtoantienmua = await _context.Phieuthanhtoantienmuas
                .Include(p => p.HtttidhtttNavigation)
                .Include(p => p.NhanvienidnhanvienNavigation)
                .FirstOrDefaultAsync(m => m.Idptttm == id);
            if (phieuthanhtoantienmua == null)
            {
                return NotFound();
            }

            return View(phieuthanhtoantienmua);
        }

        // GET: Phieuthanhtoantienmuas/Create
        public IActionResult Create()
        {
            ViewData["Htttidhttt"] = new SelectList(_context.Httts.Where(x => x.Active == true), "Idhttt", "Tenhttt");
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien");
            var lastedphieu = _context.Phieuthanhtoantienmuas.OrderByDescending(x => x.Idptttm).First();
            int lastedID = lastedphieu.Idptttm;
            string currentDate = DateTime.Now.ToString("ddMMyyyy");
            string id = currentDate + (lastedID + 1).ToString("D3");
            ViewData["id"] = id;
            return View();
        }

        // POST: Phieuthanhtoantienmuas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idptttm,Soptttm,Ngaythanhtoan,Htttidhttt,Nhanvienidnhanvien")] Phieuthanhtoantienmua phieuthanhtoantienmua)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Phieuthanhtoantienmuas.FirstOrDefault(s => s.Soptttm == phieuthanhtoantienmua.Soptttm);
                if (check == null)
                {
                    phieuthanhtoantienmua.Active = true;
                    _context.Add(phieuthanhtoantienmua);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + phieuthanhtoantienmua.Soptttm + " already exists.";
                    ViewData["Htttidhttt"] = new SelectList(_context.Httts.Where(x => x.Active == true), "Idhttt", "Tenhttt");
                    ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien");
                    return View(phieuthanhtoantienmua);
                }
            }
            ViewData["Htttidhttt"] = new SelectList(_context.Httts, "Idhttt", "Idhttt", phieuthanhtoantienmua.Htttidhttt);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens, "Idnhanvien", "Idnhanvien", phieuthanhtoantienmua.Nhanvienidnhanvien);
            return View(phieuthanhtoantienmua);
        }

        // GET: Phieuthanhtoantienmuas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthanhtoantienmua = await _context.Phieuthanhtoantienmuas.FindAsync(id);
            if (phieuthanhtoantienmua == null)
            {
                return NotFound();
            }
            ViewData["Htttidhttt"] = new SelectList(_context.Httts.Where(x => x.Active == true), "Idhttt", "Tenhttt", phieuthanhtoantienmua.Htttidhttt);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens.Where(x => x.Active == true), "Idnhanvien", "Tennhanvien", phieuthanhtoantienmua.Nhanvienidnhanvien);
            return View(phieuthanhtoantienmua);
        }

        // POST: Phieuthanhtoantienmuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idptttm,Soptttm,Ngaythanhtoan,Htttidhttt,Nhanvienidnhanvien")] Phieuthanhtoantienmua phieuthanhtoantienmua)
        {
            if (id != phieuthanhtoantienmua.Idptttm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    phieuthanhtoantienmua.Active = true;
                    _context.Update(phieuthanhtoantienmua);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuthanhtoantienmuaExists(phieuthanhtoantienmua.Idptttm))
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
            ViewData["Htttidhttt"] = new SelectList(_context.Httts, "Idhttt", "Idhttt", phieuthanhtoantienmua.Htttidhttt);
            ViewData["Nhanvienidnhanvien"] = new SelectList(_context.Nhanviens, "Idnhanvien", "Idnhanvien", phieuthanhtoantienmua.Nhanvienidnhanvien);
            return View(phieuthanhtoantienmua);
        }

        // GET: Phieuthanhtoantienmuas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthanhtoantienmua = await _context.Phieuthanhtoantienmuas
                .Include(p => p.HtttidhtttNavigation)
                .Include(p => p.NhanvienidnhanvienNavigation)
                .FirstOrDefaultAsync(m => m.Idptttm == id);
            if (phieuthanhtoantienmua == null)
            {
                return NotFound();
            }

            return View(phieuthanhtoantienmua);
        }

        // POST: Phieuthanhtoantienmuas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieuthanhtoantienmua = await _context.Phieuthanhtoantienmuas.FindAsync(id);
            _context.Phieuthanhtoantienmuas.Remove(phieuthanhtoantienmua);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ptttm = await _context.Phieuthanhtoantienmuas
                .FirstOrDefaultAsync(m => m.Idptttm == id);
            if (ptttm == null)
            {
                return NotFound();
            }


            ptttm.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuthanhtoantienmuaExists(int id)
        {
            return _context.Phieuthanhtoantienmuas.Any(e => e.Idptttm == id);
        }
    }
}
