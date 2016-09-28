using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IngSoftware.Models
{
    public class IngSoftwareContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public IngSoftwareContext() : base("name=IngSoftwareContext")
        {
        }

        public System.Data.Entity.DbSet<IngSoftware.Models.Profesor> Profesors { get; set; }

        public System.Data.Entity.DbSet<IngSoftware.Models.Edificio> Edificios { get; set; }

        public System.Data.Entity.DbSet<IngSoftware.Models.Salon> Salons { get; set; }

        public System.Data.Entity.DbSet<IngSoftware.Models.Equipo> Equipoes { get; set; }

        public System.Data.Entity.DbSet<IngSoftware.Models.Fecha_Apartado> Fecha_Apartado { get; set; }
    }
}
