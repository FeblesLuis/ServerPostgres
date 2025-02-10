using ApiMS.Application.Queries.Usuarios;
using ApiMS.Application.Responses.Usuarios;
using ApiMS.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Handlers.Queries.Usuarios
{
    public class BuscarUsuarioIdHandler : IRequestHandler<BuscarUsuarioIdQuery, BuscarUsuarioResponse>
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<BuscarUsuarioIdHandler> _logger;
        public BuscarUsuarioIdHandler(ApiDbContext dbContext, ILogger<BuscarUsuarioIdHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<BuscarUsuarioResponse> Handle(BuscarUsuarioIdQuery request, CancellationToken cancellationToken)
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

        private async Task<BuscarUsuarioResponse> HandleAsync(BuscarUsuarioIdQuery request)
        {

            try
            {
                _logger.LogInformation("ConsultarUsuarioIdQueryHandler.HandleAsync");
                var result = _dbContext.Usuario.Count(c => c.Id == request._request.data);

                if (result == 0) //Verifico que el Usuario exista
                {
                    throw new InvalidOperationException("No se encontro al usuario registrado");
                }

                //Traigo el ID del usuario para saber el departamento
                var usuarioId = _dbContext.Usuario.Where(c => c.Id == request._request.data).Select(c => new BuscarUsuarioResponse() { id = c.Id, });

                //Traigo al departmento
                var departamentoObj = _dbContext.Departamento
                 .Where(d => d.usuario.Id == usuarioId.FirstOrDefault().id) // Usar el ID del departamento
                 .Select(d => new BuscarDepartamentoResponse
                 {
                     nombreDepartamento = d.nombre,
                     cargo = d.cargo
                 });

                //Traigo al usuario
                var usuario = _dbContext.Usuario.Where(c => c.Id == request._request.data)
                .Select(c => new BuscarUsuarioResponse() //Traemos al usuario de la bd
                {
                    id = c.Id,
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
                    departamento = new BuscarDepartamentoResponse
                    {
                        nombreDepartamento = departamentoObj.FirstOrDefault().nombreDepartamento,
                        cargo = departamentoObj.FirstOrDefault().cargo
                    }
                });

                return await usuario.FirstAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ConsultarUsuarioIdQueryHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }



        }
    }
}

