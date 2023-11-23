using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoxCiudadOficinaDto
    {
        public string Nombre { get; set; } = null!;

        public string Apellido1 { get; set; } = null!;

        public string Apellido2 { get; set; }
        public virtual CiudadOficinaDto CodigoOficinaNavigation { get; set; } = null!;
    }
}