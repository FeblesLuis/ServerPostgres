using MediatR;
using ApiMS.Application.Requests;
using ApiMS.Application.Responses.Usuarios;

namespace ApiMS.Application.Queries.Usuarios
{
    public class BuscarUsuariosQuery : IRequest<List<UsuarioResponse>>
    {
        public BuscarUsuarioRequest _request { get; set; }
        public BuscarUsuariosQuery(BuscarUsuarioRequest request)
        {
            _request = request;
        }
    }
}

