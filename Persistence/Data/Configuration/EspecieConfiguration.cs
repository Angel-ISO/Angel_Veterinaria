using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class EspecieConfiguration : IEntityTypeConfiguration<Especie>
{
    public void Configure(EntityTypeBuilder<Especie> builder)
    {
        builder.ToTable("Especie");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_Especie")
        .HasColumnType("int")
        .IsRequired();



        builder.Property(p => p.Nombre)
       .HasColumnName("Nombre")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();
     




          builder.HasData(
            new Especie
            {
                Id = 1,
               Nombre="reptil"
            }, new Especie
            {
                Id = 2,
               Nombre="ave"
            }, new Especie
            {
                Id = 3,
               Nombre="mamifero"
            }
        ); 



    }
}