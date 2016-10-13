using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class DiaApartado
    {
        [Key]
        public int ID_DiaApartado { get; set; }

        public DateTime Fecha_Apartado { get; set; }

        public DateTime Hora_Comienzo { get; set; }

        public DateTime Hora_Terminado { get; set; }

        public int ID_Peticion { get; set; }
        public virtual Peticion Peticion { get; set; }
    }
}