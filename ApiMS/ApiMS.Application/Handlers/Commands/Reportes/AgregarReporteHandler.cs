using ApiMS.Application.Commands.Reportes;
using ApiMS.Application.Mappers.Reporte;
using ApiMS.Application.Mappers.RevisionReporte;
using ApiMS.Application.Requests.RevisionReporte;
using ApiMS.Application.Responses.Reportes;
using ApiMS.Application.Responses.Usuarios;
using ApiMS.Core.Entities;
using ApiMS.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Handlers.Commands.Reportes
{
    public class AgregarReporteHandler : IRequestHandler<AgregarReporteCommand, IdReporteResponse>
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<AgregarReporteHandler> _logger;
        public AgregarReporteHandler(ApiDbContext dbContext, ILogger<AgregarReporteHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }


        public Task<IdReporteResponse> Handle(AgregarReporteCommand request, CancellationToken cancellationToken)
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

        private async Task<IdReporteResponse> HandleAsync(AgregarReporteCommand request)
        {
            var transaccion = _dbContext.BeginTransaction();
            try
            {
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Busco el nombre del departamento
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var dep_usuario = _dbContext.Usuario
                                                .Where(u => u.Id == request._request.id) // Filtra por el Id del usuario
                                                .Select(u => new
                                                {
                                                    NombreDepartamento = _dbContext.Departamento
                                                                            .Where(d => d.usuario.Id == u.Id) // Filtra el departamento del usuario
                                                                            .Select(d => d.nombre)
                                                                            .FirstOrDefault()
                                                })
                                                .FirstOrDefault(); // Obtiene el primer resultado

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Busco al usuario gerente de ese departamento
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                var departamentoConUsuarios = _dbContext.Departamento
                                                            .Where(d => d.nombre == dep_usuario.NombreDepartamento && d.cargo.ToLower().Contains("gerente")) // Filtra por el nombre del departamento
                                                            .SelectMany(d => _dbContext.Usuario
                                                                                            .Where(u => u.Id == d.usuario.Id) // Filtra los usuarios en el departamento
                                                                                            .Select(u => new UsuarioResponse // Proyecta el usuario asociado
                                                                                            {
                                                                                                id = u.Id,
                                                                                                nombre = u.nombre,
                                                                                                departamento = new BuscarDepartamentoResponse // Asigna el departamento correspondiente
                                                                                                {
                                                                                                    cargo = d.cargo,
                                                                                                    nombreDepartamento = d.nombre,
                                                                                                }
                                                                                            }))
                                                            .FirstOrDefault(); // Genera la consulta en una lista


                var usuario = new UsuarioEntity { Id = (Guid)departamentoConUsuarios.id };
                //Agrego el reporte

                var reporte = ReporteMapper.MapRequestReporteEntity(request._request, usuario);
                _dbContext.Reporte.Add(reporte);
                await _dbContext.SaveEfContextChanges("APP");

                // Agregar el Departamento al DbContext
                var revisionRequest = new RevisionReporteRequest();
                revisionRequest.nombre = departamentoConUsuarios.nombre;
                revisionRequest.estado = false;
                var revision = RevisionReporteMapper.MapRequestRevisionReporteEntity(revisionRequest, usuario, reporte);


                _dbContext.RevisionReporte.Add(revision);
                await _dbContext.SaveEfContextChanges("APP");



                return new IdReporteResponse(reporte.Id);



            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error AgregarOperarioHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }



        }

    }

}