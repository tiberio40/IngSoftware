using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class Facultad
    {
        [Key]
        public int ID_Facultad { get; set; }

        public string Nombre { get; set; }

        public int ID_Profesor { get; set; }
        public virtual Profesor Profesor { get; set; }

        public virtual ICollection<Carrera> Carrera { get; set; }

        public virtual ICollection<Administracion> Administracion { get; set; }


    }
}