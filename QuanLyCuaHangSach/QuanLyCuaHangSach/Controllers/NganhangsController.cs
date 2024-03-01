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
    public class NganhangsController : Controller
    {
        private readonly QLCHSContext _context;

        public NganhangsController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Nganhangs
        public async Task<IActionResult> Index(string searchString,int page = 1)
        {
            var lstnh = await _context.Nganhangs.Where(x => x.Active == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                lstnh = _context.Nganhangs.Where(x => (x.Manganhang.Contains(searchString))|| (x.Tennganhang.Contains(searchString)) && (x.Active == true)).ToList();
                if (lstnh.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var lstnh1 = await _context.Nganhangs.Where(x => x.Active == true).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstnh1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    lstnh1 = lstnh1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(lstnh1);
                }
            }
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstnh.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            lstnh = lstnh.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(lstnh);
        }

        // GET: Nganhangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganhang = await _context.Nganhangs
                .FirstOrDefaultAsync(m => m.Idnganhang == id);
            if (nganhang == null)
            {
                return NotFound();
            }

            return View(nganhang);
        }

        // GET: Nganhangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nganhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnganhang,Manganhang,Tennganhang,Ghichu")] Nganhang nganhang)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Nganhangs.FirstOrDefault(s => s.Manganhang == nganhang.Manganhang);
                if (check == null)
                {
                    nganhang.Active = true;
                    _context.Add(nganhang);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + nganhang.Manganhang + " already exists.";
                    return View(nganhang);
                }
            }
            
            return View(nganhang);
        }

        // GET: Nganhangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganhang = await _context.Nganhangs.FindAsync(id);
            if (nganhang == null)
            {
                return NotFound();
            }
            return View(nganhang);
        }

        // POST: Nganhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idnganhang,Manganhang,Tennganhang,Ghichu")] Nganhang nganhang)
        {
            if (id != nganhang.Idnganhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    nganhang.Active = true;
                    _context.Update(nganhang);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NganhangExists(nganhang.Idnganhang))
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
            return View(nganhang);
        }

        // GET: Nganhangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganhang = await _context.Nganhangs
                .FirstOrDefaultAsync(m => m.Idnganhang == id);
            if (nganhang == null)
            {
                return NotFound();
            }

            return View(nganhang);
        }

        // POST: Nganhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nganhang = await _context.Nganhangs.FindAsync(id);
            _context.Nganhangs.Remove(nganhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nh = await _context.Nganhangs
                .FirstOrDefaultAsync(m => m.Idnganhang == id);
            if (nh == null)
            {
                return NotFound();
            }


            nh.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NganhangExists(int id)
        {
            return _context.Nganhangs.Any(e => e.Idnganhang == id);
        }
    }
}
