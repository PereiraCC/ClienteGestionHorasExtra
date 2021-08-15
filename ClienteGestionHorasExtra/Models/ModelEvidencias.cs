using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Models
{
    public class ModelEvidencias
    {
        public int idEvidencia { get; set; }

        public int idPersona { get; set; }

        public string RutaDocumento { get; set; }
        public System.DateTime HoraInicial { get; set; }
        public System.DateTime HoraFinal { get; set; }
        public string Motivo { get; set; }

        public bool Estado { get; set; }

        public List<Persona> funcionarios { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
