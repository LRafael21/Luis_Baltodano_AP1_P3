using Microsoft.EntityFrameworkCore;
using Luis_Baltodano_AP1_P3.Entidades;

namespace Luis_Baltodano_AP1_P3.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Servicios> Servicios { get; set; }

        public DbSet<Contratos> Contratos { get; set; }




        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

      
    }

}
