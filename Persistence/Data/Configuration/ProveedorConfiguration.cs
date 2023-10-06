using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("Proveedor");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_Proveedor")
        .HasColumnType("int")
        .IsRequired();



        builder.Property(p => p.Nombre)
       .HasColumnName("Nombre")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();

        builder.Property(p => p.Dirrecion)
       .HasColumnName("direccion")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();
     

      builder.Property(p => p.Telefono)
                 .IsRequired()
                 .HasColumnName("telefono");





         builder.HasData(
            new Proveedor
            {
                Id = 1,
               Nombre="arnulfoxD",
               Dirrecion="el bronx/ avenida municipal",
               Telefono="+1-1233-3457"
            }, new Proveedor
            {
                Id = 2,
               Nombre="stward",
               Dirrecion="carrera 15 / bucaramanga",
               Telefono="+1-1233-3457"
            }, new Proveedor
            {
                Id = 3,
               Nombre="ramiro",
               Dirrecion="new york/ aadp",
               Telefono="+1-1233-3457"
            }
        ); 



    }
}