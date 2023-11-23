using Domain.Entities;
using Domain.Views;

namespace Domain.Interfaces
{
    public interface IProducto : IGeneric<Producto>
    {
        Task<IEnumerable<ProductosMasVendidos>> GetProductosMasVendidos();
        Task<IEnumerable<ProductosVentasMas3000>> GetProductosVentasMas3000();
        Task<Producto> GetProductoPrecioVentaMasCaro();
        Task<IEnumerable<Producto>> GetProductosGamaSinPedido();
    }
}