namespace Domain.Entities;

    public class TratamientosMedico : BaseEntity
    {
        public string Dosis { get; set; }
        public DateTime FechaAdministracion { get; set; }
        public string Observacion { get; set; }
        
        public int IdCita { get; set; }
        public Cita Cita{ get; set; }
        public int IdMedicamento { get; set; }
        public Medicamento Medicamento{ get; set; }
    }
