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
    public class HtttsController : Controller
    {
        private readonly QLCHSContext _context;

        public HtttsController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Httts
        public async Task<IActionResult> Index(string searchString,int page = 1)
        {
            var qLCHSContext = await _context.Httts.Include(h => h.NganhangidnganhangNavigation).Where(x => x.Active == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                qLCHSContext = _context.Httts.Where(x => (x.Tenhttt.Contains(searchString))|| (x.Tenhttt.Contains(searchString)) && (x.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Httts.Include(h => h.NganhangidnganhangNavigation).Where(x => x.Active == true).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
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

        // GET: Httts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httt = await _context.Httts
                .Include(h => h.NganhangidnganhangNavigation)
                .FirstOrDefaultAsync(m => m.Idhttt == id);
            if (httt == null)
            {
                return NotFound();
            }

            return View(httt);
        }

        // GET: Httts/Create
        public IActionResult Create()
        {
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs.Where(x => x.Active == true), "Idnganhang", "Tennganhang");
            return View();
        }

        // POST: Httts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idhttt,Mahttt,Tenhttt,Ghichu,Nganhangidnganhang")] Httt httt)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Httts.FirstOrDefault(s => s.Mahttt == httt.Mahttt);
                if (check == null)
                {
                    httt.Active = true;
                    _context.Add(httt);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + httt.Mahttt + " already exists.";
                    ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs.Where(x => x.Active == true), "Idnganhang", "Tennganhang");
                    return View(httt);
                }

            }
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs, "Idnganhang", "Idnganhang", httt.Nganhangidnganhang);
            return View(httt);
        }

        // GET: Httts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httt = await _context.Httts.FindAsync(id);
            if (httt == null)
            {
                return NotFound();
            }
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs.Where(x => x.Active == true), "Idnganhang", "Tennganhang", httt.Nganhangidnganhang);
            return View(httt);
        }

        // POST: Httts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idhttt,Mahttt,Tenhttt,Ghichu,Nganhangidnganhang")] Httt httt)
        {
            if (id != httt.Idhttt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    httt.Active = true;
                    _context.Update(httt);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HtttExists(httt.Idhttt))
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
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs, "Idnganhang", "Idnganhang", httt.Nganhangidnganhang);
            return View(httt);
        }

        // GET: Httts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httt = await _context.Httts
                .Include(h => h.NganhangidnganhangNavigation)
                .FirstOrDefaultAsync(m => m.Idhttt == id);
            if (httt == null)
            {
                return NotFound();
            }

            return View(httt);
        }

        // POST: Httts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var httt = await _context.Httts.FindAsync(id);
            _context.Httts.Remove(httt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httt = await _context.Httts
                .FirstOrDefaultAsync(m => m.Idhttt == id);
            if (httt == null)
            {
                return NotFound();
            }


            httt.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HtttExists(int id)
        {
            return _context.Httts.Any(e => e.Idhttt == id);
        }
    }
}
