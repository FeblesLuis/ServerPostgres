using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initia_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notificacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    titulo = table.Column<string>(type: "text", nullable: true),
                    envia = table.Column<string>(type: "text", nullable: true),
                    dirigido = table.Column<string>(type: "text", nullable: true),
                    mensaje = table.Column<string>(type: "text", nullable: true),
                    Revisado = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario = table.Column<string>(type: "text", nullable: true),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    apellido = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    correo = table.Column<string>(type: "text", nullable: true),
                    preguntas_de_seguridad = table.Column<string>(type: "text", nullable: true),
                    preguntas_de_seguridad2 = table.Column<string>(type: "text", nullable: true),
                    respuesta_de_seguridad = table.Column<string>(type: "text", nullable: true),
                    respuesta_de_seguridad2 = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<bool>(type: "boolean", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    cargo = table.Column<string>(type: "text", nullable: true),
                    usuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoConformidad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    numero_expedicion = table.Column<string>(type: "text", nullable: true),
                    revisado_por = table.Column<string>(type: "text", nullable: true),
                    consecuencias = table.Column<string>(type: "text", nullable: true),
                    responsables = table.Column<List<string>>(type: "text[]", nullable: true),
                    areas_involucradas = table.Column<List<string>>(type: "text[]", nullable: true),
                    prioridad = table.Column<int>(type: "integer", nullable: true),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    calidadId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoConformidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoConformidad_Usuario_calidadId",
                        column: x => x.calidadId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cierre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    conforme = table.Column<bool>(type: "boolean", nullable: true),
                    observaciones = table.Column<string>(type: "text", nullable: true),
                    responsable = table.Column<string>(type: "text", nullable: true),
                    fecha_verificacion = table.Column<string>(type: "text", nullable: true),
                    noConformidadId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cierre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cierre_NoConformidad_noConformidadId",
                        column: x => x.noConformidadId,
                        principalTable: "NoConformidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reporte",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    detectado_por = table.Column<string>(type: "text", nullable: true),
                    area = table.Column<string>(type: "text", nullable: true),
                    titulo = table.Column<string>(type: "text", nullable: true),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    usuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    noConformidadId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reporte_NoConformidad_noConformidadId",
                        column: x => x.noConformidadId,
                        principalTable: "NoConformidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reporte_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    investigacion = table.Column<string>(type: "text", nullable: true),
                    analisis_causa = table.Column<string>(type: "text", nullable: true),
                    correccion = table.Column<string>(type: "text", nullable: true),
                    analisis_riesgo = table.Column<string>(type: "text", nullable: true),
                    noConformidadId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsable_NoConformidad_noConformidadId",
                        column: x => x.noConformidadId,
                        principalTable: "NoConformidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seguimiento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_seguimiento = table.Column<string>(type: "text", nullable: true),
                    estatus = table.Column<string>(type: "text", nullable: true),
                    observaciones = table.Column<string>(type: "text", nullable: true),
                    realizado_por = table.Column<string>(type: "text", nullable: true),
                    noConformidadId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguimiento_NoConformidad_noConformidadId",
                        column: x => x.noConformidadId,
                        principalTable: "NoConformidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inicadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    origen = table.Column<string>(type: "text", nullable: true),
                    causa = table.Column<string>(type: "text", nullable: true),
                    cierreId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inicadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inicadores_Cierre_cierreId",
                        column: x => x.cierreId,
                        principalTable: "Cierre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerificacionEfectividad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    efectiva = table.Column<bool>(type: "boolean", nullable: true),
                    observaciones = table.Column<string>(type: "text", nullable: true),
                    realizado_por = table.Column<string>(type: "text", nullable: true),
                    cierreId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificacionEfectividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificacionEfectividad_Cierre_cierreId",
                        column: x => x.cierreId,
                        principalTable: "Cierre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevisionReporte",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<bool>(type: "boolean", nullable: true),
                    reporteId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevisionReporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevisionReporte_Reporte_reporteId",
                        column: x => x.reporteId,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccionesCorrectivas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    acciones_correctivas = table.Column<List<string>>(type: "text[]", nullable: true),
                    acciones_preventivas = table.Column<List<string>>(type: "text[]", nullable: true),
                    estado = table.Column<bool>(type: "boolean", nullable: true),
                    responsableId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionesCorrectivas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccionesCorrectivas_Responsable_responsableId",
                        column: x => x.responsableId,
                        principalTable: "Responsable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevisionAccionesCorrectivas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    accionesCorrectivasId = table.Column<Guid>(type: "uuid", nullable: false),
                    usuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevisionAccionesCorrectivas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevisionAccionesCorrectivas_AccionesCorrectivas_accionesCor~",
                        column: x => x.accionesCorrectivasId,
                        principalTable: "AccionesCorrectivas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RevisionAccionesCorrectivas_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccionesCorrectivas_responsableId",
                table: "AccionesCorrectivas",
                column: "responsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Cierre_noConformidadId",
                table: "Cierre",
                column: "noConformidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_usuarioId",
                table: "Departamento",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Inicadores_cierreId",
                table: "Inicadores",
                column: "cierreId");

            migrationBuilder.CreateIndex(
                name: "IX_NoConformidad_calidadId",
                table: "NoConformidad",
                column: "calidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_noConformidadId",
                table: "Reporte",
                column: "noConformidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_usuarioId",
                table: "Reporte",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsable_noConformidadId",
                table: "Responsable",
                column: "noConformidadId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionAccionesCorrectivas_accionesCorrectivasId",
                table: "RevisionAccionesCorrectivas",
                column: "accionesCorrectivasId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionAccionesCorrectivas_usuarioId",
                table: "RevisionAccionesCorrectivas",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionReporte_reporteId",
                table: "RevisionReporte",
                column: "reporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_noConformidadId",
                table: "Seguimiento",
                column: "noConformidadId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificacionEfectividad_cierreId",
                table: "VerificacionEfectividad",
                column: "cierreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Inicadores");

            migrationBuilder.DropTable(
                name: "Notificacion");

            migrationBuilder.DropTable(
                name: "RevisionAccionesCorrectivas");

            migrationBuilder.DropTable(
                name: "RevisionReporte");

            migrationBuilder.DropTable(
                name: "Seguimiento");

            migrationBuilder.DropTable(
                name: "VerificacionEfectividad");

            migrationBuilder.DropTable(
                name: "AccionesCorrectivas");

            migrationBuilder.DropTable(
                name: "Reporte");

            migrationBuilder.DropTable(
                name: "Cierre");

            migrationBuilder.DropTable(
                name: "Responsable");

            migrationBuilder.DropTable(
                name: "NoConformidad");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
