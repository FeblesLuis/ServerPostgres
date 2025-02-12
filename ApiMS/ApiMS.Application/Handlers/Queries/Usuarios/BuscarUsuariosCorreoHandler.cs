﻿using ApiMS.Application.Queries.Usuarios;
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
    public class BuscarUsuariosCorreoHandler : IRequestHandler<BuscarUsuariosCorreoQuery, List<UsuarioResponse>>
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<BuscarUsuariosCorreoHandler> _logger;
        public BuscarUsuariosCorreoHandler(ApiDbContext dbContext, ILogger<BuscarUsuariosCorreoHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<List<UsuarioResponse>> Handle(BuscarUsuariosCorreoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null) //Pregunto si el request es nulo
                {
                    _logger.LogWarning("BuscarUsuariosCorreoHandler.Handle: Request nulo.");
                    throw new ArgumentNullException(nameof(request));

                }
                else
                {
                    return HandleAsync(request);
                }
            }
            catch (Exception)
            {
                _logger.LogWarning("BuscarUsuariosCorreoHandler.Handle: ArgumentNullException");
                throw;
            }
        }

        private async Task<List<UsuarioResponse>> HandleAsync(BuscarUsuariosCorreoQuery request)
        {

            try
            {
                _logger.LogInformation("BuscarUsuariosCorreoHandler.HandleAsync");
                var result = _dbContext.Usuario.Count(c => c.correo == request._request.data);

                if (result == 0) //Verifico que el Usuario exista
                {
                    throw new InvalidOperationException("No se encontro al usuario registrado");
                }

                // Realizar una consulta que una Usuario y Departamento
                var usuariosConDepartamento = _dbContext.Usuario
                    .Where(c => c.correo.ToLower().Contains(request._request.data.ToLower())) // Filtra por el correo del usuario
                    .Join(
                        _dbContext.Departamento, // Une con la tabla Departamento
                        usuario => usuario.Id, // Clave foránea en Usuario (ID del usuario)
                        departamento => departamento.usuario.Id, // Clave primaria en Departamento (ID del usuario)
                        (usuario, departamento) => new UsuarioResponse //Relleno el response
                        {
                            id = usuario.Id,
                            CreatedAt = usuario.CreatedAt,
                            CreatedBy = usuario.CreatedBy,
                            UpdatedAt = usuario.UpdatedAt,
                            UpdatedBy = usuario.UpdatedBy,

                            usuario = usuario.usuario,
                            nombre = usuario.nombre,
                            apellido = usuario.apellido,
                            password = usuario.password,
                            correo = usuario.correo,
                            discriminator = EF.Property<string>(usuario, "Discriminator"),
                            respuesta_de_seguridad = usuario.respuesta_de_seguridad,
                            respuesta_de_seguridad2 = usuario.respuesta_de_seguridad2,
                            preguntas_de_seguridad = usuario.preguntas_de_seguridad,
                            preguntas_de_seguridad2 = usuario.preguntas_de_seguridad2,
                            estado = usuario.estado,
                            departamento = new BuscarDepartamentoResponse // Asigna el departamento correspondiente
                            {
                                id = departamento.Id,
                                CreatedAt = departamento.CreatedAt,
                                CreatedBy = departamento.CreatedBy,
                                UpdatedAt = departamento.UpdatedAt,
                                UpdatedBy = departamento.UpdatedBy,

                                nombreDepartamento = departamento.nombre,
                                cargo = departamento.cargo
                            }
                        }
                    )
                    .ToList(); // Genera la consulta en una lista

                return usuariosConDepartamento; //Retorno la lista
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error BuscarUsuariosCorreoHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }



        }
    }
}
