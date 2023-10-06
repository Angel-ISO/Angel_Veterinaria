using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
{
    public void Configure(EntityTypeBuilder<Mascota> builder)
    {
        builder.ToTable("Mascota");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_Mascota")
        .HasColumnType("int")
        .IsRequired();



        builder.Property(p => p.Nombre)
       .HasColumnName("Nombre")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();


        builder.Property(p => p.FechaNacimiento)
                 .IsRequired()
                 .HasColumnName("fechaNacimiento");



        builder.HasOne(p => p.Propietario)
                 .WithMany(c => c.Mascotas)
                 .HasForeignKey(p => p.IdPropietario)
                 .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Especie)
        .WithMany(c => c.Mascotas)
        .HasForeignKey(p => p.IdEspecie)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Raza)
        .WithMany(c => c.Mascotas)
        .HasForeignKey(p => p.IdRaza)
        .OnDelete(DeleteBehavior.Cascade);




           builder.HasData(
              new Mascota
              {
                 Id = 1,
                 Nombre="muñeca",
                 FechaNacimiento= new DateTime(2020, 4, 15),
                 IdPropietario=1,
                 IdEspecie=1,
                 IdRaza=1

              }, new Mascota
              {
                 Id = 2,
                 Nombre="winchi",
                 FechaNacimiento= new DateTime(2019, 3, 10),
                 IdPropietario=2,
                 IdEspecie=1,
                 IdRaza=2
              }, new Mascota
              {
                 Id = 3,
                 Nombre="mataGigantes",
                 FechaNacimiento= new DateTime(2015, 6, 4),
                 IdPropietario=3,
                 IdEspecie=1,
                 IdRaza=2
              }
          ); 



    }
}