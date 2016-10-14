using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class Materia
    {
        [key]
        public int ID_Materia { get; set; }

        public string Nombre { get; set; }

        public string Semestre { get; set; }

        public virtual Profesor Profesor { get; set; }

        public virtual ICollection<Estudiante> Estudiante { get; set; }
    }
}