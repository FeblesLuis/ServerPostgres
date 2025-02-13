using ApiMS.Application.Requests.Departamento;
using ApiMS.Core.Entities;


namespace ApiMS.Application.Mappers.Departamento
{
    public class DepartamentoMapper
    {
        public static DepartamentoEntity MapRequestDepartamentoEntity(DepartamentoRequest request)
        {
            var entity = new DepartamentoEntity()
            {
                nombre = request.nombre,
                cargo = request.cargo,
            };
            return entity;
        }

    }
}
