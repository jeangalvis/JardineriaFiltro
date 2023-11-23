using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class GamaProductoRepository : GenericRepository<GamaProducto>, IGamaProducto
{
    private readonly JardineriaContext _context;
    public GamaProductoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<GamaProducto> GetByIdAsync(string id)
    {
        return await _context.GamaProductos
                            .FirstOrDefaultAsync(p => p.Gama == id);
    }

    public override async Task<IEnumerable<GamaProducto>> GetAllAsync()
    {
        return await _context.GamaProductos.ToListAsync();
    }
}