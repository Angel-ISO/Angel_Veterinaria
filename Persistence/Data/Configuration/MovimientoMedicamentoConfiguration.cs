using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
{
    public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
    {
        builder.ToTable("MovimientoMedicamento");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_MovimientoMed")
        .HasColumnType("int")
        .IsRequired();



       builder.Property(p => p.Cantidad)
                 .IsRequired()
                 .HasColumnName("cantidad");


        builder.Property(p => p.Fecha)
                 .IsRequired()
                 .HasColumnName("fecha");



        builder.HasOne(p => p.Medicamento)
                 .WithMany(c => c.MovimientoMedicamentos)
                 .HasForeignKey(p => p.IdMedicamento)
                 .OnDelete(DeleteBehavior.Cascade);

       




           builder.HasData(
              new MovimientoMedicamento
              {
                 Id = 1,
                 Cantidad=2,
                 Fecha= new DateTime(2022, 1, 10),
                 IdMedicamento=1
              }, new MovimientoMedicamento
              {
                 Id = 2,
                 Cantidad=4,
                 Fecha= new DateTime(2022, 9, 10),
                 IdMedicamento=2
              }, new MovimientoMedicamento
              {
                 Id = 3,
                 Cantidad=5,
                 Fecha= new DateTime(2021, 6, 10),
                 IdMedicamento=3
              },
              new MovimientoMedicamento
              {
                 Id = 4,
                 Cantidad=6,
                 Fecha= new DateTime(2011, 5, 30),
                 IdMedicamento=3
              }
              
          ); 



    }
}