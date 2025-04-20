using Microsoft.EntityFrameworkCore;
using BuildingCommissioningAPI.Models;

namespace BuildingCommissioningAPI.Data
{
    public class CommissioningDbContext : DbContext  // ✅ Use PascalCase for class names
    {
        public CommissioningDbContext(DbContextOptions<CommissioningDbContext> options)
            : base(options)
        {
        }

        public DbSet<AssetComponent> AssetComponents { get; set; }
    }
}
