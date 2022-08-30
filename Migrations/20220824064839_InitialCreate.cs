using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PolloRapiPostgre.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enumerado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enumerado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    PrecioBruto = table.Column<decimal>(type: "numeric", nullable: false),
                    Descuento = table.Column<decimal>(type: "numeric", nullable: true),
                    PrecioNeto = table.Column<decimal>(type: "numeric", nullable: false),
                    Imagen = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promociones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promociones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Modulo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnumeradoJerarquias",
                columns: table => new
                {
                    AncestroId = table.Column<int>(type: "integer", nullable: false),
                    DescendienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumeradoJerarquias", x => new { x.AncestroId, x.DescendienteId });
                    table.ForeignKey(
                        name: "FK_EnumeradoJerarquias_Enumerado_AncestroId",
                        column: x => x.AncestroId,
                        principalTable: "Enumerado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnumeradoJerarquias_Enumerado_DescendienteId",
                        column: x => x.DescendienteId,
                        principalTable: "Enumerado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EnumeradoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Enumerado_EnumeradoId",
                        column: x => x.EnumeradoId,
                        principalTable: "Enumerado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoPromociones",
                columns: table => new
                {
                    ProductoPromocionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProductoId = table.Column<int>(type: "integer", nullable: false),
                    PromocionId = table.Column<int>(type: "integer", nullable: false),
                    EnumeradoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoPromociones", x => x.ProductoPromocionId);
                    table.ForeignKey(
                        name: "FK_ProductoPromociones_Enumerado_EnumeradoId",
                        column: x => x.EnumeradoId,
                        principalTable: "Enumerado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoPromociones_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoPromociones_Promociones_PromocionId",
                        column: x => x.PromocionId,
                        principalTable: "Promociones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellidos = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Distrito = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    RolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductoId = table.Column<int>(type: "integer", nullable: false),
                    PedidoId = table.Column<int>(type: "integer", nullable: true),
                    PromocionId = table.Column<int>(type: "integer", nullable: false),
                    EnumeradoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Enumerado_EnumeradoId",
                        column: x => x.EnumeradoId,
                        principalTable: "Enumerado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Promociones_PromocionId",
                        column: x => x.PromocionId,
                        principalTable: "Promociones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NombreUsuario = table.Column<string>(type: "text", nullable: false),
                    Contrasena = table.Column<string>(type: "text", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comprobantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MedioPagoId = table.Column<int>(type: "integer", nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "integer", nullable: true),
                    CuentasId = table.Column<int>(type: "integer", nullable: false),
                    PedidoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comprobantes_Cuentas_CuentasId",
                        column: x => x.CuentasId,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comprobantes_Enumerado_MedioPagoId",
                        column: x => x.MedioPagoId,
                        principalTable: "Enumerado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comprobantes_Enumerado_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "Enumerado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comprobantes_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_CuentasId",
                table: "Comprobantes",
                column: "CuentasId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_MedioPagoId",
                table: "Comprobantes",
                column: "MedioPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_PedidoId",
                table: "Comprobantes",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_TipoDocumentoId",
                table: "Comprobantes",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UsuarioId",
                table: "Cuentas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumeradoJerarquias_DescendienteId",
                table: "EnumeradoJerarquias",
                column: "DescendienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalles_EnumeradoId",
                table: "PedidoDetalles",
                column: "EnumeradoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalles_PedidoId",
                table: "PedidoDetalles",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalles_ProductoId",
                table: "PedidoDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalles_PromocionId",
                table: "PedidoDetalles",
                column: "PromocionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EnumeradoId",
                table: "Pedidos",
                column: "EnumeradoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPromociones_EnumeradoId",
                table: "ProductoPromociones",
                column: "EnumeradoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPromociones_ProductoId",
                table: "ProductoPromociones",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPromociones_PromocionId",
                table: "ProductoPromociones",
                column: "PromocionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comprobantes");

            migrationBuilder.DropTable(
                name: "EnumeradoJerarquias");

            migrationBuilder.DropTable(
                name: "PedidoDetalles");

            migrationBuilder.DropTable(
                name: "ProductoPromociones");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Promociones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Enumerado");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
