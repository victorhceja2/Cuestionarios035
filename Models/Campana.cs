using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcMovie.Models
{
    public class Campana
    {
        public int Id { get; set; }

        [Required]
        public int Id_Usuario {get; set;}
        public int Id_CuesH {get; set;}


        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Required]
        public string? Comentarios { get; set; }
    
        public int? Dias { get; set; }
        
        [Required]
        public int? Estatus { get; set; }
    }
}