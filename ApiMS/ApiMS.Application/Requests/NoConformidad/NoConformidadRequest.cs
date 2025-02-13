using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Requests.NoConformidad
{
    public class NoConformidadRequest
    {
        public Guid? reporte_Id { get; set; }                    // Id Reporte
        public string? revisado_por { get; set; }                // Revisado por
        public string? consecuencias { get; set; }               // Consecuencias del reporte
        public List<string>? responsables { get; set; }          // Responsables
        public List<string>? areas_involucradas { get; set; }    // Áreas involucradas
        public int? prioridad { get; set; }                      // Prioridad
        public string? estado { get; set; }                       // Estado es un enumerado de la carpera Core>Enum
    }
}
