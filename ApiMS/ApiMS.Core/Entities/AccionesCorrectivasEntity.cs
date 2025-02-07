using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class AccionesCorrectivasEntity : BaseEntity
    {
        public List<string>? acciones_correctivas { get; set; }     // Acciones correctivas
        public List<string>? acciones_preventivas { get; set; }     // Acciones preventivas
        public bool? estado { get; set; }                           // Estado

        //Relaciones 1 a n

        public ICollection<UsuarioEntity> usuarios = new List<UsuarioEntity>();


    }
}
