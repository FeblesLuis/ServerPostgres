using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class AccionCorrectivaEntity : BaseEntity
    {
        public List<string>? acciones_correctivas { get; set; }     // Acciones correctivas
        public List<string>? acciones_preventivas { get; set; }     // Acciones preventivas
        public bool? estado { get; set; }                           // Estado

        //Relaciones PK
            //1..n RevisionAccionesCorrectivas
            public ICollection<RevisionAccionesCorrectivasEntity> revisionAccionesCorrectivas { set; get; } = null!;
        //Relaciones FK
            // 1..* Responsable
            public ResponsableEntity responsable { get; set; } = null!;
    }
}
