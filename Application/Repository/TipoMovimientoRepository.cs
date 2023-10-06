using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class TipoMovimientoRepository :GenericRepository<TipoMovimiento>,ITipoMovimiento
    {
        private readonly E1AppContext _Context;

    public TipoMovimientoRepository (E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<TipoMovimiento>> GetAllAsync()
    {
        return await _Context.Set<TipoMovimiento>()
                                .Include(p => p.DetalleMovimientos)
                                .ToListAsync();
    }
    
}