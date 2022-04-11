using System.ComponentModel.DataAnnotations;

namespace Luis_Baltodano_AP1_P3.Entidades
{
    public partial class ContratosDetalle
    {
        [Key]
        public int Id { get; set; }

        public int ContratoId { get; set; }


        public int ServicioId { get; set; }



        public float Cantidad { get; set; }


        public float Importe { get; set; }

        public float MontoTotal { get; set; }

        public virtual Servicios servicios { get; set; }


      

        public ContratosDetalle( int servicioId, string plan, float cantidad, float precio, float importe)
        {
            ServicioId = servicioId;

            Cantidad = cantidad;

            Importe = importe;

        }

        public ContratosDetalle()
        {
            ServicioId = 0;

            Cantidad = 0;

            Importe = 0;

        }

    }
}