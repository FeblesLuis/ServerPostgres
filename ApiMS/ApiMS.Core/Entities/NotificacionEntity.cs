using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class NotificacionEntity : BaseEntity
    {
        public string? titulo { get; set; }         // Titulo del correo
        public string? envia { get; set; }          // Envidado por 
        public string? dirigido { get; set; }       // Dirigido a
        public string? mensaje { get; set; }        // Nota del mensaje
        public bool? Revisado { get; set; }       // Si el mensaje fue revisado o no
    }
}
