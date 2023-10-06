using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
{
    public void Configure(EntityTypeBuilder<Veterinario> builder)
    {
        builder.ToTable("Veterinario");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_Veterinario")
        .HasColumnType("int")
        .IsRequired();



        builder.Property(p => p.Nombre)
       .HasColumnName("Nombre")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();

        builder.Property(p => p.Correo)
       .HasColumnName("correo")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();

       builder.Property(p => p.Especialidad)
       .HasColumnName("especialdad")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();
     

      builder.Property(p => p.Telefono)
                 .IsRequired()
                 .HasColumnName("telefono");



         builder.HasData(
            new Veterinario
            {
               Id = 1,
               Nombre="juancho",
               Correo="juancho@martinezgmail.com",
               Especialidad="cirujanobascular",
               Telefono="+32-2345-4542"
            }, new Veterinario
            {
               Id = 2,
               Nombre="miranda",
               Correo="miranda@gmail.com",
               Especialidad="enfermera",
               Telefono="+32-5432-4325"
            }, new Veterinario
            {
                Id = 3,
               Nombre="ana",
               Correo="ana@gmail.com",
               Especialidad="inyectologa",
               Telefono="+32-7654-9860"
            }
        ); 



    }
}