using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcMovie.Models
{
    public class Pregunta
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Preguntaa { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Respuesta { get; set; }

         
        [Required]
        public int? Estatus { get; set; }
    }
}