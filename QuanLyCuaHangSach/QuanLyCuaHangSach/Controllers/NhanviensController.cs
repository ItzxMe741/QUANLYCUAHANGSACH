using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangSach.Models;

namespace QuanLyCuaHangSach.Controllers
{
    public class NhanviensController : Controller
    {
        private readonly QLCHSContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public NhanviensController(QLCHSContext context, IWebHostEnvironment webHost)
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

        // GET: Nhanviens
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            var lstnv = await _context.Nhanviens.Where(x => x.Active == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {

                lstnv = _context.Nhanviens.Where(x => (x.Manhanvien.Contains(searchString))|| (x.Tennhanvien.Contains(searchString)) && (x.Active == true)).ToList();
                if (lstnv.Any() == false)
                {

                    TempData["AlertMessagetk"] = "Not found this item";
                    var lstnv1 = await _context.Nhanviens.Where(x => x.Active == true).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstnv1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    lstnv1 = lstnv1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(lstnv1);
                }
            }
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstnv.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            lstnv = lstnv.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(lstnv);
        }

        // GET: Nhanviens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .FirstOrDefaultAsync(m => m.Idnhanvien == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Nhanviens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnhanvien,Manhanvien,Tennhanvien,Sdt,Email,Ngaysinh,Password")] Nhanvien nhanvien, IFormFile FrontImage)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Nhanviens.FirstOrDefault(s => s.Manhanvien == nhanvien.Manhanvien);
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

                        nhanvien.Image = uniqueFileName;
                    }
                    nhanvien.Password = GetMD5(nhanvien.Password);
                    nhanvien.Active = true;
                    _context.Attach(nhanvien);
                    _context.Entry(nhanvien).State = EntityState.Added;
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
               
            }
                else
                {
                    TempData["AlertMessage"] = " This " + nhanvien.Manhanvien + " already exists.";
                    return View(nhanvien);
                }
                //string uniqueFileName = UploadFile(nhanvien);
                //nhanvien.Image = uniqueFileName;
                //nhanvien.Active = true;
                //_context.Attach(nhanvien);
                //_context.Entry(nhanvien).State = EntityState.Added;
                ////_context.Add(nhanvien);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            //}
            return View(nhanvien);
        }

        // GET: Nhanviens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        // POST: Nhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idnhanvien,Manhanvien,Tennhanvien,Sdt,Email,Ngaysinh,Password")] Nhanvien nhanvien, IFormFile FrontImage)
        {
            if (id != nhanvien.Idnhanvien)
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

                        nhanvien.Image = uniqueFileName;
                    }
                    nhanvien.Password = GetMD5(nhanvien.Password);
                    nhanvien.Active = true;
                    //_context.Attach(nhanvien);
                    //_context.Entry(nhanvien).State = EntityState.Modified;
                    _context.Update(nhanvien);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.Idnhanvien))
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
            return View(nhanvien);
        }

        // GET: Nhanviens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .FirstOrDefaultAsync(m => m.Idnhanvien == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Nhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            _context.Nhanviens.Remove(nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nv = await _context.Nhanviens
                .FirstOrDefaultAsync(m => m.Idnhanvien == id);
            if (nv == null)
            {
                return NotFound();
            }


            nv.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private string UploadFile(Nhanvien nv)
        {
            string uniqueFileName = null;
            if (nv.FrontImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "-" + nv.FrontImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    nv.FrontImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private bool NhanvienExists(int id)
        {
            return _context.Nhanviens.Any(e => e.Idnhanvien == id);
        }
    }
}
