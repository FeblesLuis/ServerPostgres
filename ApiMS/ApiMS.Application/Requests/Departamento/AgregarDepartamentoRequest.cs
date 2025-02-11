using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMS.Application.Requests.Departamento
{
    public class AgregarDepartamentoRequest
    {
        // Constructor para limpiar automáticamente las cadenas
        public AgregarDepartamentoRequest()
        {
            LimpiarCadenas();
        }




        public string? nombre { get; set; }         //Nombre del departamento
        public string? cargo { get; set; }          //Cargo en el departamento







        private void LimpiarCadenas()
        {
            nombre = LimpiarCadena(nombre);
            cargo = LimpiarCadena(cargo);
        }

        // Método para limpiar una cadena y poner la primera letra en mayúscula
        private string? LimpiarCadena(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return valor;

            // Eliminar espacios innecesarios
            valor = valor.Trim();

            // Poner la primera letra en mayúscula
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(valor.ToLower());
        }
    }
}
