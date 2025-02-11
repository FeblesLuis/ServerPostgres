using MediatR;
using ApiMS.Application.Requests;
using ApiMS.Application.Responses.Usuarios;


namespace ApiMS.Application.Queries.Usuarios
{
    public class BuscarUsuariosUsuarioQuery : IRequest<List<UsuarioResponse>>
    {
        public BuscarUsuarioRequest _request { get; set; }
        public BuscarUsuariosUsuarioQuery(BuscarUsuarioRequest request)
        {
            _request = request;
        }
    }
}
