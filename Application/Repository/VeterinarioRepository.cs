using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class VeterinarioRepository :GenericRepository<Veterinario>,IVeterinario
    {
        private readonly E1AppContext _Context;

    public VeterinarioRepository (E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<Veterinario>> GetAllAsync()
    {
        return await _Context.Set<Veterinario>()
                                .Include(p => p.Citas)
                                .ToListAsync();
    }


    public async Task<IEnumerable<Veterinario>> GetVeterinarioCardioVascular(string especialidad)
{
    if (string.IsNullOrEmpty(especialidad))
    {
        throw new ArgumentException("Espefique la especialidad ");
    }

    var veterinarioC = await _Context.Veterinarios
        .Where(h => h.Especialidad.Equals("cardiobascular") && h.Especialidad.Equals(especialidad))
        .ToListAsync();

    return veterinarioC;
}



    /* public async Task<IEnumerable<Veterinario>> GetVeterinarioCardioVascular() =>
                    await _Context.Veterinarios
                    .Where(h => h.Especialidad.Equals("cardiobascular")).ToListAsync();
     */
}