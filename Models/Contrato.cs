using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcMovie.Models
{
    public class Contrato
    {
        public int Id { get; set; }

        [Required]
        public int Id_Usuario {get; set;}


        [StringLength(15, MinimumLength = 3)]
        [Required]
        public string? NumeroContrato { get; set; }

       
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string? Comentarios { get; set; }
        [Required]
        public int Activo { get; set; }

    }
}