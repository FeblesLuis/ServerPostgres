using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class IndicadoresEntity : BaseEntity
    {
        public string? origen { get; set; }   // Origen
        public string? causa { get; set; }    // Causa
    }

}
