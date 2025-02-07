using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class NoConformidadEntity : BaseEntity
    {
        public string? revisado_por { get; set; }                // Revisado por
        public List<string>? responsables { get; set; }          // Responsables
        public List<string>? areas_involucradas { get; set; }    // Áreas involucradas
        public int? prioridad { get; set; }                      // Prioridad
        public string? descripcion { get; set; }                 // Descripción
        public Estado estado { get; set; }                        // Estado es un enumerado de la carpera Core>Enum

        //Relaciones
        public ReporteEntity reporte= new ReporteEntity();
        public CierreEntity cierre= new CierreEntity();
        public ICollection<ResponsableEntity> reponsable = new List<ResponsableEntity>();

    }

}
