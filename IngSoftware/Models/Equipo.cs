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
        public string Nombre { get; set; }


        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public int Cantidad { get; set; }

        public int ID_Salon { get; set; }

        public virtual Salon Salon { get; set; }

    }
}