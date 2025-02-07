using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class ReporteEntity : BaseEntity
    {
        public string? detectado_por { get; set; }       // Quién detectó el reporte
        public string? area { get; set; }                // Área relacionada con el reporte
        public string? titulo { get; set; }              // Título del reporte
        public string? descripcion { get; set; }         // Descripción detallada del reporte
        public string? consecuencias { get; set; }       // Consecuencias del reporte

        //Relaciones
        public RevisionEntity revision;

    }

}
