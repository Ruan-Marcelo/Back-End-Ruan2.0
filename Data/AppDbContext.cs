using Microsoft.EntityFrameworkCore;
using RuanApi.Models;

namespace RuanApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Certificacao> Certificacoes { get; set; }
    }
}