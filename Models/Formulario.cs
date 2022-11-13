using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcMovie.Models
{
    public class Formulario
    {
        public int Id { get; set; }

        [Required]
        public int Id_Campana {get; set;}

       [StringLength(100, MinimumLength = 3)]
        public string? Nombre { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string? CorreoElectronico { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string? Descripcion { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }

        [StringLength(500, MinimumLength = 3)]
        public string? Pregunta { get; set; }

        [StringLength(500, MinimumLength = 3)]
        public string? Respuesta { get; set; }   

        [StringLength(200, MinimumLength = 3)]
        public string? Comentarios { get; set; }

        public int? Empleado {get; set;}

  
    }
}