using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly JardineriaContext _context;
    public EmpleadoRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Empleado> GetByIdAsync(int id)
    {
        return await _context.Empleados
                            .FirstOrDefaultAsync(p => p.CodigoEmpleado == id);
    }

    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _context.Empleados.ToListAsync();
    }
    public async Task<IEnumerable<Empleado>> GetEmpleadosSinClienteSinJefe()
    {
        return await _context.Empleados
                                    .Include(e => e.Clientes)
                                    .Include(e => e.CodigoOficinaNavigation)
                                    .Where(e => !e.Clientes.Any() && e.CodigoJefe == null)
                                    .ToListAsync();
    }
}