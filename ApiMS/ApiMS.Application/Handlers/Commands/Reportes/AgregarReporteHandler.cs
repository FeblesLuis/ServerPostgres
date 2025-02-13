﻿using ApiMS.Application.Commands.Reportes;
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
                                            .Select(u => new UsuarioEntity
                                            {
                                                 departamento = u.departamento
                                            })
                                            .FirstOrDefault(); // Obtiene el primer resultado

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Busco al usuario gerente de ese departamento
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                var gerente = _dbContext.Usuario
                                        .Where(u => u.departamento.nombre == dep_usuario.departamento.nombre && u.departamento.cargo.Contains("Gerente"))
                                        .Select(u => new UsuarioResponse
                                        {
                                               id = u.Id,
                                               nombre= u.nombre,
                                               apellido= u.apellido,
                                        }).FirstOrDefault();

                //Agrego el reporte

                var reporte = ReporteMapper.MapRequestReporteEntity(request._request, (Guid)request._request.id);
                _dbContext.Reporte.Add(reporte);
                await _dbContext.SaveEfContextChanges("APP");

                // Agregar el RevisionReporte al DbContext

                var revisionRequest = new RevisionReporteRequest();
                revisionRequest.nombre = gerente.nombre + " " + gerente.apellido;
                revisionRequest.estado = false;

                var revision = RevisionReporteMapper.MapRequestRevisionReporteEntity(revisionRequest, reporte, (Guid)gerente.id);
                _dbContext.RevisionReporte.Add(revision);
                await _dbContext.SaveEfContextChanges("APP");
                transaccion.Commit();

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