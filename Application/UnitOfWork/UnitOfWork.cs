using Aplicacion.Repository;
using Application.Repository;
using Domain.Interfaces;
using Persistence;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly E1AppContext _context;
    private IRol _rols;
    private IUser _users;

    private ICita _citas;
    private IDetalleMovimiento _detalleMovimientos;
    private IEspecie _especies;
    private ILaboratorio _laboratorios;
    private IMascota _mascotas;
    private IMedicamento _medicamentos;
    private IMovimientoMedicamento _movimientoMedicamentos;
    private IProoveedor _prooveedores;
    private IPropietario _propietarios;
    private IRaza _razas;
    private ITipoMovimiento _tipoMovimientos;     
    private ITratamientosMedico _tratamientosmedicos;
    private IVeterinario _veterinarios;




    
    public UnitOfWork(E1AppContext context)
    {
        _context = context;
    }

    public IUser Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }


   public IRol Rols
    {
        get
        {
            _rols ??= new RolRepository(_context);
            return _rols;
        }
    }



     public ICita Citas
    {
        get
        {
            _citas ??= new CitaRepository(_context);
            return _citas;
        }
    }


public IDetalleMovimiento DetalleMovimientos
    {
        get
        {
            _detalleMovimientos ??= new DetalleMovimientoRepository(_context);
            return _detalleMovimientos;
        }
    }


public IEspecie Especies
    {
        get
        {
            _especies ??= new EspecieRepository(_context);
            return _especies;
        }
    }


    public ILaboratorio Laboratorios
    {
        get
        {
            _laboratorios ??= new LaboratorioRepository(_context);
            return _laboratorios;
        }
    }


     public IMascota Mascotas
    {
        get
        {
            _mascotas ??= new MascotaRepository(_context);
            return _mascotas;
        }
    }


      public IMedicamento Medicamentos
    {
        get
        {
            _medicamentos ??= new MedicamentoRepository(_context);
            return _medicamentos;
        }
    }


 public IMovimientoMedicamento MovimientoMedicamentos
    {
        get
        {
            _movimientoMedicamentos ??= new MovimientoMedicamentoRepository(_context);
            return _movimientoMedicamentos;
        }
    }


    public IPropietario Propietarios
    {
        get
        {
            _propietarios ??= new PropietarioRepository(_context);
            return _propietarios;
        }
    }



public IProoveedor Prooveedores
    {
        get
        {
            _prooveedores ??= new ProveedorRepository(_context);
            return _prooveedores;
        }
    }


    public IRaza Razas
    {
        get
        {
            _razas ??= new RazaRepository(_context);
            return _razas;
        }
    }


    public ITipoMovimiento TipoMovimientos
    {
        get
        {
            _tipoMovimientos ??= new TipoMovimientoRepository(_context);
            return _tipoMovimientos;
        }
    }


       public ITratamientosMedico TratamientosMedicos
    {
        get
        {
            _tratamientosmedicos ??= new TratamientoMedicoRepository(_context);
            return _tratamientosmedicos;
        }
    }




       public IVeterinario Veterinarios
    {
        get
        {
            _veterinarios ??= new VeterinarioRepository(_context);
            return _veterinarios;
        }
    }





    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}