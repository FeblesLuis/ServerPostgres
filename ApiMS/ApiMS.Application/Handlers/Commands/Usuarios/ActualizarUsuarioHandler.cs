using ApiMS.Application.Commands.Usuario;
using ApiMS.Application.Mappers.Departamento;
using ApiMS.Application.Mappers.Usuario;
using ApiMS.Application.Requests.Departamento;
using ApiMS.Application.Responses.Usuarios;
using ApiMS.Core.Entities;
using ApiMS.Infrastructure.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Handlers.Commands.Usuarios
{
    public class ActualizarUsuarioHandler : IRequestHandler<ActualizarUsuarioCommand, IdUsuarioResponse>
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<ActualizarUsuarioHandler> _logger;
        public ActualizarUsuarioHandler(ApiDbContext dbContext, ILogger<ActualizarUsuarioHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<IdUsuarioResponse> Handle(ActualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null) //Pregunto si el request es nulo
                {
                    _logger.LogWarning("AgregarOperarioHandler.Handle: Request nulo.");
                    throw new ArgumentNullException(nameof(request));

                }
                else
                {
                    return HandleAsync(request);
                }
            }
            catch (Exception)
            {
                _logger.LogWarning("AgregarOperarioHandler.Handle: ArgumentNullException");
                throw;
            }
        }

        private async Task<IdUsuarioResponse> HandleAsync(ActualizarUsuarioCommand request)
        {
            var transaccion = _dbContext.BeginTransaction();
            try
            {
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Pregunto si el usuario existe
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                var usuario = _dbContext.Usuario.FirstOrDefault(c => c.Id == request._request.id);
                if (usuario == null)
                {
                    throw new InvalidOperationException("Registro fallido: el usuario NO existe");
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Actualizo el Usuario
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                // Actualizar propiedades solo si no están vacías o nulas
                if (!string.IsNullOrEmpty(request._request.primer_nombre))
                    usuario.nombre = request._request.nombre;

                if (!string.IsNullOrEmpty(request._request.primer_apellido))
                    usuario.apellido = request._request.apellido;

                if (!string.IsNullOrEmpty(request._request.password))
                    usuario.password = request._request.password;

                if (!string.IsNullOrEmpty(request._request.correo))
                    usuario.correo = request._request.correo;

                if (!string.IsNullOrEmpty(request._request.preguntas_de_seguridad))
                    usuario.preguntas_de_seguridad = request._request.preguntas_de_seguridad;

                if (!string.IsNullOrEmpty(request._request.preguntas_de_seguridad2))
                    usuario.preguntas_de_seguridad2 = request._request.preguntas_de_seguridad2;

                if (!string.IsNullOrEmpty(request._request.respuesta_de_seguridad))
                    usuario.respuesta_de_seguridad = request._request.respuesta_de_seguridad;

                if (!string.IsNullOrEmpty(request._request.respuesta_de_seguridad2))
                    usuario.respuesta_de_seguridad2 = request._request.respuesta_de_seguridad2;

                if (request._request.estado.HasValue)
                    usuario.estado = request._request.estado.Value;

                // Guardar cambios
                _dbContext.Usuario.Update(usuario);
                await _dbContext.SaveEfContextChanges("APP");
                transaccion.Commit();

                _logger.LogInformation("Usuario actualizado correctamente. ID: {UsuarioId}", usuario.Id);
                return new IdUsuarioResponse(usuario.Id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error AgregarOperarioHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }

        }
    }
}
