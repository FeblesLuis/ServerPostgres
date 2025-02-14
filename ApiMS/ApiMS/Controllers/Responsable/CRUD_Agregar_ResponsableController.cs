using Microsoft.AspNetCore.Mvc;
using MediatR;
using ApiMS.Base;
using ApiMS.Application.Commands.Responsable;
using ApiMS.Application.Responses.Reportes;
using ApiMS.Application.Requests.Responsables;


namespace ApiMS.Controllers.Responsable
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUD_Agregar_ResponsableController : BaseController<CRUD_Agregar_ResponsableController>
    {

        private readonly IMediator _mediator;

        public CRUD_Agregar_ResponsableController(IMediator mediator, ILogger<CRUD_Agregar_ResponsableController> logger) : base(logger)
        {
            _mediator = mediator;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost("Agregar_Responsable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IdResponsableResponse>> Agregar_Responsable([FromBody] ResponsableRequest request)
        {
            _logger.LogInformation("Entrando al método que registra los valores de prueba");
            try
            {
                var command = new AgregarResponsableCommand(request);
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
