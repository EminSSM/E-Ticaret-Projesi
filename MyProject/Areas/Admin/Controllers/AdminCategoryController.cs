using BusinessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        IGenericRepository<Category> repocategory;

        public AdminCategoryController(IGenericRepository<Category> _repocategory)
        {
            repocategory = _repocategory;
        }

        public IActionResult Category()
        {

            return View(repocategory.GetAll().OrderBy(x => x.ID));
        }
        public IActionResult New()
        {

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(Category category)
        {
            if (ModelState.IsValid)
            {

                repocategory.Insert(category);
                return RedirectToAction("Category");
            }

            return RedirectToAction("New");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = repocategory.GetBy(x => x.ID == id);
            if (category != null)
            {
                return View(category);
            }
            return RedirectToAction("Category");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                repocategory.Update(category);
                return RedirectToAction("Category");
            }
            return RedirectToAction("New");

        }
        public IActionResult Delete(int id)
        {
            var category = repocategory.GetBy(x => x.ID.Equals(id));
            if (category != null)
            {
                repocategory.Delete(category);
            }
            return RedirectToAction("Category");

        }


        

    }
}
