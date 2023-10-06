namespace Domain.Entities;

    public class TipoMovimiento : BaseEntity
    {
        public string Description { get; set; }
       public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; } 
    }
