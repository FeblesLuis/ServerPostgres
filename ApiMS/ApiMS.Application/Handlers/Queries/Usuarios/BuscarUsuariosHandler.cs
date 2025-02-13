using ApiMS.Application.Queries.Usuarios;
using ApiMS.Application.Responses.Departamento;
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
    public class BuscarUsuariosHandler : IRequestHandler<BuscarUsuariosQuery, List<UsuarioResponse>>
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<BuscarUsuariosHandler> _logger;
        public BuscarUsuariosHandler(ApiDbContext dbContext, ILogger<BuscarUsuariosHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<List<UsuarioResponse>> Handle(BuscarUsuariosQuery request, CancellationToken cancellationToken)
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

        private async Task<List<UsuarioResponse>> HandleAsync(BuscarUsuariosQuery request)
        {

            try
            {


                // Realizar una consulta que una Usuario y Departamento
                var usuariosConDepartamento = _dbContext.Usuario
                .Where(c => c.nombre.ToLower().Contains(request._request.data.ToLower()) || // Busca en el nombre
                            c.apellido.ToLower().Contains(request._request.data.ToLower())
                            ) // Busca en el apellido) // Búsqueda insensible a mayúsculas y minúsculas
                            .Select(c => new UsuarioResponse // Rellena el response
                            {
                                id = c.Id,
                                CreatedAt = c.CreatedAt,
                                CreatedBy = c.CreatedBy,
                                UpdatedAt = c.UpdatedAt,
                                UpdatedBy = c.UpdatedBy,

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
                                departamento = new DepartamentoResponse // Asigna el departamento correspondiente
                                {
                                    id = c.departamento.Id,
                                    CreatedAt = c.departamento.CreatedAt,
                                    CreatedBy = c.departamento.CreatedBy,
                                    UpdatedAt = c.departamento.UpdatedAt,
                                    UpdatedBy = c.departamento.UpdatedBy,

                                    nombreDepartamento = c.departamento.nombre,
                                    cargo = c.departamento.cargo
                                }
                            }).ToList();

                return usuariosConDepartamento; //Retorno la lista
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ConsultarUsuarioIdQueryHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }



        }
    }
}
