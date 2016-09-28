using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class Profesor
    {
        [Key]
        public int ID_Profesor { get; set; }

        [Display(Name = "Nombre del Profesor")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos del Profesor")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Display(Name = "Numero Teléfono")]
        [StringLength(11, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string NumeroTelefonico { get; set; }

        public virtual ICollection<Fecha_Apartado> Fecha_Apartado { get; set; }
    }
}