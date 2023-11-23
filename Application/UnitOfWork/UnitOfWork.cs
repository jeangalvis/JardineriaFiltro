using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly JardineriaContext context;
        private ICliente _cliente;
        private IDetallePedido _detallePedido;
        private IEmpleado _empleado;
        private IGamaProducto _gamaProducto;
        private IOficina _oficina;
        private IPago _pago;
        private IPedido _pedido;
        private IProducto _producto;
        public UnitOfWork(JardineriaContext _context)
        {
            context = _context;
        }

        public ICliente Clientes {
            get{
                if(_cliente == null){
                    _cliente = new ClienteRepository(context);
                }
                return _cliente;
            }
        }

        public IDetallePedido DetallePedidos {
            get{
                if(_detallePedido == null){
                    _detallePedido = new DetallePedidoRepository(context);
                }
                return _detallePedido;
            }
        }

        public IEmpleado Empleados {
            get{
                if(_empleado == null){
                    _empleado = new EmpleadoRepository(context);
                }
                return _empleado;
            }
        }

        public IGamaProducto GamaProductos {
            get{
                if(_gamaProducto == null){
                    _gamaProducto = new GamaProductoRepository(context);
                }
                return _gamaProducto;
            }
        }
        
        public IOficina Oficinas {
            get{
                if(_oficina == null){
                    _oficina = new OficinaRepository(context);
                }
                return _oficina;
            }
        }

        public IPago Pagos {
            get{
                if(_pago == null){
                    _pago = new PagoRepository(context);
                }
                return _pago;
            }
        }

        public IPedido Pedidos {
            get{
                if(_pedido == null){
                    _pedido = new PedidoRepository(context);
                }
                return _pedido;
            }
        }
        
        public IProducto Productos {
            get{
                if(_producto == null){
                    _producto = new ProductoRepository(context);
                }
                return _producto;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}