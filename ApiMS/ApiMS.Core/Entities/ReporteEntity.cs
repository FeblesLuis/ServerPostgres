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

        //Relacion PK 1..1 con Revision 
            public RevisionReporteEntity revision =new RevisionReporteEntity();

            public NoConformidadEntity? noConformidad;
        //Relaciones FK
            // 1..n con Usuarios 
            public Guid usuario_Id { get; set; }
            public UsuarioEntity usuario { get; set; } = null!;

    }

}
