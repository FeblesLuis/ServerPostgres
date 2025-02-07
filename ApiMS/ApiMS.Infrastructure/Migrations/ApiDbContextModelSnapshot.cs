﻿// <auto-generated />
using System;
using System.Collections.Generic;
using ApiMS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiMS.Infrastructure.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiMS.Core.Entities.AccionCorrectivaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.PrimitiveCollection<List<string>>("acciones_correctivas")
                        .HasColumnType("text[]");

                    b.PrimitiveCollection<List<string>>("acciones_preventivas")
                        .HasColumnType("text[]");

                    b.Property<bool?>("estado")
                        .HasColumnType("boolean");

                    b.Property<Guid>("responsableId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("responsableId");

                    b.ToTable("AccionesCorrectivasEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.CierreEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<bool?>("conforme")
                        .HasColumnType("boolean");

                    b.Property<string>("fecha_verificacion")
                        .HasColumnType("text");

                    b.Property<Guid>("noConformidadId")
                        .HasColumnType("uuid");

                    b.Property<string>("observaciones")
                        .HasColumnType("text");

                    b.Property<string>("responsable")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("noConformidadId");

                    b.ToTable("CierreEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.DepartamentoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("cargo")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<Guid>("usuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("usuarioId");

                    b.ToTable("DepartamentoEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.IndicadoresEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("causa")
                        .HasColumnType("text");

                    b.Property<Guid>("cierreId")
                        .HasColumnType("uuid");

                    b.Property<string>("origen")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("cierreId");

                    b.ToTable("InicadoresEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.NoConformidadEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.PrimitiveCollection<List<string>>("areas_involucradas")
                        .HasColumnType("text[]");

                    b.Property<Guid>("calidadId")
                        .HasColumnType("uuid");

                    b.Property<string>("consecuencias")
                        .HasColumnType("text");

                    b.Property<string>("descripcion")
                        .HasColumnType("text");

                    b.Property<int>("estado")
                        .HasColumnType("integer");

                    b.Property<string>("numero_expedicion")
                        .HasColumnType("text");

                    b.Property<int?>("prioridad")
                        .HasColumnType("integer");

                    b.PrimitiveCollection<List<string>>("responsables")
                        .HasColumnType("text[]");

                    b.Property<string>("revisado_por")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("calidadId");

                    b.ToTable("NoConformidadEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.NotificacionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool?>("Revisado")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("dirigido")
                        .HasColumnType("text");

                    b.Property<string>("envia")
                        .HasColumnType("text");

                    b.Property<string>("mensaje")
                        .HasColumnType("text");

                    b.Property<string>("titulo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NotificacionEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.ReporteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("area")
                        .HasColumnType("text");

                    b.Property<string>("descripcion")
                        .HasColumnType("text");

                    b.Property<string>("detectado_por")
                        .HasColumnType("text");

                    b.Property<Guid>("noConformidadId")
                        .HasColumnType("uuid");

                    b.Property<string>("titulo")
                        .HasColumnType("text");

                    b.Property<Guid>("usuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("noConformidadId");

                    b.HasIndex("usuarioId");

                    b.ToTable("ReporteEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.ResponsableEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("analisis_causa")
                        .HasColumnType("text");

                    b.Property<string>("analisis_riesgo")
                        .HasColumnType("text");

                    b.Property<string>("correccion")
                        .HasColumnType("text");

                    b.Property<string>("investigacion")
                        .HasColumnType("text");

                    b.Property<Guid>("noConformidadId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("noConformidadId");

                    b.ToTable("ResponsableEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.RevisionAccionesCorrectivasEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("accionesCorrectivasId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("usuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("accionesCorrectivasId");

                    b.HasIndex("usuarioId");

                    b.ToTable("RevisionAccionesCorrectivasEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.RevisionReporteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<bool?>("estado")
                        .HasColumnType("boolean");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<Guid>("reporteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("reporteId");

                    b.ToTable("RevisionReporteEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.SeguimientoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("estatus")
                        .HasColumnType("text");

                    b.Property<string>("fecha_seguimiento")
                        .HasColumnType("text");

                    b.Property<Guid>("noConformidadId")
                        .HasColumnType("uuid");

                    b.Property<string>("observaciones")
                        .HasColumnType("text");

                    b.Property<string>("realizado_por")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("noConformidadId");

                    b.ToTable("Seguimiento");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.UsuarioEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("apellido")
                        .HasColumnType("text");

                    b.Property<string>("correo")
                        .HasColumnType("text");

                    b.Property<bool?>("estado")
                        .HasColumnType("boolean");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("preguntas_de_seguridad")
                        .HasColumnType("text");

                    b.Property<string>("preguntas_de_seguridad2")
                        .HasColumnType("text");

                    b.Property<string>("respuesta_de_seguridad")
                        .HasColumnType("text");

                    b.Property<string>("respuesta_de_seguridad2")
                        .HasColumnType("text");

                    b.Property<string>("usuario")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UsuarioEntity");

                    b.HasDiscriminator().HasValue("UsuarioEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ApiMS.Core.Entities.VerificacionEfectividadEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("cierreId")
                        .HasColumnType("uuid");

                    b.Property<bool?>("efectiva")
                        .HasColumnType("boolean");

                    b.Property<string>("observaciones")
                        .HasColumnType("text");

                    b.Property<string>("realizado_por")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("cierreId");

                    b.ToTable("VerificacionEfectividadEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.AdministradorEntity", b =>
                {
                    b.HasBaseType("ApiMS.Core.Entities.UsuarioEntity");

                    b.HasDiscriminator().HasValue("AdministradorEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.CalidadEntity", b =>
                {
                    b.HasBaseType("ApiMS.Core.Entities.UsuarioEntity");

                    b.HasDiscriminator().HasValue("CalidadEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.OperarioEntity", b =>
                {
                    b.HasBaseType("ApiMS.Core.Entities.UsuarioEntity");

                    b.HasDiscriminator().HasValue("OperarioEntity");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.AccionCorrectivaEntity", b =>
                {
                    b.HasOne("ApiMS.Core.Entities.ResponsableEntity", "responsable")
                        .WithMany()
                        .HasForeignKey("responsableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("responsable");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.CierreEntity", b =>
                {
                    b.HasOne("ApiMS.Core.Entities.NoConformidadEntity", "noConformidad")
                        .WithMany()
                        .HasForeignKey("noConformidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("noConformidad");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.DepartamentoEntity", b =>
                {
                    b.HasOne("ApiMS.Core.Entities.UsuarioEntity", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.IndicadoresEntity", b =>
                {
                    b.HasOne("ApiMS.Core.Entities.CierreEntity", "cierre")
                        .WithMany()
                        .HasForeignKey("cierreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cierre");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.NoConformidadEntity", b =>
                {
                    b.HasOne("ApiMS.Core.Entities.CalidadEntity", "calidad")
                        .WithMany("noConformidad")
                        .HasForeignKey("calidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("calidad");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.ReporteEntity", b =>
                {
                    b.HasOne("ApiMS.Core.Entities.NoConformidadEntity", "noConformidad")
                        .WithMany()
                        .HasForeignKey("noConformidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiMS.Core.Entities.UsuarioEntity", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("noConformidad");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.ResponsableEntity", b =>
                {
                    b.HasOne("ApiMS.Core.Entities.NoConformidadEntity", "noConformidad")
                        .WithMany()
                        .HasForeignKey("noConformidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("noConformidad");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.RevisionAccionesCorrectivasEntity", b =>
                {
                    b.HasOne("ApiMS.Core.Entities.AccionCorrectivaEntity", "accionesCorrectivas")
                        .WithMany("revisionAccionesCorrectivas")
                        .HasForeignKey("accionesCorrectivasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiMS.Core.Entities.UsuarioEntity", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("accionesCorrectivas");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.RevisionReporteEntity", b =>
                {
                    b.HasOne("ApiMS.Core.Entities.ReporteEntity", "reporte")
                        .WithMany()
                        .HasForeignKey("reporteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("reporte");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.SeguimientoEntity", b =>
                {
                    b.HasOne("ApiMS.Core.Entities.NoConformidadEntity", "noConformidad")
                        .WithMany()
                        .HasForeignKey("noConformidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("noConformidad");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.VerificacionEfectividadEntity", b =>
                {
                    b.HasOne("ApiMS.Core.Entities.CierreEntity", "cierre")
                        .WithMany()
                        .HasForeignKey("cierreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cierre");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.AccionCorrectivaEntity", b =>
                {
                    b.Navigation("revisionAccionesCorrectivas");
                });

            modelBuilder.Entity("ApiMS.Core.Entities.CalidadEntity", b =>
                {
                    b.Navigation("noConformidad");
                });
#pragma warning restore 612, 618
        }
    }
}
