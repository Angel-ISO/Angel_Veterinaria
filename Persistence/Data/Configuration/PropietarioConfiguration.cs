using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario>
{
    public void Configure(EntityTypeBuilder<Propietario> builder)
    {
        builder.ToTable("Propietario");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_Propietario")
        .HasColumnType("int")
        .IsRequired();



        builder.Property(p => p.Nombre)
       .HasColumnName("Nombre")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();

        builder.Property(p => p.Email)
       .HasColumnName("email")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();
     

      builder.Property(p => p.Telefono)
                 .IsRequired()
                 .HasColumnName("telefono");





        builder.HasData(
            new Propietario
            {
               Id = 1,
               Nombre="orlando",
               Email="orlando@gmail.com",
               Telefono="+65-3456-6543"
            }, new Propietario
            {
                Id = 2,
               Nombre="luisa",
               Email="luisa@gmail.com",
               Telefono="+45-5684-4797"
            }, new Propietario
            {
                Id = 3,
               Nombre="sofia",
               Email="sofia@gmail.com",
               Telefono="+25-2323-3754"
            }
        ); 



    }
}