using Microsoft.EntityFrameworkCore;
using Maentl.Models;
namespace Maentl.Data
{
    public class MaentlDbContext : DbContext
    {
        public MaentlDbContext(DbContextOptions<MaentlDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
