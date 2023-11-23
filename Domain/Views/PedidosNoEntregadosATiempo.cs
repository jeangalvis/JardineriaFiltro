using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Views
{
    public class PedidosNoEntregadosATiempo
    {
        public int CodigoPedido { get; set; }
        public int CodigoCliente { get; set; }
        public DateOnly FechaEsperada { get; set; }
        public DateOnly? FechaEntrega { get; set; }
    }
}