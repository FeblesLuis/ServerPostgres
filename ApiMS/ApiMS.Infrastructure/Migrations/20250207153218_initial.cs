using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificacionEntity",
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
                    table.PrimaryKey("PK_NotificacionEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEntity",
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
                    table.PrimaryKey("PK_UsuarioEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentoEntity",
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
                    table.PrimaryKey("PK_DepartamentoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartamentoEntity_UsuarioEntity_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "UsuarioEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoConformidadEntity",
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
                    table.PrimaryKey("PK_NoConformidadEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoConformidadEntity_UsuarioEntity_calidadId",
                        column: x => x.calidadId,
                        principalTable: "UsuarioEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CierreEntity",
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
                    table.PrimaryKey("PK_CierreEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CierreEntity_NoConformidadEntity_noConformidadId",
                        column: x => x.noConformidadId,
                        principalTable: "NoConformidadEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReporteEntity",
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
                    table.PrimaryKey("PK_ReporteEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReporteEntity_NoConformidadEntity_noConformidadId",
                        column: x => x.noConformidadId,
                        principalTable: "NoConformidadEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReporteEntity_UsuarioEntity_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "UsuarioEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsableEntity",
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
                    table.PrimaryKey("PK_ResponsableEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsableEntity_NoConformidadEntity_noConformidadId",
                        column: x => x.noConformidadId,
                        principalTable: "NoConformidadEntity",
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
                        name: "FK_Seguimiento_NoConformidadEntity_noConformidadId",
                        column: x => x.noConformidadId,
                        principalTable: "NoConformidadEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InicadoresEntity",
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
                    table.PrimaryKey("PK_InicadoresEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InicadoresEntity_CierreEntity_cierreId",
                        column: x => x.cierreId,
                        principalTable: "CierreEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerificacionEfectividadEntity",
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
                    table.PrimaryKey("PK_VerificacionEfectividadEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificacionEfectividadEntity_CierreEntity_cierreId",
                        column: x => x.cierreId,
                        principalTable: "CierreEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevisionReporteEntity",
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
                    table.PrimaryKey("PK_RevisionReporteEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevisionReporteEntity_ReporteEntity_reporteId",
                        column: x => x.reporteId,
                        principalTable: "ReporteEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccionesCorrectivasEntity",
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
                    table.PrimaryKey("PK_AccionesCorrectivasEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccionesCorrectivasEntity_ResponsableEntity_responsableId",
                        column: x => x.responsableId,
                        principalTable: "ResponsableEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevisionAccionesCorrectivasEntity",
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
                    table.PrimaryKey("PK_RevisionAccionesCorrectivasEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevisionAccionesCorrectivasEntity_AccionesCorrectivasEntity~",
                        column: x => x.accionesCorrectivasId,
                        principalTable: "AccionesCorrectivasEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RevisionAccionesCorrectivasEntity_UsuarioEntity_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "UsuarioEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccionesCorrectivasEntity_responsableId",
                table: "AccionesCorrectivasEntity",
                column: "responsableId");

            migrationBuilder.CreateIndex(
                name: "IX_CierreEntity_noConformidadId",
                table: "CierreEntity",
                column: "noConformidadId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentoEntity_usuarioId",
                table: "DepartamentoEntity",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_InicadoresEntity_cierreId",
                table: "InicadoresEntity",
                column: "cierreId");

            migrationBuilder.CreateIndex(
                name: "IX_NoConformidadEntity_calidadId",
                table: "NoConformidadEntity",
                column: "calidadId");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteEntity_noConformidadId",
                table: "ReporteEntity",
                column: "noConformidadId");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteEntity_usuarioId",
                table: "ReporteEntity",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsableEntity_noConformidadId",
                table: "ResponsableEntity",
                column: "noConformidadId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionAccionesCorrectivasEntity_accionesCorrectivasId",
                table: "RevisionAccionesCorrectivasEntity",
                column: "accionesCorrectivasId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionAccionesCorrectivasEntity_usuarioId",
                table: "RevisionAccionesCorrectivasEntity",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionReporteEntity_reporteId",
                table: "RevisionReporteEntity",
                column: "reporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_noConformidadId",
                table: "Seguimiento",
                column: "noConformidadId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificacionEfectividadEntity_cierreId",
                table: "VerificacionEfectividadEntity",
                column: "cierreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartamentoEntity");

            migrationBuilder.DropTable(
                name: "InicadoresEntity");

            migrationBuilder.DropTable(
                name: "NotificacionEntity");

            migrationBuilder.DropTable(
                name: "RevisionAccionesCorrectivasEntity");

            migrationBuilder.DropTable(
                name: "RevisionReporteEntity");

            migrationBuilder.DropTable(
                name: "Seguimiento");

            migrationBuilder.DropTable(
                name: "VerificacionEfectividadEntity");

            migrationBuilder.DropTable(
                name: "AccionesCorrectivasEntity");

            migrationBuilder.DropTable(
                name: "ReporteEntity");

            migrationBuilder.DropTable(
                name: "CierreEntity");

            migrationBuilder.DropTable(
                name: "ResponsableEntity");

            migrationBuilder.DropTable(
                name: "NoConformidadEntity");

            migrationBuilder.DropTable(
                name: "UsuarioEntity");
        }
    }
}
