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

}
