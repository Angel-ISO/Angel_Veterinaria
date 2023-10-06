namespace Domain.Entities;

    public class Medicamento : BaseEntity
    {
        public string  Nombre { get; set; }
        public int CantidadDisponible { get; set; }
        public int Precio { get; set; }
        public int IdLaboratio { get; set; }
        public Laboratorio Laboratorio { get; set;}





    public ICollection<Proveedor> Proveedores { get; set; } = new HashSet<Proveedor>();
        
    public ICollection<MedicamentoProveedor> MedicamentoProveedores { get; set; } 
    public ICollection<MovimientoMedicamento> MovimientoMedicamentos { get; set; } 
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; } 
    public ICollection<TratamientosMedico> TratamientosMedicos { get; set; } 
    }
