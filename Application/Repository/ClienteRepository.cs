using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly JardineriaContext _context;
    public ClienteRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes
                            .FirstOrDefaultAsync(p => p.CodigoCliente == id);
    }

    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.ToListAsync();
    }
}