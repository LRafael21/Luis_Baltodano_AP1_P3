using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Luis_Baltodano_AP1_P3.Entidades
{
    public partial class Contratos
    {

        [Key]
        public int ContratoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar la fecha de nacimiento")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        public string ClienteId { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar el comentario")]
        [MinLength(2, ErrorMessage = "El comentario debe tener al menos {0} caractéres")]
        [MaxLength(1000, ErrorMessage = "El comentario no debe pasar de {0} caracterés")]

        public string Comentarios { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar el Monto ")]
       
        public float Monto { get; set; }


        [ForeignKey("ContratoId")]
        public virtual List<ContratosDetalle> ContratosDetalle { get; set; } = new List<ContratosDetalle>();

    }
}