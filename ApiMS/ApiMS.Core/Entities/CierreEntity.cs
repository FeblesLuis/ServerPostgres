using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class CierreEntity : BaseEntity
    {
        public bool? conforme { get; set; }              // Conforme
        public string? observaciones { get; set; }       // Observaciones
        public string? responsable { get; set; }         // Responsable
        public string? fecha_verificacion { get; set; }  // Fecha de verificación

        //Relaciones
        public VerificacionEfectividadEntity verificacionEfectividad = new VerificacionEfectividadEntity();
        public IndicadoresEntity indicadores = new IndicadoresEntity();
        public ICollection<SeguimientoEntity> seguimiento;
    }

}
