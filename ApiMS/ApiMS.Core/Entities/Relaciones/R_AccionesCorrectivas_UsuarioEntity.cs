using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities.Relaciones
{
    public class R_AccionesCorrectivas_UsuarioEntity : BaseEntity
    {
        // Relacion FK
        // AccionesCorrectivas 1..n 

        public Guid accionesCorrectivas_Id { get; set; }
        public AccionCorrectivaEntity accionesCorrectivas { set; get; } = null!;

        // Usuario 1..*
        public Guid usuario_Id { get; set; }
        public UsuarioEntity usuario { get; set; } = null!;
    }
}
