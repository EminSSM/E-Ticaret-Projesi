using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Category
	{
        public int ID { get; set; }
        public string Title { get; set; }
        public string Ikon { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
