using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class RevisionAccionesCorrectivasEntity: BaseEntity
    {
        // Relacion FK
            // AccionesCorrectivas 1..n 
            public AccionCorrectivaEntity accionesCorrectivas { set; get; } = null!;
            // Usuario 1..*
            public UsuarioEntity usuario { get; set; } = null!;
    }
}
