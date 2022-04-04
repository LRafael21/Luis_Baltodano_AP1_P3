using System.ComponentModel.DataAnnotations;

namespace Luis_Baltodano_AP1_P3.Entidades
{
    public partial class ContratosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ContratoId { get; set; }

        public int ServicioId { get; set; }

        public decimal Cantidad { get; set; }

    
        public decimal Precio { get; set; }

    

        public ContratosDetalle( int id, int contratoId, int servicioId, decimal cantidad, decimal precio)
        {
            Id = id;
            ContratoId = contratoId;
            ServicioId = servicioId;
            Cantidad = cantidad;
            Precio = precio;

        }

        public ContratosDetalle() { }
    }
}