using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class ProveedorRepository :GenericRepository<Proveedor>,IProoveedor
    {
        private readonly E1AppContext _Context;

    public ProveedorRepository (E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _Context.Set<Proveedor>()
                                .Include(p => p.Medicamentos)
                                .Include(p => p.MedicamentoProveedores)
                                .ToListAsync();
    }
    
}