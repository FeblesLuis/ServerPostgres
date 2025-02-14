using ApiMS.Application.Commands.Acciones;
using ApiMS.Application.Commands.NoConformidad;
using ApiMS.Application.Mappers.Acciones;
using ApiMS.Application.Mappers.NoConformidad;
using ApiMS.Application.Mappers.Notificacion;
using ApiMS.Application.Mappers.R_Acciones_Usuario;
using ApiMS.Application.Mappers.R_Calidad_NoConformidadMapper;
using ApiMS.Application.Mappers.Responsable;
using ApiMS.Application.Requests.Notificacion;
using ApiMS.Application.Responses.Acciones;
using ApiMS.Application.Responses.NoConformidad;
using ApiMS.Application.Responses.Reportes;
using ApiMS.Infrastructure.Database;
using MassTransit.Topology;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiMS.Application.Handlers.Commands.Acciones
{
    public  class AgregarAccionesHandler : IRequestHandler<AgregarAccionesCommand, IdAccionesResponse>
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<AgregarAccionesHandler> _logger;
        public AgregarAccionesHandler(ApiDbContext dbContext, ILogger<AgregarAccionesHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public Task<IdAccionesResponse> Handle(AgregarAccionesCommand request, CancellationToken cancellationToken)
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

        private async Task<IdAccionesResponse> HandleAsync(AgregarAccionesCommand request)
        {
            var transaccion = _dbContext.BeginTransaction();
            try
            {

                var responsable = _dbContext.Responsable
                                            .Where(n => n.Id == request._request.responsable_Id)
                                            .Select(n => new 
                                            {
                                                noConformidad = n.noConformidad.reporte.titulo,
                                            }).FirstOrDefault();

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Crear una instancia de Responsable con los datos del request
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (request._request.Correctivas_Id != null)
                {
                    var entity = AccionesMapper.MapPreventivasEntity(request._request);

                    // Agregar el usuario al DbContext
                    _dbContext.Preventivas.Add(entity);
                    await _dbContext.SaveEfContextChanges("APP");

                    var relacion = R_Acciones_UsuarioMapper.MapR_Acciones_UsuarioEntity(entity.Id, (Guid)request._request.usuario_Id);
                    _dbContext.R_Acciones_Usuario.Add(relacion);
                    await _dbContext.SaveEfContextChanges("APP");

                    return new IdAccionesResponse(entity.Id);
                }
                else 
                {
                    var entity = AccionesMapper.MapCorrectivasEntity(request._request);

                    // Agregar el usuario al DbContext
                    _dbContext.Correctivas.Add(entity);
                    await _dbContext.SaveEfContextChanges("APP");

                    var relacion = R_Acciones_UsuarioMapper.MapR_Acciones_UsuarioEntity(entity.Id, (Guid)request._request.usuario_Id);
                    _dbContext.R_Acciones_Usuario.Add(relacion);
                    await _dbContext.SaveEfContextChanges("APP");

                    return new IdAccionesResponse(entity.Id);
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Genero la notificacion
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error AgregarOperarioHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }

        }

    }
}

