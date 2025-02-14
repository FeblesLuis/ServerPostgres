using ApiMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Requests.Responsables
{
    public class ResponsableRequest
    {
        public string? investigacion { get; set; }    // Investigación
        public string? analisis_causa { get; set; }   // Análisis de causa
        public string? correccion { get; set; }       // Corrección
        public string? analisis_riesgo { get; set; }  // Análisis de riesgo



        public Guid usuario_Id { get; set; }

        public Guid noConformidad_Id { get; set; }
    }
}
