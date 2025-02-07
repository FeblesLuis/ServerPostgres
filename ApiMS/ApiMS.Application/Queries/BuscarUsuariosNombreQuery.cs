using MediatR;
using ApiMS.Application.Responses;
using ApiMS.Application.Requests;

namespace ApiMS.Application.Queries
{
    public class BuscarUsuariosNombreQuery : IRequest<List<BuscarUsuariosNombreResponse>>
    {
        public BuscarUsuariosNombreRequest _request { get; set; }
        public BuscarUsuariosNombreQuery(BuscarUsuariosNombreRequest request) 
        {
            _request = request;
        }
    }
}
