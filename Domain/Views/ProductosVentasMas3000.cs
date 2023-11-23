using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Views
{
    public class ProductosVentasMas3000
    {
        public string? Nombre { get; set; }
        public int UnidadesVendidas { get; set; }
        public decimal TotalFacturado { get; set; }
        public decimal TotalFacturadoImpuestos { get; set; }
    }
}