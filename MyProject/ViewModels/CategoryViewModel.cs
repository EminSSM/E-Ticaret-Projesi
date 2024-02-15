using EntityLayer.Concrete;

namespace MyProject.UI.ViewModels
{
    public class CategoryViewModel
    {
        public IQueryable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Testimonial> Testimonials { get; set; }

    }
}
