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

    // Relaciones PK
        // 1..1 departamento
        public DepartamentoEntity departamento = new DepartamentoEntity();
        // 1..n Reporte
        public ICollection<ReporteEntity>? reporte;
        // 1..n RevisionReporte
        public ICollection<RevisionReporteEntity>? revisionReporte;
        // 1..n RevisionAcciones 
        public ICollection<RevisionAccionesCorrectivasEntity>? revicionAccionesCorrectivas;

}
