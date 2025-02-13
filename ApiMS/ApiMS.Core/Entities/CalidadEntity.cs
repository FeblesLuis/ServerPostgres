using ApiMS.Core.Entities.Relaciones;
using System.Diagnostics.CodeAnalysis;

namespace ApiMS.Core.Entities;

public class CalidadEntity : UsuarioEntity
{
    //Relaciones PK

    //1..* NoConformidad
    public ICollection<R_Calidad_NoConformidadEntity>? r_Calidad_NoConformidadEntity;


}
