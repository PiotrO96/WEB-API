using Microsoft.EntityFrameworkCore;
using PS4_WebApi.Shared.Models;

namespace PS4_WebApi.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<Przedmiot> Przedmioty { get; set; }

        public DbSet<Koszyk> Koszyki { get; set; }

     //   public DbSet<mojSklep> mojSklepy { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
