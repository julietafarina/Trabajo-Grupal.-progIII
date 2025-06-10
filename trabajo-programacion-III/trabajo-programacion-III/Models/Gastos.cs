using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabajo_programacion_III.Models
{
    public class Gastos
    { 
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a cero")]
        public decimal Monto { get; set; }
        [Required]
        [StringLength(250)]
        [MinLength(3)]
        public string Descripcion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        
        public DateTime Fecha { get; set; }
        [Required]
        [StringLength(250)]
        [MinLength(1)]
        public string NombreComercio { get; set; }

     
        


    }
}
