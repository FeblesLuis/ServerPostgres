using ApiMS.Core.Database;
using ApiMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Reflection;


namespace ApiMS.Infrastructure.Database;

public class ApiDbContext : DbContext , IApiDbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<AccionCorrectivaEntity> AccionesCorrectivas { get; set; }
    public DbSet<AdministradorEntity> Administrador { get; set; }
    public DbSet<CalidadEntity> Calidad { get; set; }
    public DbSet<CierreEntity> Cierre { get; set; }
    public DbSet<DepartamentoEntity> Departamento { get;set; }
    public DbSet<IndicadoresEntity> Inicadores { get; set; }
    public DbSet<NoConformidadEntity> NoConformidad { get; set; }
    public DbSet<NotificacionEntity> Notificacion { get; set; }
    public DbSet<OperarioEntity> Operario { get; set; }
    public DbSet<ReporteEntity> Reporte { get; set; }
    public DbSet<ResponsableEntity> Responsable { get;set; }
    public DbSet<RevisionAccionesCorrectivasEntity> RevisionAccionesCorrectivas { get; set; }
    public DbSet<RevisionReporteEntity> RevisionReporte { get; set; }
    public DbSet<SeguimientoEntity> Seguimiento {  get; set; }
    public DbSet<UsuarioEntity> Usuario { get; set; }
    public DbSet<VerificacionEfectividadEntity> VerificacionEfectividad { get; set; }


    public DbContext DbContext
    {
        get
        {
            return this;
        }
    }

    
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///             RELACIONES FK
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ///////////////////////////////////////////////////////////////////////////////
        // Configurar la relación entre AccionCorrectivaEntity y ResponsableEntity
        modelBuilder.Entity<AccionCorrectivaEntity>()
            .HasOne(r => r.responsable)
            .WithMany()
            .HasForeignKey(r => r.responsable_Id);


        ///////////////////////////////////////////////////////////////////////////////
        // Configurar la relación entre CierreEntity y NoConformidadEntity
        modelBuilder.Entity<CierreEntity>()
            .HasOne(r => r.noConformidad)
            .WithMany()
            .HasForeignKey(r => r.noConformidad_Id);


        ///////////////////////////////////////////////////////////////////////////////
        // Configurar la relación entre DepartamentoEntity y UsuarioEntity
        modelBuilder.Entity<DepartamentoEntity>()
            .HasOne(r => r.usuario)
            .WithMany()
            .HasForeignKey(r => r.usuario_Id);


        ///////////////////////////////////////////////////////////////////////////////
        // Configurar la relación entre IndicadoresEntity y CierreEntity
        modelBuilder.Entity<IndicadoresEntity>()
            .HasOne(r => r.cierre)
            .WithMany()
            .HasForeignKey(r => r.cierre_Id);


        ///////////////////////////////////////////////////////////////////////////////
        // Configurar la relación entre NoConformidadEntity y CalidadEntity
        modelBuilder.Entity<NoConformidadEntity>()
            .HasOne(r => r.calidad)
            .WithMany()
            .HasForeignKey(r => r.calidad_id);

        // Configurar la relación entre NoConformidadEntity y reporteEntity
        modelBuilder.Entity<NoConformidadEntity>()
            .HasOne(r => r.reporte)
            .WithMany()
            .HasForeignKey(r => r.reporte_Id);


        ///////////////////////////////////////////////////////////////////////////////
        // Configurar la relación entre ReporteEntity y UsuariosEntity
        modelBuilder.Entity<ReporteEntity>()
            .HasOne(r => r.usuario)
            .WithMany()
            .HasForeignKey(r => r.usuario_Id);


        ///////////////////////////////////////////////////////////////////////////////
        // Configurar la relación entre ReporteEntity y NoConformidadEntity
        modelBuilder.Entity<ResponsableEntity>()
            .HasOne(r => r.noConformidad)
            .WithMany()
            .HasForeignKey(r => r.noConformidad_Id);


        ///////////////////////////////////////////////////////////////////////////////
        // Configurar la relación entre RevisionAccionesCorrectivasEntity y AccionCorrectivaEntity
        modelBuilder.Entity<RevisionAccionesCorrectivasEntity>()
            .HasOne(r => r.accionesCorrectivas)
            .WithMany()
            .HasForeignKey(r => r.accionesCorrectivas_Id);

        // Configurar la relación entre RevisionAccionesCorrectivasEntity y UsuarioEntity
        modelBuilder.Entity<RevisionAccionesCorrectivasEntity>()
            .HasOne(r => r.usuario)
            .WithMany()
            .HasForeignKey(r => r.usuario_Id);


        ///////////////////////////////////////////////////////////////////////////////
        // Configurar la relación entre RevisionReporteEntity y ReporteEntity
        modelBuilder.Entity<RevisionReporteEntity>()
            .HasOne(r => r.reporte)
            .WithMany()
            .HasForeignKey(r => r.reporte_Id);

        // Configurar la relación entre RevisionReporteEntity y UsuarioEntity
        modelBuilder.Entity<RevisionReporteEntity>()
            .HasOne(r => r.usuario)
            .WithMany()
            .HasForeignKey(r => r.usuario_Id);


        ///////////////////////////////////////////////////////////////////////////////
        // Configurar la relación entre SeguimientoEntity y NoConformidadEntity
        modelBuilder.Entity<SeguimientoEntity>()
            .HasOne(r => r.noConformidad)
            .WithMany()
            .HasForeignKey(r => r.noConformidad_Id);


        ///////////////////////////////////////////////////////////////////////////////
        // Configurar la relación entre VerificacionEfectividadEntity y CierreEntity
        modelBuilder.Entity<VerificacionEfectividadEntity>()
            .HasOne(r => r.cierre)
            .WithMany()
            .HasForeignKey(r => r.cierre_Id);
    }


    public IDbContextTransactionProxy BeginTransaction()
    {
        return new DbContextTransactionProxy(this);
    }

    virtual public void SetPropertyIsModifiedToFalse<TEntity, TProperty>(TEntity entity,
        Expression<Func<TEntity, TProperty>> propertyExpression) where TEntity : class
    {
        Entry(entity).Property(propertyExpression).IsModified = false;
    }

    virtual public void ChangeEntityState<TEntity>(TEntity entity, EntityState state)
    {
        if (entity != null)
        {
            Entry(entity).State = state;
        }
    }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
                Entry((BaseEntity)entityEntry.Entity).Property(x => x.CreatedAt).IsModified = false;
                Entry((BaseEntity)entityEntry.Entity).Property(x => x.CreatedBy).IsModified = false;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> SaveChangesAsync(string user, CancellationToken cancellationToken = default)
    {
        var state = new List<EntityState> { EntityState.Added, EntityState.Modified };

        var entries = ChangeTracker.Entries().Where(e =>
            e.Entity is BaseEntity && state.Any(s => e.State == s)
        );

        var dt = DateTime.UtcNow;

        foreach (var entityEntry in entries)
        {
            var entity = (BaseEntity)entityEntry.Entity;

            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedAt = dt;
                entity.CreatedBy = user;
                Entry(entity).Property(x => x.UpdatedAt).IsModified = false;
                Entry(entity).Property(x => x.UpdatedBy).IsModified = false;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entity.UpdatedAt = dt;
                entity.UpdatedBy = user;
                Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                Entry(entity).Property(x => x.CreatedBy).IsModified = false;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> SaveEfContextChanges(CancellationToken cancellationToken = default)
    {
        return await SaveChangesAsync(cancellationToken) >= 0;
    }

    public async Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default)
    {
        return await SaveChangesAsync(user, cancellationToken) >= 0;
    }

}
