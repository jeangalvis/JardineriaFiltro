using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class JardineriaContext : DbContext
    {
        public JardineriaContext(DbContextOptions<JardineriaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
            public DbSet<Cliente> Clientes { get; set; }

            public DbSet<DetallePedido> DetallePedidos { get; set; }

            public DbSet<Empleado> Empleados { get; set; }

            public DbSet<GamaProducto> GamaProductos { get; set; }

            public DbSet<Oficina> Oficinas { get; set; }

            public DbSet<Pago> Pagos { get; set; }

            public DbSet<Pedido> Pedidos { get; set; }

            public DbSet<Producto> Productos { get; set; }
    }
}