using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiNetCore.Models {
    public class AutorNuevoDTO {
        [Required]
        public string Nombre { get; set; }
    }
}