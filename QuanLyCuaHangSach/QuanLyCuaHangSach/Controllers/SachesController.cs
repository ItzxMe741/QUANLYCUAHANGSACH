using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangSach.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuanLyCuaHangSach.Controllers
{
    public class SachesController : Controller
    {
        private readonly QLCHSContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public SachesController(QLCHSContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        // GET: Saches
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {

            var qLCHSContext = await _context.Saches.Include(s => s.LoaisachidloaiNavigation).Include(s => s.NgonnguidngonnguNavigation).Include(s => s.NhaxuatbanidnxbNavigation).Include(s => s.TacgiaidtacgiaNavigation).Where(x => x.Active == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {

                qLCHSContext = _context.Saches.Where(x => (x.Masach.Contains(searchString)) || (x.Tensach.Contains(searchString)) && (x.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Saches.Include(s => s.LoaisachidloaiNavigation).Include(s => s.NgonnguidngonnguNavigation).Include(s => s.NhaxuatbanidnxbNavigation).Include(s => s.TacgiaidtacgiaNavigation).Where(x => x.Active == true).ToListAsync();
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

        // GET: Saches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches
                .Include(s => s.LoaisachidloaiNavigation)
                .Include(s => s.NgonnguidngonnguNavigation)
                .Include(s => s.NhaxuatbanidnxbNavigation)
                .Include(s => s.TacgiaidtacgiaNavigation)
                .FirstOrDefaultAsync(m => m.Idsach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // GET: Saches/Create
        public IActionResult Create()
        {
            ViewData["Loaisachidloai"] = new SelectList(_context.Loaisaches.Where(x => x.Active == true), "Idloai", "Tenloai");
            ViewData["Ngonnguidngonngu"] = new SelectList(_context.Ngonngus.Where(x => x.Active == true), "Idngonngu", "Tenngongu");
            ViewData["Nhaxuatbanidnxb"] = new SelectList(_context.Nhaxuatbans.Where(x => x.Active == true), "Idnxb", "Tennxb");
            ViewData["Tacgiaidtacgia"] = new SelectList(_context.Tacgias.Where(x => x.Active == true), "Idtacgia", "Tentacgia");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idsach,Masach,Tensach,Ngayxb,Lanxb,Ghichu,Loaisachidloai,Nhaxuatbanidnxb,Tacgiaidtacgia,Ngonnguidngonngu")] Sach sach, IFormFile FrontImage)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Saches.FirstOrDefault(s => s.Masach == sach.Masach);
                if (check == null)
                {
                    if (FrontImage != null && FrontImage.Length > 0)
                    {
                        string uniqueFileName = null;
                        // Lưu hình ảnh vào thư mục wwwroot/images
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                        uniqueFileName = Guid.NewGuid().ToString() + "-" + FrontImage.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            FrontImage.CopyTo(fileStream);
                        }

                        sach.Image = uniqueFileName;
                    }
                    sach.Active = true;
                    _context.Attach(sach);
                    _context.Entry(sach).State = EntityState.Added;
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + sach.Masach + " already exists.";
                    ViewData["Loaisachidloai"] = new SelectList(_context.Loaisaches.Where(x => x.Active == true), "Idloai", "Tenloai");
                    ViewData["Ngonnguidngonngu"] = new SelectList(_context.Ngonngus.Where(x => x.Active == true), "Idngonngu", "Tenngongu");
                    ViewData["Nhaxuatbanidnxb"] = new SelectList(_context.Nhaxuatbans.Where(x => x.Active == true), "Idnxb", "Tennxb");
                    ViewData["Tacgiaidtacgia"] = new SelectList(_context.Tacgias.Where(x => x.Active == true), "Idtacgia", "Tentacgia");
                    return View(sach);
                }

            }
            ViewData["Loaisachidloai"] = new SelectList(_context.Loaisaches, "Idloai", "Idloai", sach.Loaisachidloai);
            ViewData["Ngonnguidngonngu"] = new SelectList(_context.Ngonngus, "Idngonngu", "Idngonngu", sach.Ngonnguidngonngu);
            ViewData["Nhaxuatbanidnxb"] = new SelectList(_context.Nhaxuatbans, "Idnxb", "Idnxb", sach.Nhaxuatbanidnxb);
            ViewData["Tacgiaidtacgia"] = new SelectList(_context.Tacgias, "Idtacgia", "Idtacgia", sach.Tacgiaidtacgia);
            return View(sach);
        }

        // GET: Saches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            ViewData["Loaisachidloai"] = new SelectList(_context.Loaisaches.Where(x => x.Active == true), "Idloai", "Tenloai", sach.Loaisachidloai);
            ViewData["Ngonnguidngonngu"] = new SelectList(_context.Ngonngus.Where(x => x.Active == true), "Idngonngu", "Tenngongu", sach.Ngonnguidngonngu);
            ViewData["Nhaxuatbanidnxb"] = new SelectList(_context.Nhaxuatbans.Where(x => x.Active == true), "Idnxb", "Tennxb", sach.Nhaxuatbanidnxb);
            ViewData["Tacgiaidtacgia"] = new SelectList(_context.Tacgias.Where(x => x.Active == true), "Idtacgia", "Tentacgia", sach.Tacgiaidtacgia);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idsach,Masach,Tensach,Ngayxb,Lanxb,Ghichu,Loaisachidloai,Nhaxuatbanidnxb,Tacgiaidtacgia,Ngonnguidngonngu")] Sach sach, IFormFile FrontImage)
        {
            if (id != sach.Idsach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (FrontImage != null && FrontImage.Length > 0)
                    {
                        string uniqueFileName = null;
                        // Lưu hình ảnh vào thư mục wwwroot/images
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                        uniqueFileName = Guid.NewGuid().ToString() + "-" + FrontImage.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            FrontImage.CopyTo(fileStream);
                        }

                        sach.Image = uniqueFileName;
                    }
                    sach.Active = true;
                    _context.Update(sach);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.Idsach))
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
            ViewData["Loaisachidloai"] = new SelectList(_context.Loaisaches, "Idloai", "Idloai", sach.Loaisachidloai);
            ViewData["Ngonnguidngonngu"] = new SelectList(_context.Ngonngus, "Idngonngu", "Idngonngu", sach.Ngonnguidngonngu);
            ViewData["Nhaxuatbanidnxb"] = new SelectList(_context.Nhaxuatbans, "Idnxb", "Idnxb", sach.Nhaxuatbanidnxb);
            ViewData["Tacgiaidtacgia"] = new SelectList(_context.Tacgias, "Idtacgia", "Idtacgia", sach.Tacgiaidtacgia);
            return View(sach);
        }

        // GET: Saches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches
                .Include(s => s.LoaisachidloaiNavigation)
                .Include(s => s.NgonnguidngonnguNavigation)
                .Include(s => s.NhaxuatbanidnxbNavigation)
                .Include(s => s.TacgiaidtacgiaNavigation)
                .FirstOrDefaultAsync(m => m.Idsach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sach = await _context.Saches.FindAsync(id);
            _context.Saches.Remove(sach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var s = await _context.Saches
                .FirstOrDefaultAsync(m => m.Idsach == id);
            if (s == null)
            {
                return NotFound();
            }


            s.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachExists(int id)
        {
            return _context.Saches.Any(e => e.Idsach == id);
        }
    }
}
