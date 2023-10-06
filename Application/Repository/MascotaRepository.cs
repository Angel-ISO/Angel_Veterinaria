using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class MascotaRepository :GenericRepository<Mascota>,IMascota
    {
        private readonly E1AppContext _Context;

    public MascotaRepository (E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<Mascota>> GetAllAsync()
    {
        return await _Context.Set<Mascota>()
                                .Include(p => p.Propietario)
                                .Include(p => p.Especie)
                                .Include(p => p.Raza)
                                .Include(p => p.Citas)
                                .ToListAsync();
    }
    
}