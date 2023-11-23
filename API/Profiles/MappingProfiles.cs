using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Views;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<DetallePedido, DetallePedidoDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<GamaProducto, GamaProductoDto>().ReverseMap();
            CreateMap<Oficina, OficinaDto>().ReverseMap();
            CreateMap<Pago, PagoDto>().ReverseMap();
            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();

            //Consultas
            CreateMap<PedidosNoEntregadosATiempo, PedidosNoEntregadosATiempoDto>().ReverseMap();
            CreateMap<Cliente, ClientesxRepVentasDto>().ReverseMap();
            CreateMap<Oficina, CiudadOficinaDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoxCiudadOficinaDto>().ReverseMap();
            CreateMap<ProductosMasVendidos, ProductosMasVendidosDto>().ReverseMap();
            CreateMap<ProductosVentasMas3000, ProductosVentasMas3000Dto>().ReverseMap();
            CreateMap<ClientesxPedido, ClientesxPedidoDto>().ReverseMap();
            CreateMap<ClienteRepCiudadOficina, ClienteRepCiudadOficinaDto>().ReverseMap();
            CreateMap<Producto, ProductoConGamaDto>().ReverseMap();
        }
    }
}