using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangSach.Models;

namespace QuanLyCuaHangSach.Controllers
{
    public class LoaisachesController : Controller
    {
        private readonly QLCHSContext _context;

        public LoaisachesController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Loaisaches
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            var lstls = await _context.Loaisaches.Where(x => x.Active == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {

                lstls = _context.Loaisaches.Where(x => (x.Tenloai.Contains(searchString))|| (x.Maloai.Contains(searchString)) && (x.Active == true)).ToList();
                if (lstls.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var lstls1 = await _context.Loaisaches.Where(x => x.Active == true).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstls1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    lstls1 = lstls1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(lstls1);
                }
            }
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstls.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            lstls = lstls.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(lstls);
        }

        // GET: Loaisaches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisach = await _context.Loaisaches
                .FirstOrDefaultAsync(m => m.Idloai == id);
            if (loaisach == null)
            {
                return NotFound();
            }

            return View(loaisach);
        }

        // GET: Loaisaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loaisaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idloai,Maloai,Tenloai")] Loaisach loaisach)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Loaisaches.FirstOrDefault(s => s.Maloai == loaisach.Maloai);
                if (check == null)
                {
                    loaisach.Active = true;
                    _context.Add(loaisach);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + loaisach.Maloai + " already exists.";
                    return View(loaisach);
                }

            }
            return View(loaisach);
        }

        // GET: Loaisaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisach = await _context.Loaisaches.FindAsync(id);
            if (loaisach == null)
            {
                return NotFound();
            }
            return View(loaisach);
        }

        // POST: Loaisaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idloai,Maloai,Tenloai")] Loaisach loaisach)
        {
            if (id != loaisach.Idloai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    loaisach.Active = true;
                    _context.Update(loaisach);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaisachExists(loaisach.Idloai))
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
            return View(loaisach);
        }

        // GET: Loaisaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisach = await _context.Loaisaches
                .FirstOrDefaultAsync(m => m.Idloai == id);
            if (loaisach == null)
            {
                return NotFound();
            }

            return View(loaisach);
        }

        // POST: Loaisaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaisach = await _context.Loaisaches.FindAsync(id);
            _context.Loaisaches.Remove(loaisach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ls = await _context.Loaisaches
                .FirstOrDefaultAsync(m => m.Idloai == id);
            if (ls == null)
            {
                return NotFound();
            }


            ls.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaisachExists(int id)
        {
            return _context.Loaisaches.Any(e => e.Idloai == id);
        }
    }
}
