
using ApiMS.Application.Requests.Departamento;
using ApiMS.Application.Requests.Notificacion;
using ApiMS.Core.Entities;

namespace ApiMS.Application.Mappers.Notificacion
{
    public class NotificacionMapper
    {
        public static NotificacionEntity MapRequestNotificacionEntity(NotificacionRequest request)
        {
            var entity = new NotificacionEntity()
            {
                 titulo = request.titulo,
                envia   = request.envia,
                dirigido = request.dirigido,
                mensaje = request.mensaje,
                Revisado = request.Revisado,           
            };
            return entity;
        }
    }
}
