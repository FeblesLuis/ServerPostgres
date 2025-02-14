using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Requests.Notificacion
{
    public class NotificacionRequest
    {
        public string? titulo { get; set; }         // Titulo del correo
        public string? envia { get; set; }          // Envidado por 
        public string? dirigido { get; set; }       // Dirigido a
        public string? mensaje { get; set; }        // Nota del mensaje
        public bool? Revisado { get; set; }       // Si el mensaje fue revisado o no

        public NotificacionRequest(string titulo, string envia, string dirigido, string mensaje, bool revisado)
        {
            this.titulo = titulo;
            this.envia = envia;
            this.dirigido = dirigido;
            this.mensaje = mensaje;
            this.Revisado = revisado;
        }
    }
}
