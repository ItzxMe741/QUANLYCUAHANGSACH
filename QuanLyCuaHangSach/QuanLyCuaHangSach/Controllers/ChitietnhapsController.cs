using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangSach.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QuanLyCuaHangSach.Controllers
{
    public class ChitietnhapsController : Controller
    {
        private readonly QLCHSContext _context;

        public ChitietnhapsController(QLCHSContext context)
        {
            _context = context;
        }

        // GET: Chitietnhaps
        public async Task<IActionResult> Index(int Idpdhm, int page = 1)
        {
            var qLCHSContext = await _context.Chitietnhaps.Include(c => c.PhieudathangmuaidpdhmNavigation).Include(c => c.SachidsachNavigation).Where(x => x.Phieudathangmuaidpdhm == Idpdhm).ToListAsync();
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            TempData["phieudathangmua"] = _context.Phieudathangmuas.Where(i => i.Idpdhm == Idpdhm).FirstOrDefault();
            return View(qLCHSContext);
        }

        public async Task<IActionResult> Indexbaocao(DateTime fromDate, DateTime toDate, string searchString, int page = 1)
        {
            var qLCHSContext = await _context.Chitietnhaps.Include(c => c.PhieudathangmuaidpdhmNavigation).Include(c => c.SachidsachNavigation).Where(x => x.PhieudathangmuaidpdhmNavigation.Active == true).ToListAsync();
            
            var fdate = fromDate.ToString("ddMMyyyy");
            var tdate = toDate.ToString("ddMMyyyy");

            if (fdate != "01010001" && tdate != "01010001" && Int32.Parse(fdate) < Int32.Parse(tdate))
            {
                qLCHSContext = _context.Chitietnhaps.Where(x => (x.PhieudathangmuaidpdhmNavigation.Ngaygiaohang >= fromDate) && (x.PhieudathangmuaidpdhmNavigation.Ngaygiaohang <= toDate) && (x.PhieudathangmuaidpdhmNavigation.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Chitietnhaps.Include(c => c.PhieudathangmuaidpdhmNavigation).Include(c => c.SachidsachNavigation).Where(x => x.PhieudathangmuaidpdhmNavigation.Active == true).ToListAsync();
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

            if (!string.IsNullOrEmpty(searchString))
            {
                qLCHSContext = _context.Chitietnhaps.Where(x => (x.PhieudathangmuaidpdhmNavigation.Sopdhm.Contains(searchString)) || (x.SachidsachNavigation.Tensach.Contains(searchString)) && (x.PhieudathangmuaidpdhmNavigation.Active == true)).ToList();
                if (qLCHSContext.Any() == false)
                {
                    TempData["AlertMessagetk"] = "Not found this item";
                    var qLCHSContext1 = await _context.Chitietnhaps.Include(c => c.PhieudathangmuaidpdhmNavigation).Include(c => c.SachidsachNavigation).Where(x => x.PhieudathangmuaidpdhmNavigation.Active == true).ToListAsync();
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

        public async Task<IActionResult> Indexxem(int Idpdhm, int page = 1)
        {
            var qLCHSContext = await _context.Chitietnhaps.Include(c => c.PhieudathangmuaidpdhmNavigation).Include(c => c.SachidsachNavigation).Where(x => x.Phieudathangmuaidpdhm == Idpdhm).ToListAsync();
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            TempData["phieudathangmua"] = _context.Phieudathangmuas.Where(i => i.Idpdhm == Idpdhm).FirstOrDefault();
            return View(qLCHSContext);
        }

        public async Task<IActionResult> Indexxem1(int Idpdhm, int page = 1)
        {
            var qLCHSContext = await _context.Chitietnhaps.Include(c => c.PhieudathangmuaidpdhmNavigation).Include(c => c.SachidsachNavigation).Where(x => x.Phieudathangmuaidpdhm == Idpdhm).ToListAsync();
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            TempData["phieudathangmua"] = _context.Phieudathangmuas.Where(i => i.Idpdhm == Idpdhm).FirstOrDefault();
            return View(qLCHSContext);
        }

        public async Task<IActionResult> Indexxacnhan(int Idpdhm, int page = 1)
        {
            var qLCHSContext = await _context.Chitietnhaps.Include(c => c.PhieudathangmuaidpdhmNavigation).Include(c => c.SachidsachNavigation).Where(x => x.Phieudathangmuaidpdhm == Idpdhm).ToListAsync();
            int NoOfRecordPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(qLCHSContext.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            qLCHSContext = qLCHSContext.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            TempData["phieudathangmua"] = _context.Phieudathangmuas.Where(i => i.Idpdhm == Idpdhm).FirstOrDefault();
            return View(qLCHSContext);
        }

        // GET: Chitietnhaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietnhap = await _context.Chitietnhaps
                .Include(c => c.PhieudathangmuaidpdhmNavigation)
                .Include(c => c.SachidsachNavigation)
                .FirstOrDefaultAsync(m => m.Idctn == id);
            if (chitietnhap == null)
            {
                return NotFound();
            }

            return View(chitietnhap);
        }

        // GET: Chitietnhaps/Create
        public IActionResult Create(int Idpdhm)
        {
            ViewData["Phieudathangmuaidpdhm"] = new SelectList(_context.Phieudathangmuas.Where(x => x.Active == true), "Idpdhm", "Sopdhm");
            ViewData["Sachidsach"] = new SelectList(_context.Saches.Where(x => x.Active == true), "Idsach", "Tensach");
            TempData["phieudathangmua"] = _context.Phieudathangmuas.Where(i => i.Idpdhm == Idpdhm).FirstOrDefault();
            return View();
        }

        // POST: Chitietnhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idctn,Sldat,Slgiao,Dongianhap,Sachidsach,Phieudathangmuaidpdhm")] Chitietnhap chitietnhap)
        {
            if (ModelState.IsValid)
            {
                chitietnhap.Xacnhan = false;
                _context.Add(chitietnhap);
                await _context.SaveChangesAsync();
                //TempData["phieudathangmua"] = _context.Phieudathangmuas.Where(i => i.Idpdhm == chitietnhap.Phieudathangmuaidpdhm).FirstOrDefault();
                TempData["AlertMessage1"] = " Create success!";
                return RedirectToAction("Index", "Chitietnhaps", new { Idpdhm = chitietnhap.Phieudathangmuaidpdhm});
            }
            ViewData["Phieudathangmuaidpdhm"] = new SelectList(_context.Phieudathangmuas, "Idpdhm", "Idpdhm", chitietnhap.Phieudathangmuaidpdhm);
            ViewData["Sachidsach"] = new SelectList(_context.Saches, "Idsach", "Idsach", chitietnhap.Sachidsach);
            return View(chitietnhap);
        }


        public async Task<IActionResult> Editslgiao(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietnhap = await _context.Chitietnhaps.FindAsync(id);
            if (chitietnhap == null)
            {
                return NotFound();
            }
            ViewData["Phieudathangmuaidpdhm"] = new SelectList(_context.Phieudathangmuas.Where(x => x.Active == true), "Idpdhm", "Sopdhm", chitietnhap.Phieudathangmuaidpdhm);
            ViewData["Sachidsach"] = new SelectList(_context.Saches.Where(x => x.Active == true), "Idsach", "Tensach", chitietnhap.Sachidsach);
            TempData["phieudathangmua"] = _context.Phieudathangmuas.Where(i => i.Idpdhm == chitietnhap.Phieudathangmuaidpdhm).FirstOrDefault();
            return View(chitietnhap);
        }

        // POST: Chitietnhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editslgiao(int id, [Bind("Idctn,Sldat,Slgiao,Dongianhap,Sachidsach,Phieudathangmuaidpdhm")] Chitietnhap chitietnhap)
        {
            if (id != chitietnhap.Idctn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    chitietnhap.Xacnhan = false;
                    _context.Update(chitietnhap);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietnhapExists(chitietnhap.Idctn))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Indexxem", "Chitietnhaps", new { Idpdhm = chitietnhap.Phieudathangmuaidpdhm });
            }
            ViewData["Phieudathangmuaidpdhm"] = new SelectList(_context.Phieudathangmuas, "Idpdhm", "Idpdhm", chitietnhap.Phieudathangmuaidpdhm);
            ViewData["Sachidsach"] = new SelectList(_context.Saches, "Idsach", "Idsach", chitietnhap.Sachidsach);
            return View(chitietnhap);
        }


        // GET: Chitietnhaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietnhap = await _context.Chitietnhaps.FindAsync(id);
            if (chitietnhap == null)
            {
                return NotFound();
            }
            ViewData["Phieudathangmuaidpdhm"] = new SelectList(_context.Phieudathangmuas.Where(x => x.Active == true), "Idpdhm", "Sopdhm", chitietnhap.Phieudathangmuaidpdhm);
            ViewData["Sachidsach"] = new SelectList(_context.Saches.Where(x => x.Active == true), "Idsach", "Tensach", chitietnhap.Sachidsach);
            TempData["phieudathangmua"] = _context.Phieudathangmuas.Where(i => i.Idpdhm == chitietnhap.Phieudathangmuaidpdhm).FirstOrDefault();
            return View(chitietnhap);
        }

        // POST: Chitietnhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idctn,Sldat,Slgiao,Dongianhap,Sachidsach,Phieudathangmuaidpdhm")] Chitietnhap chitietnhap)
        {
            if (id != chitietnhap.Idctn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    chitietnhap.Xacnhan = false;
                    _context.Update(chitietnhap);
                    TempData["AlertMessage1"] = " Edit success!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietnhapExists(chitietnhap.Idctn))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Chitietnhaps", new { Idpdhm = chitietnhap.Phieudathangmuaidpdhm });
            }
            ViewData["Phieudathangmuaidpdhm"] = new SelectList(_context.Phieudathangmuas, "Idpdhm", "Idpdhm", chitietnhap.Phieudathangmuaidpdhm);
            ViewData["Sachidsach"] = new SelectList(_context.Saches, "Idsach", "Idsach", chitietnhap.Sachidsach);
            return View(chitietnhap);
        }

        // GET: Chitietnhaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietnhap = await _context.Chitietnhaps
                .Include(c => c.PhieudathangmuaidpdhmNavigation)
                .Include(c => c.SachidsachNavigation)
                .FirstOrDefaultAsync(m => m.Idctn == id);
            if (chitietnhap == null)
            {
                return NotFound();
            }

            return View(chitietnhap);
        }

        // POST: Chitietnhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chitietnhap = await _context.Chitietnhaps.FindAsync(id);
            _context.Chitietnhaps.Remove(chitietnhap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> XacNhan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctn = await _context.Chitietnhaps
                .FirstOrDefaultAsync(m => m.Idctn == id);
            if (ctn == null)
            {
                return NotFound();
            }


            ctn.Xacnhan = true;

            await _context.SaveChangesAsync();
            return RedirectToAction("Indexxacnhan", "Chitietnhaps", new { Idpdhm = ctn.Phieudathangmuaidpdhm });
        }

        public async Task<IActionResult> ExportExcel2()
        {
            var all = await _context.Chitietnhaps.Include(c => c.PhieudathangmuaidpdhmNavigation).Include(c => c.SachidsachNavigation).Where(x => x.PhieudathangmuaidpdhmNavigation.Active == true).ToListAsync();


            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Baocaonhaphang");
                var currentRow = 2;

                //worksheet.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                worksheet.Range(worksheet.Cell(1, 1), worksheet.Cell(1, 6)).Merge().Value = "DANH SÁCH BÁO CÁO NHẬP HÀNG";
                worksheet.Range(worksheet.Cell(1, 1), worksheet.Cell(1, 6)).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                worksheet.Row(1).Height = 20.0;
                worksheet.Range(worksheet.Cell(1, 1), worksheet.Cell(1, 6)).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range(worksheet.Cell(1, 1), worksheet.Cell(1, 6)).Style.Fill.BackgroundColor = XLColor.AntiqueWhite;
                worksheet.Row(1).Style.Font.Bold = true;

                worksheet.Row(currentRow).Height = 15.0;
                worksheet.Row(currentRow).Style.Font.Bold = true;

                worksheet.Row(currentRow).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Range("A2:F2").Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                worksheet.Range("A2:F2").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Range("A2:F2").Style.Fill.BackgroundColor = XLColor.LightGray;

                worksheet.Cell(currentRow, 1).Value = "Tên sách";
                worksheet.Cell(currentRow, 2).Value = "Số lượng sách";
                worksheet.Cell(currentRow, 3).Value = "Đơn giá nhập";
                worksheet.Cell(currentRow, 4).Value = "Số p.đặt hàng mua";
                worksheet.Cell(currentRow, 5).Value = "Ngày nhập hàng";
                worksheet.Cell(currentRow, 6).Value = "Xác nhận";

                string nd;

                foreach (var item in all)
                {
                    if (item.Xacnhan == true)
                    {
                        nd = "Đã xử lý";
                    } else
                    {
                        nd = "Chưa xử lý";
                    }
                    currentRow++;
                    //worksheet.Cell(currentRow, 1).Value = item.SachidsachNavigation.Tensach;
                    worksheet.Cell(currentRow, 2).Value = item.Slgiao;
                    worksheet.Cell(currentRow, 3).Value = item.Dongianhap;
                    worksheet.Cell(currentRow, 3).Style.NumberFormat.Format = "0:#,0";
                    worksheet.Cell(currentRow, 4).Value = item.PhieudathangmuaidpdhmNavigation.Sopdhm;
                    worksheet.Cell(currentRow, 5).Value = item.PhieudathangmuaidpdhmNavigation.Ngaygiaohang;
                    worksheet.Cell(currentRow, 6).Value = nd;


                }
                using (var stream = new MemoryStream())
                {

                    worksheet.Columns().AdjustToContents();
                    worksheet.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Baocaonhaphang.xlsx");
                }
            }

        }

        private bool ChitietnhapExists(int id)
        {
            return _context.Chitietnhaps.Any(e => e.Idctn == id);
        }
    }
}
