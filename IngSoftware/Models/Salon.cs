using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class Salon
    {
        [Key]
        public int ID_Salon { get; set; }

        [Display(Name = "Nombre del Salon")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public int Capacidad { get; set; }

        public int ID_Edificio { get; set; }
        public virtual Edificio Edificio { get; set; }

        public virtual ICollection<Equipo> Equipo { get; set; }

        public virtual ICollection<Fecha_Apartado> Fecha_Apartado { get; set; }
    }
}