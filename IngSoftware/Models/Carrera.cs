using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class Carrera
    {
        [Key]
        public int ID_Carrera { get; set; }

        public string Nombre { get; set; }

        public int ID_Facultad { get; set; }
        public virtual Facultad Facultad { get; set; }

        public virtual ICollection<Estudiante> Estudiante { get; set; }
    }
}