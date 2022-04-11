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

        public Planes Plan { get; set; } = new Planes();

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




     


    }


}