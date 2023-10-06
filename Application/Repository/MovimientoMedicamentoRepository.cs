using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class MovimientoMedicamentoRepository :GenericRepository<MovimientoMedicamento>,IMovimientoMedicamento
    {
        private readonly E1AppContext _Context;

    public MovimientoMedicamentoRepository (E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<MovimientoMedicamento>> GetAllAsync()
    {
        return await _Context.Set<MovimientoMedicamento>()
                                .Include(p => p.Medicamento)
                                .Include(p => p.DetalleMovimientos)
                                .ToListAsync();
    }
    
}