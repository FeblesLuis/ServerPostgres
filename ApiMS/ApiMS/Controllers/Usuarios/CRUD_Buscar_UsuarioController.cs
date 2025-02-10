﻿using Microsoft.AspNetCore.Mvc;
using ApiMS.Application.Requests;
using ApiMS.Application.Queries;
using MediatR;
using ApiMS.Base;
using ApiMS.Application.Responses.Usuarios;

namespace ApiMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUD_Buscar_UsuarioController : BaseController<CRUD_Buscar_UsuarioController>
    {

        private readonly IMediator _mediator;

        public CRUD_Buscar_UsuarioController(IMediator mediator, ILogger<CRUD_Buscar_UsuarioController> logger) : base(logger)
        {
            _mediator = mediator;
        }


        [HttpGet("BuscarUsuario_Nombre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<BuscarUsuarioResponse>>> BuscarUsuario_Nombre([FromBody] BuscarUsuarioRequest request)
        {
            _logger.LogInformation("Entrando al método que consulta los Usuario");

            try
            {
                var query = new BuscarUsuariosNombreQuery(request);
                var response = await _mediator.Send(query);
                return Response200(NewResponseOperation(), response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
                return Response400(NewResponseOperation(), ex.Message,
                    "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
            }
        }
        [HttpGet("BuscarUsuario_Apellido")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<BuscarUsuarioResponse>>> BuscarUsuario_Apellido([FromBody] BuscarUsuarioRequest request)
        {
            _logger.LogInformation("Entrando al método que consulta los Usuario");

            try
            {
                var query = new BuscarUsuariosApellidoQuery(request);
                var response = await _mediator.Send(query);
                return Response200(NewResponseOperation(), response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
                return Response400(NewResponseOperation(), ex.Message,
                    "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
            }
        }

        [HttpGet("BuscarUsuario_Usuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<BuscarUsuarioResponse>>> BuscarUsuario_Usuario([FromBody] BuscarUsuarioRequest request)
        {
            _logger.LogInformation("Entrando al método que consulta los Usuario");

            try
            {
                var query = new BuscarUsuariosUsuarioQuery(request);
                var response = await _mediator.Send(query);
                return Response200(NewResponseOperation(), response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
                return Response400(NewResponseOperation(), ex.Message,
                    "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
            }
        }

        [HttpGet("BuscarUsuario_Correo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<BuscarUsuarioResponse>>> BuscarUsuario_Correo([FromBody] BuscarUsuarioRequest request)
        {
            _logger.LogInformation("Entrando al método que consulta los Usuario");

            try
            {
                var query = new BuscarUsuariosCorreoQuery(request);
                var response = await _mediator.Send(query);
                return Response200(NewResponseOperation(), response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
                return Response400(NewResponseOperation(), ex.Message,
                    "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
            }
        }

        [HttpGet("BuscarUsuario_ID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<BuscarUsuarioResponse>>> BuscarUsuario_ID([FromBody] BuscarUsuarioIDRequest request)
        {
            _logger.LogInformation("Entrando al método que consulta los Usuario");

            try
            {
                var query = new BuscarUsuarioIdQuery(request);
                var response = await _mediator.Send(query);
                return Response200(NewResponseOperation(), response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
                return Response400(NewResponseOperation(), ex.Message,
                    "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
            }
        }
        [HttpGet("BuscarUsuario_Departamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<BuscarUsuarioResponse>>> BuscarUsuario_Departamento([FromBody] BuscarUsuarioRequest request)
        {
            _logger.LogInformation("Entrando al método que consulta los Usuario");

            try
            {
                var query = new BuscarUsuariosDepartamentoQuery(request);
                var response = await _mediator.Send(query);
                return Response200(NewResponseOperation(), response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error al intentar registrar un valor de prueba. Exception: " + ex);
                return Response400(NewResponseOperation(), ex.Message,
                    "Ocurrio un error al intentar registrar un valor de prueba", ex.InnerException?.ToString());
            }
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