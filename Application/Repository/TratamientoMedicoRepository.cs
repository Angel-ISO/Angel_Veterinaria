using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class TratamientoMedicoRepository :GenericRepository<TratamientosMedico>,ITratamientosMedico
    {
        private readonly E1AppContext _Context;

    public TratamientoMedicoRepository (E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<TratamientosMedico>> GetAllAsync()
    {
        return await _Context.Set<TratamientosMedico>()
                                .Include(p => p.Cita)
                                .Include(p => p.Medicamento)
                                .ToListAsync();
    }
    
}