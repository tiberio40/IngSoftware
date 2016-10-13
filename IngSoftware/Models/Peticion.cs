using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class Peticion
    {
        [Key]
        public int ID_Peticion { get; set; }

        public DateTime Fecha_Solicitud { get; set; }

        public string Tema { get; set; }

        public int Cantidad_Inscritos { get; set; }

        public string Estado { get; set; }

        public int ID_Salon { get; set; }
        public virtual Salon Salon { get; set; }

        public virtual ICollection<Respuesta> Respuesta { get; set; }

        public virtual ICollection<DiaApartado> DiaApartado { get; set; }

        public virtual ICollection<Estudiante> Estudiante { get; set; }

        public virtual ICollection<Profesor> Profesor { get; set; }

        public virtual ICollection<Administracion> Administracion { get; set; }
    }
}


