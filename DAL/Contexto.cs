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

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>().HasData(new Clientes
            {
                ClienteId = 4,
                Nombre = "Rafael",
                Apellido = "Baltodano",
                Direccion = "Av Caonabo #64",
                NumeroCedula = "4024311800",
                NumeroTelefono = "8097250705"
            });
        }*/

    }
}
