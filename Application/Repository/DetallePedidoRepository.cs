using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class DetallePedidoRepository : GenericRepository<DetallePedido>, IDetallePedido
{
    private readonly JardineriaContext _context;
    public DetallePedidoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<DetallePedido> GetByIdAsync(int id)
    {
        return await _context.DetallePedidos
                            .FirstOrDefaultAsync(p => p.CodigoPedido == id);
    }

    public override async Task<IEnumerable<DetallePedido>> GetAllAsync()
    {
        return await _context.DetallePedidos.ToListAsync();
    }

}