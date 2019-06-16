using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TestePratico.Net.Restaurante.Data.Extensions;
using TestePratico.Net.Restaurante.Data.Mappings;

namespace TestePratico.Net.Restaurante.Data.Context
{
    public class RestauranteContext : DbContext
    {
        public DbSet<Domain.Eventos.Model.Restaurante> Restaurantes { get; set; }
        public DbSet<Domain.Eventos.Model.Prato> Pratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new RestauranteMapping());
            modelBuilder.AddConfiguration(new PratoMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

    }
}
