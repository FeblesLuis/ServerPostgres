using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    usuario_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_Usuario_usuario_Id",
                        column: x => x.usuario_Id,
                        principalTable: "Usuario",
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
                    usuario_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reporte_Usuario_usuario_Id",
                        column: x => x.usuario_Id,
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
                    calidad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reporte_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CalidadEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoConformidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoConformidad_Reporte_reporte_Id",
                        column: x => x.reporte_Id,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoConformidad_Usuario_CalidadEntityId",
                        column: x => x.CalidadEntityId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NoConformidad_Usuario_calidad_id",
                        column: x => x.calidad_id,
                        principalTable: "Usuario",
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
                    reporte_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevisionReporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevisionReporte_Reporte_reporte_Id",
                        column: x => x.reporte_Id,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RevisionReporte_Usuario_usuario_Id",
                        column: x => x.usuario_Id,
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
                    noConformidad_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cierre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cierre_NoConformidad_noConformidad_Id",
                        column: x => x.noConformidad_Id,
                        principalTable: "NoConformidad",
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
                    noConformidad_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsable_NoConformidad_noConformidad_Id",
                        column: x => x.noConformidad_Id,
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
                    noConformidad_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguimiento_NoConformidad_noConformidad_Id",
                        column: x => x.noConformidad_Id,
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
                    cierre_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inicadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inicadores_Cierre_cierre_Id",
                        column: x => x.cierre_Id,
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
                    cierre_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificacionEfectividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificacionEfectividad_Cierre_cierre_Id",
                        column: x => x.cierre_Id,
                        principalTable: "Cierre",
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
                    responsable_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionesCorrectivas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccionesCorrectivas_Responsable_responsable_Id",
                        column: x => x.responsable_Id,
                        principalTable: "Responsable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevisionAccionesCorrectivas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    accionesCorrectivas_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccionCorrectivaEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevisionAccionesCorrectivas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevisionAccionesCorrectivas_AccionesCorrectivas_AccionCorre~",
                        column: x => x.AccionCorrectivaEntityId,
                        principalTable: "AccionesCorrectivas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RevisionAccionesCorrectivas_AccionesCorrectivas_accionesCor~",
                        column: x => x.accionesCorrectivas_Id,
                        principalTable: "AccionesCorrectivas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RevisionAccionesCorrectivas_Usuario_usuario_Id",
                        column: x => x.usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccionesCorrectivas_responsable_Id",
                table: "AccionesCorrectivas",
                column: "responsable_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cierre_noConformidad_Id",
                table: "Cierre",
                column: "noConformidad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_usuario_Id",
                table: "Departamento",
                column: "usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inicadores_cierre_Id",
                table: "Inicadores",
                column: "cierre_Id");

            migrationBuilder.CreateIndex(
                name: "IX_NoConformidad_calidad_id",
                table: "NoConformidad",
                column: "calidad_id");

            migrationBuilder.CreateIndex(
                name: "IX_NoConformidad_CalidadEntityId",
                table: "NoConformidad",
                column: "CalidadEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_NoConformidad_reporte_Id",
                table: "NoConformidad",
                column: "reporte_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_usuario_Id",
                table: "Reporte",
                column: "usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Responsable_noConformidad_Id",
                table: "Responsable",
                column: "noConformidad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionAccionesCorrectivas_AccionCorrectivaEntityId",
                table: "RevisionAccionesCorrectivas",
                column: "AccionCorrectivaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionAccionesCorrectivas_accionesCorrectivas_Id",
                table: "RevisionAccionesCorrectivas",
                column: "accionesCorrectivas_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionAccionesCorrectivas_usuario_Id",
                table: "RevisionAccionesCorrectivas",
                column: "usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionReporte_reporte_Id",
                table: "RevisionReporte",
                column: "reporte_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionReporte_usuario_Id",
                table: "RevisionReporte",
                column: "usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_noConformidad_Id",
                table: "Seguimiento",
                column: "noConformidad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VerificacionEfectividad_cierre_Id",
                table: "VerificacionEfectividad",
                column: "cierre_Id");
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
                name: "Cierre");

            migrationBuilder.DropTable(
                name: "Responsable");

            migrationBuilder.DropTable(
                name: "NoConformidad");

            migrationBuilder.DropTable(
                name: "Reporte");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
