using Domain.Entities;
using Domain.Views;

namespace Domain.Interfaces
{
    public interface IPedido : IGeneric<Pedido>
    {
        Task<IEnumerable<PedidosNoEntregadosATiempo>> GetNoEntregadosATiempo();
    }
}