using ApiMS.Application.Requests.Reportes;
using ApiMS.Application.Requests.Responsables;
using ApiMS.Application.Responses.Reportes;
using MediatR;


namespace ApiMS.Application.Commands.Responsable
{
    public class AgregarResponsableCommand : IRequest<IdResponsableResponse>
    {
        public ResponsableRequest _request { get; set; }
        public AgregarResponsableCommand(ResponsableRequest request)
        {
            _request = request;
        }
    }
}
