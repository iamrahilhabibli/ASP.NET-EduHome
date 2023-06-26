using Microsoft.EntityFrameworkCore;

namespace EduHome.DataAccess.Contexts
{
	public class AppDbContext:DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
    }
}
