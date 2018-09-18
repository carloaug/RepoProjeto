using System.Data.Entity;

namespace RSistema.Models
{
    public class PratoDbContext : DbContext
    {


        public DbSet<Prato> Pratos { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
    }
}