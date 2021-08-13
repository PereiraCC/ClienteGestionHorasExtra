using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Models
{
    public class ModelFormularioAvalado
    {

        public string Email { get; set; }
        public string NombreCompleto { get; set; }
        public int idFormularioAvalado { get; set; }
        public System.DateTime FechaEnvio { get; set; }
        public string Motivo { get; set; }
        public bool Estado { get; set; }
        public CrearFormularioAvalado formulario { get; set; }

        public List<string> motivos { get; set; }


    }
}
