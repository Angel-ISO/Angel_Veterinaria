using Domain.Entities;

namespace Domain.Interfaces;

public interface IVeterinario : IGenericRepository<Veterinario>
{
    Task<IEnumerable<Veterinario>> GetVeterinarioCardioVascular(string especialidad);
}