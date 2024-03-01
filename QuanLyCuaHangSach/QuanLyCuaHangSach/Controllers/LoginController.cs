using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuanLyCuaHangSach.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using static System.Net.WebRequestMethods;

namespace QuanLyCuaHangSach.Controllers
{
   
        [AllowAnonymous]

        public class LoginController : Controller
        {
            private readonly ILogger<LoginController> _logger;
            private readonly QLCHSContext _context;
            public LoginController(ILogger<LoginController> logger, QLCHSContext context)
            {
                _context = context;
                _logger = logger;
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

        public IActionResult Create()
        {
            return View();
        }

        // POST: Khachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idkhachhang,Email,Password")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Khachhangs.FirstOrDefault(s => s.Email == khachhang.Email);
                if (check == null)
                {
                    khachhang.Password = GetMD5(khachhang.Password);
                    khachhang.Active = true;
                    _context.Add(khachhang);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage1"] = " Sign up success!";
                    return RedirectToAction(nameof(Logout));
                }
                else
                {
                    TempData["AlertMessagetk"] = " This " + khachhang.Email + " already exists.";
                    return View(khachhang);
                }
            }
            return View(khachhang);
        }

        [HttpGet]
            [Route("/login")]
            public IActionResult Index(string returnUrl)
            {
                if (HttpContext.User.Identity.Name == null)
                    return View("Login");
                else
                {
                    if (string.IsNullOrWhiteSpace(returnUrl) || !returnUrl.StartsWith("/"))
                    {
                        returnUrl = "/";
                    }
                    return Redirect(returnUrl);
                }
            }
            [HttpPost]
            [Route("/login")]
            public async Task<IActionResult> LoginUser(Nhanvien nv, string returnUrl)
            {
                QLCHSContext context = new QLCHSContext();
                Nhanvien a = context.Nhanviens
                    .FirstOrDefault(x => x.Manhanvien == nv.Manhanvien);
                Donvivanchuyen b = context.Donvivanchuyens
                    .FirstOrDefault(x => x.Madvvc == nv.Manhanvien);
                Nhacungcap c = context.Nhacungcaps
                        .FirstOrDefault(x => x.Mancc == nv.Manhanvien);
                Khachhang d = context.Khachhangs
                        .FirstOrDefault(x => x.Email == nv.Manhanvien);

                var f_password = GetMD5(nv.Password);

                if (a != null)
                {
                    if (a.Password.Equals(f_password))
                    {
                        await SignInUser(a);

                        if (string.IsNullOrWhiteSpace(returnUrl) || !returnUrl.StartsWith("/"))
                        {
                            returnUrl = "/Home/Index";
                        }
                        TempData["AlertMessage1"] = " Log in success!";
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        TempData["AlertMessagetk"] = " Password or Username incorrect.";
                        return RedirectToAction(nameof(Index));
                    } 
                }
                
                if (b != null)
                {
                    if (b.Password.Equals(f_password))
                    {
                        await SignInUserdvvc(b);

                        if (string.IsNullOrWhiteSpace(returnUrl) || !returnUrl.StartsWith("/"))
                        {
                            returnUrl = "/Phieudathangmuas/Capnhattrangthaidvvc";
                        }
                        TempData["AlertMessage1"] = " Log in success!";
                        return Redirect(returnUrl+ "?Iddvvc=" + b.Iddvvc);
                    }
                    else
                    {
                        TempData["AlertMessagetk"] = " Password or Username incorrect.";
                        return RedirectToAction(nameof(Index));
                    } 
                }
                
                if (c != null)
                {
                    if (c.Password.Equals(f_password))
                    {
                        await SignInUserncc(c);

                        if (string.IsNullOrWhiteSpace(returnUrl) || !returnUrl.StartsWith("/"))
                        {
                            returnUrl = "/Phieudathangmuas/Capnhattrangthai";
                        }
                        TempData["AlertMessage1"] = " Log in success!";
                        return Redirect(returnUrl + "?Idncc=" + c.Idncc);
                    }
                    else
                    {
                        TempData["AlertMessagetk"] = " Password or Username incorrect.";
                        return RedirectToAction(nameof(Index));
                    } 
                }
                
                if (d != null)
                {
                    if (d.Password.Equals(f_password))
                    {
                        await SignInUserkh(d);

                        if (string.IsNullOrWhiteSpace(returnUrl) || !returnUrl.StartsWith("/"))
                        {
                            returnUrl = "/Home/Indexkh";
                        }
                        TempData["AlertMessage1"] = " Log in success!";
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        TempData["AlertMessagetk"] = " Password or Username incorrect.";
                        return RedirectToAction(nameof(Index));
                    } 
                }
            return RedirectToAction(nameof(Index));
            //return RedirectToAction("Index");

        }
            [HttpGet]
            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index");
            }
            private async Task SignInUser(Nhanvien accounts)
            {
                QLCHSContext context = new QLCHSContext();
                Nhanvien user = context.Nhanviens.Where(x => x.Idnhanvien == accounts.Idnhanvien).FirstOrDefault();

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Idnhanvien.ToString()),
            };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
            }

            private async Task SignInUserdvvc(Donvivanchuyen accounts)
            {
                QLCHSContext context = new QLCHSContext();
                Donvivanchuyen user = context.Donvivanchuyens.Where(x => x.Iddvvc == accounts.Iddvvc).FirstOrDefault();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Iddvvc.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
            }

            private async Task SignInUserncc(Nhacungcap accounts)
            {
                QLCHSContext context = new QLCHSContext();
                Nhacungcap user = context.Nhacungcaps.Where(x => x.Idncc == accounts.Idncc).FirstOrDefault();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Idncc.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
            }
            
            private async Task SignInUserkh(Khachhang accounts)
            {
                QLCHSContext context = new QLCHSContext();
                Khachhang user = context.Khachhangs.Where(x => x.Idkhachhang == accounts.Idkhachhang).FirstOrDefault();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Idkhachhang.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
            }


    }
    }

