using ApiMS.Application.Queries.Usuarios;
using ApiMS.Application.Responses.Usuarios;
using ApiMS.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace ApiMS.Application.Handlers.Queries.Usuarios
{
    public class BuscarUsuariosDepartamentoHandler : IRequestHandler<BuscarUsuariosDepartamentoQuery, List<BuscarUsuarioResponse>>
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<BuscarUsuariosDepartamentoHandler> _logger;
        public BuscarUsuariosDepartamentoHandler(ApiDbContext dbContext, ILogger<BuscarUsuariosDepartamentoHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<List<BuscarUsuarioResponse>> Handle(BuscarUsuariosDepartamentoQuery request, CancellationToken cancellationToken)
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

        private async Task<List<BuscarUsuarioResponse>> HandleAsync(BuscarUsuariosDepartamentoQuery request)
        {

            try
            {
                //Traigo al departmento
                var departamentoObj = _dbContext.Departamento
                 .Where(d => d.nombre == request._request.data) // Usar el ID del departamento
                 .Select(d => new BuscarDepartamentoResponse
                 {
                     id = d.usuario.Id,
                     nombreDepartamento = d.nombre,
                     cargo = d.cargo
                 });

                // Obtener los IDs de los usuarios relacionados con los departamentos
                var usuarioIds = departamentoObj.Select(d => d.id).ToList();

                // Traer los usuarios relacionados con los IDs obtenidos
                var usuario = _dbContext.Usuario
                    .Where(c => usuarioIds.Contains(c.Id)) // Filtra por los IDs de los usuarios
                    .Select(c => new BuscarUsuarioResponse() // Mapea la respuesta del usuario
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
                    }); // Convertir a lista para obtener todos los usuarios

                return await usuario.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ConsultarUsuarioIdQueryHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }
        }
    }
}
