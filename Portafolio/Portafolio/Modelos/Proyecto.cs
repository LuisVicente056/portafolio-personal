using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portafolio.Modelos
{
    [Table("tblProyecto")]
    public class Proyecto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "100 cars. max.")]
        public string Titulo { get; set; }

        [StringLength(500, ErrorMessage = "500 cars. max.")]
        public string Descripcion { get; set; }

        [StringLength(100, ErrorMessage = "100 cars. max.")]
        public string Tecnologias { get; set; }  // ej: "Blazor, EF Core, SQL Server"

        [StringLength(200, ErrorMessage = "200 cars. max.")]
        public string UrlRepositorio { get; set; }  // link a GitHub

        [StringLength(200, ErrorMessage = "200 cars. max.")]
        public string UrlDemo { get; set; }         // link si está en la nube

        public DateTime FechaCreacion { get; set; }

        [StringLength(50, ErrorMessage = "50 cars. max.")]
        public string Categoria { get; set; }  // ej: "Web", "Base de Datos", "API"

        public bool Destacado { get; set; }
        public bool Inactivo { get; set; }
    }
}