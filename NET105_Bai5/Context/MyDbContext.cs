using Microsoft.EntityFrameworkCore;

namespace NET105_Bai5.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        public DbSet<Car> Cars { get; set; }
    }
}
