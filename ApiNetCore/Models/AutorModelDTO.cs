using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiNetCore.Models {
    public class AutorModelDTO {
        [Required]
        public string Nombre { get; set; }
    }
}