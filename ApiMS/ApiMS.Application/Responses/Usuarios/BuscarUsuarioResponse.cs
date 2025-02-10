namespace ApiMS.Application.Responses.Usuarios
{
    public class BuscarUsuarioResponse
    {
        public Guid? id { get; set; }
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
        public BuscarDepartamentoResponse? departamento { get; set; }
    }

}
