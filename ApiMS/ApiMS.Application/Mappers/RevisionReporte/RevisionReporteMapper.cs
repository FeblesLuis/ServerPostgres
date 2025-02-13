using ApiMS.Application.Requests.Reportes;
using ApiMS.Application.Requests.RevisionReporte;
using ApiMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Mappers.RevisionReporte
{
    public  class RevisionReporteMapper
    {
        public static RevisionReporteEntity MapRequestRevisionReporteEntity(RevisionReporteRequest request, ReporteEntity reporte, Guid id)
        {
            var entity = new RevisionReporteEntity()
            {
                nombre = request.nombre,
                estado = request.estado,
                reporte = reporte,
                usuario_Id = id,
            };
            return entity;
        }
    }
}
