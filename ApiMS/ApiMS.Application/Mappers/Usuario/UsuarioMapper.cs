﻿using ApiMS.Application.Requests.Usuarios;
using ApiMS.Core.Entities.Child.Usuario;


namespace ApiMS.Application.Mappers.Usuario
{
    public class UsuarioMapper
    {

        public static OperarioEntity MapRequestOperarioEntity(UsuarioRequest request, Guid id)
        {
            var entity = new OperarioEntity()
            {
                usuario = request.usuario,
                nombre = request.nombre,
                apellido = request.apellido,
                password = request.password, // Asegúrate de hashear la contraseña antes de guardarla
                correo = request.correo,
                preguntas_de_seguridad = request.preguntas_de_seguridad,
                preguntas_de_seguridad2 = request.preguntas_de_seguridad2,
                respuesta_de_seguridad = request.respuesta_de_seguridad,
                respuesta_de_seguridad2 = request.respuesta_de_seguridad2,
                estado = request.estado,
                departamento_Id = id
            };
            return entity;
        }
        public static CalidadEntity MapRequestCalidadEntity(UsuarioRequest request, Guid id)
        {
            var entity = new CalidadEntity()
            {
                usuario = request.usuario,
                nombre = request.nombre,
                apellido = request.apellido,
                password = request.password, // Asegúrate de hashear la contraseña antes de guardarla
                correo = request.correo,
                preguntas_de_seguridad = request.preguntas_de_seguridad,
                preguntas_de_seguridad2 = request.preguntas_de_seguridad2,
                respuesta_de_seguridad = request.respuesta_de_seguridad,
                respuesta_de_seguridad2 = request.respuesta_de_seguridad2,
                estado = request.estado,
                departamento_Id = id
            };
            return entity;
        }
    }
}
