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
    public class TrangthaisController : Controller
    {
        private readonly QLCHSContext _context;

        public TrangthaisController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Trangthais
        public async Task<IActionResult> Index(string searchString,int page = 1)
        {
            var lsttt = await _context.Trangthais.Where(x => x.Active == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                
                lsttt = _context.Trangthais.Where(x => (x.Tentt.Contains(searchString)) && (x.Active == true)).ToList();
                if (lsttt.Any()==false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var lsttt1 = await _context.Trangthais.Where(x => x.Active == true).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lsttt1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    lsttt1 = lsttt1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(lsttt1);
                }
            }
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lsttt.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            lsttt = lsttt.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(lsttt);
        }

        // GET: Trangthais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangthai = await _context.Trangthais
                .FirstOrDefaultAsync(m => m.Idtt == id);
            if (trangthai == null)
            {
                return NotFound();
            }

            return View(trangthai);
        }

        // GET: Trangthais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trangthais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtt,Tentt")] Trangthai trangthai)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Trangthais.FirstOrDefault(s => s.Tentt == trangthai.Tentt);
                if (check == null)
                {
                    trangthai.Active = true;
                    _context.Add(trangthai);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + trangthai.Tentt + " already exists.";
                    return View(trangthai);
                }

            }
            return View(trangthai);
        }

        // GET: Trangthais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangthai = await _context.Trangthais.FindAsync(id);
            if (trangthai == null)
            {
                return NotFound();
            }
            return View(trangthai);
        }

        // POST: Trangthais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idtt,Tentt")] Trangthai trangthai)
        {
            if (id != trangthai.Idtt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    trangthai.Active = true;
                    _context.Update(trangthai);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrangthaiExists(trangthai.Idtt))
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
            return View(trangthai);
        }

        // GET: Trangthais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangthai = await _context.Trangthais
                .FirstOrDefaultAsync(m => m.Idtt == id);
            if (trangthai == null)
            {
                return NotFound();
            }

            return View(trangthai);
        }

        // POST: Trangthais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trangthai = await _context.Trangthais.FindAsync(id);
            _context.Trangthais.Remove(trangthai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tt = await _context.Trangthais
                .FirstOrDefaultAsync(m => m.Idtt == id);
            if (tt == null)
            {
                return NotFound();
            }


            tt.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrangthaiExists(int id)
        {
            return _context.Trangthais.Any(e => e.Idtt == id);
        }
    }
}
