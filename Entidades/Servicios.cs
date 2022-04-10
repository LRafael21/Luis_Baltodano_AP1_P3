using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Luis_Baltodano_AP1_P3.Entidades
{
    public partial class Servicios
    {

        [Key]
        public int ServicioId { get; set; }


        [Required(ErrorMessage = "Es obligatorio indicar el Plan")]
        [MinLength(2, ErrorMessage = "El Plan debe tener al menos {0} caractéres.")]
        [MaxLength(50, ErrorMessage = "El Plan no debe pasar de {0} caractéres.")]

        public string Plan { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar la Descripcion")]
        [MinLength(2, ErrorMessage = "La descripcion debe tener al menos {0} caractéres")]
        [MaxLength(100, ErrorMessage = "La descripcion no debe pasar de {0} caracterés")]

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Campo \"Precio\"esta vacio. Por favor indique un precio.")]
        [Range(1, float.MaxValue, ErrorMessage = "El precio debe estar dentro del rango permitido (Mayor que {1})")]
        public float Precio { get; set; }

        public float MontoFacturado { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio indicar la fecha de nacimiento")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

       

        [ForeignKey("ServicioId")]
        public virtual List<ContratosDetalle> ContratosDetalle { get; set; }


        public Servicios()
        {
            ServicioId = 0;
            Plan = string.Empty;
            Descripcion = string.Empty;
            Precio = 0;
            MontoFacturado = 0;
            FechaCreacion = DateTime.Now;
            ContratosDetalle = new List<ContratosDetalle>();
        }


    }


}