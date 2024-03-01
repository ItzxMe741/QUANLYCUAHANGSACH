using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DonvivanchuyensController : Controller
    {
        private readonly QLCHSContext _context;

        public DonvivanchuyensController(QLCHSContext context)
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

        // GET: Donvivanchuyens
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            //var qLTQNKContext = _context.KeHoachDieuTri.Include(k => k.IdbnkhNavigation).Include(k => k.IdbslkhNavigation);
            //return View(await qLTQNKContext.ToListAsync());


            //var ketquatk = _context.Donvivanchuyens.Where(x => x.Active == true).ToList();
            var ketquatk = await _context.Donvivanchuyens.Where(x => x.Active == true).ToListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                ketquatk = _context.Donvivanchuyens.Where(x => (x.Madvvc.Contains(searchString))||(x.Tendvvc.Contains(searchString)) && (x.Active == true)).ToList();
                if (ketquatk.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var ketquatk1 = await _context.Donvivanchuyens.Where(x => x.Active == true).ToListAsync();
                    int NoOfRecordPerPage1 = 10;
                    int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(ketquatk1.Count) /
                        Convert.ToDouble(NoOfRecordPerPage1)));
                    int NoOfRecordToSkip1 = (page - 1) * NoOfRecordPerPage1;
                    ViewBag.Page = page;
                    ViewBag.NoOfPages = NoOfPages1;
                    ketquatk1 = ketquatk1.Skip(NoOfRecordToSkip1).Take(NoOfRecordPerPage1).ToList();
                    return View(ketquatk1);
                }
            }

            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(ketquatk.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            ketquatk = ketquatk.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(ketquatk); /*await _context.Donvivanchuyens.ToListAsync()*/
        }

        // GET: Donvivanchuyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donvivanchuyen = await _context.Donvivanchuyens
                .FirstOrDefaultAsync(m => m.Iddvvc == id);
            if (donvivanchuyen == null)
            {
                return NotFound();
            }

            return View(donvivanchuyen);
        }

        

        // GET: Donvivanchuyens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donvivanchuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddvvc,Madvvc,Tendvvc,Diachi,Sdt,Email,Password,Ghichu")] Donvivanchuyen donvivanchuyen)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Donvivanchuyens.FirstOrDefault(s => s.Madvvc == donvivanchuyen.Madvvc);
                if (check == null)
                {
                    donvivanchuyen.Password = GetMD5(donvivanchuyen.Password);
                    donvivanchuyen.Active = true;
                    _context.Add(donvivanchuyen);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Create success!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["AlertMessage"] = " This "+ donvivanchuyen.Madvvc + " already exists.";
                    return View(donvivanchuyen);
                }
                
            }
            return View(donvivanchuyen);
        }

        // GET: Donvivanchuyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donvivanchuyen = await _context.Donvivanchuyens.FindAsync(id);
            if (donvivanchuyen == null)
            {
                return NotFound();
            }
            return View(donvivanchuyen);
        }

        // POST: Donvivanchuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iddvvc,Madvvc,Tendvvc,Diachi,Sdt,Email,Password,Ghichu")] Donvivanchuyen donvivanchuyen)
        {
            if (id != donvivanchuyen.Iddvvc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    donvivanchuyen.Password = GetMD5(donvivanchuyen.Password);
                    donvivanchuyen.Active = true;
                    _context.Update(donvivanchuyen);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonvivanchuyenExists(donvivanchuyen.Iddvvc))
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
            return View(donvivanchuyen);
        }

        // GET: Donvivanchuyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donvivanchuyen = await _context.Donvivanchuyens
                .FirstOrDefaultAsync(m => m.Iddvvc == id);
            if (donvivanchuyen == null)
            {
                return NotFound();
            }

            return View(donvivanchuyen);
        }

        // POST: Donvivanchuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donvivanchuyen = await _context.Donvivanchuyens.FindAsync(id);
            _context.Donvivanchuyens.Remove(donvivanchuyen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XoaTam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvvc = await _context.Donvivanchuyens
                .FirstOrDefaultAsync(m => m.Iddvvc == id);
            if (dvvc == null)
            {
                return NotFound();
            }


            dvvc.Active = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonvivanchuyenExists(int id)
        {
            return _context.Donvivanchuyens.Any(e => e.Iddvvc == id);
        }
    }
}
