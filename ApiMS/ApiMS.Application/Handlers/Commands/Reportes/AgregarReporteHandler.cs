using ApiMS.Application.Commands.Reportes;
using ApiMS.Application.Commands.Usuario;
using ApiMS.Application.Handlers.Commands.Usuarios;
using ApiMS.Application.Mappers.Departamento;
using ApiMS.Application.Mappers.Usuario;
using ApiMS.Application.Requests.Departamento;
using ApiMS.Application.Responses.Reportes;
using ApiMS.Application.Responses.Usuarios;
using ApiMS.Infrastructure.Database;
using MediatR;
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
                ///     Pregunto si el usuario ya esta registrado
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                var Registrado = _dbContext.Usuario.Count(c => c.correo == request._request.correo);
                if (Registrado > 0)
                {
                    throw new InvalidOperationException("Registro fallido: el usuario ya existe");
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Creo el Usuario
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                // Suponiendo que nombre = "Luis", nombre2 = "Felipe" y apellido = "Febles" y apellido2 = "Castro" 

                //Genero el primer Usuario
                request._request.usuario =
                    request._request.primer_nombre.Substring(0, 1) + // Primera letra del nombre
                    request._request.primer_apellido;                // Apellido completo

                //Pregunto si Mi usuario no esta registrado en el sistema = lfebles
                var result = _dbContext.Usuario.Count(c => c.usuario == request._request.usuario);

                if (result > 0) //Si ya estoy registrado agrego la primera letra del segundo nombre lffebles 
                {
                    request._request.usuario =
                        request._request.primer_nombre.Substring(0, 1) + // Primera letra del nombre
                        request._request.segundo_nombre.Substring(0, 1) + // Primera letra del nombre2
                        request._request.primer_apellido;                // Apellido completo
                }

                //Pregunto si Mi usuario no esta registrado en el sistema
                var result2 = _dbContext.Usuario.Count(c => c.usuario == request._request.usuario);

                if (result2 > 0) //Si ya estoy registrado agrego la primera letra del segundo apellido lffeblesC
                {
                    request._request.usuario =
                        request._request.primer_nombre.Substring(0, 1) +    // Primera letra del nombre
                        request._request.segundo_nombre.Substring(0, 1) +   // Primera letra del nombre2
                        request._request.primer_apellido +                  // Apellido completo
                        request._request.segundo_apellido.Substring(0, 1);  // Primera letra del Apellido
                }


                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Mappeo la entidad para la insercion y le paso los campos / Luego Inserto en la bd
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (request._request.nombreDepartamento.Contains("Calidad"))
                {
                    // Crear una instancia de CalidadEntity con los datos del request
                    var entity = AgregarUsuarioMapper.MapRequestCalidadEntity(request._request);

                    // Lleno una instancia para mapear el departamento y agregarlo
                    var request_departamento = new AgregarDepartamentoRequest();
                    request_departamento.nombre = request._request.nombreDepartamento;
                    request_departamento.cargo = request._request.cargoDepartamento;

                    var departamento = AgregarDepartamentoMapper.MapRequestDepartamentoEntity(request_departamento, entity);

                    // Agregar el usuario al DbContext
                    _dbContext.Calidad.Add(entity);
                    await _dbContext.SaveEfContextChanges("APP");
                    // Agregar el Departamento al DbContext
                    _dbContext.Departamento.Add(departamento);
                    await _dbContext.SaveEfContextChanges("APP");

                    //Doy commit
                    transaccion.Commit();

                    //Retorno ID
                    return new IdUsuarioResponse(entity.Id);
                }
                else
                {
                    // Crear una instancia de OperarioEntity con los datos del request
                    var entity = AgregarUsuarioMapper.MapRequestOperarioEntity(request._request);

                    // Lleno una instancia para mapear el departamento y agregarlo
                    var request_departamento = new AgregarDepartamentoRequest();
                    request_departamento.nombre = request._request.nombreDepartamento;
                    request_departamento.cargo = request._request.cargoDepartamento;

                    var departamento = AgregarDepartamentoMapper.MapRequestDepartamentoEntity(request_departamento, entity);

                    // Agregar el usuario al DbContext
                    _dbContext.Operario.Add(entity);
                    await _dbContext.SaveEfContextChanges("APP");
                    // Agregar el Departamento al DbContext
                    _dbContext.Departamento.Add(departamento);
                    await _dbContext.SaveEfContextChanges("APP");

                    //Doy commit
                    transaccion.Commit();

                    //Retorno ID
                    return new IdUsuarioResponse(entity.Id);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error AgregarOperarioHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }



        }

    }
