using System.Diagnostics.CodeAnalysis;


namespace ApiMS.Core.Entities;

public class UsuarioEntity : BaseEntity
{
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

    // Relaciones 
    public DepartamentoEntity departamento = new DepartamentoEntity();

    public ICollection<ReporteEntity> reporte;


    // Relacion Usuario Acciones correctivas 1..n 

    public AccionesCorrectivasEntity accionesCorrectivas;

}
