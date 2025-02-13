using ApiMS.Application.Responses.Departamento;

namespace ApiMS.Application.Responses.Usuarios
{
    public class UsuarioResponse
    {
        public Guid? id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public string? usuario { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? password { get; set; }
        public string? correo { get; set; }
        public string? preguntas_de_seguridad { set; get; }
        public string? preguntas_de_seguridad2 { set; get; }
        public string? respuesta_de_seguridad { set; get; }
        public string? respuesta_de_seguridad2 { set; get; }
        public bool? estado { set; get; }
        public string? discriminator { set; get; }
        // Nueva propiedad para almacenar información del departamento
        public DepartamentoResponse? departamento { get; set; }
    }

}
