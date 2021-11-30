using Microsoft.EntityFrameworkCore;
using SassApi.Models;

namespace SassApi.Data
{
    public class SassApiContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public SassApiContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DATABASE_URL"));
        }
    }
}
