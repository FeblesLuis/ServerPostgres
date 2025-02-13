using ApiMS.Application.Requests.NoConformidad;
using ApiMS.Core.Entities;
using System;

namespace ApiMS.Application.Mappers.NoConformidad
{
    public class NoConformidadMapper
    {
        public static NoConformidadEntity MapRequestNoConformidadEntity(NoConformidadRequest request,string expedicion)
        {
            // convertir el string al enum Estado
            if (!Enum.TryParse<Estado>(request.estado, out Estado estado))
            {
                // Si no coincide, lanzar excepción (o manejar como necesites)
                throw new ArgumentException(
                    $"El valor '{request.estado}' no es un estado válido. " +
                    $"Valores permitidos: {string.Join(", ", Enum.GetNames(typeof(Estado)))}");
            }

            // Mapear la entidad con el estado convertido
            return new NoConformidadEntity
            {
                numero_expedicion = expedicion,
                revisado_por = request.revisado_por,
                consecuencias = request.consecuencias,
                responsables = request.responsables,
                areas_involucradas = request.areas_involucradas,
                estado = estado, // Asignar el valor del enum
                reporte_Id = (Guid)request.reporte_Id,
            };
        }
    }
}