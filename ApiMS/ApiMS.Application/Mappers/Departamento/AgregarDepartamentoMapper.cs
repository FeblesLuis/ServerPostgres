using ApiMS.Application.Requests.Departamento;
using ApiMS.Core.Entities;


namespace ApiMS.Application.Mappers.Departamento
{
    public class AgregarDepartamentoMapper
    {
        public static DepartamentoEntity MapRequestDepartamentoEntity(AgregarDepartamentoRequest request, UsuarioEntity usuario)
        {
            var entity = new DepartamentoEntity()
            {
                nombre = request.nombre,
                cargo = request.cargo,
                usuario = usuario,
            };
            return entity;
        }

    }
}
