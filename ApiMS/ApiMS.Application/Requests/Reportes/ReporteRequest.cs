
using ApiMS.Application.Requests.RevisionReporte;

namespace ApiMS.Application.Requests.Reportes
{
    public class ReporteRequest
    {
        public Guid? id { get; set; }
        public string? detectado_por { get; set; }       // Quién detectó el reporte
        public string? area { get; set; }                // Área relacionada con el reporte
        public string? titulo { get; set; }              // Título del reporte
        public string? descripcion { get; set; }         // Descripción detallada del reporte

        public RevisionReporteRequest? revisionReporte { get; set; }
    }
}
