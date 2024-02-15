using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.UI.Tools;
using System.Security.Claims;
using BusinessLayer.Repository;
using EntityLayer.Concrete;

namespace MyProject.UI.Areas.Admin.Controllers
{
    [Area("admin"), Authorize] // Bu Controllera erişimi kısıtlıyoruz ve her isteyen giriş yapamıyor
    public class HomeController : Controller
    {
        IGenericRepository<AdminUser> repoAdmin;
        public HomeController(IGenericRepository<AdminUser> _repoAdmin)
        {
            repoAdmin = _repoAdmin;
        }


        public IActionResult Index()
        {
            return View();
        }

        // AllowAnonymous: attribute u ile kilitli olan controller içerisindeki belirtilen action a erişimi izin verdik
        [AllowAnonymous, Route("/admin/login")]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }


        [AllowAnonymous, Route("/admin/login"), HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password, string ReturnUrl)
        {
            string md5Password = GeneralTools.GetMD5(password);
            AdminUser admin = repoAdmin.GetBy(x => x.UserName == username && x.Password == md5Password);
            if (admin != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.PrimarySid, admin.ID.ToString()),
                    new Claim(ClaimTypes.Name, admin.NameSurname)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ProjectAuth");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });

                if (!string.IsNullOrEmpty(ReturnUrl)) return Redirect(ReturnUrl);
                else return Redirect("/admin");

            }
            else TempData["bilgi"] = "Yanlış Kullanıcı Adı veya Parola";
            return RedirectToAction("Login");
        }

        [Route("admin/logout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }


    }
}
