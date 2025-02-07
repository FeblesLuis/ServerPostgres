using System.Diagnostics.CodeAnalysis;

namespace ApiMS.Core.Entities;

public class CalidadEntity : UsuarioEntity
{
    //    //Relaciones
    public ICollection<NoConformidadEntity> noConformidad;

}
