using ApiMS.Core.Entities.Relaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class AccionesEntity : BaseEntity
    {
        public string? investigacion { get; set; }     // Acciones correctivas
        public string? area { get; set; }             // Area donde se detecto
        public bool? estado { get; set; }             // Estado
        public bool? visto_bueno { get; set; }        // Revisado por el gerente

        //Relaciones PK
        //1..n RevisionAccionesCorrectivas
            public ICollection<R_Acciones_UsuarioEntity>? R_AccionesCorrectivas_Usuario;
        //Relaciones FK
            // 1..* Responsable
            public Guid responsable_Id { get; set; }
            public ResponsableEntity responsable { get; set; } = null!;
    }
}
