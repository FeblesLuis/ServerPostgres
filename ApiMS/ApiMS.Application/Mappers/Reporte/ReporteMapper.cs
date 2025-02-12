using ApiMS.Application.Requests.Departamento;
using ApiMS.Application.Requests.Reportes;
using ApiMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Mappers.Reporte
{
    public class ReporteMapper
    {
        public static ReporteEntity MapRequestReporteEntity(ReporteRequest request)
        {
            var entity = new ReporteEntity()
            {
                detectado_por = request.detectado_por,
                area = request.area,
                titulo = request.titulo,
                descripcion = request.descripcion,
            };
            return entity;
        }
    }
}
