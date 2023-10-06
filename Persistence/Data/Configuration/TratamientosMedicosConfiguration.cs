using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class TratamientosMedicoConfiguration : IEntityTypeConfiguration<TratamientosMedico>
{
    public void Configure(EntityTypeBuilder<TratamientosMedico> builder)
    {
        builder.ToTable("TratamientosMedico");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_Tratamiento")
        .HasColumnType("int")
        .IsRequired();



        builder.Property(p => p.Dosis)
       .HasColumnName("Dosis")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();


        builder.Property(p => p.FechaAdministracion)
                 .IsRequired()
                 .HasColumnName("fechaAdministracion");



        builder.Property(p => p.Observacion)
            .HasColumnName("obsevacion")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();


        builder.HasOne(p => p.Cita)
                 .WithMany(c => c.TratamientosMedicos)
                 .HasForeignKey(p => p.IdCita)
                 .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Medicamento)
        .WithMany(c => c.TratamientosMedicos)
        .HasForeignKey(p => p.IdMedicamento)
        .OnDelete(DeleteBehavior.Cascade);

      




           builder.HasData(
              new TratamientosMedico
              {
                 Id = 1,
                 Dosis="inyeccion",
                 FechaAdministracion= new DateTime(2021, 4, 15),
                 Observacion="signos vitales buenos",
                 IdCita=1,
                 IdMedicamento=1

              }, new TratamientosMedico
              {
                  Id = 2,
                 Dosis="cirugia",
                 FechaAdministracion= new DateTime(2023, 6, 25),
                 Observacion="operacion perfecta",
                 IdCita=2,
                 IdMedicamento=1

              }, new TratamientosMedico
              {
                  Id = 3,
                 Dosis="baypass gastrico",
                 FechaAdministracion= new DateTime(2025, 2, 1),
                 Observacion="perdida del paciente",
                 IdCita=1,
                 IdMedicamento=1

              }
          ); 



    }
}