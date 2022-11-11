using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace MvcMovie.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Nombre { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Apellido { get; set; }

        //[RegularExpression(@"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/")]
        [Required]
        [StringLength(500)]
        public string? CorreoElectronico { get; set; }
        public string? NumeroContrato { get; set; }
         public string? NombreEmpresa { get; set; }
        public string? NumeroEmpleados { get; set; }
         public string? RFC { get; set; }
        public string? Domicilio { get; set; }
        public string? Colonia { get; set; }
        public string? Ciudad { get; set; }
        public string? Pais { get; set; }
        public string? Giro { get; set; }

        [Required]
        [StringLength(8)]
        public string? Password { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }

    }
}