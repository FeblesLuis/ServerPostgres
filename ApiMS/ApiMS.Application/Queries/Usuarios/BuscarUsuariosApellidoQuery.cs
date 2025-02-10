﻿using MediatR;
using ApiMS.Application.Requests;
using ApiMS.Application.Responses.Usuarios;

namespace ApiMS.Application.Queries.Usuarios
{
    public class BuscarUsuariosApellidoQuery : IRequest<List<BuscarUsuarioResponse>>
    {
        public BuscarUsuarioRequest _request { get; set; }
        public BuscarUsuariosApellidoQuery(BuscarUsuarioRequest request)
        {
            _request = request;
        }
    }
}

