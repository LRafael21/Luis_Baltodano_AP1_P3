using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Luis_Baltodano_AP1_P3.Entidades
{
    public partial class Clientes
    {

        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Es obligatorio indicar el nombre")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos {1} caractéres.")]
        [MaxLength(50, ErrorMessage = "El nombre no debe pasar de {1} caractéres.")]

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Caracteres invalidos para el Nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar el apellido")]
        [MinLength(3, ErrorMessage = "El apellido debe tener al menos {1} caractéres.")]
        [MaxLength(50, ErrorMessage = "El apellido no debe pasar de {1} caracterés")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Caracteres invalidos para el Apellido.")]


        public string Apellido { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar la direccion")]
        [MinLength(2, ErrorMessage = "La direccion debe tener al menos {1} caractéres")]
        [MaxLength(100, ErrorMessage = "La direccion no debe pasar de {1} caracterés")]



        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar el Numero de Cedula")]

        [MinLength(1, ErrorMessage = "El Numero de Cedula debe estar dentro del rango de 1-14 numeros ")]
        [MaxLength(14, ErrorMessage = "El Numero de Cedula se sale de los rangos establecidos (1-14)")]
        [RegularExpression(@"^\d{3}[- ]?\d{7}[- ]?\d{1}$", ErrorMessage = "Cedula invalida - el formato debe ser: 000-0000000-0")]
        public string NumeroCedula { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar el Numero de Telefono")]
        [MinLength(1, ErrorMessage = "El Numero de Telefono debe estar dentro del rango de 1-14 numeros ")]
        [MaxLength(14, ErrorMessage = "El Numero de Telefono se sale de los rangos establecidos (1-14)")]

        [RegularExpression(@"^\d{3}[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Telefono Invalido")]
        public string NumeroTelefono { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar la fecha de nacimiento")]

        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
    }
}