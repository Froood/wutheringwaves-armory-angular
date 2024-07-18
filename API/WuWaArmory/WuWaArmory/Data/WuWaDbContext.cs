using Microsoft.EntityFrameworkCore;
using WuWaArmory.Models;

namespace WuWaArmory.Data
{
    public class WuWaDbContext : DbContext
    {
        public WuWaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Character> Characters { get; set; }
    }
}
