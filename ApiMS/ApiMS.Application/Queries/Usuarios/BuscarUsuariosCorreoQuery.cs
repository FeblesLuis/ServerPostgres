using MediatR;
using ApiMS.Application.Requests;
using ApiMS.Application.Responses.Usuarios;

namespace ApiMS.Application.Queries.Usuarios
{
    public class BuscarUsuariosCorreoQuery : IRequest<List<BuscarUsuarioResponse>>
    {
        public BuscarUsuarioRequest _request { get; set; }
        public BuscarUsuariosCorreoQuery(BuscarUsuarioRequest request)
        {
            _request = request;
        }
    }
}
