
namespace ApiMS.Application.Responses.Usuarios
{
    public class IdUsuarioResponse
    {
        public IdUsuarioResponse() { }
        public IdUsuarioResponse(Guid data) 
        {
            id = data;
        }
        public Guid? id { get; set; }

    }
}
