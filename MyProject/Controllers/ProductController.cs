using BusinessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MyProject.UI.ViewModels;

namespace MyProject.UI.Controllers
{
    public class ProductController : Controller
    {
        IGenericRepository<Product> _repositoryproduct;
        IGenericRepository<Category> _repositorycategory;


        public ProductController(IGenericRepository<Product> repositoryproduct, IGenericRepository<Category> repositorycategory)
        {
            _repositoryproduct = repositoryproduct;
            _repositorycategory = repositorycategory;
        }
        [Route("/Product/{name}/{id}")]
        public IActionResult Index(int id,string name)
        {
            var products = _repositoryproduct.GetAll(x => x.CategoryId == id).Include(x => x.category);
          
            return View(products);
        }
		[Route("/Product/{name}")]
		public IActionResult Detail(int id,string name)
        {
            Product product = _repositoryproduct.GetAll(x => x.ProductID == id).Include(x => x.category).FirstOrDefault();
            if (product != null)
            {
                ProductViewModel viewModel = new ProductViewModel()
                {
                    products = product,
                    RelatedProducts = _repositoryproduct.GetAll(x => x.CategoryId == product.CategoryId && x.ProductID != product.ProductID).Include(x => x.category)
				};
                return View(viewModel);
            }
            return Redirect("/");
          
        }
        
    }
}
