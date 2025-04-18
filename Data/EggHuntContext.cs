using EggHuntApp.Models;
using Microsoft.EntityFrameworkCore;
namespace EggHuntApp.Data

{
    public class EggHuntContext : DbContext
    {
        public EggHuntContext(DbContextOptions<EggHuntContext> options) : base(options)
        {
        }
        public DbSet<EggFound> EggsFound { get; set; } = null!;
       
    }
    
}
