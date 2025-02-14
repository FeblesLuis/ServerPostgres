namespace ApiMS.Application.Responses.Reportes
{
    public class IdResponsableResponse
    {
        public Guid? id {  get; set; }

        public IdResponsableResponse( Guid id) 
        {
            this.id = id;
        }
    }
}
