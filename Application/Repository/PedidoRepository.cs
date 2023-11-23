using Domain.Entities;
using Domain.Interfaces;
using Domain.Views;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class PedidoRepository : GenericRepository<Pedido>, IPedido
{
    private readonly JardineriaContext _context;
    public PedidoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Pedido> GetByIdAsync(int id)
    {
        return await _context.Pedidos
                            .FirstOrDefaultAsync(p => p.CodigoPedido == id);
    }

    public override async Task<IEnumerable<Pedido>> GetAllAsync()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task<IEnumerable<PedidosNoEntregadosATiempo>> GetNoEntregadosATiempo()
    {
        return await _context.Pedidos
                                    .Where(p => p.FechaEsperada < p.FechaEntrega)
                                    .Select(p => new PedidosNoEntregadosATiempo
                                    {
                                        CodigoPedido = p.CodigoPedido,
                                        CodigoCliente = p.CodigoCliente,
                                        FechaEsperada = p.FechaEsperada,
                                        FechaEntrega = p.FechaEntrega
                                    })
                                    .ToListAsync();
    }
}