using Microsoft.AspNetCore.Mvc;
using ApiMS.Application.Requests;
using ApiMS.Application.Queries;
using ApiMS.Application.Responses;
using MediatR;
using ApiMS.Base;


namespace ApiMS.Controllers.Usuarios
{
    public class CRUD_Agregar_UsuarioControler : BaseController<CRUD_Agregar_UsuarioControler>
    {

        private readonly IMediator _mediator;

        public CRUD_Agregar_UsuarioControler(IMediator mediator, ILogger<CRUD_Agregar_UsuarioControler> logger) : base(logger)
        {
            _mediator = mediator;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost("AgregarUsuario_Operario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Guid>> AgregarUsuario_Operario([FromBody] RegistrarPrestadorRequest request)
        {
            _logger.LogInformation("Entrando al método que registra los valores de prueba");
            try
            {
                var command = new AgregarRegistrarPrestadorCommand(request);
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
