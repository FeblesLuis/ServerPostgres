using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class NoConformidadEntity : BaseEntity
    {
        public string? numero_expedicion {  get; set; }          // Numero de expedicion de la no conformidad NC-25-001
        public string? revisado_por { get; set; }                // Revisado por
        public string? consecuencias { get; set; }               // Consecuencias del reporte
        public List<string>? responsables { get; set; }          // Responsables
        public List<string>? areas_involucradas { get; set; }    // Áreas involucradas
        public int? prioridad { get; set; }                      // Prioridad
        public string? descripcion { get; set; }                 // Descripción
        public Estado estado { get; set; }                       // Estado es un enumerado de la carpera Core>Enum

        //Relaciones PK
            // 1..* seguimiento
            public SeguimientoEntity? seguimiento;
            // 1..1 Cierre
            public CierreEntity cierre= new CierreEntity();
            // 1..* Reponsables
            public ICollection<ResponsableEntity> reponsable = new List<ResponsableEntity>();

        //Relacion FK 
            //1..1 Usuarios
            public CalidadEntity calidad { get; set; } = null!;

    }

}
