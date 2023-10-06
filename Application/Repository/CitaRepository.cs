

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class CitaRepository:GenericRepository<Cita>,ICita
    {
        private readonly E1AppContext _Context;

    public CitaRepository(E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _Context.Set<Cita>()
                                .Include(p => p.Veterinario)
                                .Include(p => p.Mascota)
                                .Include(p => p.TratamientosMedicos)
                                .ToListAsync();
    }
    
}