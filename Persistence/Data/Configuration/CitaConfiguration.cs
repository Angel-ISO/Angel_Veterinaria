using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ToTable("Cita");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_Cita")
        .HasColumnType("int")
        .IsRequired();


        builder.Property(p => p.Fecha)
                .IsRequired()
                .HasColumnName("fecha_cita");

        builder.Property(p => p.Hora)
        .HasColumnName("hora")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();


        builder.Property(p => p.Motivo)
        .HasColumnName("Motivo")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();


        builder.HasOne(p => p.Veterinario)
                .WithMany(c => c.Citas)
                .HasForeignKey(p => p.IdVeterinario)
                .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(p => p.Mascota)
                      .WithMany(c => c.Citas)
                      .HasForeignKey(p => p.IdMascota)
                      .OnDelete(DeleteBehavior.Cascade);


       



         builder.HasData(
            new Cita
            {
                Id = 1,
                Fecha = new DateTime(2023, 9, 30),
                Hora = "3:00 PM",
                Motivo= "resfriado",
                IdVeterinario= 1,
                IdMascota = 2        
            }, new Cita
            {
                Id = 2,
                Fecha = new DateTime(2023, 6, 10),
                Hora = "2:00 PM",
                Motivo= "paro respiratorio",
                IdVeterinario= 2,
                IdMascota = 1        
            }, new Cita
            {
                Id = 3,
                Fecha = new DateTime(2022, 5, 20),
                Hora = "5:00 AM",
                Motivo= "alimento no comestible",
                IdVeterinario= 3,
                IdMascota = 3        
            }, new Cita
            {
                Id = 4,
                Fecha = new DateTime(2023, 3, 25),
                Hora = "10:00 AM",
                Motivo= "revicion",
                IdVeterinario= 3,
                IdMascota = 2        
            }
        ); 



    }
}