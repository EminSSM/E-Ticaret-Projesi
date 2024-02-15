using EntityLayer.Concrete;
using MyProject.UI.Models;

namespace MyProject.UI.ViewModels
{
	public class CheckOutViewModel
	{
		public Order Order { get; set; }
		public IEnumerable<Cart> Carts { get; set; }

    }
}
