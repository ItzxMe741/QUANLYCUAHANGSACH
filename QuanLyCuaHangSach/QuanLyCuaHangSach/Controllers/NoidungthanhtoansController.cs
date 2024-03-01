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
    public class NoidungthanhtoansController : Controller
    {
        private readonly QLCHSContext _context;

        public NoidungthanhtoansController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Noidungthanhtoans
        public async Task<IActionResult> Index(int Idptttm, int page = 1)
        {
            var qLCHSContext = await _context.Noidungthanhtoans.Include(n => n.PhieudathangmuaidpdhmNavigation).Include(n => n.PhieuthanhtoantienmuaidptttmNavigation).Where(x => x.Phieuthanhtoantienmuaidptttm == Idptttm).ToListAsync();
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            TempData["phieuthanhtoantienmua"] = _context.Phieuthanhtoantienmuas.Where(i => i.Idptttm == Idptttm).FirstOrDefault();
            return View(qLCHSContext);
        }

        public async Task<IActionResult> Indexbaocao(int page = 1)
        {
            var qLCHSContext = await _context.Noidungthanhtoans.Include(n => n.PhieudathangmuaidpdhmNavigation).ThenInclude(x => x.Ngaygiaohang).Include(n => n.PhieuthanhtoantienmuaidptttmNavigation).ThenInclude(x => x.Ngaythanhtoan).ToListAsync();
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(qLCHSContext);
        }

        // GET: Noidungthanhtoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noidungthanhtoan = await _context.Noidungthanhtoans
                .Include(n => n.PhieudathangmuaidpdhmNavigation)
                .Include(n => n.PhieuthanhtoantienmuaidptttmNavigation)
                .FirstOrDefaultAsync(m => m.Idndtt == id);
            if (noidungthanhtoan == null)
            {
                return NotFound();
            }

            return View(noidungthanhtoan);
        }

        // GET: Noidungthanhtoans/Create
        public IActionResult Create(int Idptttm)
        {
            ViewData["Phieudathangmuaidpdhm"] = new SelectList(_context.Phieudathangmuas.Where(x => x.Active == true), "Idpdhm", "Sopdhm");
            ViewData["Phieuthanhtoantienmuaidptttm"] = new SelectList(_context.Phieuthanhtoantienmuas.Where(x => x.Active == true), "Idptttm", "Soptttm");
            TempData["phieuthanhtoantienmua"] = _context.Phieuthanhtoantienmuas.Where(i => i.Idptttm == Idptttm).FirstOrDefault();
            return View();
        }

        // POST: Noidungthanhtoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idndtt,Sotienthanhtoan,Phieuthanhtoantienmuaidptttm,Phieudathangmuaidpdhm")] Noidungthanhtoan noidungthanhtoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noidungthanhtoan);
                await _context.SaveChangesAsync();
                TempData["AlertMessage1"] = " Create success!";
                return RedirectToAction("Index", "Noidungthanhtoans", new { Idptttm = noidungthanhtoan.Phieuthanhtoantienmuaidptttm });
            }
            ViewData["Phieudathangmuaidpdhm"] = new SelectList(_context.Phieudathangmuas, "Idpdhm", "Idpdhm", noidungthanhtoan.Phieudathangmuaidpdhm);
            ViewData["Phieuthanhtoantienmuaidptttm"] = new SelectList(_context.Phieuthanhtoantienmuas, "Idptttm", "Idptttm", noidungthanhtoan.Phieuthanhtoantienmuaidptttm);
            return View(noidungthanhtoan);
        }

        // GET: Noidungthanhtoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noidungthanhtoan = await _context.Noidungthanhtoans.FindAsync(id);
            if (noidungthanhtoan == null)
            {
                return NotFound();
            }
            ViewData["Phieudathangmuaidpdhm"] = new SelectList(_context.Phieudathangmuas.Where(x => x.Active == true), "Idpdhm", "Sopdhm", noidungthanhtoan.Phieudathangmuaidpdhm);
            ViewData["Phieuthanhtoantienmuaidptttm"] = new SelectList(_context.Phieuthanhtoantienmuas.Where(x => x.Active == true), "Idptttm", "Soptttm", noidungthanhtoan.Phieuthanhtoantienmuaidptttm);
            TempData["phieuthanhtoantienmua"] = _context.Phieuthanhtoantienmuas.Where(i => i.Idptttm == noidungthanhtoan.Phieuthanhtoantienmuaidptttm).FirstOrDefault();
            return View(noidungthanhtoan);
        }

        // POST: Noidungthanhtoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idndtt,Sotienthanhtoan,Phieuthanhtoantienmuaidptttm,Phieudathangmuaidpdhm")] Noidungthanhtoan noidungthanhtoan)
        {
            if (id != noidungthanhtoan.Idndtt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noidungthanhtoan);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoidungthanhtoanExists(noidungthanhtoan.Idndtt))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Noidungthanhtoans", new { Idptttm = noidungthanhtoan.Phieuthanhtoantienmuaidptttm });
            }
            ViewData["Phieudathangmuaidpdhm"] = new SelectList(_context.Phieudathangmuas, "Idpdhm", "Idpdhm", noidungthanhtoan.Phieudathangmuaidpdhm);
            ViewData["Phieuthanhtoantienmuaidptttm"] = new SelectList(_context.Phieuthanhtoantienmuas, "Idptttm", "Idptttm", noidungthanhtoan.Phieuthanhtoantienmuaidptttm);
            return View(noidungthanhtoan);
        }

        // GET: Noidungthanhtoans/Delete/5
        public async Task<IActionResult> Delete(int? Idptttm)
        {
            if (Idptttm == null)
            {
                return NotFound();
            }

            var noidungthanhtoan = await _context.Noidungthanhtoans
                .Include(n => n.PhieudathangmuaidpdhmNavigation)
                .Include(n => n.PhieuthanhtoantienmuaidptttmNavigation)
                .FirstOrDefaultAsync(m => m.Idndtt == Idptttm);
            if (noidungthanhtoan == null)
            {
                return NotFound();
            }

            return View(noidungthanhtoan);
        }

        // POST: Noidungthanhtoans/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int Idptttm)
        {
            var noidungthanhtoan = await _context.Noidungthanhtoans.FindAsync(Idptttm);
            _context.Noidungthanhtoans.Remove(noidungthanhtoan);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Noidungthanhtoans", new { Idptttm = Idptttm });
        }

        private bool NoidungthanhtoanExists(int id)
        {
            return _context.Noidungthanhtoans.Any(e => e.Idndtt == id);
        }
    }
}
