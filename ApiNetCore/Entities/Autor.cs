using ApiNetCore.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiNetCore.Entities {
    public class Autor {
        public int Id { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; }
    }
}
