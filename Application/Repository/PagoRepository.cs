using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class PagoRepository : GenericRepository<Pago>, IPago
{
    private readonly JardineriaContext _context;
    public PagoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Pago> GetByIdAsync(int id)
    {
        return await _context.Pagos
                            .FirstOrDefaultAsync(p => p.CodigoCliente == id);
    }

    public override async Task<IEnumerable<Pago>> GetAllAsync()
    {
        return await _context.Pagos.ToListAsync();
    }
}