namespace Domain.Entities;

    public class Raza : BaseEntity
    {
        public string Name { get; set; }
        public int IdEspecie { get; set; }
        public Especie Especie { get; set; }

        public ICollection<Mascota> Mascotas { get; set; } 
    }
