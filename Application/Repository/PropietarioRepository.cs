using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class PropietarioRepository :GenericRepository<Propietario>,IPropietario
    {
        private readonly E1AppContext _Context;

    public PropietarioRepository (E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<Propietario>> GetAllAsync()
    {
        return await _Context.Set<Propietario>()
                                .Include(p => p.Mascotas)
                                .ToListAsync();
    }
    
}