using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class RazaConfiguration : IEntityTypeConfiguration<Raza>
{
    public void Configure(EntityTypeBuilder<Raza> builder)
    {
        builder.ToTable("Raza");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_Raza")
        .HasColumnType("int")
        .IsRequired();


         builder.Property(p => p.Name)
       .HasColumnName("name")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();





         builder.HasOne(p => p.Especie)
                 .WithMany(c => c.Razas)
                 .HasForeignKey(p => p.IdEspecie)
                 .OnDelete(DeleteBehavior.Cascade);





         builder.HasData(
            new Raza
            {
                Id = 1,
               Name="roge wailler",
               IdEspecie=3
            }, new Raza
            {
                Id = 2,
               Name="cabeza leon",
              IdEspecie=3

            }, new Raza
            {
                Id = 3,
               Name="puddle",
               IdEspecie=3

            }
        ); 



    }
}