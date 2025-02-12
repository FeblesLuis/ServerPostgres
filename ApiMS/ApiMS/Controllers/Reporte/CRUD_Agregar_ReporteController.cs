using Microsoft.AspNetCore.Mvc;
using ApiMS.Application.Requests;
using ApiMS.Application.Queries;
using MediatR;
using ApiMS.Base;
using ApiMS.Application.Responses.Usuarios;
using ApiMS.Application.Requests.Usuarios;
using ApiMS.Application.Commands.Usuario;
using ApiMS.Application.Responses.Reportes;
using ApiMS.Application.Requests.Reportes;
using ApiMS.Application.Commands.Reportes;

namespace ApiMS.Controllers.Reporte
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUD_Agregar_ReporteController : BaseController<CRUD_Agregar_ReporteController>
    {

        private readonly IMediator _mediator;

        public CRUD_Agregar_ReporteController(IMediator mediator, ILogger<CRUD_Agregar_ReporteController> logger) : base(logger)
        {
            _mediator = mediator;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost("Agregar_Reporte")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IdReporteResponse>> AgregarReporte([FromBody] ReporteRequest request)
        {
            _logger.LogInformation("Entrando al método que registra los valores de prueba");
            try
            {
                var command = new AgregarReporteCommand(request);
                var response = await _mediator.Send(command);
                return Response200(NewResponseOperation(), response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
                return Response400(NewResponseOperation(), ex.Message,
                    "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
            }
        }
    }
}
