using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class OrderDetail
	{
		public int ID { get; set; }
		[Display(Name = "Sipariş Numarası")]
		public int OrderId { get; set; }
		public Order Order { get; set; }

		[Column(TypeName = "Varchar(100)"), StringLength(100), Display(Name = "Ürün Adı")]
		public string ProductName { get; set; }

		[Column(TypeName = "Varchar(150)"), StringLength(150), Display(Name = "Ürün Resmi")]
		public string ProductPicture { get; set; }
		[Column(TypeName = "decimal(18,2)"), Display(Name = "Ürün Fiyatı")]
		public decimal ProductPrice { get; set; }
		[Display(Name = "Miktar")]
		public int Quantity { get; set; }

		[Display(Name = "Ürün Adı")]
		public int? ProductID { get; set; }
		public Product Product { get; set; }
	}
}
