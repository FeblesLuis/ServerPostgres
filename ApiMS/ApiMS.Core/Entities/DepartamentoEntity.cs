﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class DepartamentoEntity : BaseEntity
    {
        public string? nombre { get; set; }         //Nombre del departamento
        public string? cargo { get; set; }          //Cargo en el departamento

        //Relacion FK 
            //1..1 Usuarios
            public Guid usuario_Id { get; set; }
            public UsuarioEntity usuario { get; set; } = null!;
    }
}
