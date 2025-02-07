using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class RevisionEntity : BaseEntity
    {
        public string? nombre { get; set; }     // Nombre de la revisión 
        public bool? estado { get; set; }       // Estado de la revisión 
    }

}
