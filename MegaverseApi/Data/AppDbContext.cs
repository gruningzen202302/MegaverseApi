using MegaverseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaverseApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Polyanet> Polyanets { get; set; }
        public DbSet<Soloon> Soloons { get; set; }
        public DbSet<Cometh> Comeths { get; set; }

    }
}
