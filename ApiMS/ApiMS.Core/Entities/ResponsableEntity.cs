﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Core.Entities
{
    public class ResponsableEntity : BaseEntity
    {
        public string? investigacion { get; set; }    // Investigación
        public string? analisis_causa { get; set; }   // Análisis de causa
        public string? correccion { get; set; }       // Corrección
        public string? analisis_riesgo { get; set; }  // Análisis de riesgo
       
        //Relaciones PK
            //Acciones Correctivas
            public ICollection<AccionCorrectivaEntity> accionesCorrectivas = null!;

        //Relacion FK 
            //1..* No Conformidad
            public NoConformidadEntity noConformidad { get; set; } = null!;
    }

}
