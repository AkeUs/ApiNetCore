using System.ComponentModel.DataAnnotations;

namespace ApiNetCore.Models
{
    public class LibroDTO {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public int AutorId { get; set; }
        public AutorDTO Autor { get; set; }
    }
}