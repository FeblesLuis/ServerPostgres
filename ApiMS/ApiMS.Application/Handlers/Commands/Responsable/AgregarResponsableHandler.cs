using ApiMS.Application.Commands.Responsable;
using ApiMS.Application.Mappers.Notificacion;
using ApiMS.Application.Mappers.Responsable;
using ApiMS.Application.Requests.Notificacion;
using ApiMS.Application.Responses.Reportes;
using ApiMS.Core.Entities;
using ApiMS.Infrastructure.Database;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiMS.Application.Handlers.Commands.Responsable
{
    public class AgregarResponsableHandler : IRequestHandler<AgregarResponsableCommand, IdResponsableResponse>
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<AgregarResponsableHandler> _logger;
        public AgregarResponsableHandler(ApiDbContext dbContext, ILogger<AgregarResponsableHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<IdResponsableResponse> Handle(AgregarResponsableCommand request, CancellationToken cancellationToken)
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

        private async Task<IdResponsableResponse> HandleAsync(AgregarResponsableCommand request)
        {
            var transaccion = _dbContext.BeginTransaction();
            try
            {
                // Crear una instancia de Responsable con los datos del request
                var entity = ResponsableMapper.MapResponsableMapperEntity(request._request);

                // Agregar el usuario al DbContext
                _dbContext.Responsable.Add(entity);
                await _dbContext.SaveEfContextChanges("APP");


                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Genero la notificacion
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var noConformidad = _dbContext.NoConformidad.Where(n => n.Id == request._request.noConformidad_Id).FirstOrDefault();
                var reporte = _dbContext.Reporte.Where(r => r.Id == noConformidad.reporte_Id).FirstOrDefault();
                var usuario = _dbContext.Usuario.Where(u => u.Id == request._request.usuario_Id).FirstOrDefault();

                var notificacion = NotificacionMapper.MapRequestNotificacionEntity(new NotificacionRequest(reporte.titulo, "Garantia de calidad", usuario.correo, "Se ha diferido una no conformidad a su departamento", false));
                _dbContext.Notificacion.Add(notificacion);
                await _dbContext.SaveEfContextChanges("APP");
                transaccion.Commit();

                //Retorno ID
                return new IdResponsableResponse(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error AgregarOperarioHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }

        }
    }
}
