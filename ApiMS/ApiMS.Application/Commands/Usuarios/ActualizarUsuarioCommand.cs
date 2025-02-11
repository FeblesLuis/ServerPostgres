using ApiMS.Application.Requests.Reportes;
using ApiMS.Application.Responses.Usuarios;
using MediatR;

namespace ApiMS.Application.Commands.Usuario
{
    public class ActualizarUsuarioCommand : IRequest<IdUsuarioResponse>
    {
        public ReporteRequest _request { get; set; }
        public ActualizarUsuarioCommand(ReporteRequest request)
        {
            _request = request;
        }
    }
}
