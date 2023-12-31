namespace Domain.Entities;

    public class Mascota : BaseEntity
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }


        public int  IdPropietario  { get; set; }
        public Propietario Propietario{ get; set; }
        public int IdEspecie { get; set; }
        public Especie Especie { get; set; }
        public int IdRaza { get; set; }
        public Raza Raza{ get; set; }



        public ICollection<Cita> Citas { get; set; } 
    }
