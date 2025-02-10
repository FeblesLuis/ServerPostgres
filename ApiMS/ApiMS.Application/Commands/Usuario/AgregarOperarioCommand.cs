using MediatR;
using ApiMS.Application.Requests;
using ApiMS.Application.Responses.Usuarios;


namespace ApiMS.Application.Commands.Usuario
{
    public class AgregarOperarioCommand : IRequest<BuscarUsuarioResponse>
    {
        public BuscarUsuarioIDRequest _request { get; set; }
        public AgregarOperarioCommand(BuscarUsuarioIDRequest request)
        {
            _request = request;
        }
    }
}