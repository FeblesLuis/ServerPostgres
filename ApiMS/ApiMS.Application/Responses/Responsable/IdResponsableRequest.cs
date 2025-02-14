
namespace ApiMS.Application.Responses.Responsable
{
    public class IdResponsableRequest
    {
        public Guid? id { get; set; }

        public IdResponsableRequest(Guid id)
        {
            this.id = id;
        }
    }
}
