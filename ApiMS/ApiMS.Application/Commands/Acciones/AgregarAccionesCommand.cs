using ApiMS.Application.Requests.AccionesCorrectivas;
using ApiMS.Application.Requests.NoConformidad;
using ApiMS.Application.Responses.Acciones;
using ApiMS.Application.Responses.NoConformidad;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Commands.Acciones
{
    public class AgregarAccionesCommand : IRequest<IdAccionesResponse>
    {
        public AccionesRequest _request { get; set; }
        public AgregarAccionesCommand(AccionesRequest request)
        {
            _request = request;
        }
    }
}
