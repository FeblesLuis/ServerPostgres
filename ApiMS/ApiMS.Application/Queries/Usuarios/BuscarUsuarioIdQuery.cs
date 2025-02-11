using MediatR;
using ApiMS.Application.Requests;
using ApiMS.Application.Responses.Usuarios;

namespace ApiMS.Application.Queries.Usuarios
{
    public class BuscarUsuarioIdQuery : IRequest<UsuarioResponse>
    {
        public BuscarUsuarioIDRequest _request { get; set; }
        public BuscarUsuarioIdQuery(BuscarUsuarioIDRequest request)
        {
            _request = request;
        }
    }
}
