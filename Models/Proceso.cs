using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcMovie.Models
{
    public class Proceso
    {
        public int Id { get; set; }

        [Required]
        public int Id_Campana {get; set;}


        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }

        [StringLength(500, MinimumLength = 3)]
        public string? Url { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Required]
        public string? Comentarios { get; set; }
        
        [Required]
        public int? Estatus { get; set; }
    }
}