using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities.Child.Acciones
{
    public class PreventivasEntity : AccionesEntity
    {
        // Usuario 1..*
        public Guid correctiva_Id { get; set; }
        public CorrectivasEntity correctiva { get; set; } = null!;
    }
}
