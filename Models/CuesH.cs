using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcMovie.Models
{
    public class CuesH
    {
        public int Id { get; set; }

        [Required]
        public int Id_Usuario {get; set;}


        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Descripcion { get; set; }
         
        [Required]
        public int? Estatus { get; set; }
    }
}