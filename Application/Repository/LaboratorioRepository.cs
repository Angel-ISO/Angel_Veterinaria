

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class LaboratorioRepository:GenericRepository<Laboratorio>,ILaboratorio
    {
        private readonly E1AppContext _Context;

    public LaboratorioRepository(E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<Laboratorio>> GetAllAsync()
    {
        return await _Context.Set<Laboratorio>()
                                .Include(p => p.Medicamentos)
                                .ToListAsync();
    }
    
}