namespace Domain.Entities;

    public class Proveedor : BaseEntity
    {
        public string Nombre { get; set; }
        public string Dirrecion { get; set; }
        public string Telefono { get; set; }


         public ICollection<Medicamento> Medicamentos { get; set; } = new HashSet<Medicamento>();
     public ICollection<MedicamentoProveedor> MedicamentoProveedores { get; set; } = new HashSet<MedicamentoProveedor>();
    }
