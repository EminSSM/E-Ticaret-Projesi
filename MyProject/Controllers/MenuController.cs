using BusinessLayer.Repository;
using DataAccessLayer;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.UI.ViewModels;
using System.Collections;

namespace MyProject.UI.Controllers
{
    public class MenuController : Controller
	{

		IGenericRepository<Product> repoProduct;
		IGenericRepository<Category> repoCategory;
		DataContext dataContext;


        public MenuController(IGenericRepository<Product> _repoProduct, IGenericRepository<Category> _repoCategory, DataContext dataContext)
        {
            repoProduct = _repoProduct;
            repoCategory = _repoCategory;
            this.dataContext = dataContext;
        }
        public IActionResult Index()
		{
			CategoryViewModel indexVM = new CategoryViewModel()
			{
				Categories = repoCategory.GetAll().OrderBy(x => x.ID),
				Products = repoProduct.GetAll().Include(x => x.category).OrderBy(x => Guid.NewGuid()).Take(8),
				Testimonials = dataContext.Testimonials.OrderBy(x => x.DisplayIndex),
			};
			return View(indexVM);
		}
	}
}
