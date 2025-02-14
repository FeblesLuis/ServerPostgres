using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Requests.AccionesCorrectivas
{
    public class AccionesRequest
    {
        public Guid? usuario_Id {  get; set; }
        public Guid? Correctivas_Id { get; set; }
        public Guid? responsable_Id {  get; set; }
        public string? investigacion { get; set; }     // Acciones correctivas
        public string? area { get; set; }           
        public bool? estado { get; set; }             // Estado
        public bool? visto_bueno { get; set; }        // Revisado por el gerente

    }
}
