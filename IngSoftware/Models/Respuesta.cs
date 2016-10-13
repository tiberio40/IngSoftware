using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class Respuesta
    {
        [Key]
        public int ID_Respuesta { get; set; }

        public string Contenido { get; set; }

        public int ID_Peticion { get; set; }
        public virtual Peticion Peticion { get; set; }
    }
}