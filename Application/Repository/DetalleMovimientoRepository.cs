

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class DetalleMovimientoRepository:GenericRepository<DetalleMovimiento>,IDetalleMovimiento
    {
        private readonly E1AppContext _Context;

    public DetalleMovimientoRepository(E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<DetalleMovimiento>> GetAllAsync()
    {
        return await _Context.Set<DetalleMovimiento>()
                                .Include(p => p.TipoMovimiento)
                                .Include(p => p.Medicamento)
                                .Include(p => p.MovimientoMedicamento)
                                .ToListAsync();
    }
    
}