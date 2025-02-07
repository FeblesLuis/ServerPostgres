using ApiMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;


namespace ApiMS.Infrastructure.Database;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<UsuarioEntity> UsuarioEntity { get; set; }
    public DbSet<AdministradorEntity> AdministradorEntity { get; set; }
    public DbSet<OperarioEntity> OperarioEntity { get; set; }

    public DbSet<CalidadEntity> CalidadEntity { get; set; }

    public DbSet<DepartamentoEntity> DepartamentoEntity { get;set; }

    public DbSet<RevisionEntity> RevisionEntity { get; set; }
    public DbSet<ReporteEntity> ReporteEntity { get; set; }

    public DbSet<NoConformidadEntity> NoConformidadEntity { get; set; }

    public DbSet<ResponsableEntity> ResponsableEntity { get;set; }

    public DbSet<AccionesCorrectivasEntity> AccionesCorrectivasEntity { get; set; }

    public DbSet<CierreEntity> CierreEntity { get; set; }

    public DbSet<SeguimientoEntity> SeguimientoEntity { get; set;}

    public DbSet<VerificacionEfectividadEntity> verificacionEfectividadEntity { get; set; }

    public DbSet<IndicadoresEntity> InicadoresEntity { get; set; }

}
