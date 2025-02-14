using ApiMS.Core.Entities.Relaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities.Child.Acciones
{
    public class CorrectivasEntity : AccionesEntity
    {
        //Relaciones PK

        //1..* NoConformidad
        public ICollection<PreventivasEntity>? preventivas;
    }
}
