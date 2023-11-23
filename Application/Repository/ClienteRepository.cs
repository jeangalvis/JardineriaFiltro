using Domain.Entities;
using Domain.Interfaces;
using Domain.Views;
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

    public async Task<IEnumerable<Cliente>> GetClienteRepresentanteVentaNoPagoOficina()
    {
        return await _context.Clientes
                                    .Include(p => p.Pagos)
                                    .Include(p => p.CodigoEmpleadoRepVentasNavigation)
                                    .ThenInclude(p => p.CodigoOficinaNavigation)
                                    .Where(p => !p.Pagos.Any() && p.CodigoEmpleadoRepVentasNavigation.CodigoOficinaNavigation.CodigoOficina == p.CodigoEmpleadoRepVentasNavigation.CodigoOficina)
                                    .Select(p => new Cliente
                                    {
                                        NombreCliente = p.NombreCliente,
                                        CodigoEmpleadoRepVentasNavigation = new Empleado
                                        {
                                            Nombre = p.CodigoEmpleadoRepVentasNavigation.Nombre,
                                            Apellido1 = p.CodigoEmpleadoRepVentasNavigation.Apellido1,
                                            Apellido2 = p.CodigoEmpleadoRepVentasNavigation.Apellido2,
                                            CodigoOficinaNavigation = new Oficina
                                            {
                                                Ciudad = p.Ciudad
                                            }
                                        }
                                    })
                                    .ToListAsync();

    }
    public async Task<IEnumerable<ClientesxPedido>> GetClientesxPedido()
    {
        return await _context.Clientes
                                    .Select(p => new ClientesxPedido
                                    {
                                        Nombre = p.NombreCliente,
                                        CantidadPedidos = p.Pedidos.Sum(p => p.CodigoCliente)
                                    })
                                    .ToListAsync();
    }
    public async Task<IEnumerable<ClienteRepCiudadOficina>> GetClienteRepCiudadOficinas()
    {
        return await _context.Clientes
                                    .Select(p => new ClienteRepCiudadOficina
                                    {
                                        NombreCliente = p.NombreCliente,
                                        NombreEmpleado = p.CodigoEmpleadoRepVentasNavigation.Nombre,
                                        ApellidoEmpleado = p.CodigoEmpleadoRepVentasNavigation.Apellido1,
                                        CiudadOficina = p.CodigoEmpleadoRepVentasNavigation.CodigoOficinaNavigation.Ciudad
                                    })
                                    .ToListAsync();
    }
}