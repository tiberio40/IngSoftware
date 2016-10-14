using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class Administracion
    {
        [Key]
        public int ID_Administracion { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Display(Name = "Numero Teléfono")]
        [StringLength(11, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string NumeroTelefonico { get; set; }

        public string Email { get; set; }

        public string Cargo { get; set; }

        public string Privilegio { get; set; }

        public virtual ICollection<Peticion> Peticion { get; set; }

        public virtual ICollection<Facultad> Facultad { get; set; }
    }
}