using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>
{
    public void Configure(EntityTypeBuilder<Laboratorio> builder)
    {
        builder.ToTable("Laboratorio");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_Laboratorio")
        .HasColumnType("int")
        .IsRequired();



        builder.Property(p => p.Nombre)
       .HasColumnName("Nombre")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();


       builder.Property(p => p.Dirrecion)
       .HasColumnName("dirrecion")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();
     

     builder.Property(p => p.Telefono)
       .HasColumnName("telefono")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();




         builder.HasData(
            new Laboratorio
            {
                Id = 1,
               Nombre="MQ industries",
               Dirrecion="bogota Dc Norte",
               Telefono="+1-12332-1232"
            }, new Laboratorio
            {
                Id = 2,
               Nombre="genfar",
                Dirrecion="medellin Dc Norte",
               Telefono="+51-12342-232"
            }, new Laboratorio
            {
                Id = 3,
               Nombre="real tapitas farmacos",
               Dirrecion="Venezuela",
               Telefono="+35-1222-33424"
            }
        ); 



    }
}