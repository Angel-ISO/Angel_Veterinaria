using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class EspecieRepository:GenericRepository<Especie>,IEspecie
    {
        private readonly E1AppContext _Context;

    public EspecieRepository(E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<Especie>> GetAllAsync()
    {
        return await _Context.Set<Especie>()
                                .Include(p => p.Razas)
                                .Include(p => p.Mascotas)
                                .ToListAsync();
    }
    
}