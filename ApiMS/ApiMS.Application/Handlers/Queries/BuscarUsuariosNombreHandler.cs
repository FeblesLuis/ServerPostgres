using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ApiMS.Application.Queries;
using ApiMS.Application.Responses;
using ApiMS.Infrastructure.Database;
using ApiMS.Application.Requests;
using ApiMS.Core.Entities;


namespace ApiMS.Application.Handlers.Queries;

public class BuscarUsuariosNombreHandler : IRequestHandler<BuscarUsuariosNombreQuery, List<BuscarUsuariosNombreResponse>>
{
    private readonly ApiDbContext _dbContext;
    private readonly ILogger<BuscarUsuariosNombreHandler> _logger;
    public BuscarUsuariosNombreHandler(ApiDbContext dbContext, ILogger<BuscarUsuariosNombreHandler> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<List<BuscarUsuariosNombreRequest>> Handle(BuscarUsuariosNombreQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) //Pregunto si el request es nulo
            {
                _logger.LogWarning("ConsultarUsuarioIdQueryHandler.Handle: Request nulo.");
                throw new ArgumentNullException(nameof(request));

            }
            else
            {
                return HandleAsync(request);
            }
        }
        catch (Exception)
        {
            _logger.LogWarning("ConsultarUsuariosQueryHandler.Handle: ArgumentNullException");
            throw;
        }
    }

    private async Task<List<BuscarUsuariosNombreRequest>> HandleAsync(BuscarUsuariosNombreQuery request)
    {

        try
        {
            _logger.LogInformation("ConsultarUsuarioIdQueryHandler.HandleAsync");


            var result = _dbContext.UsuarioEntity
                .Where(u => u.nombre.Contains(request._request.nombre.Trim()))
                .Select(c => new BuscarUsuariosNombreResponse()
                {
                    usuario = c.usuario,
                    nombre = c.nombre,
                    apellido = c.apellido,
                    password = c.password,
                    correo = c.correo,
                    discriminator = EF.Property<string>(c, "Discriminator"),
                    respuesta_de_seguridad = c.respuesta_de_seguridad,
                    respuesta_de_seguridad2 = c.respuesta_de_seguridad2,
                    preguntas_de_seguridad = c.preguntas_de_seguridad,
                    preguntas_de_seguridad2 = c.preguntas_de_seguridad2,
                    estado = c.estado,
                    cargo = c.departamento.cargo,
                    departamento = c.departamento.nombre
                });

            return await result.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ConsultarUsuarioIdQueryHandler.HandleAsync. {Mensaje}", ex.Message);
            throw;
        }



    }

}
