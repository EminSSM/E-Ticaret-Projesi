using EntityLayer.Concrete;
using MyProject.UI.Models;

namespace MyProject.UI.ViewModels
{
	public class CartViewModel
	{
		public List<Cart> Carts { get; set; }
		public IEnumerable<Product> BestSelling { get; set; }
		
	}
}
