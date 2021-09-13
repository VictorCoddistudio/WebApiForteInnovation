using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIForteT.Models
{
    public class Permiso
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string NombreEmpleado { get; set; }
        
        [Required]
        public string ApellidosEmpleado { get; set; }
        

        
        public int TipoPermisoId { get; set; }
        public virtual string idString => TipoPermisoId.ToString();
        public virtual TipoPermiso TipoPermiso { get; set; }

        public DateTime FechaPermiso { get; set; }

    }
}
