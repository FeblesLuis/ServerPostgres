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

        //Relacion FK 
        //1..1 Cierre
            public Guid cierre_Id { get; set; }
            public CierreEntity cierre { get; set; } = null!;
    }

}
