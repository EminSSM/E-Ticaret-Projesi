using EntityLayer.Concrete;

namespace MyProject.UI.Models
{
    public class Cart
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }

        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }

        public decimal Total
        {
            get { return ProductPrice * Quantity; }
        }
    }
}
