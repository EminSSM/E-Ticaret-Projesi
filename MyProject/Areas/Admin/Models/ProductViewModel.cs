using EntityLayer.Concrete;

namespace MyProject.UI.Areas.Admin.Models
{
	public class ProductViewModel
	{
        public Product Product { get; set; }
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Category> Categories { get; set; }
    }
}
