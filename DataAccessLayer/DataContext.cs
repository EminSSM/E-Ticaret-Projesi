using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<AdminUser>().HasData(new AdminUser
            {
                ID = 1,
                NameSurname = "Emin Susam",
                LastLoginDate = DateTime.Now,
                LastloginIP = "",
                UserName = "Emin123",
                Password = "202cb962ac59075b964b07152d234b70"
            });
        }

        public DbSet<AdminUser> AdminUser { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Product> Product { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

	}
}
