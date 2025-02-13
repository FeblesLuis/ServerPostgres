using ApiMS.Application.Responses.Usuarios;

namespace ApiMS.Application.Responses.Departamento
{
    public class DepartamentoResponse
    {
        public Guid? id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public Guid? usuarioId { get; set; }


        public string? nombreDepartamento { get; set; }
        public string? cargo { get; set; }

        public UsuarioResponse? usuario { get; set; }
    }
}
