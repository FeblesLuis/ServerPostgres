using ApiMS.Core.Entities.Relaciones;
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
            public ICollection<R_AccionesCorrectivas_UsuarioEntity>? revisionAccionesCorrectivas;
        //Relaciones FK
            // 1..* Responsable
            public Guid responsable_Id { get; set; }
            public ResponsableEntity responsable { get; set; } = null!;
    }
}
