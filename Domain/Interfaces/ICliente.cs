using Domain.Entities;
using Domain.Views;

namespace Domain.Interfaces
{
    public interface ICliente : IGeneric<Cliente>
    {
        Task<IEnumerable<Cliente>> GetClienteRepresentanteVentaNoPagoOficina();
        Task<IEnumerable<ClientesxPedido>> GetClientesxPedido();
        Task<IEnumerable<ClienteRepCiudadOficina>> GetClienteRepCiudadOficinas();
    }
}