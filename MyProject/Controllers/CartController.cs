using BusinessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using MyProject.UI.Models;
using MyProject.UI.ViewModels;
using Newtonsoft.Json;
using System.Net;

namespace MyProject.UI.Controllers
{
	public class CartController : Controller
	{
		IGenericRepository<Product> repoProduct;
		IGenericRepository<Order> repoOrder;
		IGenericRepository<OrderDetail> repoOrderDetail;

		public CartController(IGenericRepository<OrderDetail> _repoOrderDetail, IGenericRepository<Order> _repoOrder, IGenericRepository<Product> _repoProduct)
		{
			repoOrderDetail = _repoOrderDetail;
			repoOrder = _repoOrder;
			repoProduct = _repoProduct;
		}


		[Route("/sepet/sepeteekle"), HttpPost]
		public string AddCart(int productid, int quantity)
		{

			Product product = repoProduct.GetAll(x => x.ProductID == productid).FirstOrDefault();
			bool varmi = false;
			if (product != null)
			{

				Cart cart = new Cart()
				{
					ProductID = productid,
					ProductName = product.Title,
					ProductPrice = product.Price,
					Quantity = quantity,
					Image = product.Image,
				};

				List<Cart> carts = new List<Cart>();
				if (Request.Cookies["MyCart"] != null)
				{
					carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
					foreach (Cart c in carts)
					{
						if (c.ProductID == productid)
						{
							varmi = true;
							if (c.ProductID == productid) c.Quantity += quantity;
							break;

						}

					}
				}
				if (!varmi)
					carts.Add(cart);

				CookieOptions option = new();
				option.Expires = DateTime.Now.AddHours(3);
				Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), option);
				return product.Title;
			}

			return "~ Ürün Bulunamadı";
		}

		[Route("/sepet/sepetsayisi")]
		public int CartCount()
		{
			int geri = 0;
			if (Request.Cookies["MyCart"] != null)
			{
				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
				geri = carts.Sum(x => x.Quantity);
			}
			return geri;
		}


        [HttpPost]
        public IActionResult UpdateBasket(int productId, int quantity)
        {
			return View();
        }

        [Route("/sepet")]
		public IActionResult Index()
		{


			if (Request.Cookies["MyCart"] != null)
			{
				CartViewModel cartVm = new CartViewModel()
				{
					Carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]),
					BestSelling = repoProduct.GetAll().OrderByDescending(x => x.SumQuantity).Take(4)

				};
				return View(cartVm);
			}
			else
			{
				return Redirect("/");
			}
		}
		
		[Route("/sepet/alisverisitamamla")]
		public IActionResult CheckOut()
		{
			ViewBag.ShippingFee = 1000;
			if (Request.Cookies["MyCart"] != null)
			{
				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
				CheckOutViewModel checkOutVM = new CheckOutViewModel()
				{
					Order = new Order(),
					Carts = carts
				};
				return View(checkOutVM);
			}
			else
			{
				return Redirect("/");
			}
		}


		[Route("/sepet/alisverisitamamla"), HttpPost, ValidateAntiForgeryToken]
		public IActionResult CheckOut(CheckOutViewModel model)
		{
			if (model.Order.PaymentOption == EPaymentOption.KrediKarti)
			{
				//Kredi Kartı Kontrol 

			}
			model.Order.RecDate = DateTime.Now;
			string orderNumber = DateTime.Now.Microsecond.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Microsecond.ToString() + DateTime.Now.Microsecond.ToString();

			if (orderNumber.Length > 20) orderNumber = orderNumber.Substring(0, 20);
			model.Order.OrderNumber = orderNumber;
			model.Order.OrderStatus = EOrderStatus.Hazirlaniyor;

			repoOrder.Insert(model.Order);
			List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
			foreach (Cart c in carts)
			{
				OrderDetail od = new OrderDetail()
				{
					OrderId = model.Order.ID,
					ProductID = c.ProductID,
					ProductName = c.ProductName,
					ProductPicture = c.Image,
					ProductPrice = c.ProductPrice,
					Quantity = c.Quantity,

				};
				var urun = repoProduct.GetBy(x => x.ProductID == c.ProductID);
				urun.SumQuantity += c.Quantity;
				repoProduct.Update(urun);

				repoOrderDetail.Insert(od);
			}
			Response.Cookies.Delete("MyCart");

			return Redirect("/");
		}


		[Route("/sepet/sepettensil"), HttpPost]
		public string RemoveCart(int productId)
		{
			string rtn = "";
			if (Request.Cookies["MyCart"] != null)
			{
				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
				bool varMi = false;
				foreach (Cart c in carts)
				{
					if (c.ProductID == productId)
					{
						varMi = true;
						carts.Remove(c);
						break;
					}
				}
				if (varMi)
				{
					CookieOptions options = new();
					options.Expires = DateTime.Now.AddHours(3);
					Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), options);
					rtn = "OK";

				}

			}

			return rtn;
		}
	}

}
