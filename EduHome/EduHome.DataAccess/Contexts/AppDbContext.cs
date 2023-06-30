using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHome.DataAccess.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HomeSlider> homeSliders { get; set; }
        public DbSet<Notices> notices { get; set; } 
        public DbSet<Events> events { get; set; }   
        public DbSet<EventDetails> eventDetails { get; set; }   

        public DbSet<Courses> courses { get; set; }
        public DbSet<CourseDetails> courseDetails { get; set; }
        public DbSet<Teachers> teachers { get; set; }
        public DbSet<TeacherDetails> teachersDetails { get; set;}
        public DbSet<Testimonials> testimonials { get; set;}
        public DbSet<UserReplies> userReplies { get; set; }
        public DbSet<Users> users { get; set; }

        public DbSet<Blogs> blogs { get; set; }
    }
}
