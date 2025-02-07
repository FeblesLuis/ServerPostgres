using System.Diagnostics.CodeAnalysis;

namespace ApiMS.Core.Entities;

public class CalidadEntity : UsuarioEntity
{
    //Relaciones PK

        //1..* NoConformidad
        public ICollection<NoConformidadEntity> noConformidad { get; set; } = null!;
}
