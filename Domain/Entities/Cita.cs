
namespace Domain.Entities;

    public class Cita : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Motivo { get; set; }
        
        public int IdVeterinario { get; set; }
        public Veterinario Veterinario{ get; set; }
        public int IdMascota { get; set; }
        public Mascota Mascota{ get; set; }


        public ICollection<TratamientosMedico> TratamientosMedicos { get; set; } 
    }
