using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebAPIForteT.Models;

namespace WebAPIForteT.Models
{
    public class TipoPermiso
    {
        
        public int TipoPermisoId { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public virtual List<Permiso> Permisos { get; set; }
    }
}
