using EntityLayer.Concrete;
using MyProject.UI.Models;

namespace MyProject.UI.ViewModels
{
    public class ProductViewModel
    {
        public Product products { get; set; }
		public List<Product> Products { get; set; }
		public IEnumerable<Product> RelatedProducts { get; set; }
    }
}
