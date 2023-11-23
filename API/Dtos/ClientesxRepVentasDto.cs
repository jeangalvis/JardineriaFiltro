using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClientesxRepVentasDto
    {
        public string NombreCliente { get; set; } = null!;
        public virtual EmpleadoxCiudadOficinaDto CodigoEmpleadoRepVentasNavigation { get; set; }
    }
}