using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    Id_Especie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.Id_Especie);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                columns: table => new
                {
                    Id_Laboratorio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dirrecion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorio", x => x.Id_Laboratorio);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    Id_Propietario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.Id_Propietario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id_Proveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id_Proveedor);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id_Rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameRol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descRol = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id_Rol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                columns: table => new
                {
                    Id_TipoMov = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimiento", x => x.Id_TipoMov);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameUser = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id_User);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Veterinario",
                columns: table => new
                {
                    Id_Veterinario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    correo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    especialdad = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.Id_Veterinario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Raza",
                columns: table => new
                {
                    Id_Raza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEspecie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raza", x => x.Id_Raza);
                    table.ForeignKey(
                        name: "FK_Raza_Especie_IdEspecie",
                        column: x => x.IdEspecie,
                        principalTable: "Especie",
                        principalColumn: "Id_Especie",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    Id_Medicamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cantidadDisponible = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false),
                    IdLaboratio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.Id_Medicamento);
                    table.ForeignKey(
                        name: "FK_Medicamento_Laboratorio_IdLaboratio",
                        column: x => x.IdLaboratio,
                        principalTable: "Laboratorio",
                        principalColumn: "Id_Laboratorio",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsersRols",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRols", x => new { x.UserId, x.RolId });
                    table.ForeignKey(
                        name: "FK_UsersRols_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id_Rol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRols_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    Id_Mascota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdPropietario = table.Column<int>(type: "int", nullable: false),
                    IdEspecie = table.Column<int>(type: "int", nullable: false),
                    IdRaza = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id_Mascota);
                    table.ForeignKey(
                        name: "FK_Mascota_Especie_IdEspecie",
                        column: x => x.IdEspecie,
                        principalTable: "Especie",
                        principalColumn: "Id_Especie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mascota_Propietario_IdPropietario",
                        column: x => x.IdPropietario,
                        principalTable: "Propietario",
                        principalColumn: "Id_Propietario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mascota_Raza_IdRaza",
                        column: x => x.IdRaza,
                        principalTable: "Raza",
                        principalColumn: "Id_Raza",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicamentoProveedores",
                columns: table => new
                {
                    IdMedicamento = table.Column<int>(type: "int", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentoProveedores", x => new { x.IdMedicamento, x.IdProveedor });
                    table.ForeignKey(
                        name: "FK_MedicamentoProveedores_Medicamento_IdMedicamento",
                        column: x => x.IdMedicamento,
                        principalTable: "Medicamento",
                        principalColumn: "Id_Medicamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentoProveedores_Proveedor_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "Id_Proveedor",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovimientoMedicamento",
                columns: table => new
                {
                    Id_MovimientoMed = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdMedicamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoMedicamento", x => x.Id_MovimientoMed);
                    table.ForeignKey(
                        name: "FK_MovimientoMedicamento_Medicamento_IdMedicamento",
                        column: x => x.IdMedicamento,
                        principalTable: "Medicamento",
                        principalColumn: "Id_Medicamento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id_Cita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fecha_cita = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    hora = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Motivo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdVeterinario = table.Column<int>(type: "int", nullable: false),
                    IdMascota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id_Cita);
                    table.ForeignKey(
                        name: "FK_Cita_Mascota_IdMascota",
                        column: x => x.IdMascota,
                        principalTable: "Mascota",
                        principalColumn: "Id_Mascota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Veterinario_IdVeterinario",
                        column: x => x.IdVeterinario,
                        principalTable: "Veterinario",
                        principalColumn: "Id_Veterinario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleMovimiento",
                columns: table => new
                {
                    Id_DetalleMovimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false),
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: false),
                    IdMedicamento = table.Column<int>(type: "int", nullable: false),
                    IdMovimientoMed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleMovimiento", x => x.Id_DetalleMovimiento);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_Medicamento_IdMedicamento",
                        column: x => x.IdMedicamento,
                        principalTable: "Medicamento",
                        principalColumn: "Id_Medicamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_MovimientoMedicamento_IdMovimientoMed",
                        column: x => x.IdMovimientoMed,
                        principalTable: "MovimientoMedicamento",
                        principalColumn: "Id_MovimientoMed",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_TipoMovimiento_IdTipoMovimiento",
                        column: x => x.IdTipoMovimiento,
                        principalTable: "TipoMovimiento",
                        principalColumn: "Id_TipoMov",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TratamientosMedico",
                columns: table => new
                {
                    Id_Tratamiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dosis = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaAdministracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    obsevacion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCita = table.Column<int>(type: "int", nullable: false),
                    IdMedicamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamientosMedico", x => x.Id_Tratamiento);
                    table.ForeignKey(
                        name: "FK_TratamientosMedico_Cita_IdCita",
                        column: x => x.IdCita,
                        principalTable: "Cita",
                        principalColumn: "Id_Cita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TratamientosMedico_Medicamento_IdMedicamento",
                        column: x => x.IdMedicamento,
                        principalTable: "Medicamento",
                        principalColumn: "Id_Medicamento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Especie",
                columns: new[] { "Id_Especie", "Nombre" },
                values: new object[,]
                {
                    { 1, "reptil" },
                    { 2, "ave" },
                    { 3, "mamifero" }
                });

            migrationBuilder.InsertData(
                table: "Laboratorio",
                columns: new[] { "Id_Laboratorio", "dirrecion", "Nombre", "telefono" },
                values: new object[,]
                {
                    { 1, "bogota Dc Norte", "MQ industries", "+1-12332-1232" },
                    { 2, "medellin Dc Norte", "genfar", "+51-12342-232" },
                    { 3, "Venezuela", "real tapitas farmacos", "+35-1222-33424" }
                });

            migrationBuilder.InsertData(
                table: "Propietario",
                columns: new[] { "Id_Propietario", "email", "Nombre", "telefono" },
                values: new object[,]
                {
                    { 1, "orlando@gmail.com", "orlando", "+65-3456-6543" },
                    { 2, "luisa@gmail.com", "luisa", "+45-5684-4797" },
                    { 3, "sofia@gmail.com", "sofia", "+25-2323-3754" }
                });

            migrationBuilder.InsertData(
                table: "Proveedor",
                columns: new[] { "Id_Proveedor", "direccion", "Nombre", "telefono" },
                values: new object[,]
                {
                    { 1, "el bronx/ avenida municipal", "arnulfoxD", "+1-1233-3457" },
                    { 2, "carrera 15 / bucaramanga", "stward", "+1-1233-3457" },
                    { 3, "new york/ aadp", "ramiro", "+1-1233-3457" }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id_Rol", "descRol", "NameRol" },
                values: new object[,]
                {
                    { 1, "Rol de administrador", "Admin" },
                    { 2, "Gestor de administracion", "Gerente" },
                    { 3, "Asalariado de la empresa", "veterinario" },
                    { 4, "dueño de un paciente", "propietario" }
                });

            migrationBuilder.InsertData(
                table: "TipoMovimiento",
                columns: new[] { "Id_TipoMov", "description" },
                values: new object[,]
                {
                    { 1, "importacion" },
                    { 2, "devolucion" },
                    { 3, "envio aereo" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id_User", "Email", "NameUser", "Password" },
                values: new object[,]
                {
                    { 1, "angel@gmail.com", "Angel", "1234" },
                    { 2, "sofia@gmail.com", "sofia", "1234" },
                    { 3, "lucia@gmail.com", "lucia", "1234" }
                });

            migrationBuilder.InsertData(
                table: "Veterinario",
                columns: new[] { "Id_Veterinario", "correo", "especialdad", "Nombre", "telefono" },
                values: new object[,]
                {
                    { 1, "juancho@martinezgmail.com", "cirujanobascular", "juancho", "+32-2345-4542" },
                    { 2, "miranda@gmail.com", "enfermera", "miranda", "+32-5432-4325" },
                    { 3, "ana@gmail.com", "inyectologa", "ana", "+32-7654-9860" }
                });

            migrationBuilder.InsertData(
                table: "Medicamento",
                columns: new[] { "Id_Medicamento", "cantidadDisponible", "IdLaboratio", "Nombre", "precio" },
                values: new object[,]
                {
                    { 1, 3, 1, "paracetamol", 1000 },
                    { 2, 3, 1, "acetaminofen", 5000 },
                    { 3, 3, 2, "champiojo", 110000 },
                    { 4, 10, 2, "cianuro", 1105000 }
                });

            migrationBuilder.InsertData(
                table: "Raza",
                columns: new[] { "Id_Raza", "IdEspecie", "name" },
                values: new object[,]
                {
                    { 1, 3, "roge wailler" },
                    { 2, 3, "cabeza leon" },
                    { 3, 3, "puddle" }
                });

            migrationBuilder.InsertData(
                table: "Mascota",
                columns: new[] { "Id_Mascota", "fechaNacimiento", "IdEspecie", "IdPropietario", "IdRaza", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, "muñeca" },
                    { 2, new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 2, "winchi" },
                    { 3, new DateTime(2015, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 2, "mataGigantes" }
                });

            migrationBuilder.InsertData(
                table: "MovimientoMedicamento",
                columns: new[] { "Id_MovimientoMed", "cantidad", "fecha", "IdMedicamento" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 4, new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 5, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 6, new DateTime(2011, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Cita",
                columns: new[] { "Id_Cita", "fecha_cita", "hora", "IdMascota", "IdVeterinario", "Motivo" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "3:00 PM", 2, 1, "resfriado" },
                    { 2, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "2:00 PM", 1, 2, "paro respiratorio" },
                    { 3, new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "5:00 AM", 3, 3, "alimento no comestible" },
                    { 4, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "10:00 AM", 2, 3, "revicion" }
                });

            migrationBuilder.InsertData(
                table: "DetalleMovimiento",
                columns: new[] { "Id_DetalleMovimiento", "Cantidad", "IdMedicamento", "IdMovimientoMed", "IdTipoMovimiento", "precio" },
                values: new object[,]
                {
                    { 1, 5, 1, 1, 1, 2000 },
                    { 2, 7, 1, 2, 1, 5000 },
                    { 3, 9, 2, 3, 3, 500 }
                });

            migrationBuilder.InsertData(
                table: "TratamientosMedico",
                columns: new[] { "Id_Tratamiento", "Dosis", "fechaAdministracion", "IdCita", "IdMedicamento", "obsevacion" },
                values: new object[,]
                {
                    { 1, "inyeccion", new DateTime(2021, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "signos vitales buenos" },
                    { 2, "cirugia", new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "operacion perfecta" },
                    { 3, "baypass gastrico", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "perdida del paciente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdMascota",
                table: "Cita",
                column: "IdMascota");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdVeterinario",
                table: "Cita",
                column: "IdVeterinario");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdMedicamento",
                table: "DetalleMovimiento",
                column: "IdMedicamento");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdMovimientoMed",
                table: "DetalleMovimiento",
                column: "IdMovimientoMed");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdTipoMovimiento",
                table: "DetalleMovimiento",
                column: "IdTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdEspecie",
                table: "Mascota",
                column: "IdEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdPropietario",
                table: "Mascota",
                column: "IdPropietario");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdRaza",
                table: "Mascota",
                column: "IdRaza");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_IdLaboratio",
                table: "Medicamento",
                column: "IdLaboratio");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoProveedores_IdProveedor",
                table: "MedicamentoProveedores",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoMedicamento_IdMedicamento",
                table: "MovimientoMedicamento",
                column: "IdMedicamento");

            migrationBuilder.CreateIndex(
                name: "IX_Raza_IdEspecie",
                table: "Raza",
                column: "IdEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosMedico_IdCita",
                table: "TratamientosMedico",
                column: "IdCita");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosMedico_IdMedicamento",
                table: "TratamientosMedico",
                column: "IdMedicamento");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRols_RolId",
                table: "UsersRols",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleMovimiento");

            migrationBuilder.DropTable(
                name: "MedicamentoProveedores");

            migrationBuilder.DropTable(
                name: "TratamientosMedico");

            migrationBuilder.DropTable(
                name: "UsersRols");

            migrationBuilder.DropTable(
                name: "MovimientoMedicamento");

            migrationBuilder.DropTable(
                name: "TipoMovimiento");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Veterinario");

            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropTable(
                name: "Raza");

            migrationBuilder.DropTable(
                name: "Especie");
        }
    }
}
