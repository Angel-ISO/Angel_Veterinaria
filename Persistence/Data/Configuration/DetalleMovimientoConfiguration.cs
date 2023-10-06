using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
{
    public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
    {
        builder.ToTable("DetalleMovimiento");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_DetalleMovimiento")
        .HasColumnType("int")
        .IsRequired();

     


            builder.Property(p => p.Cantidad)
            .IsRequired()
            .HasColumnName("Cantidad");  

                builder.Property(p => p.Precio)
            .IsRequired()
            .HasColumnName("precio");  
    

        builder.HasOne(p => p.TipoMovimiento)
                .WithMany(c => c.DetalleMovimientos)
                .HasForeignKey(p => p.IdTipoMovimiento)
                .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(p => p.Medicamento)
                      .WithMany(c => c.DetalleMovimientos)
                      .HasForeignKey(p => p.IdMedicamento)
                      .OnDelete(DeleteBehavior.Cascade);


      
        builder.HasOne(p => p.MovimientoMedicamento)
                      .WithMany(c => c.DetalleMovimientos)
                      .HasForeignKey(p => p.IdMovimientoMed)
                      .OnDelete(DeleteBehavior.Cascade);


          builder.HasData(
            new DetalleMovimiento
            {
                Id = 1,
                Cantidad = 5,
                Precio = 2000,
                IdMovimientoMed=1,
                IdMedicamento= 1,
                IdTipoMovimiento=1
            },
            new DetalleMovimiento
            {
                Id = 2,
                Cantidad = 7,
                Precio = 5000,
                IdMovimientoMed=2,
                IdMedicamento= 1,
                IdTipoMovimiento=1
            },
            new DetalleMovimiento
            {
                Id = 3,
                Cantidad = 9,
                Precio = 500,
                IdMovimientoMed=3,
                IdMedicamento= 2,
                IdTipoMovimiento=3
            }
        ); 



    }
}