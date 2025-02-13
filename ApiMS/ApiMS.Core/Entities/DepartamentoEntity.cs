using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class DepartamentoEntity : BaseEntity
    {
        public string? nombre { get; set; }         //Nombre del departamento
        public string? cargo { get; set; }          //Cargo en el departamento

        public ICollection<UsuarioEntity>? usuarios;
    }
}
