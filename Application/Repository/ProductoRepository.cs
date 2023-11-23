using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly JardineriaContext _context;
    public ProductoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Producto> GetByIdAsync(string id)
    {
        return await _context.Productos
                            .FirstOrDefaultAsync(p => p.CodigoProducto == id);
    }

    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos.ToListAsync();
    }
}