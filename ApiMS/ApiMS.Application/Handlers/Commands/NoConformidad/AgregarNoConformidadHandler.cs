using ApiMS.Application.Commands.NoConformidad;
using ApiMS.Application.Mappers.NoConformidad;
using ApiMS.Application.Mappers.R_Calidad_NoConformidadMapper;
using ApiMS.Application.Mappers.Reporte;
using ApiMS.Application.Mappers.RevisionReporte;
using ApiMS.Application.Requests.RevisionReporte;
using ApiMS.Application.Responses.NoConformidad;
using ApiMS.Application.Responses.Reportes;
using ApiMS.Application.Responses.Usuarios;
using ApiMS.Core.Entities.Relaciones;
using ApiMS.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiMS.Application.Handlers.Commands.NoConformidad
{
    public class AgregarNoConformidadHandler : IRequestHandler<AgregarNoConformidadCommand, IdNoConformidadResponse>
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger<AgregarNoConformidadHandler> _logger;
        public AgregarNoConformidadHandler(ApiDbContext dbContext, ILogger<AgregarNoConformidadHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }


        public Task<IdNoConformidadResponse> Handle(AgregarNoConformidadCommand request, CancellationToken cancellationToken)
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

        private async Task<IdNoConformidadResponse> HandleAsync(AgregarNoConformidadCommand request)
        {
            var transaccion = _dbContext.BeginTransaction();
            try
            {
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Obtengo los usuarios de calidad
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var calidad_usuarios = _dbContext.Calidad
                                                .Select(u => new
                                                {
                                                    id = u.Id,
                                                }).ToList();

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///     Busco al usuario gerente de ese departamento
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var noConformidad = NoConformidadMapper.MapRequestNoConformidadEntity(request._request, GenerarNuevaExpedicion());
                _dbContext.NoConformidad.Add(noConformidad);
                await _dbContext.SaveEfContextChanges("APP");

                transaccion.Commit();


                //Agrego la relacion Calidad_NoConformidad
                foreach (var calidad in calidad_usuarios)
                {
                    _dbContext.R_Calidad_NoConformidad.Add(R_Calidad_NoConformidadMapper.MapR_Calidad_NoConformidadEntity(calidad.id, noConformidad.Id)); R_Calidad_NoConformidadMapper.MapR_Calidad_NoConformidadEntity(calidad.id, noConformidad.Id);
                }




                return new IdNoConformidadResponse(noConformidad.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error AgregarOperarioHandler.HandleAsync. {Mensaje}", ex.Message);
                throw;
            }

        }
        public string GenerarNuevaExpedicion()
        {
            // 1. Obtener año actual en formato corto
            string añoActual = DateTime.Now.ToString("yy"); // Ej: "24" para 2024

            // 2. Buscar la última expedición registrada en toda la tabla
            var ultimaExpedicion = _dbContext.NoConformidad
                .OrderByDescending(n => n.numero_expedicion)
                .Select(n => n.numero_expedicion)
                .FirstOrDefault();

            int nuevoNumero = 1;

            // 3. Si existe al menos una expedición
            if (!string.IsNullOrEmpty(ultimaExpedicion))
            {
                // 4. Extraer componentes de la última expedición
                var partes = ultimaExpedicion.Split('-');

                if (partes.Length == 3 && partes[0] == "NC")
                {
                    string ultimoAño = partes[1];
                    string ultimoNumeroStr = partes[2];

                    // 5. Comparar años
                    if (ultimoAño == añoActual)
                    {
                        // Mismo año: incrementar número
                        if (int.TryParse(ultimoNumeroStr, out int ultimoNumero))
                        {
                            nuevoNumero = ultimoNumero + 1;
                        }
                    }
                    else
                    {
                        // Año diferente: resetear a 1
                        nuevoNumero = 1;
                    }
                }
            }

            // 6. Formatear nuevo número con 2 dígitos
            return $"NC-{añoActual}-{nuevoNumero:D2}";
        }
    }
}
