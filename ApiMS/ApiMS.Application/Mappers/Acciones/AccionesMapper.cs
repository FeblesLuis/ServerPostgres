using ApiMS.Application.Requests.AccionesCorrectivas;
using ApiMS.Application.Requests.Departamento;
using ApiMS.Core.Entities;
using ApiMS.Core.Entities.Child.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Mappers.Acciones
{
    public class AccionesMapper
    {
        public static CorrectivasEntity MapCorrectivasEntity(AccionesRequest request)
        {
            var entity = new CorrectivasEntity()
            {
                investigacion = request.investigacion,
                area = request.area,
                estado = request.estado,
                visto_bueno = request.visto_bueno,
                responsable_Id = (Guid)request.responsable_Id,
            };
            return entity;
        }

        public static PreventivasEntity MapPreventivasEntity(AccionesRequest request)
        {
            var entity = new PreventivasEntity()
            {
                correctiva_Id = (Guid)request.Correctivas_Id,
                investigacion = request.investigacion,
                area = request.area,
                estado = request.estado,
                visto_bueno = request.visto_bueno,
                responsable_Id = (Guid)request.responsable_Id,
            };
            return entity;
        }
    }
}
