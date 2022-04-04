using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Luis_Baltodano_AP1_P3.Entidades
{
    public partial class Clientes
    {

        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage ="Es obligatorio indicar el nombre")]
        [MinLength(2, ErrorMessage = "El nombre debe tener al menos {0} caractéres.")]
        [MaxLength(50, ErrorMessage = "El nombre no debe pasar de {0} caractéres.")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage ="Es obligatorio indicar el apellido")]
        [MinLength(2, ErrorMessage ="El apellido debe tener al menos {0} caractéres.")]
        [MaxLength(50, ErrorMessage ="El apellido no debe pasar de {0} caracterés")]
        public string Apellido { get; set; }

        [Required(ErrorMessage ="Es obligatorio indicar la direccion")]
        [MinLength(2, ErrorMessage ="La direccion debe tener al menos {0} caractéres")]
        [MaxLength(100,ErrorMessage ="La direccion no debe pasar de {0} caracterés")]

        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar el Numero de Cedula")]
        [MinLength(1, ErrorMessage = "El Numero de Cedula debe estar dentro del rango de 1-11 numeros ")]
        [MaxLength(11, ErrorMessage = "El Numero de Cedula se sale de los rangos establecidos (1-10)")]
        public string NumeroCedula { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar el Numero de Telefono")]
        [MinLength(1, ErrorMessage = "El Numero de Telefono debe estar dentro del rango de 1-10 numeros ")]
         [MaxLength(11, ErrorMessage = "El Numero de Telefono se sale de los rangos establecidos (1-10)")]
        public string NumeroTelefono { get; set; }

        [Required(ErrorMessage ="Es obligatorio indicar la fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

    }
}