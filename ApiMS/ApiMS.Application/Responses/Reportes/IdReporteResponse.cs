namespace ApiMS.Application.Responses.Reportes
{
    public class IdReporteResponse
    {
        public Guid? id {  get; set; }

        public IdReporteResponse(Guid id) 
        {
            this.id = id;
        }
    }
}
