using System.ComponentModel.DataAnnotations;

namespace Luis_Baltodano_AP1_P3.Entidades
{
    public partial class ContratosDetalle
    {
        [Key]

        public int ServicioId { get; set; }

        public string Plan { get; set; }

        public float Cantidad { get; set; }

        public float Precio { get; set; }
        public float Importe { get; set; }

        public virtual Servicios servicios { get; set; }


      
    

        public ContratosDetalle( int servicioId, string plan, float cantidad, float precio, float importe)
        {
            ServicioId = servicioId;
            Plan = plan;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;

        }

        public ContratosDetalle()
        {
            ServicioId = 0;
            Plan = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;

        }

    }
}