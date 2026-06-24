using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portafolio.Modelos
{
    [Table("tblCategoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "50 cars. max.")]
        public string Nombre { get; set; }

        [StringLength(200, ErrorMessage = "200 cars. max.")]
        public string Descripcion { get; set; }
    }
}