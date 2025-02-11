using MediatR;
using ApiMS.Application.Requests;
using ApiMS.Application.Responses.Usuarios;
using ApiMS.Application.Requests.Usuarios;


namespace ApiMS.Application.Commands.Usuario
{
    public class AgregarUsuarioCommand : IRequest<IdUsuarioResponse>
    {
        public UsuarioRequest _request { get; set; }
        public AgregarUsuarioCommand(UsuarioRequest request)
        {
            _request = request;
        }
    }
}