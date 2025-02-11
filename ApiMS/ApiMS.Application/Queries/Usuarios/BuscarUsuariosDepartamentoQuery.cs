using ApiMS.Application.Requests;
using ApiMS.Application.Responses.Usuarios;
using MediatR;


namespace ApiMS.Application.Queries.Usuarios
{
    public class BuscarUsuariosDepartamentoQuery : IRequest<List<UsuarioResponse>>
    {
        public BuscarUsuarioRequest _request { get; set; }
        public BuscarUsuariosDepartamentoQuery(BuscarUsuarioRequest request)
        {
            _request = request;
        }
    }
}

