using Domain.Entities;
using Domain.Interfaces;
using Domain.Views;
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

    public async Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidos()
    {
        return await _context.Productos
                                    .Select(p => new ProductosMasVendidos
                                    {
                                        Nombre = p.Nombre,
                                        Cantidad = p.DetallePedidos.Sum(p => p.Cantidad)
                                    })
                                    .OrderByDescending(p => p.Cantidad)
                                    .Take(20)
                                    .ToListAsync();
    }

    public async Task<IEnumerable<ProductosVentasMas3000>> GetProductosVentasMas3000()
    {
        return await _context.DetallePedidos
                                    .Where(p => p.PrecioUnidad * p.Cantidad > 3000)
                                    .Select(p => new ProductosVentasMas3000
                                    {
                                        Nombre = p.CodigoProductoNavigation.Nombre,
                                        UnidadesVendidas = p.Cantidad,
                                        TotalFacturado = p.Cantidad * p.PrecioUnidad,
                                        TotalFacturadoImpuestos = p.Cantidad * p.PrecioUnidad * 1.21m
                                    })
                                    .ToListAsync();

    }
    public async Task<Producto> GetProductoPrecioVentaMasCaro()
    {
        return await _context.Productos
                                    .OrderByDescending(p => p.PrecioVenta)
                                    .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<Producto>> GetProductosGamaSinPedido()
    {
        return await _context.Productos
                                    .Include(p => p.GamaNavigation)
                                    .Where(p => !p.DetallePedidos.Any())
                                    .Select(p => new Producto
                                    {
                                        Nombre = p.Nombre,
                                        GamaNavigation = new GamaProducto
                                        {
                                            Gama = p.GamaNavigation.Gama,
                                            DescripcionHtml = p.GamaNavigation.DescripcionHtml,
                                            DescripcionTexto = p.GamaNavigation.DescripcionTexto,
                                            Imagen = p.GamaNavigation.Imagen
                                        }
                                    })
                                    .ToListAsync();
    }
}