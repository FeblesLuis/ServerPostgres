using ApiMS.Application.Requests.Reportes;
using ApiMS.Application.Requests.Usuarios;
using ApiMS.Application.Responses.Usuarios;
using MediatR;

namespace ApiMS.Application.Commands.Usuario
{
    public class ActualizarUsuarioCommand : IRequest<IdUsuarioResponse>
    {
        public UsuarioRequest _request { get; set; }
        public ActualizarUsuarioCommand(UsuarioRequest request)
        {
            _request = request;
        }
    }
}
