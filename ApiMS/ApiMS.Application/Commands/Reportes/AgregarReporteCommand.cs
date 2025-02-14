using ApiMS.Application.Requests.Reportes;
using ApiMS.Application.Responses.Reportes;
using MediatR;

namespace ApiMS.Application.Commands.Reportes
{
    public class AgregarReporteCommand : IRequest<IdResponsableResponse>
    {
        public ReporteRequest _request { get; set; }
        public AgregarReporteCommand(ReporteRequest request)
        {
            _request = request;
        }
    }
}
