using ApiMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Database
{
    public interface IApiDbContext
    {
        public DbSet<AccionCorrectivaEntity> AccionesCorrectivas { get; set; }
        public DbSet<AdministradorEntity> Administrador { get; set; }
        public DbSet<CalidadEntity> Calidad { get; set; }
        public DbSet<CierreEntity> Cierre { get; set; }
        public DbSet<DepartamentoEntity> Departamento { get; set; }
        public DbSet<IndicadoresEntity> Inicadores { get; set; }
        public DbSet<NoConformidadEntity> NoConformidad { get; set; }
        public DbSet<NotificacionEntity> Notificacion { get; set; }
        public DbSet<OperarioEntity> Operario { get; set; }
        public DbSet<ReporteEntity> Reporte { get; set; }
        public DbSet<ResponsableEntity> Responsable { get; set; }
        public DbSet<RevisionAccionesCorrectivasEntity> RevisionAccionesCorrectivas { get; set; }
        public DbSet<RevisionReporteEntity> RevisionReporte { get; set; }
        public DbSet<SeguimientoEntity> Seguimiento { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<VerificacionEfectividadEntity> VerificacionEfectividad { get; set; }

        DbContext DbContext
        {
            get;
        }

        IDbContextTransactionProxy BeginTransaction();

        void ChangeEntityState<TEntity>(TEntity entity, EntityState state);

        Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default);
    }
}
