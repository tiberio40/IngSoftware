using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class Equipo
    {
        [Key]
        public int ID_Equipo { get; set; }

        [Display(Name = "Nombre del Equipo ")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Tipo_Equipo { get; set; }

        public virtual ICollection<Inventario> Inventario { get; set; }

    }
}