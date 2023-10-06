
namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IRol Rols {get;} 
    IUser Users {get;} 
    ICita Citas {get;} 
    IDetalleMovimiento DetalleMovimientos {get;} 
    IEspecie Especies {get;}
    ILaboratorio Laboratorios {get;}  
    IMascota Mascotas {get;} 
    IMedicamento Medicamentos {get;} 
    IMovimientoMedicamento MovimientoMedicamentos {get;} 
    IProoveedor Prooveedores {get;} 
    IPropietario Propietarios {get;} 
    IRaza Razas {get;} 
    ITipoMovimiento TipoMovimientos {get;} 
    ITratamientosMedico TratamientosMedicos {get;} 
    IVeterinario Veterinarios {get;} 

    Task<int> SaveAsync();
}