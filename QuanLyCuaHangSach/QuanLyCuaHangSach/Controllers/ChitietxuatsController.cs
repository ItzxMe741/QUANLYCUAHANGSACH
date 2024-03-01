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
    public class ChitietxuatsController : Controller
    {
        private readonly QLCHSContext _context;

        public ChitietxuatsController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Chitietxuats
        public async Task<IActionResult> Index(int Idpdhb, int page = 1)
        {
            var qLCHSContext = await _context.Chitietxuats.Include(c => c.PhieudathangbanidpdhbNavigation).Include(c => c.SachidsachNavigation).ToListAsync();
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            TempData["phieudathangban"] = _context.Phieudathangbans.Where(i => i.Idpdhb == Idpdhb).FirstOrDefault();
            return View(qLCHSContext);
        }

        public async Task<IActionResult> Indexbaocao(DateTime fromDate, DateTime toDate, string searchString, int page = 1)
        {
            var qLCHSContext = await _context.Chitietxuats.Include(c => c.PhieudathangbanidpdhbNavigation).Include(c => c.SachidsachNavigation).Where(x=> x.PhieudathangbanidpdhbNavigation.Trangthaiidtt == 9).ToListAsync();
            var fdate = fromDate.ToString("ddMMyyyy");
            var tdate = toDate.ToString("ddMMyyyy");

            if (fdate != "01010001" && tdate != "01010001" && Int32.Parse(fdate) < Int32.Parse(tdate))
            {
                qLCHSContext = _context.Chitietxuats
                    .Where(x => (x.PhieudathangbanidpdhbNavigation.Ngaygiaohang >= fromDate) && (x.PhieudathangbanidpdhbNavigation.Ngaygiaohang <= toDate) && (x.PhieudathangbanidpdhbNavigation.Trangthaiidtt == 9) && (x.PhieudathangbanidpdhbNavigation.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Chitietxuats.Include(p => p.PhieudathangbanidpdhbNavigation).Include(p => p.SachidsachNavigation)
                        .Where(x => (x.PhieudathangbanidpdhbNavigation.Trangthaiidtt == 9) && (x.PhieudathangbanidpdhbNavigation.Active == true )).ToListAsync();
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
                qLCHSContext = _context.Chitietxuats.Where(x => (x.SachidsachNavigation.Tensach.Contains(searchString)) && (x.PhieudathangbanidpdhbNavigation.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Chitietxuats.Include(p => p.PhieudathangbanidpdhbNavigation).Include(p => p.SachidsachNavigation)
                        .Where(x => (x.PhieudathangbanidpdhbNavigation.Trangthaiidtt == 9) && (x.PhieudathangbanidpdhbNavigation.Active == true)).ToListAsync();

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

        public async Task<IActionResult> Indexxem(int Idpdhb, int page = 1)
        {
            var qLCHSContext = await _context.Chitietxuats.Include(c => c.PhieudathangbanidpdhbNavigation).Include(c => c.SachidsachNavigation).ToListAsync();
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            TempData["phieudathangban"] = _context.Phieudathangbans.Where(i => i.Idpdhb == Idpdhb).FirstOrDefault();
            return View(qLCHSContext);
        }

        // GET: Chitietxuats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietxuat = await _context.Chitietxuats
                .Include(c => c.PhieudathangbanidpdhbNavigation)
                .Include(c => c.SachidsachNavigation)
                .FirstOrDefaultAsync(m => m.Idctx == id);
            if (chitietxuat == null)
            {
                return NotFound();
            }

            return View(chitietxuat);
        }

        // GET: Chitietxuats/Create
        public IActionResult Create(int Idpdhb)
        {
            ViewData["Phieudathangbanidpdhb"] = new SelectList(_context.Phieudathangbans.Where(x => x.Active == true), "Idpdhb", "Sopdhb");
            ViewData["Sachidsach"] = new SelectList(_context.Saches.Where(x => x.Active == true), "Idsach", "Tensach");
            TempData["phieudathangban"] = _context.Phieudathangbans.Where(i => i.Idpdhb == Idpdhb).FirstOrDefault();
            return View();
        }

        // POST: Chitietxuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idctx,Sldat,Slgiao,Dongiaban,Xacnhan,Sachidsach,Phieudathangbanidpdhb")] Chitietxuat chitietxuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitietxuat);
                await _context.SaveChangesAsync();
                TempData["AlertMessage1"] = " Create success!";
                return RedirectToAction("Index", "Chitietxuats", new { Idpdhb = chitietxuat.Phieudathangbanidpdhb });
            }
            ViewData["Phieudathangbanidpdhb"] = new SelectList(_context.Phieudathangbans, "Idpdhb", "Idpdhb", chitietxuat.Phieudathangbanidpdhb);
            ViewData["Sachidsach"] = new SelectList(_context.Saches, "Idsach", "Idsach", chitietxuat.Sachidsach);
            return View(chitietxuat);
        }

        // GET: Chitietxuats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietxuat = await _context.Chitietxuats.FindAsync(id);
            if (chitietxuat == null)
            {
                return NotFound();
            }
            ViewData["Phieudathangbanidpdhb"] = new SelectList(_context.Phieudathangbans.Where(x => x.Active == true), "Idpdhb", "Sopdhb", chitietxuat.Phieudathangbanidpdhb);
            ViewData["Sachidsach"] = new SelectList(_context.Saches.Where(x => x.Active == true), "Idsach", "Tensach", chitietxuat.Sachidsach);
            TempData["phieudathangban"] = _context.Phieudathangbans.Where(i => i.Idpdhb == chitietxuat.Phieudathangbanidpdhb).FirstOrDefault();
            return View(chitietxuat);
        }

        // POST: Chitietxuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idctx,Sldat,Slgiao,Dongiaban,Xacnhan,Sachidsach,Phieudathangbanidpdhb")] Chitietxuat chitietxuat)
        {
            if (id != chitietxuat.Idctx)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitietxuat);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietxuatExists(chitietxuat.Idctx))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Chitietxuats", new { Idpdhb = chitietxuat.Phieudathangbanidpdhb });
            }
            ViewData["Phieudathangbanidpdhb"] = new SelectList(_context.Phieudathangbans, "Idpdhb", "Idpdhb", chitietxuat.Phieudathangbanidpdhb);
            ViewData["Sachidsach"] = new SelectList(_context.Saches, "Idsach", "Idsach", chitietxuat.Sachidsach);
            return View(chitietxuat);
        }

        // GET: Chitietxuats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietxuat = await _context.Chitietxuats
                .Include(c => c.PhieudathangbanidpdhbNavigation)
                .Include(c => c.SachidsachNavigation)
                .FirstOrDefaultAsync(m => m.Idctx == id);
            if (chitietxuat == null)
            {
                return NotFound();
            }

            return View(chitietxuat);
        }

        // POST: Chitietxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chitietxuat = await _context.Chitietxuats.FindAsync(id);
            _context.Chitietxuats.Remove(chitietxuat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitietxuatExists(int id)
        {
            return _context.Chitietxuats.Any(e => e.Idctx == id);
        }
    }
}
