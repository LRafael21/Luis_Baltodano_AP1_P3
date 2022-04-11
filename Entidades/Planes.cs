using System.ComponentModel.DataAnnotations;

namespace Luis_Baltodano_AP1_P3.Entidades
{
    public partial class Planes
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }

}