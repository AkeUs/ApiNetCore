using System.ComponentModel.DataAnnotations;
using ApiNetCore.Entities;

namespace ApiNetCore.Models
{
    public class LibroDTO {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}