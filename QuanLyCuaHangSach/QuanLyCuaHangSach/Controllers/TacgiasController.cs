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
    public class TacgiasController : Controller
    {
        private readonly QLCHSContext _context;

        public TacgiasController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Tacgias
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            var lsttg = await _context.Tacgias.Where(x => x.Active == true).ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {

                lsttg = _context.Tacgias.Where(x => (x.Matacgia.Contains(searchString)) || (x.Tentacgia.Contains(searchString)) && (x.Active == true)).ToList();
                if (lsttg.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var lsttg1 = await _context.Tacgias.Where(x => x.Active == true).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lsttg1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    lsttg1 = lsttg1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(lsttg1);
                }
            }
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lsttg.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            lsttg = lsttg.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(lsttg);
        }

        // GET: Tacgias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacgia = await _context.Tacgias
                .FirstOrDefaultAsync(m => m.Idtacgia == id);
            if (tacgia == null)
            {
                return NotFound();
            }

            return View(tacgia);
        }

        // GET: Tacgias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tacgias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtacgia,Matacgia,Tentacgia,Ghichu")] Tacgia tacgia)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Tacgias.FirstOrDefault(s => s.Matacgia == tacgia.Matacgia);
                if (check == null)
                {
                    tacgia.Active = true;
                    _context.Add(tacgia);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + tacgia.Matacgia + " already exists.";
                    return View(tacgia);
                }

            }
            return View(tacgia);
        }

        // GET: Tacgias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacgia = await _context.Tacgias.FindAsync(id);
            if (tacgia == null)
            {
                return NotFound();
            }
            return View(tacgia);
        }

        // POST: Tacgias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idtacgia,Matacgia,Tentacgia,Ghichu")] Tacgia tacgia)
        {
            if (id != tacgia.Idtacgia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tacgia.Active = true;
                    _context.Update(tacgia);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TacgiaExists(tacgia.Idtacgia))
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
            return View(tacgia);
        }

        // GET: Tacgias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tacgia = await _context.Tacgias
                .FirstOrDefaultAsync(m => m.Idtacgia == id);
            if (tacgia == null)
            {
                return NotFound();
            }

            return View(tacgia);
        }

        // POST: Tacgias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tacgia = await _context.Tacgias.FindAsync(id);
            _context.Tacgias.Remove(tacgia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tg = await _context.Tacgias
                .FirstOrDefaultAsync(m => m.Idtacgia == id);
            if (tg == null)
            {
                return NotFound();
            }


            tg.Active = false;
            TempData["AlertMessage1"] = " Edit success!";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TacgiaExists(int id)
        {
            return _context.Tacgias.Any(e => e.Idtacgia == id);
        }
    }
}
