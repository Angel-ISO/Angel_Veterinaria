using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class RazaRepository :GenericRepository<Raza>,IRaza
    {
        private readonly E1AppContext _Context;

    public RazaRepository (E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<Raza>> GetAllAsync()
    {
        return await _Context.Set<Raza>()
                                .Include(p => p.Mascotas)
                                .Include(p => p.Especie)
                                .ToListAsync();
    }
    
}