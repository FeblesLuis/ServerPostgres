using ApiMS.Application.Requests.NoConformidad;
using ApiMS.Application.Responses.NoConformidad;
using MediatR;

namespace ApiMS.Application.Commands.NoConformidad
{
    public class AgregarNoConformidadCommand : IRequest<IdNoConformidadResponse>
    {
        public NoConformidadRequest _request { get; set; }
        public AgregarNoConformidadCommand(NoConformidadRequest request)
        {
            _request = request;
        }
    }
}
