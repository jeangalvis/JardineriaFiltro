using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class OficinaRepository : GenericRepository<Oficina>, IOficina
{
    private readonly JardineriaContext _context;
    public OficinaRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Oficina> GetByIdAsync(string id)
    {
        return await _context.Oficinas
                            .FirstOrDefaultAsync(p => p.CodigoOficina == id);
    }

    public override async Task<IEnumerable<Oficina>> GetAllAsync()
    {
        return await _context.Oficinas.ToListAsync();
    }
    public async Task<IEnumerable<Oficina>> GetOficinasNoTrabajanRepresentantes()
    {
        return await _context.Oficinas
                            .Where(o => !o.Empleados
                            .Any(e => e.Clientes
                            .Any(c => c.Pedidos
                            .Any(p => p.DetallePedidos
                            .Any(dp => dp.CodigoProductoNavigation.GamaNavigation.Gama == "Frutales")))))
                            .ToListAsync();
    }
}