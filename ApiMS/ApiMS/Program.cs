using ApiMS.Application.Queries.Usuarios;
using ApiMS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// crear variable para la cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//registrar servicio para la conexion
builder.Services.AddDbContext<ApiDbContext>(
    options => options.UseNpgsql(connectionString)
    );

// Registrar MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(BuscarUsuariosNombreQuery).Assembly));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
