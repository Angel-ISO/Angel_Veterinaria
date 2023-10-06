using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimiento>
{
    public void Configure(EntityTypeBuilder<TipoMovimiento> builder)
    {
        builder.ToTable("TipoMovimiento");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_TipoMov")
        .HasColumnType("int")
        .IsRequired();



        builder.Property(p => p.Description)
       .HasColumnName("description")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();




         builder.HasData(
            new TipoMovimiento
            {
                Id = 1,
               Description="importacion"
            }, new TipoMovimiento
            {
                Id = 2,
               Description="devolucion"
            }, new TipoMovimiento
            {
                Id = 3,
               Description="envio aereo"
            }
        ); 



    }
}