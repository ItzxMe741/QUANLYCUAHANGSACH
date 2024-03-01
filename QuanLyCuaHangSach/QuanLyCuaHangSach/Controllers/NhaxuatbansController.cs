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
    public class NhaxuatbansController : Controller
    {
        private readonly QLCHSContext _context;

        public NhaxuatbansController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Nhaxuatbans
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            var lstnxb = await _context.Nhaxuatbans.Where(x => x.Active == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {

                lstnxb = _context.Nhaxuatbans.Where(x => (x.Manxb.Contains(searchString)) || (x.Tennxb.Contains(searchString)) && (x.Active == true)).ToList();
                if (lstnxb.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var lstnxb1 = await _context.Nhaxuatbans.Where(x => x.Active == true).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstnxb1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    lstnxb1 = lstnxb1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(lstnxb1);
                }
            }
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstnxb.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            lstnxb = lstnxb.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(lstnxb);
        }

        // GET: Nhaxuatbans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaxuatban = await _context.Nhaxuatbans
                .FirstOrDefaultAsync(m => m.Idnxb == id);
            if (nhaxuatban == null)
            {
                return NotFound();
            }

            return View(nhaxuatban);
        }

        // GET: Nhaxuatbans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhaxuatbans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnxb,Manxb,Tennxb")] Nhaxuatban nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Nhaxuatbans.FirstOrDefault(s => s.Manxb == nhaxuatban.Manxb);
                if (check == null)
                {
                    nhaxuatban.Active = true;
                    _context.Add(nhaxuatban);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + nhaxuatban.Manxb + " already exists.";
                    return View(nhaxuatban);
                }

            }
            return View(nhaxuatban);
        }

        // GET: Nhaxuatbans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaxuatban = await _context.Nhaxuatbans.FindAsync(id);
            if (nhaxuatban == null)
            {
                return NotFound();
            }
            return View(nhaxuatban);
        }

        // POST: Nhaxuatbans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idnxb,Manxb,Tennxb")] Nhaxuatban nhaxuatban)
        {
            if (id != nhaxuatban.Idnxb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    nhaxuatban.Active = true;
                    _context.Update(nhaxuatban);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaxuatbanExists(nhaxuatban.Idnxb))
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
            return View(nhaxuatban);
        }

        // GET: Nhaxuatbans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaxuatban = await _context.Nhaxuatbans
                .FirstOrDefaultAsync(m => m.Idnxb == id);
            if (nhaxuatban == null)
            {
                return NotFound();
            }

            return View(nhaxuatban);
        }

        // POST: Nhaxuatbans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhaxuatban = await _context.Nhaxuatbans.FindAsync(id);
            _context.Nhaxuatbans.Remove(nhaxuatban);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nxb = await _context.Nhaxuatbans
                .FirstOrDefaultAsync(m => m.Idnxb == id);
            if (nxb == null)
            {
                return NotFound();
            }


            nxb.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaxuatbanExists(int id)
        {
            return _context.Nhaxuatbans.Any(e => e.Idnxb == id);
        }
    }
}
