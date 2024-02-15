using BusinessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.UI.Areas.Admin.Models;
using NuGet.Protocol;

namespace MyProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductController : Controller
    {
        IGenericRepository<Product> repoproduct;
        IGenericRepository<Category> repocategory;


        public AdminProductController(IGenericRepository<Product> _repoproduct, IGenericRepository<Category> _repocategory)
        {
            repoproduct = _repoproduct;
            repocategory = _repocategory;
        }

        public IActionResult AllProduct()
        {
            var productAll = repoproduct.GetAll().Include(c => c.category).OrderByDescending(x => x.ProductID).ToList();

            return View(productAll);
        }
        public IActionResult Product(int id)
        {
            var product = repoproduct.GetAll().Include(c => c.category).Where(c => c.CategoryId == id).ToList();

            return View(product);
        }


        public IActionResult New()
        {
            ViewData["KategoriId"] = new SelectList(repocategory.GetAll(), "ID", "Title");
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(Product product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "bilgisayar"))) // söylenen konumda belirtilen dosyayı arıyor
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "bilgisayar")); // dosyayı oluşturuyor
                    }
                    string dosyaAdi = Request.Form.Files["Image"].FileName;
                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "bilgisayar", dosyaAdi), FileMode.Create))
                    {
                        await Request.Form.Files["Image"].CopyToAsync(stream);
                    }
                    product.Image = "/img/bilgisayar/" + dosyaAdi;
                }

                repoproduct.Insert(product);
                return RedirectToAction("AllProduct");
            }

            return RedirectToAction("New");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = repoproduct.GetBy(x => x.ProductID == id);
            ViewData["KategoriId"] = new SelectList(repocategory.GetAll(), "ID", "Title");


            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Product");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "bilgisayar"))) // söylenen konumda belirtilen dosyayı arıyor
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "bilgisayar")); // dosyayı oluşturuyor
                    }
                    string dosyaAdi = Request.Form.Files["Image"].FileName;
                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "bilgisayar", dosyaAdi), FileMode.Create))
                    {
                        await Request.Form.Files["Image"].CopyToAsync(stream);
                    }
                    product.Image = "/img/bilgisayar/" + dosyaAdi;
                }
                repoproduct.Update(product);
                return RedirectToAction("AllProduct");
            }
            return RedirectToAction("New");

        }
        public IActionResult Delete(int id)
        {
            var product = repoproduct.GetBy(x => x.ProductID.Equals(id));
            if (product != null)
            {
                repoproduct.Delete(product);
            }
            return RedirectToAction("Product");

        }


       
        public IActionResult SearchProduct(string search)
        {
            
            var lowerCaseSearch = search.ToLower(); // arama yaparken buyuk kucuk harf duyarlılıgını kaldırdık //

            var products = repoproduct.GetAll().Include(y => y.category)
                                         .Where(p => p.Title != null && p.Title.ToLower().Contains(lowerCaseSearch))
                                        .ToList();

            ViewBag.deneme = search;

            return View(products);
        }


    }

}

