using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "Varchar(150)"), Display(Name = "Ürün Adı")]
        public string Title { get; set; }
        [Column(TypeName = "decimal(18,2)"), Display(Name = "Fiyat Bilgisi")]
        public decimal Price { get; set; }
		[Display(Name = "Stok Miktarı")]
		public int Stock { get; set; }
		public int SumQuantity { get; set; }
		public int CategoryId { get; set; }
		public Category category { get; set; }
		public int Star { get; set; }
        [Column(TypeName = "Varchar(150)"), Display(Name = "Ürün Özellikleri")]
        public string Detail { get; set; }
        [Column(TypeName = "Varchar(150)"), Display(Name = "Kargo Detayı")]
        public string CargoDetail { get; set; }

    }
}
