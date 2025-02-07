using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class SeguimientoEntity : BaseEntity
    {
        public string? fecha_seguimiento { get; set; }  // Fecha de seguimiento
        public string? estatus { get; set; }            // Estatus
        public string? observaciones { get; set; }      // Observaciones
        public string? realizado_por { get; set; }      // Realizado por
    }

}
