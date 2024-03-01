using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangSach.Models;
using static System.Net.WebRequestMethods;

namespace QuanLyCuaHangSach.Controllers
{
    public class KhachhangsController : Controller
    {
        private readonly QLCHSContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public KhachhangsController(QLCHSContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }

        // GET: Khachhangs
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            var qLCHSContext = await _context.Khachhangs.Include(k => k.NganhangidnganhangNavigation).Where(x => x.Active == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                qLCHSContext = _context.Khachhangs.Where(x => (x.Makhachhang.Contains(searchString))|| (x.Tenkhachhang.Contains(searchString)) && (x.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Khachhangs.Include(k => k.NganhangidnganhangNavigation).Where(x => x.Active == true).ToListAsync();
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

        // GET: Khachhangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs
                .Include(k => k.NganhangidnganhangNavigation)
                .FirstOrDefaultAsync(m => m.Idkhachhang == id);
            if (khachhang == null)
            {
                return NotFound();
            }
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs, "Idnganhang", "Idnganhang", khachhang.Nganhangidnganhang);
            return View(khachhang);
        }

        // GET: Khachhangs/Create
        public IActionResult Create()
        {
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs.Where(x => x.Active == true), "Idnganhang", "Tennganhang");
            return View();
        }

        // POST: Khachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idkhachhang,Makhachhang,Tenkhachhang,Diachi,Sdt,Email,Password,Stk,Nganhangidnganhang")] Khachhang khachhang, IFormFile FrontImage)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Khachhangs.FirstOrDefault(s => (s.Makhachhang == khachhang.Makhachhang) || (s.Email == khachhang.Email));
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

                        khachhang.Image = uniqueFileName;
                    }
                    khachhang.Password = GetMD5(khachhang.Password);
                    khachhang.Active = true;
                    _context.Attach(khachhang);
                    _context.Entry(khachhang).State = EntityState.Added;
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessagetk"] = " This item already exists.";
                    ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs.Where(x => x.Active == true), "Idnganhang", "Tennganhang");
                    return View(khachhang);
                }

            }
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs, "Idnganhang", "Idnganhang", khachhang.Nganhangidnganhang);
            return View(khachhang);
        }

        // GET: Khachhangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs.Where(x => x.Active==true), "Idnganhang", "Tennganhang", khachhang.Nganhangidnganhang);
            return View(khachhang);
        }

        // POST: Khachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idkhachhang,Makhachhang,Tenkhachhang,Diachi,Sdt,Email,Password,Stk,Nganhangidnganhang")] Khachhang khachhang, IFormFile FrontImage)
        {
            if (id != khachhang.Idkhachhang)
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

                        khachhang.Image = uniqueFileName;
                    }
                    khachhang.Password = GetMD5(khachhang.Password);
                    khachhang.Active = true;
                    _context.Update(khachhang);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachhangExists(khachhang.Idkhachhang))
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
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs, "Idnganhang", "Idnganhang", khachhang.Nganhangidnganhang);
            return View(khachhang);
        }

        // GET: Khachhangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs
                .Include(k => k.NganhangidnganhangNavigation)
                .FirstOrDefaultAsync(m => m.Idkhachhang == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: Khachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khachhang = await _context.Khachhangs.FindAsync(id);
            _context.Khachhangs.Remove(khachhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kh = await _context.Khachhangs
                .FirstOrDefaultAsync(m => m.Idkhachhang == id);
            if (kh == null)
            {
                return NotFound();
            }


            kh.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(int id)
        {
            return _context.Khachhangs.Any(e => e.Idkhachhang == id);
        }
    }
}
