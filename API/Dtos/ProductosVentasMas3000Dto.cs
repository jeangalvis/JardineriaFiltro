using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductosVentasMas3000Dto
    {
        public string Nombre { get; set; }
        public int UnidadesVendidas { get; set; }
        public decimal TotalFacturado { get; set; }
        public decimal TotalFacturadoImpuestos { get; set; }
    }
}