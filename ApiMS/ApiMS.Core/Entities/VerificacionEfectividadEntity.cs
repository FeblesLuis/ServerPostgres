using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class VerificacionEfectividadEntity : BaseEntity
    {
        public bool? efectiva { get; set; }          // Efectiva
        public string? observaciones { get; set; }   // Observaciones
        public string? realizado_por { get; set; }   // Realizado por

        //Relacion FK 
            //1..1 Cierre
            public CierreEntity cierre { get; set; } = null!;
    }

}
