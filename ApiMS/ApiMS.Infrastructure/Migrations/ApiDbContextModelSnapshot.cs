﻿// <auto-generated />
using System;
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
#pragma warning restore 612, 618
        }
    }
}
