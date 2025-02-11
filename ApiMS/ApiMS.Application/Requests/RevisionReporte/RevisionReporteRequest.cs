using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Requests.RevisionReporte
{
    public class RevisionReporteRequest
    {
        public string? nombre { get; set; }     // Nombre de la revisión 
        public bool? estado { get; set; }       // Estado de la revisión 
    }
}
