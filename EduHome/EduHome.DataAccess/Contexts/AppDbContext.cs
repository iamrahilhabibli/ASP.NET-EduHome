using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHome.DataAccess.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HomeSlider> homeSliders { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<HomeSlider>().HasData(
        //        new HomeSlider { Title = "EDUCATION MAKE PROPER HUMANITY", Description = "I must explain to you how all this mistaken idea of denouncing pleasure and prsing pain was born and I will give you a complete account of the system ", ImagePath = "assets/img/slider/slider1.jpg" },
        //        new HomeSlider { Title = "EDUCATION MAKE PROPER HUMANITY", Description = "I must explain to you how all this mistaken idea of denouncing pleasure and prsing pain was born and I will give you a complete account of the system ", ImagePath = "assets/img/slider/slider1.jpg" },
        //        new HomeSlider { Title = "EDUCATION MAKE PROPER HUMANITY", Description = "I must explain to you how all this mistaken idea of denouncing pleasure and prsing pain was born and I will give you a complete account of the system ", ImagePath = "assets/img/slider/slider1.jpg" }
        //        );
        //}
    }
}
