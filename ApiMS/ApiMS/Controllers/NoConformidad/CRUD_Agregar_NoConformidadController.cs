using Microsoft.AspNetCore.Mvc;
using MediatR;
using ApiMS.Base;
using ApiMS.Application.Responses.NoConformidad;
using ApiMS.Application.Requests.NoConformidad;
using ApiMS.Application.Commands.NoConformidad;


namespace ApiMS.Controllers.NoConformidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUD_Agregar_NoConformidadController : BaseController<CRUD_Agregar_NoConformidadController>
    {

        private readonly IMediator _mediator;

        public CRUD_Agregar_NoConformidadController(IMediator mediator, ILogger<CRUD_Agregar_NoConformidadController> logger) : base(logger)
        {
            _mediator = mediator;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost("Agregar_NoConformidad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IdNoConformidadResponse>> Agregar_NoConformidad([FromBody] NoConformidadRequest request)
        {
            _logger.LogInformation("Entrando al método que registra los valores de prueba");
            try
            {
                var command = new AgregarNoConformidadCommand(request);
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
