using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMS.Core.Entities;
using ApiMS.Infrastructure.Database;
using ApiMS.Application.Requests;
using ApiMS.Application.Queries;
using ApiMS.Application.Responses;
using MediatR;
using ApiMS.Base;

namespace ApiMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController<UsuarioController>
    {

        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator, ILogger<UsuarioController> logger) : base(logger)
        {
            _mediator = mediator;
        }


        [HttpPost("BuscarUsuariosNombre")]
        public async Task<ActionResult<List<BuscarUsuariosNombreResponse>>> BuscarUsuariosNombre([FromBody] BuscarUsuariosNombreRequest request)
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

    }
}
