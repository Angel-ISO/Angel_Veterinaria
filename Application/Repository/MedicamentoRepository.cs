using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class MedicamentoRepository :GenericRepository<Medicamento>,IMedicamento
    {
        private readonly E1AppContext _Context;

    public MedicamentoRepository (E1AppContext context) : base(context)
    {
        _Context = context;
    }


     public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _Context.Set<Medicamento>()
                                .Include(p => p.Laboratorio)
                                .Include(p => p.Proveedores)
                                .Include(p => p.MedicamentoProveedores)
                                .Include(p => p.MovimientoMedicamentos)
                                .Include(p => p.DetalleMovimientos)
                                .Include(p => p.MovimientoMedicamentos)
                                .Include(p => p.TratamientosMedicos)
                                .ToListAsync();
    }


    public async Task<IEnumerable<Medicamento>> GetMediciaLaboratory()
    {
        string labname = "genfar";
    
        var labgenfar = await _Context.Medicamentos
            .Where(Laboratorio => Laboratorio.Nombre == labname)
            .ToListAsync();
    
        return labgenfar;
    }
    public async Task<IEnumerable<Medicamento>> GetMedicinaCara(int valor) =>
                    await _Context.Medicamentos
                        .OrderBy(p => p.Precio >= 5000 )
                        .Take(valor)
                        .ToListAsync();

     




    
}