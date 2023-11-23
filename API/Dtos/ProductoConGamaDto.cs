using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductoConGamaDto
    {
        public string Nombre { get; set; } = null!;
        public virtual GamaProductoDto GamaNavigation { get; set; } = null!;

    }
}