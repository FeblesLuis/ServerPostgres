using ApiMS.Application.Queries.Usuarios;
using ApiMS.Application.Responses.Usuarios;
using ApiMS.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace ApiMS.Application.Handlers.Queries.Usuarios
{
    public class BuscarUsuariosDepartamentoHandler : IRequestHandler<BuscarUsuariosDepartamentoQuery, List<UsuarioResponse>>
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<BuscarUsuariosDepartamentoHandler> _logger;
        public BuscarUsuariosDepartamentoHandler(ApiDbContext dbContext, ILogger<BuscarUsuariosDepartamentoHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<List<UsuarioResponse>> Handle(BuscarUsuariosDepartamentoQuery request, CancellationToken cancellationToken)
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

        private async Task<List<UsuarioResponse>> HandleAsync(BuscarUsuariosDepartamentoQuery request)
        {

            try
            {
                // Obtener el departamento y su usuario asociado
                var departamentoConUsuario = _dbContext.Departamento
                                                        .Where(d => d.nombre == request._request.data) // Filtra por el nombre del departamento
                                                        .Select(d =>  new UsuarioResponse // Proyecta el usuario asociado
                                                            {
                                                                id = d.usuario.Id,
                                                                CreatedAt = d.usuario.CreatedAt,
                                                                CreatedBy = d.usuario.CreatedBy,
                                                                UpdatedAt = d.usuario.UpdatedAt,
                                                                UpdatedBy = d.usuario.UpdatedBy,

                                                                usuario = d.usuario.usuario,
                                                                nombre = d.usuario.nombre,
                                                                apellido = d.usuario.apellido,
                                                                password = d.usuario.password,
                                                                correo = d.usuario.correo,
                                                                discriminator = EF.Property<string>(d.usuario, "Discriminator"),
                                                                respuesta_de_seguridad = d.usuario.respuesta_de_seguridad,
                                                                respuesta_de_seguridad2 = d.usuario.respuesta_de_seguridad2,
                                                                preguntas_de_seguridad = d.usuario.preguntas_de_seguridad,
                                                                preguntas_de_seguridad2 = d.usuario.preguntas_de_seguridad2,
                                                                estado = d.usuario.estado,
                                                                departamento = new BuscarDepartamentoResponse // Asigna el departamento correspondiente
                                                                {
                                                                    id = d.Id,
                                                                    CreatedAt = d.CreatedAt,
                                                                    CreatedBy = d.CreatedBy,
                                                                    UpdatedAt = d.UpdatedAt,
                                                                    UpdatedBy = d.UpdatedBy,

                                                                    nombreDepartamento = d.nombre,
                                                                    cargo = d.cargo
                                                                }

                                                        })
                                                        .ToList(); // Obtiene el primer departamento que coincida (o null si no hay coincidencias)


                if (departamentoConUsuario == null)
                {
                    // Manejar el caso en que no se encuentre el departamento
                    throw new ArgumentNullException(nameof(request));
                }


                return departamentoConUsuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ConsultarUsuarioIdQueryHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }
        }
    }
}
