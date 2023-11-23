using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOficina : IGeneric<Oficina>
    {
        Task<IEnumerable<Oficina>> GetOficinasNoTrabajanRepresentantes();
    }
}