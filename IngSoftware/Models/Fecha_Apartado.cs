using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class Fecha_Apartado
    {
        [Key]
        public int ID_Fecha_Apartado { get; set; }

        [Display(Name = "Dia de Registro")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Dia { get; set; }

        [Display(Name = "Hora de Registro")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }

        [Display(Name = "Hora de Finalizacion")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime HoraFinalizada { get; set; }

        [Display(Name = "Nombre del Salon")]
        public int ID_Salon { get; set; }

        public virtual Salon Salon { get; set; }

        [Display(Name = "Nombre del Profesor")]
        public int ID_Profesor { get; set; }

        public virtual Profesor Profesor { get; set; }
    }
}