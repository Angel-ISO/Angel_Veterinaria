namespace Domain.Entities;

    public class MovimientoMedicamento : BaseEntity
    {
        public int Cantidad  { get; set; }
        public DateTime Fecha { get; set; }

        public int IdMedicamento { get; set; }
        public Medicamento Medicamento { get; set; }



        public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; } 
    }
