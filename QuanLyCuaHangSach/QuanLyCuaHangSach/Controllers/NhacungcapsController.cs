using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangSach.Models;

namespace QuanLyCuaHangSach.Controllers
{
    public class NhacungcapsController : Controller
    {
        private readonly QLCHSContext _context;

        public NhacungcapsController(QLCHSContext context)
        {
            _context = context;
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

        // GET: Nhacungcaps
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            var qLCHSContext = await _context.Nhacungcaps.Include(n => n.NganhangidnganhangNavigation).Where(x => x.Active == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                qLCHSContext = _context.Nhacungcaps.Where(x => (x.Mancc.Contains(searchString))|| (x.Tenncc.Contains(searchString)) && (x.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Nhacungcaps.Include(n => n.NganhangidnganhangNavigation).Where(x => x.Active == true).ToListAsync();
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

        // GET: Nhacungcaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcaps
                .Include(n => n.NganhangidnganhangNavigation)
                .FirstOrDefaultAsync(m => m.Idncc == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // GET: Nhacungcaps/Create
        public IActionResult Create()
        {
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs.Where(x => x.Active == true), "Idnganhang", "Tennganhang");
            return View();
        }

        // POST: Nhacungcaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idncc,Mancc,Tenncc,Diachi,Sdt,Masothue,Email,Ghichu,Stk,Password,Nganhangidnganhang")] Nhacungcap nhacungcap)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Nhacungcaps.FirstOrDefault(s => s.Mancc == nhacungcap.Mancc);
                if (check == null)
                {
                    nhacungcap.Password = GetMD5(nhacungcap.Password);
                    nhacungcap.Active = true;
                    _context.Add(nhacungcap);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This " + nhacungcap.Mancc + " already exists.";
                    ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs.Where(x => x.Active == true), "Idnganhang", "Tennganhang");
                    return View(nhacungcap);
                }

            }
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs, "Idnganhang", "Idnganhang", nhacungcap.Nganhangidnganhang);
            return View(nhacungcap);
        }

        // GET: Nhacungcaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcaps.FindAsync(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs.Where(x => x.Active == true), "Idnganhang", "Tennganhang", nhacungcap.Nganhangidnganhang);
            return View(nhacungcap);
        }

        // POST: Nhacungcaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idncc,Mancc,Tenncc,Diachi,Sdt,Masothue,Email,Ghichu,Password,Stk,Nganhangidnganhang")] Nhacungcap nhacungcap)
        {
            if (id != nhacungcap.Idncc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    nhacungcap.Password = GetMD5(nhacungcap.Password);
                    nhacungcap.Active = true;
                    _context.Update(nhacungcap);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhacungcapExists(nhacungcap.Idncc))
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
            ViewData["Nganhangidnganhang"] = new SelectList(_context.Nganhangs, "Idnganhang", "Idnganhang", nhacungcap.Nganhangidnganhang);
            return View(nhacungcap);
        }

        // GET: Nhacungcaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcaps
                .Include(n => n.NganhangidnganhangNavigation)
                .FirstOrDefaultAsync(m => m.Idncc == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // POST: Nhacungcaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhacungcap = await _context.Nhacungcaps.FindAsync(id);
            _context.Nhacungcaps.Remove(nhacungcap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ncc = await _context.Nhacungcaps
                .FirstOrDefaultAsync(m => m.Idncc == id);
            if (ncc == null)
            {
                return NotFound();
            }


            ncc.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhacungcapExists(int id)
        {
            return _context.Nhacungcaps.Any(e => e.Idncc == id);
        }
    }
}
