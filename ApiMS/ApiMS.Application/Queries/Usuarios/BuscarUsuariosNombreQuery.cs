using MediatR;
using ApiMS.Application.Requests;
using ApiMS.Application.Responses.Usuarios;

namespace ApiMS.Application.Queries.Usuarios
{
    public class BuscarUsuariosNombreQuery : IRequest<List<BuscarUsuarioResponse>>
    {
        public BuscarUsuarioRequest _request { get; set; }
        public BuscarUsuariosNombreQuery(BuscarUsuarioRequest request)
        {
            _request = request;
        }
    }
}
