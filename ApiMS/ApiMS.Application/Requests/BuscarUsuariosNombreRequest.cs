using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Requests
{
    public class BuscarUsuariosNombreRequest
    {
        public string? nombre { get; set; }
        public string? apellido { get; set; }
    }
}
