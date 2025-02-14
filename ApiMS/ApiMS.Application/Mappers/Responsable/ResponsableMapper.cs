using ApiMS.Application.Requests.Responsables;
using ApiMS.Core.Entities;
using ApiMS.Core.Entities.Relaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Mappers.Responsable
{
    public class ResponsableMapper
    {
        public static ResponsableEntity MapResponsableMapperEntity(ResponsableRequest request)
        {
            var entity = new ResponsableEntity()
            {
                investigacion = request.investigacion,
                analisis_causa = request.analisis_causa,
                correccion = request.correccion,
                analisis_riesgo = request.analisis_riesgo,
                usuario_Id = request.usuario_Id,
                noConformidad_Id = request.noConformidad_Id,
            };
            return entity;
        }
    }
}
