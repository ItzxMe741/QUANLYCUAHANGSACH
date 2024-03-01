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
    public class NgonngusController : Controller
    {
        private readonly QLCHSContext _context;

        public NgonngusController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Ngonngus
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            var lstnn = await _context.Ngonngus.Where(x => x.Active == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                lstnn = _context.Ngonngus.Where(x => (x.Tenngongu.Contains(searchString)) && (x.Active == true)).ToList();
                if (lstnn.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var lstnn1 = await _context.Ngonngus.Where(x => x.Active == true).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstnn1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    lstnn1 = lstnn1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(lstnn1);
                }
            }
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstnn.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            lstnn = lstnn.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(lstnn);
        }

        // GET: Ngonngus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngonngu = await _context.Ngonngus
                .FirstOrDefaultAsync(m => m.Idngonngu == id);
            if (ngonngu == null)
            {
                return NotFound();
            }

            return View(ngonngu);
        }

        // GET: Ngonngus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ngonngus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idngonngu,Tenngongu")] Ngonngu ngonngu)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Ngonngus.FirstOrDefault(s => s.Tenngongu == ngonngu.Tenngongu);
                if (check == null)
                {
                    ngonngu.Active = true;
                    _context.Add(ngonngu);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + ngonngu.Tenngongu + " already exists.";
                    return View(ngonngu);
                }


            }
            return View(ngonngu);
        }

        // GET: Ngonngus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngonngu = await _context.Ngonngus.FindAsync(id);
            if (ngonngu == null)
            {
                return NotFound();
            }
            return View(ngonngu);
        }

        // POST: Ngonngus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idngonngu,Tenngongu")] Ngonngu ngonngu)
        {
            if (id != ngonngu.Idngonngu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ngonngu.Active = true;
                    _context.Update(ngonngu);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NgonnguExists(ngonngu.Idngonngu))
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
            return View(ngonngu);
        }

        // GET: Ngonngus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngonngu = await _context.Ngonngus
                .FirstOrDefaultAsync(m => m.Idngonngu == id);
            if (ngonngu == null)
            {
                return NotFound();
            }

            return View(ngonngu);
        }

        // POST: Ngonngus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ngonngu = await _context.Ngonngus.FindAsync(id);
            _context.Ngonngus.Remove(ngonngu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nn = await _context.Ngonngus
                .FirstOrDefaultAsync(m => m.Idngonngu == id);
            if (nn == null)
            {
                return NotFound();
            }


            nn.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NgonnguExists(int id)
        {
            return _context.Ngonngus.Any(e => e.Idngonngu == id);
        }
    }
}
