using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable("Medicamento");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("Id_Medicamento")
        .HasColumnType("int")
        .IsRequired();



        builder.Property(p => p.Nombre)
       .HasColumnName("Nombre")
       .HasColumnType("varchar")
       .HasMaxLength(150)
       .IsRequired();


        builder.Property(p => p.CantidadDisponible)
                 .IsRequired()
                 .HasColumnName("cantidadDisponible");


                 
        builder.Property(p => p.Precio)
                 .IsRequired()
                 .HasColumnName("precio");



        builder.HasOne(p => p.Laboratorio)
                 .WithMany(c => c.Medicamentos)
                 .HasForeignKey(p => p.IdLaboratio)
                 .OnDelete(DeleteBehavior.Cascade);



        builder
            .HasMany(p => p.Proveedores)
            .WithMany(r => r.Medicamentos)
            .UsingEntity<MedicamentoProveedor>(

                j => j
                .HasOne(pt => pt.Proveedor)
                .WithMany(t => t.MedicamentoProveedores)
                .HasForeignKey(ut => ut.IdProveedor),


                j => j
                .HasOne(et => et.Medicamento)
                .WithMany(et => et.MedicamentoProveedores)
                .HasForeignKey(el => el.IdMedicamento),

                j =>
                {
                    j.HasKey(t => new { t.IdMedicamento, t.IdProveedor });

                });
    

            builder.HasData(
              new Medicamento
              {
                 Id=1,
                 Nombre="paracetamol",
                 CantidadDisponible=3,
                 Precio=1000,
                 IdLaboratio=1

              }, new Medicamento
              {
                 Id = 2,
                 Nombre="acetaminofen",
                 CantidadDisponible=3,
                 Precio=5000,
                 IdLaboratio=1

              }, new Medicamento
              { 
                 Id = 3,
                 Nombre="champiojo",
                 CantidadDisponible=3,
                 Precio=110000,
                 IdLaboratio=2
              }, new Medicamento
              { 
                 Id = 4,
                 Nombre="cianuro",
                 CantidadDisponible=10,
                 Precio=1105000,
                 IdLaboratio=2
              }
          ); 
 
          
/* 
           builder.HasData(
              new MedicamentoProveedor
              {
                IdProveedor=1,
                IdMedicamento=2
              },
              new MedicamentoProveedor
              {
                IdProveedor=2,
                IdMedicamento=3
              },
              new MedicamentoProveedor
              {
                IdProveedor=2,
                IdMedicamento=2
              }
           ); 
 */

    }
}