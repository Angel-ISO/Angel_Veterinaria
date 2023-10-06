using Domain.Entities;

namespace Domain.Interfaces;

public interface IMedicamento : IGenericRepository<Medicamento>
{
      public  Task<IEnumerable<Medicamento>>  GetMediciaLaboratory();  
     public  Task<IEnumerable<Medicamento>> GetMedicinaCara(int valor);  
}