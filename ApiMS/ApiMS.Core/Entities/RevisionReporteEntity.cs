using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class RevisionReporteEntity : BaseEntity
    {
        public string? nombre { get; set; }     // Nombre de la revisión 
        public bool? estado { get; set; }       // Estado de la revisión 

        //Relaciones FK 
            //1..1 con Reporte
            public ReporteEntity reporte { get; set; } = null!;
    }

}
