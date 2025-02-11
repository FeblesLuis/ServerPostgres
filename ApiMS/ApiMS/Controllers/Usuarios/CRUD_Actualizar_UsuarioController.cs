using Microsoft.AspNetCore.Mvc;
using ApiMS.Application.Requests;
using ApiMS.Application.Queries;
using MediatR;
using ApiMS.Base;
using ApiMS.Application.Responses.Usuarios;
using ApiMS.Application.Requests.Usuarios;
using ApiMS.Application.Commands.Usuario;

namespace ApiMS.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUD_Actualizar_UsuarioController : BaseController<CRUD_Actualizar_UsuarioController>
    {

        private readonly IMediator _mediator;

        public CRUD_Actualizar_UsuarioController(IMediator mediator, ILogger<CRUD_Actualizar_UsuarioController> logger) : base(logger)
        {
            _mediator = mediator;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPut("Actualizar_Usuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IdUsuarioResponse>> ActualizarUsuario([FromBody] UsuarioRequest request)
        {
            _logger.LogInformation("Entrando al método que registra los valores de prueba");
            try
            {
                var command = new ActualizarUsuarioCommand(request);
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
