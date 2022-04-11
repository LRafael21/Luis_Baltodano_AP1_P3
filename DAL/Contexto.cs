using Microsoft.EntityFrameworkCore;
using Luis_Baltodano_AP1_P3.Entidades;

namespace Luis_Baltodano_AP1_P3.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Servicios> Servicios { get; set; }

        public DbSet<Contratos> Contratos { get; set; }

        public DbSet<Planes> Planes { get; set; }



        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planes>().HasData(new Planes
            {
                Id = 1,
                Descripcion = "Internet(5Mbps - 1Mbps) - Cable(120 Canales)"

            });

            modelBuilder.Entity<Planes>().HasData(new Planes
            {
                Id = 2,
                Descripcion = "Internet (100Mbps - 50Mbps) - Cable (300 Canales)"

            });

            modelBuilder.Entity<Planes>().HasData(new Planes
            {
                Id = 3,
                Descripcion = "Internet (5Mbps - 1Mbps)"

            });

            modelBuilder.Entity<Planes>().HasData(new Planes
            {
                Id = 4,
                Descripcion = "(10Mbps - 5Mbps)"

            });

            modelBuilder.Entity<Planes>().HasData(new Planes
            {
                Id = 5,
                Descripcion = "Internet (100Mbps - 50Mbps)"

            });

            modelBuilder.Entity<Planes>().HasData(new Planes
            {
                Id = 6,
                Descripcion = "Cable (120 Canales)"

            });

            modelBuilder.Entity<Planes>().HasData(new Planes
            {
                Id = 7,
                Descripcion = " Cable (150 Canales)"

            });

            modelBuilder.Entity<Planes>().HasData(new Planes
            {
                Id = 8,
                Descripcion = "Cable (300 Canales)"

            });

        }

    }
}
