namespace Domain.Entities;

    public class DetalleMovimiento : BaseEntity
    {
        public int Cantidad { get; set; }
        public int Precio { get; set; }

        public int IdTipoMovimiento { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }

        public int IdMedicamento { get; set; }
        public Medicamento Medicamento{ get; set; }
 
        public int IdMovimientoMed  { get; set; }
        public MovimientoMedicamento  MovimientoMedicamento{ get; set;}
    }
