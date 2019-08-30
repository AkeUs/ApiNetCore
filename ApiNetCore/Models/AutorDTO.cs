using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApiNetCore.Helpers;

namespace ApiNetCore.Models
{
    public class AutorDTO {
        public int Id { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        public List<LibroDTO> Libros { get; set; }
        
    }
}