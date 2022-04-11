using System.ComponentModel.DataAnnotations;

namespace Luis_Baltodano_AP1_P3.Entidades
{
    public partial class ContratosDetalle
    {
        [Key]
        public int Id { get; set; }



        public float Cantidad { get; set; }


        public float Importe { get; set; }

        public float MontoTotal { get; set; }

        public virtual Servicios servicios { get; set; }
  


      

        public ContratosDetalle( )
        {
    
        }

      

    }
}