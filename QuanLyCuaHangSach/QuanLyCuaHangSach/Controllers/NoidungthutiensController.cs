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
    public class NoidungthutiensController : Controller
    {
        private readonly QLCHSContext _context;

        public NoidungthutiensController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Noidungthutiens
        public async Task<IActionResult> Index(int Idpttb, int page = 1)
        {
            var qLCHSContext = await _context.Noidungthutiens.Include(n => n.PhieudathangbanidpdhbNavigation).Include(n => n.PhieuthutienbanidpttbNavigation).Where(x => x.Phieuthutienbanidpttb == Idpttb).ToListAsync();
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            TempData["phieuthutienban"] = _context.Phieuthutienbans.Where(i => i.Idpttb == Idpttb).FirstOrDefault();
            return View(qLCHSContext);
        }

        // GET: Noidungthutiens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noidungthutien = await _context.Noidungthutiens
                .Include(n => n.PhieudathangbanidpdhbNavigation)
                .Include(n => n.PhieuthutienbanidpttbNavigation)
                .FirstOrDefaultAsync(m => m.Idndthu == id);
            if (noidungthutien == null)
            {
                return NotFound();
            }

            return View(noidungthutien);
        }

        // GET: Noidungthutiens/Create
        public IActionResult Create(int Idpttb)
        {
            ViewData["Phieudathangbanidpdhb"] = new SelectList(_context.Phieudathangbans.Where(x => x.Active == true), "Idpdhb", "Sopdhb");
            ViewData["Phieuthutienbanidpttb"] = new SelectList(_context.Phieuthutienbans.Where(x => x.Active == true), "Idpttb", "Sopttb");
            TempData["phieuthutienban"] = _context.Phieuthutienbans.Where(i => i.Idpttb == Idpttb).FirstOrDefault();
            return View();
        }

        // POST: Noidungthutiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idndthu,Phieudathangbanidpdhb,Phieuthutienbanidpttb,Sotienthu")] Noidungthutien noidungthutien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noidungthutien);
                await _context.SaveChangesAsync();
                TempData["AlertMessage1"] = " Create success!";
                return RedirectToAction("Index", "Noidungthutiens", new { Idpttb = noidungthutien.Phieuthutienbanidpttb });
            }
            ViewData["Phieudathangbanidpdhb"] = new SelectList(_context.Phieudathangbans, "Idpdhb", "Idpdhb", noidungthutien.Phieudathangbanidpdhb);
            ViewData["Phieuthutienbanidpttb"] = new SelectList(_context.Phieuthutienbans, "Idpttb", "Idpttb", noidungthutien.Phieuthutienbanidpttb);
            return View(noidungthutien);
        }

        // GET: Noidungthutiens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noidungthutien = await _context.Noidungthutiens.FindAsync(id);
            if (noidungthutien == null)
            {
                return NotFound();
            }
            ViewData["Phieudathangbanidpdhb"] = new SelectList(_context.Phieudathangbans.Where(x => x.Active == true), "Idpdhb", "Sopdhb", noidungthutien.Phieudathangbanidpdhb);
            ViewData["Phieuthutienbanidpttb"] = new SelectList(_context.Phieuthutienbans.Where(x => x.Active == true), "Idpttb", "Sopttb", noidungthutien.Phieuthutienbanidpttb);
            TempData["phieuthutienban"] = _context.Phieuthutienbans.Where(i => i.Idpttb == noidungthutien.Phieuthutienbanidpttb).FirstOrDefault();
            return View(noidungthutien);
        }

        // POST: Noidungthutiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idndthu,Phieudathangbanidpdhb,Phieuthutienbanidpttb,Sotienthu")] Noidungthutien noidungthutien)
        {
            if (id != noidungthutien.Idndthu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noidungthutien);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoidungthutienExists(noidungthutien.Idndthu))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Noidungthutiens", new { Idpttb = noidungthutien.Phieuthutienbanidpttb });
            }
            ViewData["Phieudathangbanidpdhb"] = new SelectList(_context.Phieudathangbans, "Idpdhb", "Idpdhb", noidungthutien.Phieudathangbanidpdhb);
            ViewData["Phieuthutienbanidpttb"] = new SelectList(_context.Phieuthutienbans, "Idpttb", "Idpttb", noidungthutien.Phieuthutienbanidpttb);
            return View(noidungthutien);
        }

        // GET: Noidungthutiens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noidungthutien = await _context.Noidungthutiens
                .Include(n => n.PhieudathangbanidpdhbNavigation)
                .Include(n => n.PhieuthutienbanidpttbNavigation)
                .FirstOrDefaultAsync(m => m.Idndthu == id);
            if (noidungthutien == null)
            {
                return NotFound();
            }

            return View(noidungthutien);
        }

        // POST: Noidungthutiens/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int Idpttb)
        {
            var noidungthutien = await _context.Noidungthutiens.FindAsync(Idpttb);
            _context.Noidungthutiens.Remove(noidungthutien);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Noidungthutiens", new { Idpttb = Idpttb });
        }

        private bool NoidungthutienExists(int id)
        {
            return _context.Noidungthutiens.Any(e => e.Idndthu == id);
        }
    }
}
